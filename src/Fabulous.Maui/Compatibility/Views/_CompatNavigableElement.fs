namespace Fabulous.Maui.Compatibility

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls

type IFabCompatNavigableElement =
    inherit IFabCompatElement

module CompatNavigableElement =
    let Style =
        Attributes.defineBindableWithEquality<Style> NavigableElement.StyleProperty

[<Extension>]
type CompatNavigableElementModifiers =

    [<Extension>]
    static member inline style(this: WidgetBuilder<'msg, #IFabCompatNavigableElement>, style: Style) =
        this.AddScalar(CompatNavigableElement.Style.WithValue(style))
