using Microsoft.Maui;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui.Controls;

public interface IFabStackLayout : IStackLayout, IFabLayout
{
    void SetSpacing(double value);
}

public abstract class FabStackLayout: FabLayout, IFabStackLayout
{
    public double Spacing { get; private set; } = StackLayoutDefaults.Spacing;
    
    public void SetSpacing(double value) => Spacing = value;
}