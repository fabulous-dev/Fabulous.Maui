namespace Fabulous.Maui

open Microsoft.Maui
open Fabulous
open Fabulous.Maui.Controls

module VStack =
    let WidgetKey = Widgets.register<FabVerticalStackLayout>()

[<AutoOpen>]
module VStackBuilders =
    type Fabulous.Maui.View with
        static member inline VStack<'msg>() =
            CollectionBuilder<'msg, IStackLayout, IView>(
                VStack.WidgetKey,
                Container.Children
            )
