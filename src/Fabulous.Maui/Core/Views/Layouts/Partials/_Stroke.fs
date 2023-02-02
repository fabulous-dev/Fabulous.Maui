namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Graphics
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

[<Extension>]
type StrokeModifiers =
    [<Extension>]
    static member stroke(this: WidgetBuilder<'msg, #IFabStroke>, value: Paint) =
        this.AddScalar(Stroke.Stroke.WithValue(value))
        
    [<Extension>]
    static member strokeThickness(this: WidgetBuilder<'msg, #IFabStroke>, value: float) =
        this.AddScalar(Stroke.StrokeThickness.WithValue(value))
        
    [<Extension>]
    static member strokeLineCap(this: WidgetBuilder<'msg, #IFabStroke>, value: LineCap) =
        this.AddScalar(Stroke.StrokeLineCap.WithValue(value))
        
    [<Extension>]
    static member strokeLineJoin(this: WidgetBuilder<'msg, #IFabStroke>, value: LineJoin) =
        this.AddScalar(Stroke.StrokeLineJoin.WithValue(value))
        
    [<Extension>]
    static member strokeDashPattern(this: WidgetBuilder<'msg, #IFabStroke>, value: float list) =
        this.AddScalar(Stroke.StrokeDashPattern.WithValue(value |> List.map float32 |> List.toArray))
        
    [<Extension>]
    static member strokeDashOffset(this: WidgetBuilder<'msg, #IFabStroke>, value: float) =
        this.AddScalar(Stroke.StrokeDashOffset.WithValue(float32 value))
        
    [<Extension>]
    static member strokeMiterLimit(this: WidgetBuilder<'msg, #IFabStroke>, value: float) =
        this.AddScalar(Stroke.StrokeMiterLimit.WithValue(float32 value))
        
[<Extension>]
type StrokeExtraModifiers =
    [<Extension>]
    static member stroke(this: WidgetBuilder<'msg, #IFabStroke>, value: FabColor) =
        this.stroke(SolidPaint(value.ToMauiColor()))