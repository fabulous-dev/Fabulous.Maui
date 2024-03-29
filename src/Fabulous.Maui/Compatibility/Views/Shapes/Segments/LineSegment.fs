namespace Fabulous.Maui.Compatibility

open Fabulous
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type IFabCompatLineSegment =
    inherit IFabCompatPathSegment

module LineSegment =
    let WidgetKey = CompatWidgets.register<LineSegment>()

    let Point = Attributes.defineBindableWithEquality<Point> LineSegment.PointProperty

[<AutoOpen>]
module LineSegmentBuilders =

    type Fabulous.Maui.View with

        static member inline LineSegment<'msg>(point: Point) =
            WidgetBuilder<'msg, IFabCompatLineSegment>(LineSegment.WidgetKey, LineSegment.Point.WithValue(point))
