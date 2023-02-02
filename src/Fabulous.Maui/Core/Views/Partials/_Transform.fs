namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Handlers.Defaults

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

[<Extension>]
type TransformModifiers =
    [<Extension>]
    static member anchorX(this: WidgetBuilder<'msg, #IFabTransform>, value: float) =
        this.AddScalar(Transform.AnchorX.WithValue(value))

    [<Extension>]
    static member anchorY(this: WidgetBuilder<'msg, #IFabTransform>, value: float) =
        this.AddScalar(Transform.AnchorY.WithValue(value))

    [<Extension>]
    static member rotation(this: WidgetBuilder<'msg, #IFabTransform>, value: float) =
        this.AddScalar(Transform.Rotation.WithValue(value))

    [<Extension>]
    static member rotationX(this: WidgetBuilder<'msg, #IFabTransform>, value: float) =
        this.AddScalar(Transform.RotationX.WithValue(value))

    [<Extension>]
    static member rotationY(this: WidgetBuilder<'msg, #IFabTransform>, value: float) =
        this.AddScalar(Transform.RotationY.WithValue(value))

    [<Extension>]
    static member scale(this: WidgetBuilder<'msg, #IFabTransform>, value: float) =
        this.AddScalar(Transform.Scale.WithValue(value))

    [<Extension>]
    static member scaleX(this: WidgetBuilder<'msg, #IFabTransform>, value: float) =
        this.AddScalar(Transform.ScaleX.WithValue(value))

    [<Extension>]
    static member scaleY(this: WidgetBuilder<'msg, #IFabTransform>, value: float) =
        this.AddScalar(Transform.ScaleY.WithValue(value))

    [<Extension>]
    static member translationX(this: WidgetBuilder<'msg, #IFabTransform>, value: float) =
        this.AddScalar(Transform.TranslationX.WithValue(value))

    [<Extension>]
    static member translationY(this: WidgetBuilder<'msg, #IFabTransform>, value: float) =
        this.AddScalar(Transform.TranslationY.WithValue(value))
