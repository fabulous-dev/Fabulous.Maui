using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public interface IFabSafeAreaView: ISafeAreaView
{
    void SetIgnoreSafeArea(bool value);
}