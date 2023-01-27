namespace Fabulous.Maui.Compatibility

open Fabulous
open Fabulous.Maui
open Microsoft.Maui

[<AutoOpen>]
module AnyBuilders =
    type Fabulous.Maui.View with

        /// Downcast to IPage to allow to return different types of pages in a single expression (e.g. if/else, match with pattern, etc.)
        static member AnyPage(widget: WidgetBuilder<'msg, #IFabCompatPage>) =
            WidgetBuilder<'msg, IFabCompatPage>(widget.Key, widget.Attributes)

        /// Downcast to ICell to allow to return different types of cells in a single expression (e.g. if/else, match with pattern, etc.)
        static member AnyCell<'msg, 'marker when 'marker :> IFabCompatCell>(widget: WidgetBuilder<'msg, 'marker>) =
            WidgetBuilder<'msg, IFabCompatCell>(widget.Key, widget.Attributes)
            