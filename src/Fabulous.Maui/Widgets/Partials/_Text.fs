namespace Fabulous.Maui

open Microsoft.Maui.Handlers.Defaults
open Fabulous.Maui.Controls

module Text =
    let Text = Attributes.defineMauiProperty "Text" TextDefaults.Text FabText.SetText