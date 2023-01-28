namespace Fabulous.Maui

open Fabulous.Maui.Controls
open Microsoft.Maui.Handlers.Defaults

module Range =
    let Value = Attributes.defineMauiPropertyWithEvent "Value" RangeDefaults.Value RangeDefaults.OnValueChanged (fun (target: IFabRange) -> target.SetValue)
    let MinimumMaximum = Attributes.defineMauiProperty "MinimumMaximum" (struct (RangeDefaults.Minimum, RangeDefaults.Maximum)) (fun (target: IFabRange) -> target.SetMinimumMaximum)

