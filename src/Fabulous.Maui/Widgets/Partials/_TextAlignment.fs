namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Handlers.Defaults
open Fabulous
open Fabulous.Maui.Controls

module TextAlignment =
    let HorizontalTextAlignment = Attributes.defineMauiProperty "HorizontalTextAlignment" TextAlignmentDefaults.HorizontalTextAlignment FabTextAlignment.SetHorizontalTextAlignment
    let VerticalTextAlignment = Attributes.defineMauiProperty "VerticalTextAlignment" TextAlignmentDefaults.VerticalTextAlignment FabTextAlignment.SetVerticalTextAlignment
    
[<Extension>]
type TextAlignmentModifiers =
    [<Extension>]
    static member inline horizontalTextAlignment(this: WidgetBuilder<'msg, #ITextAlignment>, value: TextAlignment) =
        this.AddScalar(TextAlignment.HorizontalTextAlignment.WithValue(value))
        
    [<Extension>]
    static member inline verticalTextAlignment(this: WidgetBuilder<'msg, #ITextAlignment>, value: TextAlignment) =
        this.AddScalar(TextAlignment.VerticalTextAlignment.WithValue(value))
        
[<Extension>]
type TextAlignmentExtraModifiers =
    [<Extension>]
    static member inline centerTextHorizontal(this: WidgetBuilder<'msg, #ITextAlignment>) =
        this.horizontalTextAlignment(TextAlignment.Center)
        
    [<Extension>]
    static member inline centerTextVertical(this: WidgetBuilder<'msg, #ITextAlignment>) =
        this.verticalTextAlignment(TextAlignment.Center)