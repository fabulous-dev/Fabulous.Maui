namespace Fabulous.Maui

open Microsoft.Maui
open Fabulous
open Fabulous.Maui.Controls

module VStack =
    let WidgetKey = Widgets.register<FabVerticalStackLayout>()

[<AutoOpen>]
module VStackBuilders =
    type Fabulous.Maui.View with
        static member inline VStack<'msg>(?spacing: float) =
            match spacing with
            | None ->
                CollectionBuilder<'msg, IStackLayout, IView>(
                    VStack.WidgetKey,
                    Container.Children
                )
            | Some spacing ->
                CollectionBuilder<'msg, IStackLayout, IView>(
                    VStack.WidgetKey,
                    Container.Children,
                    StackLayout.Spacing.WithValue(spacing)
                )
