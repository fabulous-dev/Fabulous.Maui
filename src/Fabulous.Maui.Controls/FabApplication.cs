using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public static class ApplicationDefaults
{
    public const Action? OnThemeChanged = null;
}

public class FabApplication: FabElement, IApplication
{
    private readonly List<IWindow> _windows = new();

    public IWindow CreateWindow(IActivationState? activationState) => _windows[0];

    public void OpenWindow(IWindow window) => _windows.Add(window);

    public void CloseWindow(IWindow window) => _windows.Remove(window);

    public Action? OnThemeChanged { get; set; } = ApplicationDefaults.OnThemeChanged;
    public void ThemeChanged() => OnThemeChanged?.Invoke();

    public IReadOnlyList<IWindow> Windows => _windows;
    public IList<IWindow> EditableWindows => _windows;
    
}