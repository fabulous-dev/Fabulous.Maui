using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public static class TitledElementDefaults
{
    public const string? Title = null;
}

public class FabTitledElement: FabElement, ITitledElement
{
    public string? Title { get; set; } = TitledElementDefaults.Title;
}