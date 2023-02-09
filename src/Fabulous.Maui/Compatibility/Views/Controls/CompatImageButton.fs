namespace Fabulous.Maui.Compatibility

open System.IO
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Controls
open System

type IFabCompatImageButton =
    inherit IFabCompatView
    inherit IImageButton

module CompatImageButton =
    let WidgetKey = CompatWidgets.register<ImageButton>()

    let Aspect =
        Attributes.defineBindableEnum<Microsoft.Maui.Aspect> ImageButton.AspectProperty

    let BorderColor =
        Attributes.defineBindableAppThemeColor ImageButton.BorderColorProperty

    let BorderWidth = Attributes.defineBindableFloat ImageButton.BorderWidthProperty

    let CornerRadius = Attributes.defineBindableFloat ImageButton.CornerRadiusProperty

    let IsLoading = Attributes.defineBindableBool ImageButton.IsLoadingProperty

    let IsOpaque = Attributes.defineBindableBool ImageButton.IsOpaqueProperty

    let IsPressed = Attributes.defineBindableBool ImageButton.IsPressedProperty

    let Padding =
        Attributes.defineBindableWithEquality<Thickness> ImageButton.PaddingProperty

    let Source =
        Attributes.defineBindableAppTheme<ImageSource> ImageButton.SourceProperty

    let Clicked =
        Attributes.defineEventNoArg "ImageButton_Clicked" (fun target -> (target :?> ImageButton).Clicked)

    let Pressed =
        Attributes.defineEventNoArg "ImageButton_Pressed" (fun target -> (target :?> ImageButton).Pressed)

    let Released =
        Attributes.defineEventNoArg "ImageButton_Released" (fun target -> (target :?> ImageButton).Released)

[<AutoOpen>]
module CompatImageButtonBuilders =
    type Fabulous.Maui.View with

        static member inline CompatImageButton<'msg>(aspect: Aspect, light: ImageSource, onClicked: 'msg, ?dark: ImageSource) =
            WidgetBuilder<'msg, IFabCompatImageButton>(
                CompatImageButton.WidgetKey,
                CompatImageButton.Aspect.WithValue(aspect),
                CompatImageButton.Clicked.WithValue(onClicked),
                CompatImageButton.Source.WithValue(AppTheme.create light dark)
            )

        static member inline CompatImageButton<'msg>(aspect: Aspect, light: string, onClicked: 'msg, ?dark: string) =
            let light = ImageSource.FromFile(light)

            let dark =
                match dark with
                | None -> None
                | Some v -> Some(ImageSource.FromFile(v))

            View.CompatImageButton<'msg>(aspect, light = light, onClicked = onClicked, ?dark = dark)

        static member inline CompatImageButton<'msg>(aspect: Aspect, light: Uri, onClicked: 'msg, ?dark: Uri) =
            let light = ImageSource.FromUri(light)

            let dark =
                match dark with
                | None -> None
                | Some v -> Some(ImageSource.FromUri(v))

            View.CompatImageButton<'msg>(aspect, light = light, onClicked = onClicked, ?dark = dark)

        static member inline CompatImageButton<'msg>(aspect: Aspect, light: Stream, onClicked: 'msg, ?dark: Stream) =
            let light = ImageSource.FromStream(fun () -> light)

            let dark =
                match dark with
                | None -> None
                | Some v -> Some(ImageSource.FromStream(fun () -> v))

            View.CompatImageButton<'msg>(aspect, light = light, onClicked = onClicked, ?dark = dark)

[<Extension>]
type CompatImageButtonModifiers =
    /// <summary>Set the color of the image button border color</summary>
    /// <param name="light">The color of the image button border in the light theme.</param>
    /// <param name="dark">The color of the image button border in the dark theme.</param>
    [<Extension>]
    static member inline borderColor(this: WidgetBuilder<'msg, #IFabCompatImageButton>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(CompatImageButton.BorderColor.WithValue(AppTheme.create light dark))

    /// <summary>Set the width of the image button border</summary>
    /// <param name="width">The width of the image button border.</param>
    [<Extension>]
    static member inline borderWidth(this: WidgetBuilder<'msg, #IFabCompatImageButton>, value: float) =
        this.AddScalar(CompatImageButton.BorderWidth.WithValue(value))

    /// <summary>Set the corner radius of the image button</summary>
    /// <param name="radius">The corner radius of the image button.</param>
    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IFabCompatImageButton>, value: float) =
        this.AddScalar(CompatImageButton.CornerRadius.WithValue(value))

    [<Extension>]
    static member inline isLoading(this: WidgetBuilder<'msg, #IFabCompatImageButton>, value: bool) =
        this.AddScalar(CompatImageButton.IsLoading.WithValue(value))

    [<Extension>]
    static member inline isOpaque(this: WidgetBuilder<'msg, #IFabCompatImageButton>, value: bool) =
        this.AddScalar(CompatImageButton.IsOpaque.WithValue(value))

    [<Extension>]
    static member inline isPressed(this: WidgetBuilder<'msg, #IFabCompatImageButton>, value: bool) =
        this.AddScalar(CompatImageButton.IsPressed.WithValue(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabCompatImageButton>, value: Thickness) =
        this.AddScalar(CompatImageButton.Padding.WithValue(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabCompatImageButton>, value: float) =
        CompatImageButtonModifiers.padding(this, Thickness(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabCompatImageButton>, left: float, top: float, right: float, bottom: float) =
        CompatImageButtonModifiers.padding(this, Thickness(left, top, right, bottom))

    /// <summary>Event that is fired when image button is pressed.</summary>
    /// <param name="onPressed">Msg to dispatch when image button is pressed</param>
    [<Extension>]
    static member inline onPressed(this: WidgetBuilder<'msg, #IFabCompatImageButton>, onPressed: 'msg) =
        this.AddScalar(CompatImageButton.Pressed.WithValue(onPressed))

    /// <summary>Event that is fired when image button is released.</summary>
    /// <param name="onReleased">Msg to dispatch when image button is released.</param>
    [<Extension>]
    static member inline onReleased(this: WidgetBuilder<'msg, #IFabCompatImageButton>, onReleased: 'msg) =
        this.AddScalar(CompatImageButton.Released.WithValue(onReleased))

    /// <summary>Link a ViewRef to access the direct ImageButton control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCompatImageButton>, value: ViewRef<ImageButton>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
