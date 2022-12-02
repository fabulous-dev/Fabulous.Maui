using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public interface IFabText: IText
{
    new string Text { get; set; }
}

public static class FabTextSetters
{
    public static void SetText(FabElement target, string value) => ((IFabText)target).Text = value;
}