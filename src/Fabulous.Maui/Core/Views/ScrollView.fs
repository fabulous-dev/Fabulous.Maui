namespace Fabulous.Maui

open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui
open Fabulous
open Fabulous.Maui.Controls

module ScrollView =
    let WidgetKey = Widgets.register<FabScrollView>()
    
[<AutoOpen>]
module ScrollViewBuilders =
    type Fabulous.Maui.View with
        static member inline ScrollView(content: WidgetBuilder<'msg, #IView>) =
            WidgetBuilder<'msg, IFabScrollView>(
                ScrollView.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome [| ContentView.PresentedContent.WithValue(content.Compile()) |],
                    ValueNone
                )
            )
