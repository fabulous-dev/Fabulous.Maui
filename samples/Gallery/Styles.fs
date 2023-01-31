namespace Gallery

open Microsoft.Maui
open Fabulous
open Fabulous.Maui

open type Fabulous.Maui.View

module Fonts =
    let OpenSansRegular = "OpenSansRegular"
    let OpenSansSemibold = "OpenSansSemibold"
    let OpenSansBold = "OpenSansBold"

module Styles =
    let inline title (widget: WidgetBuilder<'msg, #IFabLabel>) =
        widget.centerHorizontal().font(Font.OfSize(Fonts.OpenSansBold, 30.))

    let inline subtitle (widget: WidgetBuilder<'msg, #IFabLabel>) =
        widget.centerHorizontal().font(Font.OfSize(Fonts.OpenSansSemibold, 24.))
