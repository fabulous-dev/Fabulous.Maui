namespace Fabulous.Maui.Compatibility

open System
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Maui
open Microsoft.Maui.Controls

/// FlyoutPage doesn't say if the Flyout is visible or not on IsPresentedChanged, so we implement it
type CustomFlyoutPage() as this =
    inherit FlyoutPage()

    let isPresentedChanged = Event<EventHandler<bool>, bool>()

    do this.IsPresentedChanged.Add(this.OnIsPresentedChanged)

    [<CLIEvent>]
    member _.CustomIsPresentedChanged = isPresentedChanged.Publish

    member _.OnIsPresentedChanged(_) =
        isPresentedChanged.Trigger(this, this.IsPresented)

type IFabCompatFlyoutPage =
    inherit IFabCompatPage

module FlyoutPage =
    let WidgetKey = CompatWidgets.register<CustomFlyoutPage>()

    let IsGestureEnabled =
        Attributes.defineBindableBool FlyoutPage.IsGestureEnabledProperty

    let IsPresented =
        Attributes.defineBindableWithEvent<bool, bool> "FlyoutPage_IsPresentedChanged" FlyoutPage.IsPresentedProperty (fun target ->
            (target :?> CustomFlyoutPage).CustomIsPresentedChanged)

    let Flyout =
        Attributes.definePropertyWidget "FlyoutPage_Flyout" (fun target -> (target :?> FlyoutPage).Flyout :> obj) (fun target value ->
            (target :?> FlyoutPage).Flyout <- value)

    let FlyoutLayoutBehavior =
        Attributes.defineBindableEnum<FlyoutLayoutBehavior> FlyoutPage.FlyoutLayoutBehaviorProperty

    let Detail =
        Attributes.definePropertyWidget "FlyoutPage_Detail" (fun target -> (target :?> FlyoutPage).Detail :> obj) (fun target value ->
            (target :?> FlyoutPage).Detail <- value)

    let BackButtonPressed =
        Attributes.defineEvent<BackButtonPressedEventArgs> "FlyoutPage_BackButtonPressed" (fun target -> (target :?> FlyoutPage).BackButtonPressed)

[<AutoOpen>]
module FlyoutPageBuilders =
    type Fabulous.Maui.View with

        static member inline FlyoutPage<'msg, 'flyout, 'detail when 'flyout :> IFabCompatPage and 'detail :> IFabCompatPage>
            (
                flyout: WidgetBuilder<'msg, 'flyout>,
                detail: WidgetBuilder<'msg, 'detail>
            ) =
            WidgetHelpers.buildWidgets<'msg, IFabCompatFlyoutPage>
                FlyoutPage.WidgetKey
                [| FlyoutPage.Flyout.WithValue(flyout.Compile())
                   FlyoutPage.Detail.WithValue(detail.Compile()) |]

[<Extension>]
type FlyoutPageModifiers =

    [<Extension>]
    static member inline isPresented(this: WidgetBuilder<'msg, #IFabCompatFlyoutPage>, value: bool, onChanged: bool -> 'msg) =
        this.AddScalar(FlyoutPage.IsPresented.WithValue(ValueEventData.create value (fun v -> onChanged v |> box)))

    [<Extension>]
    static member inline isGestureEnabled(this: WidgetBuilder<'msg, #IFabCompatFlyoutPage>, value: bool) =
        this.AddScalar(FlyoutPage.IsGestureEnabled.WithValue(value))

    [<Extension>]
    static member inline flyoutLayoutBehavior(this: WidgetBuilder<'msg, #IFabCompatFlyoutPage>, value: FlyoutLayoutBehavior) =
        this.AddScalar(FlyoutPage.FlyoutLayoutBehavior.WithValue(value))

    [<Extension>]
    static member inline onBackButtonPressed(this: WidgetBuilder<'msg, #IFabCompatFlyoutPage>, onBackButtonPressed: bool -> 'msg) =
        this.AddScalar(FlyoutPage.BackButtonPressed.WithValue(fun args -> onBackButtonPressed args.Handled |> box))

    /// <summary>Link a ViewRef to access the direct ContentPage control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCompatFlyoutPage>, value: ViewRef<FlyoutPage>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
