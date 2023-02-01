namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Maui.Controls
open Microsoft.FSharp.Core
open Microsoft.Maui
open Microsoft.Maui.Handlers.Defaults

module Label =
    let WidgetKey = Widgets.register<FabLabel>()

    let LineHeight = Attributes.defineMauiProperty "LineHeight" LabelDefaults.LineHeight (fun (target: IFabLabel) -> target.SetLineHeight)

    let TextDecorations = Attributes.defineMauiProperty "TextDecorations" LabelDefaults.TextDecorations (fun (target: IFabLabel) -> target.SetTextDecorations)

[<AutoOpen>]
module LabelBuilders =
    type Fabulous.Maui.View with
        static member inline Label<'msg>(text: string) =
            WidgetBuilder<'msg, IFabLabel>(Label.WidgetKey, Text.Text.WithValue(text))
            
[<Extension>]
type LabelModifiers =
    [<Extension>]
    static member inline textDecorations(this: WidgetBuilder<'msg, #IFabLabel>, value: TextDecorations) =
        this.AddScalar(Label.TextDecorations.WithValue(value))