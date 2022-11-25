namespace Fabulous.Maui

open Fabulous.Maui.Controls

module Padding =
    let Padding = Attributes.defineMauiSimpleScalarWithEquality "Padding_Padding" "Padding" (fun _ currOpt target ->
        let target = unbox<IPaddingSetter> target
        match currOpt with
        | ValueNone -> target.SetPadding(PaddingDefaults.CreateDefaultPadding())
        | ValueSome curr -> target.SetPadding(curr)
    )

