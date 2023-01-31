using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public static class AttachedData
{
    public static Func<IView, string, object?, object?>? Get;
    public static Action<IView, string, object>? Set;
}

public static class AttachedDataExtensions
{
    public static T GetAttachedData<T>(this IView view, string key, T defaultValue)
    {
        return (T?)AttachedData.Get?.Invoke(view, key, defaultValue) ?? defaultValue;
    }
    
    public static void SetAttachedData<T>(this IView view, string key, T value)
    {
        AttachedData.Set?.Invoke(view, key, value);
    }
}