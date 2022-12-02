using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public interface IFabPadding: IPadding
{
    new Thickness Padding { get; set; }
}

public static class FabPaddingSetters
{
    public static void SetPadding(FabElement target, Thickness value) => ((IFabPadding)target).Padding = value;
}