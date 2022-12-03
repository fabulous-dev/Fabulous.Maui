using Microsoft.Maui;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui.Controls;

public interface IFabTitledElement : ITitledElement
{
    new string? Title { get; set; }
}

public abstract partial class FabTitledElement: FabElement, IFabTitledElement
{
    public string? Title { get; set; } = TitledElementDefaults.Title;
}

public partial class FabTitledElement
{
    public static void SetTitle(IFabTitledElement target, string? value) => target.Title = value;
}