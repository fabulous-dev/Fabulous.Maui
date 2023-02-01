namespace Fabulous.Maui.Compatibility

open System
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Controls
open System.IO

type IFabCompatImage =
    inherit IFabCompatView
    inherit IImage

module CompatImage =
    let WidgetKey = CompatWidgets.register<Image>()

    let Aspect = Attributes.defineBindableEnum<Aspect> Image.AspectProperty

    let IsAnimationPlaying =
        Attributes.defineBindableBool Image.IsAnimationPlayingProperty

    let IsOpaque = Attributes.defineBindableBool Image.IsOpaqueProperty

    let IsLoading = Attributes.defineBindableBool Image.IsLoadingProperty

    let Source = Attributes.defineBindableAppTheme<ImageSource> Image.SourceProperty

[<AutoOpen>]
module CompatImageBuilders =
    type Fabulous.Maui.View with

        static member inline CompatImage<'msg>(aspect: Aspect, light: ImageSource, ?dark: ImageSource) =
            WidgetBuilder<'msg, IFabCompatImage>(CompatImage.WidgetKey, CompatImage.Aspect.WithValue(aspect), CompatImage.Source.WithValue(AppTheme.create light dark))

        static member inline CompatImage<'msg>(aspect: Aspect, light: string, ?dark: string) =
            let light = ImageSource.FromFile(light)

            let dark =
                match dark with
                | None -> None
                | Some v -> Some(ImageSource.FromFile(v))

            View.CompatImage<'msg>(aspect, light, ?dark = dark)

        static member inline CompatImage<'msg>(aspect: Aspect, light: Uri, ?dark: Uri) =
            let light = ImageSource.FromUri(light)

            let dark =
                match dark with
                | None -> None
                | Some v -> Some(ImageSource.FromUri(v))

            View.CompatImage<'msg>(aspect, light, ?dark = dark)

        static member inline CompatImage<'msg>(aspect: Aspect, light: Stream, ?dark: Stream) =
            let light = ImageSource.FromStream(fun () -> light)

            let dark =
                match dark with
                | None -> None
                | Some v -> Some(ImageSource.FromStream(fun () -> v))

            View.CompatImage<'msg>(aspect, light, ?dark = dark)

[<Extension>]
type CompatImageModifiers =
    /// <summary>Determines whether an animated GIF is playing or stopped.</summary>
    /// <param name="value">The default value of this property is false.</param>
    [<Extension>]
    static member inline isAnimationPlaying(this: WidgetBuilder<'msg, #IFabCompatImage>, value: bool) =
        this.AddScalar(CompatImage.IsAnimationPlaying.WithValue(value))

    /// <summary>Indicates whether the rendering engine may treat the image as opaque while rendering it.</summary>
    /// <param name="value">The default value of this property is false.</param>
    [<Extension>]
    static member inline isOpaque(this: WidgetBuilder<'msg, #IFabCompatImage>, value: bool) =
        this.AddScalar(CompatImage.IsOpaque.WithValue(value))

    /// <summary>Indicates the loading status of the image.</summary>
    /// <param name="value">The default value of this property is false</param>
    [<Extension>]
    static member inline isLoading(this: WidgetBuilder<'msg, #IFabCompatImage>, value: bool) =
        this.AddScalar(CompatImage.IsLoading.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Image control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCompatImage>, value: ViewRef<Image>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
