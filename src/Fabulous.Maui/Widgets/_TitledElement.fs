namespace Fabulous.Maui

open Fabulous
open Fabulous.Maui.Controls

module TitledElement =
    let Title =
        Attributes.defineMauiSimpleScalarWithEquality "TitledElement_Title" "Title" (fun _ currOpt target ->
            let target = target :?> FabTitledElement
            match currOpt with
            | ValueNone -> target.Title <- null
            | ValueSome curr -> target.Title <- curr
        )