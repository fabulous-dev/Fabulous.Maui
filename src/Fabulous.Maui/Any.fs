namespace Fabulous.Maui

open Fabulous
open Microsoft.Maui

[<AutoOpen>]
module AnyBuilders =
    type Fabulous.Maui.View with

        /// Downcast to IView to allow to return different types of views in a single expression (e.g. if/else, match with pattern, etc.)
        static member AnyView(widget: WidgetBuilder<'msg, #IView>) =
            WidgetBuilder<'msg, IView>(widget.Key, widget.Attributes)
