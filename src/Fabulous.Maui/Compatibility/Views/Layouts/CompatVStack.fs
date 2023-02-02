namespace Fabulous.Maui.Compatibility

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

type IFabCompatVerticalStackLayout =
    inherit IFabCompatStackBase

module CompatVerticalStackLayout =
    let WidgetKey = CompatWidgets.register<VerticalStackLayout>()

[<AutoOpen>]
module CompatVerticalStackLayoutBuilders =
    type Fabulous.Maui.View with

        static member inline CompatVStack<'msg>(?spacing: float) =
            match spacing with
            | None -> CollectionBuilder<'msg, IFabCompatVerticalStackLayout, IView>(CompatVerticalStackLayout.WidgetKey, CompatLayoutOfView.Children)
            | Some v ->
                CollectionBuilder<'msg, IFabCompatVerticalStackLayout, IView>(
                    CompatVerticalStackLayout.WidgetKey,
                    CompatLayoutOfView.Children,
                    CompatStackBase.Spacing.WithValue(v)
                )

[<Extension>]
type CompatVerticalStackLayoutModifiers =
    /// <summary>Link a ViewRef to access the direct VerticalStackLayout control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCompatVerticalStackLayout>, value: ViewRef<VerticalStackLayout>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
