namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui

[<Extension>]
type StyleExtensions =
    [<Extension>]
    static member inline style(this: WidgetBuilder<'msg, #IElement>, fn: WidgetBuilder<'msg, #IElement> -> WidgetBuilder<'msg, #IElement>) =
        fn this