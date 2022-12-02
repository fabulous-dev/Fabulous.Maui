namespace Microsoft.Maui.Handlers.Defaults;

public static class WindowDefaults
{
    public const Action? OnCreated = null;
    public const Action? OnResumed = null;
    public const Action? OnActivated = null;
    public const Action? OnDeactivated = null;
    public const Action? OnStopped = null;
    public const Action? OnDestroying = null;
    public const Action<IPersistedState>? OnBackgrounding = null;
    public const Func<bool>? OnBackButtonClicked = null;
    public const Action<float>? OnDisplayDensityChanged = null;
    public const Action<Microsoft.Maui.Graphics.Rect>? OnFrameChanged = null;
    public const IView? Content = null;
    public const IVisualDiagnosticsOverlay? VisualDiagnosticsOverlay = null;
    public const double X = -1.0;
    public const double Y = -1.0;
    public const double Width = -1.0;
    public const double MinimumWidth = -1.0;
    public const double MaximumWidth = -1.0;
    public const double Height = -1.0;
    public const double MinimumHeight = -1.0;
    public const double MaximumHeight = -1.0;
    public static FlowDirection CreateFlowDirection() => FlowDirection.MatchParent;
}