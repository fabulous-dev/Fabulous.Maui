namespace Fabulous.Maui.Compatibility

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Shapes

open Fabulous.Maui

type IFabCompatPath =
    inherit IFabCompatShape

module Path =
    let WidgetKey = CompatWidgets.register<Path>()

    let DataWidget = Attributes.defineBindableWidget Path.DataProperty

    let DataString =
        Attributes.defineSimpleScalarWithEquality<string> "Path_DataString" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Path.DataProperty)
            | ValueSome value -> target.SetValue(Path.DataProperty, PathGeometryConverter().ConvertFromInvariantString(value)))

    let RenderTransformWidget =
        Attributes.defineBindableWidget Path.RenderTransformProperty

    let RenderTransformString =
        Attributes.defineSimpleScalarWithEquality<string> "Path_RenderTransformString" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Path.RenderTransformProperty)
            | ValueSome value -> target.SetValue(Path.RenderTransformProperty, TransformTypeConverter().ConvertFromInvariantString(value)))

[<AutoOpen>]
module PathBuilders =

    type Fabulous.Maui.View with

        static member inline Path<'msg, 'marker when 'marker :> IFabCompatGeometry>(content: WidgetBuilder<'msg, 'marker>) =
            WidgetHelpers.buildWidgets<'msg, IFabCompatPath> Path.WidgetKey [| Path.DataWidget.WithValue(content.Compile()) |]

        static member inline Path<'msg>(content: string) =
            WidgetBuilder<'msg, IFabCompatPath>(Path.WidgetKey, Path.DataString.WithValue(content))

[<Extension>]
type PathModifiers =
    [<Extension>]
    static member inline renderTransform<'msg, 'marker, 'contentMarker when 'marker :> IFabCompatPath and 'contentMarker :> IFabCompatTransform>
        (
            this: WidgetBuilder<'msg, 'marker>,
            content: WidgetBuilder<'msg, 'contentMarker>
        ) =
        this.AddWidget(Path.RenderTransformWidget.WithValue(content.Compile()))

    [<Extension>]
    static member inline renderTransform(this: WidgetBuilder<'msg, #IFabCompatPath>, value: string) =
        this.AddScalar(Path.RenderTransformString.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Path control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCompatPath>, value: ViewRef<Path>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
