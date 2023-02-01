namespace Fabulous.Maui.Compatibility

open System
open System.IO
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Controls

type IFabCompatSlider =
    inherit IFabCompatView
    inherit ISlider

module CompatSliderUpdaters =
    let updateSliderMinMax _ (newValueOpt: struct (float * float) voption) (node: IViewNode) =
        let slider = node.Target :?> Slider

        match newValueOpt with
        | ValueNone ->
            slider.ClearValue(Slider.MinimumProperty)
            slider.ClearValue(Slider.MaximumProperty)
        | ValueSome(min, max) ->
            let currMax = slider.GetValue(Slider.MaximumProperty) :?> float

            if min > currMax then
                slider.SetValue(Slider.MaximumProperty, max)
                slider.SetValue(Slider.MinimumProperty, min)
            else
                slider.SetValue(Slider.MinimumProperty, min)
                slider.SetValue(Slider.MaximumProperty, max)

module CompatSlider =
    let WidgetKey = CompatWidgets.register<Slider>()

    let MinimumMaximum =
        Attributes.defineSimpleScalarWithEquality<struct (float * float)> "Slider_MinimumMaximum" CompatSliderUpdaters.updateSliderMinMax

    let MaximumTrackColor =
        Attributes.defineBindableAppThemeColor Slider.MaximumTrackColorProperty

    let MinimumTrackColor =
        Attributes.defineBindableAppThemeColor Slider.MinimumTrackColorProperty

    let ThumbColor = Attributes.defineBindableAppThemeColor Slider.ThumbColorProperty

    let ThumbImageSource =
        Attributes.defineBindableAppTheme<ImageSource> Slider.ThumbImageSourceProperty

    let ValueWithEvent =
        Attributes.defineBindableWithEvent "Slider_ValueWithEvent" Slider.ValueProperty (fun target -> (target :?> Slider).ValueChanged)

    let DragCompleted =
        Attributes.defineEventNoArg "Slider_DragCompleted" (fun target -> (target :?> Slider).DragCompleted)

    let DragStarted =
        Attributes.defineEventNoArg "Slider_DragStarted" (fun target -> (target :?> Slider).DragStarted)

[<AutoOpen>]
module CompatSliderBuilders =
    type Fabulous.Maui.View with

        static member inline CompatSlider<'msg>(min: float, max: float, value: float, onValueChanged: float -> 'msg) =
            WidgetBuilder<'msg, IFabCompatSlider>(
                CompatSlider.WidgetKey,
                CompatSlider.MinimumMaximum.WithValue(struct (min, max)),
                CompatSlider.ValueWithEvent.WithValue(ValueEventData.create value (fun args -> onValueChanged args.NewValue |> box))
            )

[<Extension>]
type CompatSliderModifiers =

    /// <summary>Set the color of the maximumTrackColor.</summary>
    /// <param name="light">The color of the text in the light theme.</param>
    /// <param name="dark">The color of the text in the dark theme.</param>
    [<Extension>]
    static member inline maximumTrackColor(this: WidgetBuilder<'msg, #IFabCompatSlider>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(CompatSlider.MaximumTrackColor.WithValue(AppTheme.create light dark))

    /// <summary>Set the color of the minimumTrackColor.</summary>
    /// <param name="light">The color of the minimumTrackColor in the light theme.</param>
    /// <param name="dark">The color of the minimumTrackColor in the dark theme.</param>
    [<Extension>]
    static member inline minimumTrackColor(this: WidgetBuilder<'msg, #IFabCompatSlider>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(CompatSlider.MinimumTrackColor.WithValue(AppTheme.create light dark))

    /// <summary>Set the color of the thumbColor.</summary>
    /// <param name="light">The color of the thumbColor in the light theme.</param>
    /// <param name="dark">The color of the thumbColor in the dark theme.</param>
    [<Extension>]
    static member inline thumbColor(this: WidgetBuilder<'msg, #IFabCompatSlider>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(CompatSlider.ThumbColor.WithValue(AppTheme.create light dark))

    /// <summary>Set the source of the thumbImage.</summary>
    /// <param name="light">The source of the thumbImage in the light theme.</param>
    /// <param name="dark">The source of the thumbImage in the dark theme.</param>
    [<Extension>]
    static member inline thumbImage(this: WidgetBuilder<'msg, #IFabCompatSlider>, light: ImageSource, ?dark: ImageSource) =
        this.AddScalar(CompatSlider.ThumbImageSource.WithValue(AppTheme.create light dark))

    /// <summary>Set the source of the thumbImage.</summary>
    /// <param name="light">The source of the thumbImage in the light theme.</param>
    /// <param name="dark">The source of the thumbImage in the dark theme.</param>
    [<Extension>]
    static member inline thumbImage(this: WidgetBuilder<'msg, #IFabCompatSlider>, light: string, ?dark: string) =
        let light = ImageSource.FromFile(light)

        let dark =
            match dark with
            | None -> None
            | Some v -> Some(ImageSource.FromFile(v))

        CompatSliderModifiers.thumbImage(this, light, ?dark = dark)

    /// <summary>Set the source of the thumbImage.</summary>
    /// <param name="light">The source of the thumbImage in the light theme.</param>
    /// <param name="dark">The source of the thumbImage in the dark theme.</param>
    [<Extension>]
    static member inline thumbImage(this: WidgetBuilder<'msg, #IFabCompatSlider>, light: Uri, ?dark: Uri) =
        let light = ImageSource.FromUri(light)

        let dark =
            match dark with
            | None -> None
            | Some v -> Some(ImageSource.FromUri(v))

        CompatSliderModifiers.thumbImage(this, light, ?dark = dark)

    /// <summary>Set the source of the thumbImage.</summary>
    /// <param name="light">The source of the thumbImage in the light theme.</param>
    /// <param name="dark">The source of the thumbImage in the dark theme.</param>
    [<Extension>]
    static member inline thumbImage(this: WidgetBuilder<'msg, #IFabCompatSlider>, light: Stream, ?dark: Stream) =
        let light = ImageSource.FromStream(fun () -> light)

        let dark =
            match dark with
            | None -> None
            | Some v -> Some(ImageSource.FromStream(fun () -> v))

        CompatSliderModifiers.thumbImage(this, light, ?dark = dark)

    [<Extension>]
    static member inline onDragCompleted(this: WidgetBuilder<'msg, #IFabCompatSlider>, onDragCompleted: 'msg) =
        this.AddScalar(CompatSlider.DragCompleted.WithValue(onDragCompleted))

    [<Extension>]
    static member inline onDragStarted(this: WidgetBuilder<'msg, #IFabCompatSlider>, onDragStarted: 'msg) =
        this.AddScalar(CompatSlider.DragStarted.WithValue(onDragStarted))

    /// <summary>Link a ViewRef to access the direct Slider control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCompatSlider>, value: ViewRef<Slider>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
