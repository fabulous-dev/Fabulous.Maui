namespace Fabulous.Maui

open Microsoft.Maui.Handlers.Defaults
open Fabulous.Maui.Controls

module Text =
    let Text = Attributes.defineMauiSimpleScalarWithEquality' "Text" "Text" TextDefaults.Text FabTextSetters.SetText