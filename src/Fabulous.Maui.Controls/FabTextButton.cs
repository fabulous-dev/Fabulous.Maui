using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public class FabTextButton: FabButton, ITextButton, ITextSetter
{
    public Microsoft.Maui.Graphics.Color TextColor { get; set; } = TextStyleDefaults.TextColor;
    public Font Font { get; set; } = TextStyleDefaults.CreateDefaultFont();
    public double CharacterSpacing { get; set; } = TextStyleDefaults.CharacterSpacing;
    public string Text { get; set; } = TextDefaults.Text;

    public void SetTextColor(Microsoft.Maui.Graphics.Color value) => TextColor = value;
    public void SetFont(Font value) => Font = value;
    public void SetCharacterSpacing(double value) => CharacterSpacing = value;
    public void SetText(string value) => Text = value;
}