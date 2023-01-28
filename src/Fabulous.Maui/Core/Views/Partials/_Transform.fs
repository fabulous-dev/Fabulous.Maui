namespace Fabulous.Maui

open Microsoft.Maui.Handlers.Defaults
open Fabulous.Maui.Controls

module Transform =
    let AnchorX =
        Attributes.defineMauiProperty "AnchorX" TransformDefaults.AnchorX (fun (target: IFabTransform) -> target.SetAnchorX)

    let AnchorY =
        Attributes.defineMauiProperty "AnchorY" TransformDefaults.AnchorY (fun (target: IFabTransform) -> target.SetAnchorY)

    let Rotation =
        Attributes.defineMauiProperty "Rotation" TransformDefaults.Rotation (fun (target: IFabTransform) -> target.SetRotation)

    let RotationX =
        Attributes.defineMauiProperty "RotationX" TransformDefaults.RotationX (fun (target: IFabTransform) -> target.SetRotationX)

    let RotationY =
        Attributes.defineMauiProperty "RotationY" TransformDefaults.RotationY (fun (target: IFabTransform) -> target.SetRotationY)

    let Scale =
        Attributes.defineMauiProperty "Scale" TransformDefaults.Scale (fun (target: IFabTransform) -> target.SetScale)

    let ScaleX =
        Attributes.defineMauiProperty "ScaleX" TransformDefaults.ScaleX (fun (target: IFabTransform) -> target.SetScaleX)

    let ScaleY =
        Attributes.defineMauiProperty "ScaleY" TransformDefaults.ScaleY (fun (target: IFabTransform) -> target.SetScaleY)

    let TranslationX =
        Attributes.defineMauiProperty "TranslationX" TransformDefaults.TranslationX (fun (target: IFabTransform) -> target.SetTranslationX)

    let TranslationY =
        Attributes.defineMauiProperty "TranslationY" TransformDefaults.TranslationY (fun (target: IFabTransform) -> target.SetTranslationY)
