namespace Fabulous.Maui

open Fabulous
open Fabulous.Maui.Controls
open Microsoft.FSharp.Core
open Microsoft.Maui

module Label =
    let WidgetKey = Widgets.register<FabLabel>()
    
[<AutoOpen>]
module LabelBuilders =
    type Fabulous.Maui.View with
        static member inline Label<'msg>(text: string) =
            WidgetBuilder<'msg, ILabel>(
                Label.WidgetKey,
                Text.Text.WithValue(text)
            )