namespace Fabulous.Maui.Compatibility

open Fabulous
open Fabulous.Maui
open Microsoft.Maui.Controls

type IFabCompatSolidColorBrush =
    inherit IFabCompatBrush

module SolidColorBrush =

    let WidgetKey = CompatWidgets.register<SolidColorBrush>()

    let Color = Attributes.defineBindableAppThemeColor SolidColorBrush.ColorProperty

[<AutoOpen>]
module SolidColorBrushBuilders =
    type Fabulous.Maui.View with

        /// <summary>SolidColorBrush, which paints an area with a solid color. For more information, see Solid color brushes.</summary>
        /// <param name="light">The color in light theme.</param>
        /// <param name="dark">The color in dark theme.</param>
        static member inline SolidColorBrush(light: FabColor, ?dark: FabColor) =
            WidgetBuilder<'msg, IFabCompatSolidColorBrush>(SolidColorBrush.WidgetKey, SolidColorBrush.Color.WithValue(AppTheme.create light dark))
