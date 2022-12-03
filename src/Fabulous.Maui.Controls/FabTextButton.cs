using Microsoft.Maui;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui.Controls;

public interface IFabTextButton : ITextButton, IFabText, IFabTextStyle
{
}

public partial class FabTextButton: FabButton, IFabTextButton
{
    public Microsoft.Maui.Graphics.Color TextColor { get; set; } = TextStyleDefaults.TextColor;
    public Font Font { get; set; } = TextStyleDefaults.CreateDefaultFont();
    public double CharacterSpacing { get; set; } = TextStyleDefaults.CharacterSpacing;
    public string Text { get; set; } = TextDefaults.Text;
}