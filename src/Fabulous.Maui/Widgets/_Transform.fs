namespace Fabulous.Maui

open Fabulous.Maui.Controls

module Transform =
    let AnchorX = Attributes.defineMauiSimpleScalarWithEquality "Transform_AnchorX" "AnchorX" (fun _ currOpt target ->
        let target = unbox<ITransformSetter> target
        match currOpt with
        | ValueNone -> target.SetAnchorX(TransformDefaults.AnchorX)
        | ValueSome curr -> target.SetAnchorX(curr)
    )
    
    let AnchorY = Attributes.defineMauiSimpleScalarWithEquality "Transform_AnchorY" "AnchorY" (fun _ currOpt target ->
        let target = unbox<ITransformSetter> target
        match currOpt with
        | ValueNone -> target.SetAnchorY(TransformDefaults.AnchorY)
        | ValueSome curr -> target.SetAnchorY(curr)
    )
    
    let Rotation = Attributes.defineMauiSimpleScalarWithEquality "Transform_Rotation" "Rotation" (fun _ currOpt target ->
        let target = unbox<ITransformSetter> target
        match currOpt with
        | ValueNone -> target.SetRotation(TransformDefaults.Rotation)
        | ValueSome curr -> target.SetRotation(curr)
    )
    
    let RotationX = Attributes.defineMauiSimpleScalarWithEquality "Transform_RotationX" "RotationX" (fun _ currOpt target ->
        let target = unbox<ITransformSetter> target
        match currOpt with
        | ValueNone -> target.SetRotationX(TransformDefaults.RotationX)
        | ValueSome curr -> target.SetRotationX(curr)
    )
    
    let RotationY = Attributes.defineMauiSimpleScalarWithEquality "Transform_RotationY" "RotationY" (fun _ currOpt target ->
        let target = unbox<ITransformSetter> target
        match currOpt with
        | ValueNone -> target.SetRotationY(TransformDefaults.RotationY)
        | ValueSome curr -> target.SetRotationY(curr)
    )
    
    let Scale = Attributes.defineMauiSimpleScalarWithEquality "Transform_Scale" "Scale" (fun _ currOpt target ->
        let target = unbox<ITransformSetter> target
        match currOpt with
        | ValueNone -> target.SetScale(TransformDefaults.Scale)
        | ValueSome curr -> target.SetScale(curr)
    )
    
    let ScaleX = Attributes.defineMauiSimpleScalarWithEquality "Transform_ScaleX" "ScaleX" (fun _ currOpt target ->
        let target = unbox<ITransformSetter> target
        match currOpt with
        | ValueNone -> target.SetScaleX(TransformDefaults.ScaleX)
        | ValueSome curr -> target.SetScaleX(curr)
    )
    
    let ScaleY = Attributes.defineMauiSimpleScalarWithEquality "Transform_ScaleY" "ScaleY" (fun _ currOpt target ->
        let target = unbox<ITransformSetter> target
        match currOpt with
        | ValueNone -> target.SetScaleY(TransformDefaults.ScaleY)
        | ValueSome curr -> target.SetScaleY(curr)
    )
    
    let TranslationX = Attributes.defineMauiSimpleScalarWithEquality "Transform_TranslationX" "TranslationX" (fun _ currOpt target ->
        let target = unbox<ITransformSetter> target
        match currOpt with
        | ValueNone -> target.SetTranslationX(TransformDefaults.TranslationX)
        | ValueSome curr -> target.SetTranslationX(curr)
    )
    
    let TranslationY = Attributes.defineMauiSimpleScalarWithEquality "Transform_TranslationY" "TranslationY" (fun _ currOpt target ->
        let target = unbox<ITransformSetter> target
        match currOpt with
        | ValueNone -> target.SetTranslationY(TransformDefaults.TranslationY)
        | ValueSome curr -> target.SetTranslationY(curr)
    )

