namespace Fabulous.Maui.Compatibility

open Microsoft.Maui
open Microsoft.Maui.Controls

type IFabCompatStackBase =
    inherit IFabCompatLayoutOfView
    inherit IStackLayout

module StackBase =
    let Spacing = Attributes.defineBindableFloat StackBase.SpacingProperty
