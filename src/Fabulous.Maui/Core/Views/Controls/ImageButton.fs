namespace Fabulous.Maui

open Fabulous.Maui.Controls.ImageSources
open Fabulous
open Fabulous.Maui.Controls
open Microsoft.Maui

module ImageButton =
    let WidgetKey = Widgets.register<FabImageButton>()

[<AutoOpen>]
module ImageButtonBuilders =
    type Fabulous.Maui.View with

        static member inline ImageButton<'msg>(source: string, onClicked: 'msg) =
            WidgetBuilder<'msg, IFabImageButton>(
                ImageButton.WidgetKey,
                ImageSourcePart.Source.WithValue(FabFileImageSource(source)),
                Button.Clicked.WithValue(fun () -> box onClicked)
            )
            
        static member inline ImageButton<'msg>(source: string, onClicked: 'msg, aspect: Aspect) =
            WidgetBuilder<'msg, IFabImageButton>(
                ImageButton.WidgetKey,
                ImageSourcePart.Source.WithValue(FabFileImageSource(source)),
                Image.Aspect.WithValue(aspect),
                Button.Clicked.WithValue(fun () -> box onClicked)
            )
