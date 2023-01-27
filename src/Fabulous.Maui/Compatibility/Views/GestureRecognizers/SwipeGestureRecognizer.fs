namespace Fabulous.Maui.Compatibility

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

type IFabCompatSwipeGestureRecognizer =
    inherit IFabCompatGestureRecognizer

module SwipeGestureRecognizer =
    let WidgetKey = CompatWidgets.register<SwipeGestureRecognizer>()

    let Direction =
        Attributes.defineBindableEnum<SwipeDirection> SwipeGestureRecognizer.DirectionProperty

    let Threshold =
        Attributes.defineBindableInt SwipeGestureRecognizer.ThresholdProperty

    let Swiped =
        Attributes.defineEvent<SwipedEventArgs> "SwipeGestureRecognizer_Swiped" (fun target -> (target :?> SwipeGestureRecognizer).Swiped)

[<AutoOpen>]
module SwipeGestureRecognizerBuilders =
    type Fabulous.Maui.View with

        static member inline SwipeGestureRecognizer<'msg>(onSwiped: SwipeDirection -> 'msg) =
            WidgetBuilder<'msg, IFabCompatSwipeGestureRecognizer>(
                SwipeGestureRecognizer.WidgetKey,
                SwipeGestureRecognizer.Swiped.WithValue(fun args -> onSwiped args.Direction |> box)
            )

[<Extension>]
type SwipeGestureRecognizerModifiers =

    /// <summary>Sets the direction of swipes to recognize.</summary>
    /// <param name="direction">The direction of swipes</param>
    [<Extension>]
    static member inline direction(this: WidgetBuilder<'msg, #IFabCompatSwipeGestureRecognizer>, direction: SwipeDirection) =
        this.AddScalar(SwipeGestureRecognizer.Direction.WithValue(direction))

    /// <summary>Sets the minimum swipe distance that will cause the gesture to be recognized.</summary>
    /// <param name="threshold">The minimum swipe distance</param>
    [<Extension>]
    static member inline threshold(this: WidgetBuilder<'msg, #IFabCompatSwipeGestureRecognizer>, threshold: int) =
        this.AddScalar(SwipeGestureRecognizer.Threshold.WithValue(threshold))
