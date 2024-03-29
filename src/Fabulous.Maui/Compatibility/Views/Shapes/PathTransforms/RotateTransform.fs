namespace Fabulous.Maui.Compatibility

open Fabulous
open Microsoft.Maui.Controls.Shapes

type IFabCompatRotateTransform =
    inherit IFabCompatTransform

module RotateTransform =
    let WidgetKey = CompatWidgets.register<RotateTransform>()

    let Angle = Attributes.defineBindableFloat RotateTransform.AngleProperty

    let CenterX = Attributes.defineBindableFloat RotateTransform.CenterXProperty

    let CenterY = Attributes.defineBindableFloat RotateTransform.CenterYProperty

[<AutoOpen>]
module RotateTransformBuilders =

    type Fabulous.Maui.View with

        static member inline RotateTransform<'msg>(angle: float, centerX: float, centerY: float) =
            WidgetBuilder<'msg, IFabCompatRotateTransform>(
                RotateTransform.WidgetKey,
                RotateTransform.Angle.WithValue(angle),
                RotateTransform.CenterX.WithValue(centerX),
                RotateTransform.CenterY.WithValue(centerY)
            )
