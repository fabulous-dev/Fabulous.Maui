using Microsoft.Maui;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui
{
    public interface IFabTitledElement : ITitledElement, IFabElement
    {
        void SetTitle(string? value);
    }
}

namespace Fabulous.Maui.Controls
{
    public abstract class FabTitledElement : FabElement, IFabTitledElement
    {
        public string? Title { get; private set; } = TitledElementDefaults.Title;

        public void SetTitle(string? value) => Title = value;
    }
}