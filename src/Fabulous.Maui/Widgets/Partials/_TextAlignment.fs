namespace Fabulous.Maui

open Microsoft.Maui.Handlers.Defaults
open Fabulous.Maui.Controls

module TextAlignment =
    let HorizontalTextAlignment = Attributes.defineMauiSimpleScalarWithEquality' "TextAlignment" "HorizontalTextAlignment" TextAlignmentDefaults.HorizontalTextAlignment FabTextAlignmentSetters.SetHorizontalTextAlignment
    let VerticalTextAlignment = Attributes.defineMauiSimpleScalarWithEquality' "TextAlignment" "VerticalTextAlignment" TextAlignmentDefaults.VerticalTextAlignment FabTextAlignmentSetters.SetVerticalTextAlignment
    