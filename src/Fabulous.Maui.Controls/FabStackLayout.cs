using Microsoft.Maui;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui.Controls;

public interface IFabStackLayout : IStackLayout, IFabLayout
{
    new double Spacing { get; set; }
}

public abstract partial class FabStackLayout: FabLayout, IFabStackLayout
{
    public double Spacing { get; set; } = StackLayoutDefaults.Spacing;
}

public partial class FabStackLayout
{
    public static void SetSpacing(IFabStackLayout target, double value) => target.Spacing = value;
}