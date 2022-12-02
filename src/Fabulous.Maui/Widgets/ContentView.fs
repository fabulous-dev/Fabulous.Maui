namespace Fabulous.Maui

open Microsoft.Maui
open Fabulous
open Fabulous.Maui.Controls
open Fabulous.StackAllocatedCollections.StackList

module ContentView =
    let WidgetKey = Widgets.register<FabContentView>()
    
    let PresentedContent = Attributes.defineMauiPropertyWidget "ContentView" "Content" (fun target -> (target :?> FabContentView).PresentedContent)  (fun target value -> (target :?> FabContentView).PresentedContent <- value)

[<AutoOpen>]
module ContentViewBuilders =
    type Fabulous.Maui.View with
        static member inline ContentView(content: WidgetBuilder<'msg, #IView>) =
            WidgetBuilder<'msg, IContentView>(
                ContentView.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome [| ContentView.PresentedContent.WithValue(content.Compile()) |],
                    ValueNone
                )
            )