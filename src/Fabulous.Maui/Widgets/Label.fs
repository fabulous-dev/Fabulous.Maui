namespace Fabulous.Maui

open Fabulous
open Fabulous.Maui.Controls
open Microsoft.FSharp.Core
open Microsoft.Maui


module Label =
    let WidgetKey = Widgets.register<FabLabel>()
    
    let Text = Attributes.defineMauiSimpleScalarWithEquality "Label_Text" "Text" (fun _ currOpt target ->
        let target = target :?> FabLabel
        match currOpt with
        | ValueNone -> target.Text <- TextDefaults.Text
        | ValueSome curr -> target.Text <- curr
    )
    
[<AutoOpen>]
module LabelBuilders =
    type Fabulous.Maui.View with
        static member inline Label<'msg>(text: string) =
            WidgetBuilder<'msg, ILabel>(
                Label.WidgetKey,
                Label.Text.WithValue(text)
            )