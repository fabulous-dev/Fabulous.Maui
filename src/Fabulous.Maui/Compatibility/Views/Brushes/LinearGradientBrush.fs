namespace Fabulous.Maui.Compatibility

open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type IFabCompatLinearGradientBrush =
    inherit IFabCompatGradientBrush

module LinearGradientBrush =

    let WidgetKey = CompatWidgets.register<LinearGradientBrush>()

    let StartPoint =
        Attributes.defineBindableWithEquality<Point> LinearGradientBrush.StartPointProperty

    let EndPoint =
        Attributes.defineBindableWithEquality<Point> LinearGradientBrush.EndPointProperty

[<AutoOpen>]
module LinearGradientBrushBuilders =
    type Fabulous.Maui.View with

        /// <summary>LinearGradientBrush paints an area with a linear gradient, which blends two or more colors along a line known as the gradient axis. </summary>
        static member inline LinearGradientBrush<'msg>() =
            CollectionBuilder<'msg, IFabCompatLinearGradientBrush, IFabCompatGradientStop>(
                LinearGradientBrush.WidgetKey,
                GradientBrush.Children,
                LinearGradientBrush.StartPoint.WithValue(Point(0., 0.)),
                LinearGradientBrush.EndPoint.WithValue(Point(1., 1.))
            )

        /// <summary>LinearGradientBrush paints an area with a linear gradient, which blends two or more colors along a line known as the gradient axis. </summary>
        /// <param name="endPoint">EndPoint, of type Point, which represents the ending two-dimensional coordinates of the linear gradient. The default value of this property is (1,1).</param>
        /// <param name="startPoint">StartPoint, of type Point, which represents the starting two-dimensional coordinates of the linear gradient. The default value of this property is (0,0).</param>
        static member inline LinearGradientBrush<'msg>(startPoint: Point, endPoint: Point) =
            CollectionBuilder<'msg, IFabCompatLinearGradientBrush, IFabCompatGradientStop>(
                LinearGradientBrush.WidgetKey,
                GradientBrush.Children,
                LinearGradientBrush.StartPoint.WithValue(startPoint),
                LinearGradientBrush.EndPoint.WithValue(endPoint)
            )
