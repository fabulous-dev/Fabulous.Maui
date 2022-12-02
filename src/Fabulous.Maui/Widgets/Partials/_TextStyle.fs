namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Handlers.Defaults
open Fabulous
open Fabulous.Maui.Controls

module TextStyle =
    let Font = Attributes.defineMauiProperty' "TextStyle" "Font" TextStyleDefaults.CreateDefaultFont FabTextStyleSetters.SetFont
    let TextColor = Attributes.defineMauiProperty "TextStyle" "TextColor" TextStyleDefaults.TextColor FabTextStyleSetters.SetTextColor

[<Extension>]
type TextStyleModifiers =
    [<Extension>]
    static member inline font(this: WidgetBuilder<'msg, #ITextStyle>, value: Font) =
        this.AddScalar(TextStyle.Font.WithValue(value))
        
    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #ITextStyle>, value: Microsoft.Maui.Graphics.Color) =
        this.AddScalar(TextStyle.TextColor.WithValue(value))
