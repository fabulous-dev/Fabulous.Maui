using Microsoft.Maui.Layouts;

namespace Fabulous.Maui.Controls
{
    public class FabHorizontalStackLayout : FabStackLayout
    {
        protected override ILayoutManager CreateLayoutManager() => new HorizontalStackLayoutManager(this);
    }
}