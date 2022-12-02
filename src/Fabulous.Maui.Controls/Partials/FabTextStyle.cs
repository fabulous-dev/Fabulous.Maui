using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public interface IFabTextStyle: ITextStyle
{
    new Microsoft.Maui.Graphics.Color TextColor { get; set; }
    new Font Font { get; set; }
    new double CharacterSpacing { get; set; }
}

public static class FabTextStyleSetters
{
    public static void SetTextColor(FabElement target, Microsoft.Maui.Graphics.Color value) => ((IFabTextStyle)target).TextColor = value;
    public static void SetFont(FabElement target, Font value) => ((IFabTextStyle)target).Font = value;
    public static void SetCharacterSpacing(FabElement target, double value) => ((IFabTextStyle)target).CharacterSpacing = value;
}