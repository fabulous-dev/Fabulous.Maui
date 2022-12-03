using Microsoft.Maui;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.FabCompat;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui.Controls;

public interface IFabApplication: IApplication
{
    Action<AppTheme>? OnThemeChanged { get; set; }
}

public partial class FabApplication: FabElement, IFabApplication
{
    private readonly List<IWindow> _windows = new();

    public IWindow CreateWindow(IActivationState? activationState) => _windows[0];

    public void OpenWindow(IWindow window) => _windows.Add(window);

    public void CloseWindow(IWindow window) => _windows.Remove(window);

    public Action<AppTheme>? OnThemeChanged { get; set; } = ApplicationDefaults.OnThemeChanged;
    public void ThemeChanged() => OnThemeChanged?.Invoke(AppInfoFixed.RequestedTheme);

    public IReadOnlyList<IWindow> Windows => _windows;
    public IList<IWindow> EditableWindows => _windows;
}

public partial class FabApplication
{
    public static void SetOnThemeChanged(IFabApplication target, Action<AppTheme>? value) => target.OnThemeChanged = value;
}