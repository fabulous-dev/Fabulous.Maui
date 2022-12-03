namespace Fabulous.Maui

open Microsoft.Maui.Handlers.Defaults
open Fabulous.Maui.Controls

module Transform =
    let AnchorX = Attributes.defineMauiProperty "AnchorX" TransformDefaults.AnchorX FabTransform.SetAnchorX
    let AnchorY = Attributes.defineMauiProperty "AnchorY" TransformDefaults.AnchorY FabTransform.SetAnchorY
    let Rotation = Attributes.defineMauiProperty "Rotation" TransformDefaults.Rotation FabTransform.SetRotation
    let RotationX = Attributes.defineMauiProperty "RotationX" TransformDefaults.RotationX FabTransform.SetRotationX
    let RotationY = Attributes.defineMauiProperty "RotationY" TransformDefaults.RotationY FabTransform.SetRotationY
    let Scale = Attributes.defineMauiProperty "Scale" TransformDefaults.Scale FabTransform.SetScale
    let ScaleX = Attributes.defineMauiProperty "ScaleX" TransformDefaults.ScaleX FabTransform.SetScaleX
    let ScaleY = Attributes.defineMauiProperty "ScaleY" TransformDefaults.ScaleY FabTransform.SetScaleY
    let TranslationX = Attributes.defineMauiProperty "TranslationX" TransformDefaults.TranslationX FabTransform.SetTranslationX
    let TranslationY = Attributes.defineMauiProperty "TranslationY" TransformDefaults.TranslationY FabTransform.SetTranslationY
