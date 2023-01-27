namespace Fabulous.Maui

open System
open Fabulous.Maui.Controls
open Microsoft.Maui.Handlers.Defaults

module Range =
    let Value = Attributes.defineMauiPropertyWithEvent "Value" RangeDefaults.Value RangeDefaults.OnValueChanged FabRange.SetValue
    let MinimumMaximum = Attributes.defineMauiProperty "MinimumMaximum" (struct (RangeDefaults.Minimum, RangeDefaults.Maximum)) FabRange.SetMinimumMaximum

