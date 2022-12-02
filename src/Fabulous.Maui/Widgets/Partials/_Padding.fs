namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Handlers.Defaults
open Fabulous
open Fabulous.Maui.Controls

module Padding =
    let Padding = Attributes.defineMauiProperty' "Padding" "Padding" PaddingDefaults.CreateDefaultPadding FabPaddingSetters.SetPadding

[<Extension>]
type PaddingModifiers =
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IPadding>, value: Thickness) =
        this.AddScalar(Padding.Padding.WithValue(value))

[<Extension>]
type PaddingExtraModifiers =
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IPadding>, uniformSize: float) =
        this.padding(Thickness(uniformSize))
        
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IPadding>, horizontalSize: float, verticalSize: float) =
        this.padding(Thickness(horizontalSize, verticalSize))