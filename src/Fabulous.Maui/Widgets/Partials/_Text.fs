namespace Fabulous.Maui

open Fabulous.Maui.Controls

module Text =
    let Text = Attributes.defineMauiSimpleScalarWithEquality "Text_Text" "Text" (fun _ currOpt target ->
        let target = unbox<ITextSetter> target
        match currOpt with
        | ValueNone -> target.SetText(TextDefaults.Text)
        | ValueSome curr -> target.SetText(curr)
    )