namespace Fabulous.Maui

open Microsoft.Maui.Handlers.Defaults
open Fabulous.Maui.Controls

module TextAlignment =
    let HorizontalTextAlignment = Attributes.defineMauiProperty "HorizontalTextAlignment" TextAlignmentDefaults.HorizontalTextAlignment FabTextAlignment.SetHorizontalTextAlignment
    let VerticalTextAlignment = Attributes.defineMauiProperty "VerticalTextAlignment" TextAlignmentDefaults.VerticalTextAlignment FabTextAlignment.SetVerticalTextAlignment
    