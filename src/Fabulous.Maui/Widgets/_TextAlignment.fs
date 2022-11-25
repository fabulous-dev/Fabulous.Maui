namespace Fabulous.Maui

open Fabulous.Maui.Controls

module TextAlignment =
    let HorizontalTextAlignment = Attributes.defineMauiSimpleScalarWithEquality "TextAlignment_HorizontalTextAlignment" "TextAlignment" (fun _ currOpt target ->
        let target = unbox<ITextAlignmentSetter> target
        match currOpt with
        | ValueNone -> target.SetHorizontalTextAlignment(TextAlignmentDefaults.HorizontalTextAlignment)
        | ValueSome curr -> target.SetHorizontalTextAlignment(curr)
    )
    
    let VerticalTextAlignment = Attributes.defineMauiSimpleScalarWithEquality "TextAlignment_VerticalTextAlignment" "TextAlignment" (fun _ currOpt target ->
        let target = unbox<ITextAlignmentSetter> target
        match currOpt with
        | ValueNone -> target.SetVerticalTextAlignment(TextAlignmentDefaults.VerticalTextAlignment)
        | ValueSome curr -> target.SetVerticalTextAlignment(curr)
    )