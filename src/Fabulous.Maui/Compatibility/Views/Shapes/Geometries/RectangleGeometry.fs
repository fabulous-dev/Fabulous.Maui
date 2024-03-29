namespace Fabulous.Maui.Compatibility

open Fabulous
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type IFabCompatRectangleGeometry =
    inherit IFabCompatGeometry

module RectangleGeometry =
    let WidgetKey = CompatWidgets.register<RectangleGeometry>()

    let Rect =
        Attributes.defineBindableWithEquality<Rect> RectangleGeometry.RectProperty

[<AutoOpen>]
module RectangleGeometryBuilders =
    type Fabulous.Maui.View with

        static member inline RectangleGeometry<'msg>(rect: Rect) =
            WidgetBuilder<'msg, IFabCompatRectangleGeometry>(RectangleGeometry.WidgetKey, RectangleGeometry.Rect.WithValue(rect))
