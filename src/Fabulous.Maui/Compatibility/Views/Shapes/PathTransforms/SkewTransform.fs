namespace Fabulous.Maui.Compatibility

open Fabulous
open Microsoft.Maui.Controls.Shapes

type IFabCompatSkewTransform =
    inherit IFabCompatTransform

module SkewTransform =
    let WidgetKey = CompatWidgets.register<SkewTransform>()

    let AnglesXY =
        Attributes.defineSimpleScalarWithEquality<struct (float * float)> "SkewTransform_Angles" (fun _ newValueOpt node ->
            let line = node.Target :?> SkewTransform

            match newValueOpt with
            | ValueNone ->
                line.AngleX <- 0.
                line.AngleY <- 0.
            | ValueSome(x, y) ->
                line.AngleX <- x
                line.AngleY <- y)

    let CenterX = Attributes.defineBindableFloat ScaleTransform.CenterXProperty

    let CenterY = Attributes.defineBindableFloat ScaleTransform.CenterYProperty

[<AutoOpen>]
module SkewTransformBuilders =

    type Fabulous.Maui.View with

        static member inline SkewTransform<'msg>(angleX: float, angleY: float, centerX: float, centerY: float) =
            WidgetBuilder<'msg, IFabCompatSkewTransform>(
                SkewTransform.WidgetKey,
                SkewTransform.AnglesXY.WithValue((angleX, angleY)),
                SkewTransform.CenterX.WithValue(centerX),
                SkewTransform.CenterY.WithValue(centerY)
            )
