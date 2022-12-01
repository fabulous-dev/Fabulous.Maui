using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public static class StackLayoutDefaults
{
    public const double Spacing = 0.0;
}

public abstract class FabStackLayout: FabLayout, IStackLayout
{
    public double Spacing { get; set; } = StackLayoutDefaults.Spacing;
}