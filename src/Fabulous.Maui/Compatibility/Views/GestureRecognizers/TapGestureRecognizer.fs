namespace Fabulous.Maui.Compatibility

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls

type IFabCompatTapGestureRecognizer =
    inherit IFabCompatGestureRecognizer

module TapGestureRecognizer =
    let WidgetKey = CompatWidgets.register<TapGestureRecognizer>()

    let Tapped =
        Attributes.defineEvent "TapGestureRecognizer_Tapped" (fun target -> (target :?> TapGestureRecognizer).Tapped)

    let NumberOfTapsRequired =
        Attributes.defineBindableInt TapGestureRecognizer.NumberOfTapsRequiredProperty

[<AutoOpen>]
module TapGestureRecognizerBuilders =
    type Fabulous.Maui.View with

        static member inline TapGestureRecognizer<'msg>(onTapped: 'msg) =
            WidgetBuilder<'msg, IFabCompatTapGestureRecognizer>(TapGestureRecognizer.WidgetKey, TapGestureRecognizer.Tapped.WithValue(fun _ -> box onTapped))

[<Extension>]
type TapGestureRecognizerModifiers =

    /// <summary>The number of taps required to trigger the callback</summary>
    /// <param name="value">The number of taps required</param>
    [<Extension>]
    static member inline numberOfTapsRequired(this: WidgetBuilder<'msg, #IFabCompatTapGestureRecognizer>, value: int) =
        this.AddScalar(TapGestureRecognizer.NumberOfTapsRequired.WithValue(value))
