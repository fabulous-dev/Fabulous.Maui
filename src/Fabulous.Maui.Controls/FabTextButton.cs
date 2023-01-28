using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers.Defaults;
using Font = Microsoft.Maui.Font;

namespace Fabulous.Maui.Controls;

public interface IFabTextButton: IFabButton, IFabText
{
}

public class FabTextButton: FabButton, ITextButton
{
    public Color TextColor { get; private set; } = TextStyleDefaults.TextColor;
    public Font Font { get; private set; } = TextStyleDefaults.CreateDefaultFont();
    public double CharacterSpacing { get; private set; } = TextStyleDefaults.CharacterSpacing;
    public string Text { get; private set; } = TextDefaults.Text;
    
    public void SetTextColor(Color? value) => TextColor = value;
    public void SetFont(Font value) => Font = value;
    public void SetCharacterSpacing(double value) => CharacterSpacing = value;
    public void SetText(string value) => Text = value;
}