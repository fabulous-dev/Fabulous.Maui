using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public interface IFabPadding: IPadding
{
    new Thickness Padding { get; set; }
}

public static class FabPadding
{
    public static void SetPadding(IFabPadding target, Thickness value) => target.Padding = value;
}