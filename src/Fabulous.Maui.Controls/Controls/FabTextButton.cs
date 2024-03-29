using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers.Defaults;
using Font = Microsoft.Maui.Font;

namespace Fabulous.Maui
{
    public interface IFabTextButton : ITextButton, IFabButton, IFabText
    {
    }
}

namespace Fabulous.Maui.Controls
{
    public class FabTextButton : FabButton, IFabTextButton
    {
        public Color TextColor { get; private set; } = TextStyleDefaults.TextColor;
        public Font Font { get; private set; } = TextStyleDefaults.CreateDefaultFont();
        public double CharacterSpacing { get; private set; } = TextStyleDefaults.CharacterSpacing;
        public string Text { get; private set; } = TextDefaults.Text;

        public void SetTextColor(Color? value) => TextColor = value;
        public void SetFont(Font value) => Font = value;
        public void SetCharacterSpacing(double value) => CharacterSpacing = value;

        public void SetText(string value)
        {
            if (Text == value) return;
            Text = value;
            InvalidateMeasure();
        }
    }
}