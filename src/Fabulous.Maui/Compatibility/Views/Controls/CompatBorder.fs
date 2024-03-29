namespace Fabulous.Maui.Compatibility

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Shapes

type IFabCompatBorder =
    inherit IFabCompatView
    inherit IBorder

module CompatBorder =
    let WidgetKey = CompatWidgets.register<Border>()

    let Stroke = Attributes.defineBindableAppTheme<Brush> Border.StrokeProperty

    let StrokeWidget = Attributes.defineBindableWidget Border.StrokeProperty

    let Content = Attributes.defineBindableWidget Border.ContentProperty

    let StrokeShape =
        Attributes.defineSimpleScalarWithEquality<Shape> "Border_StrokeShape" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Border.StrokeShapeProperty)
            | ValueSome value -> target.SetValue(Border.StrokeShapeProperty, value))

    let StrokeShapeString =
        Attributes.defineSimpleScalarWithEquality<string> "Border_StrokeShapeString" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Border.StrokeShapeProperty)
            | ValueSome value -> target.SetValue(Border.StrokeShapeProperty, StrokeShapeTypeConverter().ConvertFromInvariantString(value)))

    let StrokeShapeWidget = Attributes.defineBindableWidget Border.StrokeShapeProperty

    let StrokeThickness = Attributes.defineBindableFloat Border.StrokeThicknessProperty

    let StrokeDashArrayString =
        Attributes.defineSimpleScalarWithEquality<string> "Border_StrokeDashArrayString" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Border.StrokeDashArrayProperty)
            | ValueSome string -> target.SetValue(Shape.StrokeDashArrayProperty, DoubleCollectionConverter().ConvertFromInvariantString(string)))

    let StrokeDashArrayList =
        Attributes.defineSimpleScalarWithEquality<float list> "Border_StrokeDashArrayList" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Border.StrokeDashArrayProperty)
            | ValueSome points ->
                let coll = DoubleCollection()
                points |> List.iter coll.Add
                target.SetValue(Border.StrokeDashArrayProperty, coll))

    let StrokeDashOffset =
        Attributes.defineBindableFloat Border.StrokeDashOffsetProperty

    let StrokeLineCap =
        Attributes.defineBindableWithEquality<PenLineCap> Border.StrokeLineCapProperty

    let StrokeLineJoin =
        Attributes.defineBindableWithEquality<PenLineJoin> Border.StrokeLineJoinProperty

    let StrokeMiterLimit =
        Attributes.defineBindableFloat Border.StrokeMiterLimitProperty

    let Padding =
        Attributes.defineBindableWithEquality<Thickness> Border.PaddingProperty

[<AutoOpen>]
module CompatBorderBuilders =
    type Fabulous.Maui.View with

        /// <summary>Border is a container control that draws a border, background, or both, around another control. A Border can only contain one child object. If you want to put a border around multiple objects, wrap them in a container object such as a layout</summary>
        /// <param name="light">The color of the stroke in the light theme.</param>
        /// <param name="dark">The color of the stroke in the dark theme.</param>
        static member inline CompatBorder(content: WidgetBuilder<'msg, #IView>, light: Brush, ?dark: Brush) =
            WidgetBuilder<'msg, IFabCompatBorder>(
                CompatBorder.WidgetKey,
                AttributesBundle(
                    StackList.two(
                        CompatBorder.Stroke.WithValue(AppTheme.create light dark),
                        // By spec we need to set StrokeShape to Rectangle
                        CompatBorder.StrokeShape.WithValue(Rectangle())
                    ),
                    ValueSome [| CompatBorder.Content.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Border is a container control that draws a border, background, or both, around another control. A Border can only contain one child object. If you want to put a border around multiple objects, wrap them in a container object such as a layout</summary>
        /// <param name="stroke">The stroke brush widget</param>
        static member inline CompatBorder(content: WidgetBuilder<'msg, #IView>, stroke: WidgetBuilder<'msg, #IFabCompatBrush>) =
            WidgetBuilder<'msg, IFabCompatBorder>(
                CompatBorder.WidgetKey,
                AttributesBundle(
                    // By spec we need to set StrokeShape to Rectangle
                    StackList.one(CompatBorder.StrokeShape.WithValue(Rectangle())),
                    ValueSome
                        [| CompatBorder.Content.WithValue(content.Compile())
                           CompatBorder.StrokeWidget.WithValue(stroke.Compile()) |],
                    ValueNone
                )
            )

[<Extension>]
type CompatBorderModifiers =

    [<Extension>]
    static member inline strokeShape(this: WidgetBuilder<'msg, #IFabCompatBorder>, content: string) =
        this.AddScalar(CompatBorder.StrokeShapeString.WithValue(content))

    [<Extension>]
    static member inline strokeShape(this: WidgetBuilder<'msg, #IFabCompatBorder>, content: WidgetBuilder<'msg, #IFabCompatShape>) =
        this.AddWidget(CompatBorder.StrokeShapeWidget.WithValue(content.Compile()))

    [<Extension>]
    static member inline strokeThickness(this: WidgetBuilder<'msg, #IFabCompatBorder>, value: float) =
        this.AddScalar(CompatBorder.StrokeThickness.WithValue(value))

    [<Extension>]
    static member inline strokeDashArray(this: WidgetBuilder<'msg, #IFabCompatBorder>, value: string) =
        this.AddScalar(CompatBorder.StrokeDashArrayString.WithValue(value))

    [<Extension>]
    static member inline strokeDashArray(this: WidgetBuilder<'msg, #IFabCompatShape>, value: float list) =
        this.AddScalar(CompatBorder.StrokeDashArrayList.WithValue(value))

    [<Extension>]
    static member inline strokeDashOffset(this: WidgetBuilder<'msg, #IFabCompatBorder>, value: float) =
        this.AddScalar(CompatBorder.StrokeDashOffset.WithValue(value))

    [<Extension>]
    static member inline strokeLineCap(this: WidgetBuilder<'msg, #IFabCompatBorder>, value: PenLineCap) =
        this.AddScalar(CompatBorder.StrokeLineCap.WithValue(value))

    [<Extension>]
    static member inline strokeLineJoin(this: WidgetBuilder<'msg, #IFabCompatBorder>, value: PenLineJoin) =
        this.AddScalar(CompatBorder.StrokeLineJoin.WithValue(value))

    [<Extension>]
    static member inline strokeMiterLimit(this: WidgetBuilder<'msg, #IFabCompatBorder>, value: float) =
        this.AddScalar(CompatBorder.StrokeMiterLimit.WithValue(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabCompatBorder>, value: Thickness) =
        this.AddScalar(CompatBorder.Padding.WithValue(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabCompatBorder>, value: float) =
        CompatBorderModifiers.padding(this, Thickness(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabCompatBorder>, left: float, top: float, right: float, bottom: float) =
        CompatBorderModifiers.padding(this, Thickness(left, top, right, bottom))

    /// <summary>Link a ViewRef to access the direct Border control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCompatBorder>, value: ViewRef<Border>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
