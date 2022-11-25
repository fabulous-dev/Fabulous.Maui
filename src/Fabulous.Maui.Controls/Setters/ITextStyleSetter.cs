using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public static class TextStyleDefaults
{
    public const Microsoft.Maui.Graphics.Color? TextColor = null;
    public static Font CreateDefaultFont() => Font.Default;
    public const double CharacterSpacing = 0.0;
}

public interface ITextStyleSetter
{
    void SetTextColor(Microsoft.Maui.Graphics.Color value);
    void SetFont(Font value);
    void SetCharacterSpacing(double value);
}