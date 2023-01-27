namespace Fabulous.Maui

open Microsoft.Maui
open Fabulous
open Fabulous.Maui.Controls

module HStack =
    let WidgetKey = Widgets.register<FabHorizontalStackLayout>()

[<AutoOpen>]
module HStackBuilders =
    type Fabulous.Maui.View with
        static member inline HStack<'msg>(?spacing: float) =
            match spacing with
            | None ->
                CollectionBuilder<'msg, IFabStackLayout, IView>(
                    HStack.WidgetKey,
                    Container.Children
                )
            | Some spacing ->
                CollectionBuilder<'msg, IFabStackLayout, IView>(
                    HStack.WidgetKey,
                    Container.Children,
                    StackLayout.Spacing.WithValue(spacing)
                )