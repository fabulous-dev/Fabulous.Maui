using Microsoft.Maui.Layouts;

namespace Fabulous.Maui.Controls
{
    public class FabVerticalStackLayout : FabStackLayout
    {
        protected override ILayoutManager CreateLayoutManager() => new VerticalStackLayoutManager(this);
    }
}