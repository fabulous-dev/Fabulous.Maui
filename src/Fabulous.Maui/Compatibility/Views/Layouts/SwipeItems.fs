namespace Fabulous.Maui.Compatibility

open System.Collections.Generic
open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

type IFabCompatSwipeItems =
    inherit IFabCompatElement
    inherit ISwipeItems

module SwipeItems =

    let WidgetKey = CompatWidgets.register<SwipeItems>()

    let SwipeItems =
        Attributes.defineListWidgetCollection "SwipeItems_SwipeItems" (fun target -> (target :?> SwipeItems) :> IList<_>)

    let SwipeMode =
        Attributes.defineBindableEnum<SwipeMode> Microsoft.Maui.Controls.SwipeItems.ModeProperty

    let SwipeBehaviorOnInvoked =
        Attributes.defineBindableEnum<SwipeBehaviorOnInvoked> Microsoft.Maui.Controls.SwipeItems.SwipeBehaviorOnInvokedProperty

[<AutoOpen>]
module SwipeItemsBuilders =

    type Fabulous.Maui.View with

        static member inline SwipeItems<'msg>() =
            CollectionBuilder<'msg, IFabCompatSwipeItems, IFabSwipeItem>(SwipeItems.WidgetKey, SwipeItems.SwipeItems)

[<Extension>]
type SwipeItemsModifiers() =
    [<Extension>]
    static member inline swipeMode(this: WidgetBuilder<'msg, #IFabCompatSwipeItems>, value: SwipeMode) =
        this.AddScalar(SwipeItems.SwipeMode.WithValue(value))

    [<Extension>]
    static member inline swipeBehaviorOnInvoked(this: WidgetBuilder<'msg, #IFabCompatSwipeItems>, value: SwipeBehaviorOnInvoked) =
        this.AddScalar(SwipeItems.SwipeBehaviorOnInvoked.WithValue(value))

    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCompatSwipeItems>, value: ViewRef<SwipeItems>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
