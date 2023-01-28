namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Handlers.Defaults
open Fabulous
open Fabulous.Maui.Controls

module Padding =
    let Padding =
        Attributes.defineMauiProperty' "Padding" PaddingDefaults.CreateDefaultPadding (fun (target: IFabPadding) -> target.SetPadding)

[<Extension>]
type PaddingModifiers =
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabPadding>, value: Thickness) =
        this.AddScalar(Padding.Padding.WithValue(value))

[<Extension>]
type PaddingExtraModifiers =
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabPadding>, uniformSize: float) = this.padding(Thickness(uniformSize))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabPadding>, horizontalSize: float, verticalSize: float) =
        this.padding(Thickness(horizontalSize, verticalSize))
