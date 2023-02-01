namespace Fabulous.Maui

open Fabulous
open Fabulous.Maui.Controls
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui

module Border =
    let WidgetKey = Widgets.register<FabBorderView>()

[<AutoOpen>]
module BorderBuilders =
    type Fabulous.Maui.View with

        static member inline Border(content: WidgetBuilder<'msg, #IView>) =
            WidgetBuilder<'msg, IFabBorderView>(
                Border.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentView.PresentedContent.WithValue(content.Compile()) |], ValueNone)
            )
