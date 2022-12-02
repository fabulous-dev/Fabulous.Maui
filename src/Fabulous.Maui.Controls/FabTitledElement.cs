using Microsoft.Maui;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui.Controls;

public interface IFabTitledElement : ITitledElement
{
    new string? Title { get; set; }
}

public class FabTitledElement: FabElement, IFabTitledElement
{
    public string? Title { get; set; } = TitledElementDefaults.Title;
}

public static class FabTitledElementSetters
{
    public static void SetTitle(FabElement target, string? value) => ((IFabTitledElement)target).Title = value;
}