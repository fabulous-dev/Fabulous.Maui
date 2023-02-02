namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Maui.Controls
open Fabulous.Maui.Controls.ImageSources
open Microsoft.Maui
open Microsoft.Maui.Handlers.Defaults

module Image =
    let WidgetKey = Widgets.register<FabImage>()

    let IsAnimationPlaying =
        Attributes.defineMauiProperty "IsAnimationPlaying" ImageDefaults.IsAnimationPlaying (fun (target: IFabImage) -> target.SetIsAnimationPlaying)

    let Aspect =
        Attributes.defineMauiProperty "Aspect" ImageDefaults.Aspect (fun (target: IFabImage) -> target.SetAspect)

    let IsOpaque =
        Attributes.defineMauiProperty "IsOpaque" ImageDefaults.IsOpaque (fun (target: IFabImage) -> target.SetIsOpaque)

[<AutoOpen>]
module ImageBuilders =
    type Fabulous.Maui.View with
        static member inline Image(file: string) =
            WidgetBuilder<'msg, IFabImage>(Image.WidgetKey, ImageSourcePart.Source.WithValue(FabFileImageSource(file)))
            
        static member inline Image(file: string, aspect: Aspect) =
            WidgetBuilder<'msg, IFabImage>(
                Image.WidgetKey,
                ImageSourcePart.Source.WithValue(FabFileImageSource(file)),
                Image.Aspect.WithValue(aspect)
            )

[<Extension>]
type ImageModifiers =
    [<Extension>]
    static member isAnimationPlaying(this: WidgetBuilder<'msg, #IFabImage>, value: bool) =
        this.AddScalar(Image.IsAnimationPlaying.WithValue(value))

    [<Extension>]
    static member isOpaque(this: WidgetBuilder<'msg, #IFabImage>, value: bool) =
        this.AddScalar(Image.IsOpaque.WithValue(value))
