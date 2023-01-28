namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Handlers.Defaults
open Microsoft.Maui.Graphics
open Microsoft.Maui.Primitives
open Fabulous
open Fabulous.Maui.Controls

module View' =
    let Background =
        Attributes.defineMauiProperty "Background" ViewDefaults.Background (fun (target: IFabView) -> target.SetBackground)

    let Height =
        Attributes.defineMauiProperty "Height" ViewDefaults.Height (fun (target: IFabView) -> target.SetHeight)

    let MinimumHeight =
        Attributes.defineMauiProperty "MinimumHeight" ViewDefaults.MinimumHeight (fun (target: IFabView) -> target.SetMinimumHeight)

    let MinimumWidth =
        Attributes.defineMauiProperty "MinimumWidth" ViewDefaults.MinimumWidth (fun (target: IFabView) -> target.SetMinimumWidth)

    let MaximumHeight =
        Attributes.defineMauiProperty "MaximumHeight" ViewDefaults.MaximumHeight (fun (target: IFabView) -> target.SetMaximumHeight)

    let MaximumWidth =
        Attributes.defineMauiProperty "MaximumWidth" ViewDefaults.MaximumWidth (fun (target: IFabView) -> target.SetMaximumWidth)

    let HorizontalLayoutAlignment =
        Attributes.defineMauiProperty "HorizontalLayoutAlignment" ViewDefaults.HorizontalLayoutAlignment (fun (target: IFabView) ->
            target.SetHorizontalLayoutAlignment)

    let VerticalLayoutAlignment =
        Attributes.defineMauiProperty "VerticalLayoutAlignment" ViewDefaults.VerticalLayoutAlignment (fun (target: IFabView) ->
            target.SetVerticalLayoutAlignment)

    let Semantics =
        Attributes.defineMauiProperty' "Semantics" ViewDefaults.CreateDefaultSemantics (fun (target: IFabView) -> target.SetSemantics)

[<Extension>]
type ViewModifiers =
    [<Extension>]
    static member background(this: WidgetBuilder<'msg, #IView>, value: Paint) =
        this.AddScalar(View'.Background.WithValue(value))

    [<Extension>]
    static member height(this: WidgetBuilder<'msg, #IView>, value: float) =
        this.AddScalar(View'.Height.WithValue(value))

    [<Extension>]
    static member minimumHeight(this: WidgetBuilder<'msg, #IFabView>, value: float) =
        this.AddScalar(View'.MinimumHeight.WithValue(value))

    [<Extension>]
    static member maximumWidth(this: WidgetBuilder<'msg, #IFabView>, value: float) =
        this.AddScalar(View'.MaximumWidth.WithValue(value))

    [<Extension>]
    static member maximumHeight(this: WidgetBuilder<'msg, #IFabView>, value: float) =
        this.AddScalar(View'.MaximumHeight.WithValue(value))

    [<Extension>]
    static member minimumWidth(this: WidgetBuilder<'msg, #IFabView>, value: float) =
        this.AddScalar(View'.MinimumWidth.WithValue(value))

    [<Extension>]
    static member horizontalLayoutAlignment(this: WidgetBuilder<'msg, #IFabView>, value: LayoutAlignment) =
        this.AddScalar(View'.HorizontalLayoutAlignment.WithValue(value))

    [<Extension>]
    static member semantics(this: WidgetBuilder<'msg, #IFabView>, value: Semantics) =
        this.AddScalar(View'.Semantics.WithValue(value))

[<Extension>]
type ViewExtraModifiers =
    [<Extension>]
    static member inline centerHorizontal(this: WidgetBuilder<'msg, #IFabView>) =
        this.AddScalar(View'.HorizontalLayoutAlignment.WithValue(LayoutAlignment.Center))

    [<Extension>]
    static member inline centerVertical(this: WidgetBuilder<'msg, #IFabView>) =
        this.AddScalar(View'.VerticalLayoutAlignment.WithValue(LayoutAlignment.Center))
