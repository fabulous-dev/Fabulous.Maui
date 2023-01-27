namespace Fabulous.Maui.Compatibility

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type IFabPolygon =
    inherit IFabShape

module Polygon =

    let WidgetKey = CompatWidgets.register<Polygon>()

    let PointsString =
        Attributes.defineSimpleScalarWithEquality<string> "Polygon_PointsString" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Polygon.PointsProperty)
            | ValueSome string -> target.SetValue(Polygon.PointsProperty, PointCollectionConverter().ConvertFromInvariantString(string)))

    let PointsList =
        Attributes.defineSimpleScalarWithEquality<Point array> "Polygon_PointsList" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Polygon.PointsProperty)
            | ValueSome points ->
                let coll = PointCollection()
                points |> Array.iter coll.Add
                target.SetValue(Polygon.PointsProperty, coll))

    let FillRule = Attributes.defineBindableEnum<FillRule> Polygon.FillRuleProperty

[<AutoOpen>]
module PolygonBuilders =

    type Fabulous.Maui.View with

        static member inline Polygon<'msg>(points: string, strokeThickness: float, strokeLight: Brush, ?strokeDark: Brush) =
            WidgetBuilder<'msg, IFabPolygon>(
                Polygon.WidgetKey,
                Polygon.PointsString.WithValue(points),
                Shape.StrokeThickness.WithValue(strokeThickness),
                Shape.Stroke.WithValue(AppTheme.create strokeLight strokeDark)
            )

        static member inline Polygon<'msg>(points: Point list, strokeThickness: float, strokeLight: Brush, ?strokeDark: Brush) =
            WidgetBuilder<'msg, IFabPolygon>(
                Polygon.WidgetKey,
                Polygon.PointsList.WithValue(Array.ofList points),
                Shape.StrokeThickness.WithValue(strokeThickness),
                Shape.Stroke.WithValue(AppTheme.create strokeLight strokeDark)
            )

[<Extension>]
type PolygonModifiers =

    [<Extension>]
    static member inline fillRule(this: WidgetBuilder<'msg, #IFabPolygon>, value: FillRule) =
        this.AddScalar(Polygon.FillRule.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Polygon control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPolygon>, value: ViewRef<Polygon>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
