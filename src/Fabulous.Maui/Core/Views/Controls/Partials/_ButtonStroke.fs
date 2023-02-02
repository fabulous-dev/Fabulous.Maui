namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Handlers.Defaults
open Fabulous
open Fabulous.Maui.Controls

module ButtonStroke =
    let CornerRadius =
        Attributes.defineMauiProperty "CornerRadius" ButtonStrokeDefaults.CornerRadius (fun (target: IFabButtonStroke) -> target.SetCornerRadius)

    let StrokeColor =
        Attributes.defineMauiProperty "StrokeColor" ButtonStrokeDefaults.StrokeColor (fun (target: IFabButtonStroke) -> target.SetStrokeColor)

    let StrokeThickness =
        Attributes.defineMauiProperty "StrokeThickness" ButtonStrokeDefaults.StrokeThickness (fun (target: IFabButtonStroke) -> target.SetStrokeThickness)

[<Extension>]
type ButtonStrokeModifiers =
    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IFabButtonStroke>, value: int) =
        this.AddScalar(ButtonStroke.CornerRadius.WithValue(value))

    [<Extension>]
    static member strokeColor(this: WidgetBuilder<'msg, #IFabButtonStroke>, value: Color) =
        this.AddScalar(ButtonStroke.StrokeColor.WithValue(value))
        
    [<Extension>]
    static member strokeThickness(this: WidgetBuilder<'msg, #IFabButtonStroke>, value: float) =
        this.AddScalar(ButtonStroke.StrokeThickness.WithValue(value))