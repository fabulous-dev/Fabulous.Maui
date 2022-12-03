using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public interface IFabTextStyle: ITextStyle
{
    new Microsoft.Maui.Graphics.Color TextColor { get; set; }
    new Font Font { get; set; }
    new double CharacterSpacing { get; set; }
}

public static class FabTextStyle
{
    public static void SetTextColor(IFabTextStyle target, Microsoft.Maui.Graphics.Color value) => target.TextColor = value;
    public static void SetFont(IFabTextStyle target, Font value) => target.Font = value;
    public static void SetCharacterSpacing(IFabTextStyle target, double value) => target.CharacterSpacing = value;
}