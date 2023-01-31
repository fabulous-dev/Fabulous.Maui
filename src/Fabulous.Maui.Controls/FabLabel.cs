using Microsoft.Maui;
using Microsoft.Maui.Handlers.Defaults;
using Microsoft.Maui.Graphics;
using Font = Microsoft.Maui.Font;

namespace Fabulous.Maui
{
    public interface IFabLabel : ILabel, IFabView, IFabText, IFabTextAlignment, IFabPadding
    {
        void SetTextDecorations(TextDecorations value);
        void SetLineHeight(double value);
    }
}

namespace Fabulous.Maui.Controls
{
    public class FabLabel : FabView, IFabLabel
    {
        public Color TextColor { get; private set; } = TextStyleDefaults.TextColor;
        public Microsoft.Maui.Font Font { get; private set; } = TextStyleDefaults.CreateDefaultFont();
        public double CharacterSpacing { get; private set; } = TextStyleDefaults.CharacterSpacing;
        public string Text { get; private set; } = TextDefaults.Text;

        public TextAlignment HorizontalTextAlignment { get; private set; } =
            TextAlignmentDefaults.HorizontalTextAlignment;

        public TextAlignment VerticalTextAlignment { get; private set; } = TextAlignmentDefaults.VerticalTextAlignment;
        public Thickness Padding { get; private set; } = PaddingDefaults.CreateDefaultPadding();
        public TextDecorations TextDecorations { get; private set; } = LabelDefaults.TextDecorations;
        public double LineHeight { get; private set; } = LabelDefaults.LineHeight;


        public void SetPadding(Thickness value) => Padding = value;
        public void SetTextColor(Color? value) => TextColor = value;
        public void SetFont(Font value) => Font = value;
        public void SetCharacterSpacing(double value) => CharacterSpacing = value;
        public void SetText(string value) => Text = value;
        public void SetHorizontalTextAlignment(TextAlignment value) => HorizontalTextAlignment = value;
        public void SetVerticalTextAlignment(TextAlignment value) => VerticalTextAlignment = value;
        public void SetTextDecorations(TextDecorations value) => TextDecorations = value;
        public void SetLineHeight(double value) => LineHeight = value;
    }
}