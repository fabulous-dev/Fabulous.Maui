namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Fabulous
open Fabulous.Maui.Controls

module Padding =
    let Padding = Attributes.defineMauiSimpleScalarWithEquality "Padding_Padding" "Padding" (fun _ currOpt target ->
        let target = unbox<IPaddingSetter> target
        match currOpt with
        | ValueNone -> target.SetPadding(PaddingDefaults.CreateDefaultPadding())
        | ValueSome curr -> target.SetPadding(curr)
    )

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