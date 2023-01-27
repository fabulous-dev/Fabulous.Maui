namespace Fabulous.Maui.Compatibility

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

type IFabCompatVerticalStackLayout =
    inherit IFabCompatStackBase

module VerticalStackLayout =
    let WidgetKey = CompatWidgets.register<VerticalStackLayout>()

[<AutoOpen>]
module VerticalStackLayoutBuilders =
    type Fabulous.Maui.View with

        static member inline VStack<'msg>(?spacing: float) =
            match spacing with
            | None -> CollectionBuilder<'msg, IFabCompatVerticalStackLayout, IView>(VerticalStackLayout.WidgetKey, LayoutOfView.Children)
            | Some v ->
                CollectionBuilder<'msg, IFabCompatVerticalStackLayout, IView>(VerticalStackLayout.WidgetKey, LayoutOfView.Children, StackBase.Spacing.WithValue(v))

[<Extension>]
type VerticalStackLayoutModifiers =
    /// <summary>Link a ViewRef to access the direct VerticalStackLayout control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCompatVerticalStackLayout>, value: ViewRef<VerticalStackLayout>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
