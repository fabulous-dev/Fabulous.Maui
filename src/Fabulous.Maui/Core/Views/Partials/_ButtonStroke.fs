namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Handlers.Defaults
open Fabulous
open Fabulous.Maui.Controls

module ButtonStroke =
    let CornerRadius =
        Attributes.defineMauiProperty "CornerRadius" ButtonStrokeDefaults.CornerRadius (fun (target: IFabButtonStroke) -> target.SetCornerRadius)

[<Extension>]
type ButtonStrokeModifiers =
    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IFabButtonStroke>, value: int) =
        this.AddScalar(ButtonStroke.CornerRadius.WithValue(value))
