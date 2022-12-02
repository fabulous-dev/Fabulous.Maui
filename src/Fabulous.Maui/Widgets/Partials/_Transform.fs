namespace Fabulous.Maui

open Microsoft.Maui.Handlers.Defaults
open Fabulous.Maui.Controls

module Transform =
    let AnchorX = Attributes.defineMauiSimpleScalarWithEquality' "Transform" "AnchorX" TransformDefaults.AnchorX FabTransformSetters.SetAnchorX
    let AnchorY = Attributes.defineMauiSimpleScalarWithEquality' "Transform" "AnchorY" TransformDefaults.AnchorY FabTransformSetters.SetAnchorY
    let Rotation = Attributes.defineMauiSimpleScalarWithEquality' "Transform" "Rotation" TransformDefaults.Rotation FabTransformSetters.SetRotation
    let RotationX = Attributes.defineMauiSimpleScalarWithEquality' "Transform" "RotationX" TransformDefaults.RotationX FabTransformSetters.SetRotationX
    let RotationY = Attributes.defineMauiSimpleScalarWithEquality' "Transform" "RotationY" TransformDefaults.RotationY FabTransformSetters.SetRotationY
    let Scale = Attributes.defineMauiSimpleScalarWithEquality' "Transform" "Scale" TransformDefaults.Scale FabTransformSetters.SetScale
    let ScaleX = Attributes.defineMauiSimpleScalarWithEquality' "Transform" "ScaleX" TransformDefaults.ScaleX FabTransformSetters.SetScaleX
    let ScaleY = Attributes.defineMauiSimpleScalarWithEquality' "Transform" "ScaleY" TransformDefaults.ScaleY FabTransformSetters.SetScaleY
    let TranslationX = Attributes.defineMauiSimpleScalarWithEquality' "Transform" "TranslationX" TransformDefaults.TranslationX FabTransformSetters.SetTranslationX
    let TranslationY = Attributes.defineMauiSimpleScalarWithEquality' "Transform" "TranslationY" TransformDefaults.TranslationY FabTransformSetters.SetTranslationY
