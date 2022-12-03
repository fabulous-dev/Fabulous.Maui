namespace DotnetPodcasts

open Microsoft.Maui
open Microsoft.Maui.Graphics
open Fabulous
open Fabulous.Maui

open type Fabulous.Maui.View

module Colors =
    let white = Colors.White
    let gray900 = Color.FromArgb("#212121")
    let gray = Color.FromArgb("#1B1B1B")
    let primary = Color.FromArgb("#512BD4")
    
module Fonts =
    let OpenSansRegular = "OpenSansRegular"
    
module Styles =
    let inline textButton (widget: WidgetBuilder<'msg, #ITextButton>) =
        widget
            .textColor(ThemeAware.Of(Colors.white, Colors.primary))
            .background(SolidPaint(ThemeAware.Of(Colors.primary, Colors.white)))
            .font(Font.OfSize(Fonts.OpenSansRegular, 14))
            .cornerRadius(8)
            .padding(14., 10.)
            .minimumHeight(44.)
            .minimumWidth(44.)
            
    let inline label (widget: WidgetBuilder<'msg, #ILabel>) =
        widget
            .textColor(ThemeAware.Of(Colors.gray900, Colors.white))
            
    let inline contentView (widget: WidgetBuilder<'msg, #IContentView>) =
        widget
            .background(SolidPaint(ThemeAware.Of(Colors.white, Colors.gray)))