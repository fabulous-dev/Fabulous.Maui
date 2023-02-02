namespace Fabulous.Maui.Compatibility

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Maui
open Fabulous.StackAllocatedCollections
open Microsoft.Maui
open Microsoft.Maui.Controls

type IFabCompatView =
    inherit IFabCompatVisualElement

module CompatView =
    let HorizontalOptions =
        Attributes.defineSmallBindable<LayoutOptions> View.HorizontalOptionsProperty SmallScalars.LayoutOptions.decode

    let VerticalOptions =
        Attributes.defineSmallBindable<LayoutOptions> View.VerticalOptionsProperty SmallScalars.LayoutOptions.decode

    let Margin = Attributes.defineBindableWithEquality<Thickness> View.MarginProperty

    let GestureRecognizers =
        Attributes.defineListWidgetCollection<IGestureRecognizer> "View_GestureRecognizers" (fun target -> (target :?> View).GestureRecognizers)

[<Extension>]
type CompatViewModifiers =
    [<Extension>]
    static member inline horizontalOptions(this: WidgetBuilder<'msg, #IFabCompatView>, value: LayoutOptions) =
        this.AddScalar(CompatView.HorizontalOptions.WithValue(value))

    [<Extension>]
    static member inline verticalOptions(this: WidgetBuilder<'msg, #IFabCompatView>, value: LayoutOptions) =
        this.AddScalar(CompatView.VerticalOptions.WithValue(value))

    [<Extension>]
    static member inline center(this: WidgetBuilder<'msg, #IFabCompatView>) =
        this
            .AddScalar(CompatView.HorizontalOptions.WithValue(LayoutOptions.Center))
            .AddScalar(CompatView.VerticalOptions.WithValue(LayoutOptions.Center))

    [<Extension>]
    static member inline centerHorizontal(this: WidgetBuilder<'msg, #IFabCompatView>) =
        this.AddScalar(CompatView.HorizontalOptions.WithValue(LayoutOptions.Center))

    [<Extension>]
    static member inline centerVertical(this: WidgetBuilder<'msg, #IFabCompatView>) =
        this.AddScalar(CompatView.VerticalOptions.WithValue(LayoutOptions.Center))

    [<Extension>]
    static member inline alignStartHorizontal(this: WidgetBuilder<'msg, #IFabCompatView>) =
        this.AddScalar(CompatView.HorizontalOptions.WithValue(LayoutOptions.Start))

    [<Extension>]
    static member inline alignStartVertical(this: WidgetBuilder<'msg, #IFabCompatView>) =
        this.AddScalar(CompatView.VerticalOptions.WithValue(LayoutOptions.Start))

    [<Extension>]
    static member inline alignEndHorizontal(this: WidgetBuilder<'msg, #IFabCompatView>) =
        this.AddScalar(CompatView.HorizontalOptions.WithValue(LayoutOptions.End))

    [<Extension>]
    static member inline alignEndVertical(this: WidgetBuilder<'msg, #IFabCompatView>) =
        this.AddScalar(CompatView.VerticalOptions.WithValue(LayoutOptions.End))

    [<Extension>]
    static member inline fillHorizontal(this: WidgetBuilder<'msg, #IFabCompatView>) =
        this.AddScalar(CompatView.HorizontalOptions.WithValue(LayoutOptions.Fill))

    [<Extension>]
    static member inline fillVertical(this: WidgetBuilder<'msg, #IFabCompatView>) =
        this.AddScalar(CompatView.VerticalOptions.WithValue(LayoutOptions.Fill))

    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IFabCompatView>, value: Thickness) =
        this.AddScalar(CompatView.Margin.WithValue(value))

    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IFabCompatView>, value: float) =
        CompatViewModifiers.margin(this, Thickness(value))

    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IFabCompatView>, left: float, top: float, right: float, bottom: float) =
        CompatViewModifiers.margin(this, Thickness(left, top, right, bottom))

    [<Extension>]
    static member inline gestureRecognizers<'msg, 'marker when 'marker :> IFabCompatView>(this: WidgetBuilder<'msg, 'marker>) =
        WidgetHelpers.buildAttributeCollection<'msg, 'marker, IFabCompatGestureRecognizer> CompatView.GestureRecognizers this

[<Extension>]
type CompatViewYieldExtensions =
    [<Extension>]
    static member inline Yield
        (
            _: AttributeCollectionBuilder<'msg, #IFabCompatView, IFabCompatGestureRecognizer>,
            x: WidgetBuilder<'msg, #IFabCompatGestureRecognizer>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield
        (
            _: AttributeCollectionBuilder<'msg, #IFabCompatView, IFabCompatGestureRecognizer>,
            x: WidgetBuilder<'msg, Memo.Memoized<#IFabCompatGestureRecognizer>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
