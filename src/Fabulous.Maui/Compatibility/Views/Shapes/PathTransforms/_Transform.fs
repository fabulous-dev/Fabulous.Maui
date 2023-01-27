namespace Fabulous.Maui.Compatibility

open Microsoft.Maui.Controls.Shapes

type IFabTransform =
    inherit IFabCompatElement

module Transform =

    let Value = Attributes.defineBindableWithEquality<Matrix> Transform.ValueProperty
