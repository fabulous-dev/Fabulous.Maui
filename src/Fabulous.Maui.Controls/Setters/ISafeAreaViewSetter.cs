namespace Fabulous.Maui.Controls;

public static class SafeAreaViewDefaults
{
    public const bool IgnoreSafeArea = false;
}

public interface ISafeAreaViewSetter
{
    void SetIgnoreSafeArea(bool value);
}