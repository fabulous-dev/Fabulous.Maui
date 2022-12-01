namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Fabulous
open Fabulous.Maui.Controls

module View' =
    let Background = Attributes.defineMauiSimpleScalarWithEquality "View_Background" "Background" (fun _ (currOpt: Paint voption) target ->
        let target = target :?> FabView
        match currOpt with
        | ValueNone -> target.Background <- ViewDefaults.Background
        | ValueSome curr -> target.Background <- curr
    )
    
[<Extension>]
type ViewModifiers =
    [<Extension>]
    static member background(this: WidgetBuilder<'msg, #IView>, value: Paint) =
        this.AddScalar(View'.Background.WithValue(value))