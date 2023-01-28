namespace Fabulous.Maui.Compatibility

open Fabulous
open Microsoft.Maui.Controls.Shapes

type IFabCompatScaleTransform =
    inherit IFabCompatTransform

module ScaleTransform =
    let WidgetKey = CompatWidgets.register<ScaleTransform>()

    let ScaleXY =
        Attributes.defineSimpleScalarWithEquality<struct (float * float)> "ScaleTransform_Scale" (fun _ newValueOpt node ->
            let line = node.Target :?> ScaleTransform

            match newValueOpt with
            | ValueNone ->
                line.ScaleX <- 0.
                line.ScaleY <- 0.
            | ValueSome(x, y) ->
                line.ScaleX <- x
                line.ScaleY <- y)

    let CenterX = Attributes.defineBindableFloat ScaleTransform.CenterXProperty

    let CenterY = Attributes.defineBindableFloat ScaleTransform.CenterYProperty

[<AutoOpen>]
module ScaleTransformBuilders =

    type Fabulous.Maui.View with

        static member inline ScaleTransform<'msg>(scaleX: float, scaleY: float, centerX: float, centerY: float) =
            WidgetBuilder<'msg, IFabCompatScaleTransform>(
                ScaleTransform.WidgetKey,
                ScaleTransform.ScaleXY.WithValue((scaleX, scaleY)),
                ScaleTransform.CenterX.WithValue(centerX),
                ScaleTransform.CenterY.WithValue(centerY)
            )
