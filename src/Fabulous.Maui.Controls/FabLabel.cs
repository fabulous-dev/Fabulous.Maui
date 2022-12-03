using Microsoft.Maui;
using Microsoft.Maui.Handlers.Defaults;
using Microsoft.Maui.Graphics;

namespace Fabulous.Maui.Controls;

public interface IFabLabel: ILabel, IFabText, IFabTextStyle, IFabPadding
{
    new TextDecorations TextDecorations { get; set; }
    new double LineHeight { get; set; }
}

public partial class FabLabel : FabView, IFabLabel
{
    public Color TextColor { get; set; } = TextStyleDefaults.TextColor;
    public Microsoft.Maui.Font Font { get; set; } = TextStyleDefaults.CreateDefaultFont();
    public double CharacterSpacing { get; set; } = TextStyleDefaults.CharacterSpacing;
    public string Text { get; set; } = TextDefaults.Text;
    public TextAlignment HorizontalTextAlignment { get; set; } = TextAlignmentDefaults.HorizontalTextAlignment;
    public TextAlignment VerticalTextAlignment { get; set; } = TextAlignmentDefaults.VerticalTextAlignment;
    public Thickness Padding { get; set; } = PaddingDefaults.CreateDefaultPadding();
    public TextDecorations TextDecorations { get; set; } = LabelDefaults.TextDecorations;
    public double LineHeight { get; set; } = LabelDefaults.LineHeight;
}

public partial class FabLabel
{
    public static void SetTextDecorations(IFabLabel target, TextDecorations value) => target.TextDecorations = value;
    public static void SetLineHeight(IFabLabel target, double value) => target.LineHeight = value;
}