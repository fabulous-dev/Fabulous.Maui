namespace Fabulous.Maui.Compatibility

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Controls

type IFabCompatLabel =
    inherit IFabCompatView

module CompatLabel =
    let WidgetKey = CompatWidgets.register<Label>()

    let CharacterSpacing = Attributes.defineBindableFloat Label.CharacterSpacingProperty

    let FontAttributes =
        Attributes.defineBindableEnum<Microsoft.Maui.Controls.FontAttributes> Label.FontAttributesProperty

    let FontFamily =
        Attributes.defineBindableWithEquality<string> Label.FontFamilyProperty

    let FontSize = Attributes.defineBindableFloat Label.FontSizeProperty

    let HorizontalTextAlignment =
        Attributes.defineBindableEnum<TextAlignment> Label.HorizontalTextAlignmentProperty

    let LineBreakMode =
        Attributes.defineBindableEnum<Microsoft.Maui.LineBreakMode> Label.LineBreakModeProperty

    let LineHeight = Attributes.defineBindableFloat Label.LineHeightProperty

    let MaxLines = Attributes.defineBindableInt Label.MaxLinesProperty

    let Padding = Attributes.defineBindableWithEquality<Thickness> Label.PaddingProperty

    let TextColor = Attributes.defineBindableAppThemeColor Label.TextColorProperty

    let TextDecorations =
        Attributes.defineBindableEnum<TextDecorations> Label.TextDecorationsProperty

    let Text = Attributes.defineBindableWithEquality<string> Label.TextProperty

    let TextTransform =
        Attributes.defineBindableEnum<TextTransform> Label.TextTransformProperty

    let TextType = Attributes.defineBindableEnum<TextType> Label.TextTypeProperty

    let VerticalTextAlignment =
        Attributes.defineBindableEnum<TextAlignment> Label.VerticalTextAlignmentProperty

    let FontAutoScalingEnabled =
        Attributes.defineBindableBool Label.FontAutoScalingEnabledProperty


[<AutoOpen>]
module CompatLabelBuilders =
    type Fabulous.Maui.View with

        static member inline CompatLabel<'msg>(text: string) =
            WidgetBuilder<'msg, IFabCompatLabel>(CompatLabel.WidgetKey, CompatLabel.Text.WithValue(text))

[<Extension>]
type CompatLabelModifiers =

    [<Extension>]
    static member inline characterSpacing(this: WidgetBuilder<'msg, #IFabCompatLabel>, value: float) =
        this.AddScalar(CompatLabel.CharacterSpacing.WithValue(value))

    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, #IFabCompatLabel>,
            ?size: float,
            ?attributes: FontAttributes,
            ?fontFamily: string,
            ?autoScalingEnabled: bool
        ) =

        let mutable res = this

        match size with
        | None -> ()
        | Some v -> res <- res.AddScalar(CompatLabel.FontSize.WithValue(v))

        match attributes with
        | None -> ()
        | Some v -> res <- res.AddScalar(CompatLabel.FontAttributes.WithValue(v))

        match fontFamily with
        | None -> ()
        | Some v -> res <- res.AddScalar(CompatLabel.FontFamily.WithValue(v))

        match autoScalingEnabled with
        | None -> ()
        | Some v -> res <- res.AddScalar(CompatLabel.FontAutoScalingEnabled.WithValue(v))

        res

    [<Extension>]
    static member inline horizontalTextAlignment(this: WidgetBuilder<'msg, #IFabCompatLabel>, value: TextAlignment) =
        this.AddScalar(CompatLabel.HorizontalTextAlignment.WithValue(value))

    [<Extension>]
    static member inline lineBreakMode(this: WidgetBuilder<'msg, #IFabCompatLabel>, value: LineBreakMode) =
        this.AddScalar(CompatLabel.LineBreakMode.WithValue(value))

    [<Extension>]
    static member inline lineHeight(this: WidgetBuilder<'msg, #IFabCompatLabel>, value: float) =
        this.AddScalar(CompatLabel.LineHeight.WithValue(value))

    [<Extension>]
    static member inline maxLines(this: WidgetBuilder<'msg, #IFabCompatLabel>, value: int) =
        this.AddScalar(CompatLabel.MaxLines.WithValue(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabCompatLabel>, value: Thickness) =
        this.AddScalar(CompatLabel.Padding.WithValue(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabCompatLabel>, value: float) =
        CompatLabelModifiers.padding(this, Thickness(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabCompatLabel>, left: float, top: float, right: float, bottom: float) =
        CompatLabelModifiers.padding(this, Thickness(left, top, right, bottom))

    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #IFabCompatLabel>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(CompatLabel.TextColor.WithValue(AppTheme.create light dark))

    [<Extension>]
    static member inline textDecoration(this: WidgetBuilder<'msg, #IFabCompatLabel>, value: TextDecorations) =
        this.AddScalar(CompatLabel.TextDecorations.WithValue(value))

    [<Extension>]
    static member inline textTransform(this: WidgetBuilder<'msg, #IFabCompatLabel>, value: TextTransform) =
        this.AddScalar(CompatLabel.TextTransform.WithValue(value))

    [<Extension>]
    static member inline textType(this: WidgetBuilder<'msg, #IFabCompatLabel>, value: TextType) =
        this.AddScalar(CompatLabel.TextType.WithValue(value))

    [<Extension>]
    static member inline verticalTextAlignment(this: WidgetBuilder<'msg, #IFabCompatLabel>, value: TextAlignment) =
        this.AddScalar(CompatLabel.VerticalTextAlignment.WithValue(value))

    [<Extension>]
    static member inline centerTextHorizontal(this: WidgetBuilder<'msg, #IFabCompatLabel>) =
        this.AddScalar(CompatLabel.HorizontalTextAlignment.WithValue(TextAlignment.Center))

    [<Extension>]
    static member inline centerTextVertical(this: WidgetBuilder<'msg, #IFabCompatLabel>) =
        this.AddScalar(CompatLabel.VerticalTextAlignment.WithValue(TextAlignment.Center))

    [<Extension>]
    static member inline centerText(this: WidgetBuilder<'msg, #IFabCompatLabel>) =
        this.centerTextHorizontal().centerTextVertical()

    /// <summary>Link a ViewRef to access the direct Label control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCompatLabel>, value: ViewRef<Label>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
