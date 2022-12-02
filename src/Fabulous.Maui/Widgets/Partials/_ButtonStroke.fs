namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Handlers.Defaults
open Fabulous
open Fabulous.Maui.Controls

module ButtonStroke =
    let CornerRadius = Attributes.defineMauiProperty "ButtonStroke" "CornerRadius" ButtonStrokeDefaults.CornerRadius FabButtonStrokeSetters.SetCornerRadius

[<Extension>]
type ButtonStrokeModifiers =
    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IButtonStroke>, value: int) =
        this.AddScalar(ButtonStroke.CornerRadius.WithValue(value))