namespace Fabulous.Maui

open Microsoft.Maui.Handlers.Defaults

module Stroke =
    let Stroke =
        Attributes.defineMauiProperty "Stroke" StrokeDefaults.Stroke (fun (target: IFabStroke) -> target.SetStroke)

    let StrokeThickness =
        Attributes.defineMauiProperty "StrokeThickness" StrokeDefaults.StrokeThickness (fun (target: IFabStroke) -> target.SetStrokeThickness)

    let StrokeLineCap =
        Attributes.defineMauiProperty "StrokeLineCap" StrokeDefaults.StrokeLineCap (fun (target: IFabStroke) -> target.SetStrokeLineCap)
        
    let StrokeLineJoin =
        Attributes.defineMauiProperty "StrokeLineJoin" StrokeDefaults.StrokeLineJoin (fun (target: IFabStroke) -> target.SetStrokeLineJoin)
        
    let StrokeDashPattern =
        Attributes.defineMauiProperty "StrokeDashPattern" StrokeDefaults.StrokeDashPattern (fun (target: IFabStroke) -> target.SetStrokeDashPattern)
        
    let StrokeDashOffset =
        Attributes.defineMauiProperty "StrokeDashOffset" StrokeDefaults.StrokeDashOffset (fun (target: IFabStroke) -> target.SetStrokeDashOffset)
        
    let StrokeMiterLimit =
        Attributes.defineMauiProperty "StrokeMiterLimit" StrokeDefaults.StrokeMiterLimit (fun (target: IFabStroke) -> target.SetStrokeMiterLimit)