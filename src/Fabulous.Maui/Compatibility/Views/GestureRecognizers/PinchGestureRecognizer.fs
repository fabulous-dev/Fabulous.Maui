namespace Fabulous.Maui.Compatibility

open Fabulous
open Microsoft.Maui.Controls

type IFabCompatPinchGestureRecognizer =
    inherit IFabCompatGestureRecognizer

module PinchGestureRecognizer =
    let WidgetKey = CompatWidgets.register<PinchGestureRecognizer>()

    let PinchUpdated =
        Attributes.defineEvent<PinchGestureUpdatedEventArgs> "PinchGestureRecognizer_PinchUpdated" (fun target ->
            (target :?> PinchGestureRecognizer).PinchUpdated)

[<AutoOpen>]
module PinchGestureRecognizerBuilders =
    type Fabulous.Maui.View with

        static member inline PinchGestureRecognizer<'msg>(onPinchUpdated: PinchGestureUpdatedEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabCompatPinchGestureRecognizer>(
                PinchGestureRecognizer.WidgetKey,
                PinchGestureRecognizer.PinchUpdated.WithValue(fun args -> onPinchUpdated args |> box)
            )
