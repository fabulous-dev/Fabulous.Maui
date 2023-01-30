using Microsoft.Maui;

namespace Fabulous.Maui
{
    public interface IFabSafeAreaView : ISafeAreaView
    {
        void SetIgnoreSafeArea(bool value);
    }
}