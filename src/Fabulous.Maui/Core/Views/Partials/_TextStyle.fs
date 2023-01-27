namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Handlers.Defaults
open Fabulous
open Fabulous.Maui.Controls

module TextStyle =
    let Font = Attributes.defineMauiProperty' "Font" TextStyleDefaults.CreateDefaultFont FabTextStyle.SetFont
    let TextColor = Attributes.defineMauiProperty "TextColor" TextStyleDefaults.TextColor FabTextStyle.SetTextColor

[<Extension>]
type TextStyleModifiers =
    [<Extension>]
    static member inline font(this: WidgetBuilder<'msg, #ITextStyle>, value: Font) =
        this.AddScalar(TextStyle.Font.WithValue(value))
        
    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #ITextStyle>, value: Microsoft.Maui.Graphics.Color) =
        this.AddScalar(TextStyle.TextColor.WithValue(value))
