namespace Fabulous.Maui

open Microsoft.Maui.Handlers.Defaults
open Fabulous.Maui.Controls

module StackLayout =
    let Spacing = Attributes.defineMauiProperty "StackLayout" "Spacing" StackLayoutDefaults.Spacing FabStackLayoutSetters.SetSpacing
