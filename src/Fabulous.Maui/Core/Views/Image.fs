namespace Fabulous.Maui

open Microsoft.Maui
open Fabulous
open Fabulous.Maui.Controls
open Fabulous.Maui.Controls.ImageSources

module Image =
    let WidgetKey = Widgets.register<FabImage>()

[<AutoOpen>]
module ImageBuilders =
    type Fabulous.Maui.View with
        static member inline Image(file: string) =
            WidgetBuilder<'msg, IFabImage>(
                Image.WidgetKey,
                ImageSourcePart.Source.WithValue(FabFileImageSource(file))
            )