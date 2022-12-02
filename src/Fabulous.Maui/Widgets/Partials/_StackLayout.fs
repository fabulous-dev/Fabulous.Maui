namespace Fabulous.Maui

open Microsoft.Maui.Handlers.Defaults
open Fabulous.Maui.Controls

module StackLayout =
    let Spacing = Attributes.defineMauiSimpleScalarWithEquality' "StackLayout" "Spacing" StackLayoutDefaults.Spacing FabStackLayoutSetters.SetSpacing
