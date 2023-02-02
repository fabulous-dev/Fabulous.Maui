namespace Fabulous.Maui.Compatibility

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Maui
open Fabulous.StackAllocatedCollections
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

[<Extension>]
type GestureElementYieldExtensions =
    [<Extension>]
    static member inline Yield
        (
            _: AttributeCollectionBuilder<'msg, #IFabCompatGestureElement, IFabCompatGestureRecognizer>,
            x: WidgetBuilder<'msg, #IFabCompatGestureRecognizer>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
        
    [<Extension>]
    static member inline Yield
        (
            _: AttributeCollectionBuilder<'msg, #IFabCompatGestureElement, IFabCompatGestureRecognizer>,
            x: WidgetBuilder<'msg, Memo.Memoized<#IFabCompatGestureRecognizer>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }