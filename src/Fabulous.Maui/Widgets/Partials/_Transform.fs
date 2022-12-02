namespace Fabulous.Maui

open Microsoft.Maui.Handlers.Defaults
open Fabulous.Maui.Controls

module Transform =
    let AnchorX = Attributes.defineMauiProperty "Transform" "AnchorX" TransformDefaults.AnchorX FabTransformSetters.SetAnchorX
    let AnchorY = Attributes.defineMauiProperty "Transform" "AnchorY" TransformDefaults.AnchorY FabTransformSetters.SetAnchorY
    let Rotation = Attributes.defineMauiProperty "Transform" "Rotation" TransformDefaults.Rotation FabTransformSetters.SetRotation
    let RotationX = Attributes.defineMauiProperty "Transform" "RotationX" TransformDefaults.RotationX FabTransformSetters.SetRotationX
    let RotationY = Attributes.defineMauiProperty "Transform" "RotationY" TransformDefaults.RotationY FabTransformSetters.SetRotationY
    let Scale = Attributes.defineMauiProperty "Transform" "Scale" TransformDefaults.Scale FabTransformSetters.SetScale
    let ScaleX = Attributes.defineMauiProperty "Transform" "ScaleX" TransformDefaults.ScaleX FabTransformSetters.SetScaleX
    let ScaleY = Attributes.defineMauiProperty "Transform" "ScaleY" TransformDefaults.ScaleY FabTransformSetters.SetScaleY
    let TranslationX = Attributes.defineMauiProperty "Transform" "TranslationX" TransformDefaults.TranslationX FabTransformSetters.SetTranslationX
    let TranslationY = Attributes.defineMauiProperty "Transform" "TranslationY" TransformDefaults.TranslationY FabTransformSetters.SetTranslationY
