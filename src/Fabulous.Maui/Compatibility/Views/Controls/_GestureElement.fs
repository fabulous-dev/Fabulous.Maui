namespace Fabulous.Maui.Compatibility

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Maui
open Microsoft.Maui.Controls

type IFabCompatGestureElement =
    inherit IFabCompatElement

module GestureElement =
    let GestureRecognizers =
        Attributes.defineListWidgetCollection<IGestureRecognizer> "Span_GestureRecognizers" (fun target -> (target :?> Span).GestureRecognizers)

[<Extension>]
type GestureElementModifiers =
    [<Extension>]
    static member inline gestureRecognizers(this: WidgetBuilder<'msg, #IFabCompatGestureElement>) =
        WidgetHelpers.buildAttributeCollection<'msg, 'marker, IFabCompatGestureRecognizer> GestureElement.GestureRecognizers this
