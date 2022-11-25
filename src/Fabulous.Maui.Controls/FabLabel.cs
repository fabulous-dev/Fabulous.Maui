using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public static class LabelDefaults
{
    public const TextDecorations TextDecorations = Microsoft.Maui.TextDecorations.None;
    public const double LineHeight = 1.0;
}

public class FabLabel : FabView, ILabel
{
    public Microsoft.Maui.Graphics.Color TextColor { get; set; } = TextStyleDefaults.TextColor;
    public Font Font { get; set; } = TextStyleDefaults.CreateDefaultFont();
    public double CharacterSpacing { get; set; } = TextStyleDefaults.CharacterSpacing;
    public string Text { get; set; } = TextDefaults.Text;
    public TextAlignment HorizontalTextAlignment { get; set; } = TextAlignmentDefaults.HorizontalTextAlignment;
    public TextAlignment VerticalTextAlignment { get; set; } = TextAlignmentDefaults.VerticalTextAlignment;
    public Thickness Padding { get; set; } = PaddingDefaults.CreateDefaultPadding();
    public TextDecorations TextDecorations { get; set; } = LabelDefaults.TextDecorations;
    public double LineHeight { get; set; } = LabelDefaults.LineHeight;
}