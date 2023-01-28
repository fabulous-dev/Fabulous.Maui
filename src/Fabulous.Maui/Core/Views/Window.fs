namespace Fabulous.Maui

open Fabulous
open Fabulous.Maui.Controls
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui

module Window =
    let WidgetKey = Widgets.register<FabWindow>()

    let Content =
        Attributes.defineMauiPropertyWidget<IFabWindow, IView> "Content" (fun target -> target.Content) (fun target -> target.SetContent)


[<AutoOpen>]
module WindowBuilders =
    type Fabulous.Maui.View with

        static member inline Window(content: WidgetBuilder<'msg, #IView>) =
            WidgetBuilder<'msg, IFabWindow>(
                Window.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| Window.Content.WithValue(content.Compile()) |], ValueNone)
            )
