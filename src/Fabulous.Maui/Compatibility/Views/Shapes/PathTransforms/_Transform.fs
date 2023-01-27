namespace Fabulous.Maui.Compatibility

open Microsoft.Maui.Controls.Shapes

type IFabTransform =
    inherit IFabElement

module Transform =

    let Value = Attributes.defineBindableWithEquality<Matrix> Transform.ValueProperty
