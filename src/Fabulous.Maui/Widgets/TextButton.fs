namespace Fabulous.Maui

open Microsoft.Maui
open Fabulous
open Fabulous.Maui.Controls

module TextButton =
    let WidgetKey = Widgets.register<FabTextButton>()

[<AutoOpen>]
module TextButtonBuilders =
    type Fabulous.Maui.View with
        static member inline TextButton<'msg>(text: string, onClicked: 'msg) =
            WidgetBuilder<'msg, ITextButton>(
                TextButton.WidgetKey,
                Text.Text.WithValue(text),
                Button.Clicked.WithValue(fun () -> box onClicked)
            )