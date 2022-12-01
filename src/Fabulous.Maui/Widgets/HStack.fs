namespace Fabulous.Maui

open Microsoft.Maui
open Fabulous
open Fabulous.Maui.Controls

module HStack =
    let WidgetKey = Widgets.register<FabHorizontalStackLayout>()

[<AutoOpen>]
module HStackBuilders =
    type Fabulous.Maui.View with
        static member inline HStack<'msg>() =
            CollectionBuilder<'msg, IStackLayout, IView>(
                HStack.WidgetKey,
                Container.Children
            )