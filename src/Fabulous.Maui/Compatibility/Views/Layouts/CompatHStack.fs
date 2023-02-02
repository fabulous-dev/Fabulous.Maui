namespace Fabulous.Maui.Compatibility

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

type IFabCompatHorizontalStackLayout =
    inherit IFabCompatStackBase

module CompatHorizontalStackLayout =
    let WidgetKey = CompatWidgets.register<HorizontalStackLayout>()

[<AutoOpen>]
module CompatHorizontalStackLayoutBuilders =
    type Fabulous.Maui.View with

        static member inline CompatHStack<'msg>(?spacing: float) =
            match spacing with
            | None -> CollectionBuilder<'msg, IFabCompatHorizontalStackLayout, IView>(CompatHorizontalStackLayout.WidgetKey, CompatLayoutOfView.Children)
            | Some v ->
                CollectionBuilder<'msg, IFabCompatHorizontalStackLayout, IView>(
                    CompatHorizontalStackLayout.WidgetKey,
                    CompatLayoutOfView.Children,
                    CompatStackBase.Spacing.WithValue(v)
                )

[<Extension>]
type CompatHorizontalStackLayoutModifiers =
    /// <summary>Link a ViewRef to access the direct HorizontalStackLayout control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCompatHorizontalStackLayout>, value: ViewRef<HorizontalStackLayout>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
