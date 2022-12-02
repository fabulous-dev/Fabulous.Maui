using Microsoft.Maui;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui.Controls;

public interface IFabStackLayout : IStackLayout
{
    new double Spacing { get; set; }
}

public abstract class FabStackLayout: FabLayout, IFabStackLayout
{
    public double Spacing { get; set; } = StackLayoutDefaults.Spacing;
}

public static class FabStackLayoutSetters
{
    public static void SetSpacing(FabElement target, double value) => ((IFabStackLayout)target).Spacing = value;
}