namespace Fabulous.Maui.Compatibility

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

type IFabCompatLayout =
    inherit IFabCompatView
    inherit ILayout

module CompatLayout =
    let Padding =
        Attributes.defineBindableWithEquality<Thickness> Layout.PaddingProperty

    let CascadeInputTransparent =
        Attributes.defineBindableBool Layout.CascadeInputTransparentProperty

    let IsClippedToBounds =
        Attributes.defineBindableBool Layout.IsClippedToBoundsProperty

[<Extension>]
type CompatLayoutModifiers =
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabCompatLayout>, value: Thickness) =
        this.AddScalar(CompatLayout.Padding.WithValue(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabCompatLayout>, value: float) =
        CompatLayoutModifiers.padding(this, Thickness(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabCompatLayout>, left: float, top: float, right: float, bottom: float) =
        CompatLayoutModifiers.padding(this, Thickness(left, top, right, bottom))

    [<Extension>]
    static member inline cascadeInputTransparent(this: WidgetBuilder<'msg, #IFabCompatLayout>, value: bool) =
        this.AddScalar(CompatLayout.CascadeInputTransparent.WithValue(value))

    [<Extension>]
    static member inline isClippedToBounds(this: WidgetBuilder<'msg, #IFabCompatLayout>, value: bool) =
        this.AddScalar(CompatLayout.IsClippedToBounds.WithValue(value))
