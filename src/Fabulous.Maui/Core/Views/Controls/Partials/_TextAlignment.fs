namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Handlers.Defaults
open Fabulous
open Fabulous.Maui.Controls

module TextAlignment =
    let HorizontalTextAlignment =
        Attributes.defineMauiProperty "HorizontalTextAlignment" TextAlignmentDefaults.HorizontalTextAlignment (fun (target: IFabTextAlignment) ->
            target.SetHorizontalTextAlignment)

    let VerticalTextAlignment =
        Attributes.defineMauiProperty "VerticalTextAlignment" TextAlignmentDefaults.VerticalTextAlignment (fun (target: IFabTextAlignment) ->
            target.SetVerticalTextAlignment)

[<Extension>]
type TextAlignmentModifiers =
    [<Extension>]
    static member inline horizontalTextAlignment(this: WidgetBuilder<'msg, #IFabTextAlignment>, value: TextAlignment) =
        this.AddScalar(TextAlignment.HorizontalTextAlignment.WithValue(value))

    [<Extension>]
    static member inline verticalTextAlignment(this: WidgetBuilder<'msg, #IFabTextAlignment>, value: TextAlignment) =
        this.AddScalar(TextAlignment.VerticalTextAlignment.WithValue(value))

[<Extension>]
type TextAlignmentExtraModifiers =
    [<Extension>]
    static member inline centerTextHorizontal(this: WidgetBuilder<'msg, #IFabTextAlignment>) =
        this.horizontalTextAlignment(TextAlignment.Center)

    [<Extension>]
    static member inline centerTextVertical(this: WidgetBuilder<'msg, #IFabTextAlignment>) =
        this.verticalTextAlignment(TextAlignment.Center)
        
    [<Extension>]
    static member inline alignTextStartHorizontal(this: WidgetBuilder<'msg, #IFabTextAlignment>) =
        this.horizontalTextAlignment(TextAlignment.Start)

    [<Extension>]
    static member inline alignTextStartVertical(this: WidgetBuilder<'msg, #IFabTextAlignment>) =
        this.verticalTextAlignment(TextAlignment.Start)
        
    [<Extension>]
    static member inline alignTextEndHorizontal(this: WidgetBuilder<'msg, #IFabTextAlignment>) =
        this.horizontalTextAlignment(TextAlignment.End)

    [<Extension>]
    static member inline alignTextEndVertical(this: WidgetBuilder<'msg, #IFabTextAlignment>) =
        this.verticalTextAlignment(TextAlignment.End)
