using Microsoft.Maui.Layouts;

namespace Fabulous.Maui.Controls;

public partial class FabVerticalStackLayout : FabStackLayout
{
    protected override ILayoutManager CreateLayoutManager() => new VerticalStackLayoutManager(this);
}