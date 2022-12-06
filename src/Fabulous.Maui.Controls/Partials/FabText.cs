using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public interface IFabText: IText, IFabTextStyle
{
    new string Text { get; set; }
}

public static class FabText
{
    public static void SetText(IFabText target, string value) => target.Text = value;
}