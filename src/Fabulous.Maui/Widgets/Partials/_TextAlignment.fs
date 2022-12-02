namespace Fabulous.Maui

open Microsoft.Maui.Handlers.Defaults
open Fabulous.Maui.Controls

module TextAlignment =
    let HorizontalTextAlignment = Attributes.defineMauiProperty "TextAlignment" "HorizontalTextAlignment" TextAlignmentDefaults.HorizontalTextAlignment FabTextAlignmentSetters.SetHorizontalTextAlignment
    let VerticalTextAlignment = Attributes.defineMauiProperty "TextAlignment" "VerticalTextAlignment" TextAlignmentDefaults.VerticalTextAlignment FabTextAlignmentSetters.SetVerticalTextAlignment
    