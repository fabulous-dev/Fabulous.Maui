using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

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

public class FabWindow: FabTitledElement, IWindow
{
    private readonly List<IWindowOverlay> _overlays = new();

    public bool AddOverlay(IWindowOverlay overlay)
    {
        _overlays.Add(overlay);
        return true;
    }

    public bool RemoveOverlay(IWindowOverlay overlay)
    {
        return _overlays.Remove(overlay);
    }

    public Action? OnCreated { get; set; } = WindowDefaults.OnCreated;
    public void Created() => OnCreated?.Invoke();

    public Action? OnResumed { get; set; } = WindowDefaults.OnResumed;
    public void Resumed() => OnResumed?.Invoke();

    public Action? OnActivated { get; set; } = WindowDefaults.OnActivated;
    public void Activated() => OnActivated?.Invoke();

    public Action? OnDeactivated { get; set; } = WindowDefaults.OnDeactivated;
    public void Deactivated() => OnDeactivated?.Invoke();

    public Action? OnStopped { get; set; } = WindowDefaults.OnStopped;
    public void Stopped() => OnStopped?.Invoke();

    public Action? OnDestroying { get; set; } = WindowDefaults.OnDestroying;
    public void Destroying() => OnDestroying?.Invoke();

    public Action<IPersistedState>? OnBackgrounding { get; set; } = WindowDefaults.OnBackgrounding;
    public void Backgrounding(IPersistedState state) => OnBackgrounding?.Invoke(state);

    public Func<bool>? OnBackButtonClicked { get; set; } = WindowDefaults.OnBackButtonClicked;
    public bool BackButtonClicked() => OnBackButtonClicked?.Invoke() ?? true;

    public Action<float>? OnDisplayDensityChanged { get; set; } = WindowDefaults.OnDisplayDensityChanged;
    public void DisplayDensityChanged(float displayDensity) => OnDisplayDensityChanged?.Invoke(displayDensity);

    public Action<Microsoft.Maui.Graphics.Rect>? OnFrameChanged { get; set; } = WindowDefaults.OnFrameChanged;
    public void FrameChanged(Microsoft.Maui.Graphics.Rect frame) => OnFrameChanged?.Invoke(frame);

    public float RequestDisplayDensity()
    {
        var request = new DisplayDensityRequest();
        Handler?.Invoke(nameof(RequestDisplayDensity), request);
        return request.Result;
    }

    public IView Content { get; set; } = WindowDefaults.Content;
    public IVisualDiagnosticsOverlay VisualDiagnosticsOverlay { get; set; } = WindowDefaults.VisualDiagnosticsOverlay;
    public IReadOnlyCollection<IWindowOverlay> Overlays => _overlays;
    public double X { get; set; } = WindowDefaults.X;
    public double Y { get; set; } = WindowDefaults.Y;
    public double Width { get; set; } = WindowDefaults.Width;
    public double MinimumWidth { get; set; } = WindowDefaults.MinimumWidth;
    public double MaximumWidth { get; set; } = WindowDefaults.MaximumWidth;
    public double Height { get; set; } = WindowDefaults.Height;
    public double MinimumHeight { get; set; } = WindowDefaults.MinimumHeight;
    public double MaximumHeight { get; set; } = WindowDefaults.MaximumHeight;
    public FlowDirection FlowDirection { get; set; } = WindowDefaults.CreateFlowDirection();
}