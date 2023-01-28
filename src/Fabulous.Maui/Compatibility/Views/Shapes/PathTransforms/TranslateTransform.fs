namespace Fabulous.Maui.Compatibility

open Fabulous
open Microsoft.Maui.Controls.Shapes

type IFabCompatTranslateTransform =
    inherit IFabCompatTransform

module TranslateTransform =
    let WidgetKey = CompatWidgets.register<TranslateTransform>()

    let X = Attributes.defineBindableFloat TranslateTransform.XProperty

    let Y = Attributes.defineBindableFloat TranslateTransform.YProperty

[<AutoOpen>]
module TranslateTransformBuilders =

    type Fabulous.Maui.View with

        static member inline TranslateTransform<'msg>(x: float, y: float) =
            WidgetBuilder<'msg, IFabCompatTranslateTransform>(
                TranslateTransform.WidgetKey,
                TranslateTransform.X.WithValue(x),
                TranslateTransform.Y.WithValue(y)
            )
