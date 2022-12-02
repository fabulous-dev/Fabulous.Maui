using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public interface IFabSafeAreaView: ISafeAreaView
{
    new bool IgnoreSafeArea { get; set; }
}

public static class FabSafeAreaViewSetters
{
    public static void SetIgnoreSafeArea(FabElement target, bool value) => ((IFabSafeAreaView)target).IgnoreSafeArea = value;
}