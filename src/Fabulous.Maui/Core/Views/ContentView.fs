namespace Fabulous.Maui

open Microsoft.Maui
open Fabulous
open Fabulous.Maui.Controls
open Fabulous.StackAllocatedCollections.StackList

module ContentView =
    let WidgetKey = Widgets.register<FabContentView>()
    
    let PresentedContent = Attributes.defineMauiPropertyWidget "Content" (fun (target: IFabContentView) -> target.PresentedContent)  (fun target value -> target.PresentedContent <- value)

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