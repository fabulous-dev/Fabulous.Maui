namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Handlers.Defaults
open Fabulous

module TextStyle =
    let CharacterSpacing =
        Attributes.defineMauiProperty "CharacterSpacing" TextStyleDefaults.CharacterSpacing (fun (target: IFabTextStyle) -> target.SetCharacterSpacing)

    let Font =
        Attributes.defineMauiProperty' "Font" TextStyleDefaults.CreateDefaultFont (fun (target: IFabTextStyle) -> target.SetFont)

    let TextColor =
        Attributes.defineMauiProperty "TextColor" TextStyleDefaults.TextColor (fun (target: IFabTextStyle) -> target.SetTextColor)

[<Extension>]
type TextStyleModifiers =
    [<Extension>]
    static member inline font(this: WidgetBuilder<'msg, #IFabTextStyle>, value: Font) =
        this.AddScalar(TextStyle.Font.WithValue(value))

    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #IFabTextStyle>, value: Microsoft.Maui.Graphics.Color) =
        this.AddScalar(TextStyle.TextColor.WithValue(value))

[<Extension>]
type TextStyleExtraModifiers =
    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #IFabTextStyle>, value: FabColor) = this.textColor(value.ToMauiColor())

    [<Extension>]
    static member inline font(this: WidgetBuilder<'msg, #IFabTextStyle>, ?size: float, ?fontFamily: string) =
        match size, fontFamily with
        | Some size, Some fontFamily -> this.font(Font.OfSize(fontFamily, size))
        | Some size, None -> this.font(Font.SystemFontOfSize(size))
        | None, Some fontFamily -> this.font(Font.OfSize(fontFamily, Font.Default.Size))
        | None, None -> this
