using Microsoft.Maui;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui.Controls;

public interface IFabWindow : IWindow
{
    Action? OnCreated { get; set; }
    Action? OnResumed { get; set; }
    Action? OnActivated { get; set; }
    Action? OnDeactivated { get; set; }
    Action? OnStopped { get; set; }
    Action? OnDestroying { get; set; }
    Action<IPersistedState>? OnBackgrounding { get; set; }
    Func<bool>? OnBackButtonClicked { get; set; }
    Action<float>? OnDisplayDensityChanged { get; set; }
    Action<Microsoft.Maui.Graphics.Rect>? OnFrameChanged { get; set; }
    new IView Content { get; set; }
    new IVisualDiagnosticsOverlay VisualDiagnosticsOverlay { get; set; }
    new double X { get; set; }
    new double Y { get; set; }
    new double Width { get; set; }
    new double MinimumWidth { get; set; }
    new double MaximumWidth { get; set; }
    new double Height { get; set; }
    new double MinimumHeight { get; set; }
    new double MaximumHeight { get; set; }
    new FlowDirection FlowDirection { get; set; }
}

public partial class FabWindow: FabTitledElement, IFabWindow
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

public partial class FabWindow
{
    public static void SetOnCreated(IFabWindow target, Action? value) => target.OnCreated = value;
    public static void SetOnResumed(IFabWindow target, Action? value) => target.OnResumed = value;
    public static void SetOnActivated(IFabWindow target, Action? value) => target.OnActivated = value;
    public static void SetOnDeactivated(IFabWindow target, Action? value) => target.OnDeactivated = value;
    public static void SetOnStopped(IFabWindow target, Action? value) => target.OnStopped = value;
    public static void SetOnDestroying(IFabWindow target, Action? value) => target.OnDestroying = value;
    public static void SetOnBackgrounding(IFabWindow target, Action<IPersistedState>? value) => target.OnBackgrounding = value;
    public static void SetOnBackButtonClicked(IFabWindow target, Func<bool>? value) => target.OnBackButtonClicked = value;
    public static void SetOnDisplayDensityChanged(IFabWindow target, Action<float>? value) => target.OnDisplayDensityChanged = value;
    public static void SetOnFrameChanged(IFabWindow target, Action<Microsoft.Maui.Graphics.Rect>? value) => target.OnFrameChanged = value;
    public static void SetContent(IFabWindow target, IView? value) => target.Content = value;
    public static void SetVisualDiagnosticsOverlay(IFabWindow target, IVisualDiagnosticsOverlay? value) => target.VisualDiagnosticsOverlay = value;
    public static void SetX(IFabWindow target, double value) => target.X = value;
    public static void SetY(IFabWindow target, double value) => target.Y = value;
    public static void SetWidth(IFabWindow target, double value) => target.Width = value;
    public static void SetMinimumWidth(IFabWindow target, double value) => target.MinimumWidth = value;
    public static void SetMaximumWidth(IFabWindow target, double value) => target.MaximumWidth = value;
    public static void SetHeight(IFabWindow target, double value) => target.Height = value;
    public static void SetMinimumHeight(IFabWindow target, double value) => target.MinimumHeight = value;
    public static void SetMaximumHeight(IFabWindow target, double value) => target.MaximumHeight = value;
    public static void SetFlowDirection(IFabWindow target, FlowDirection value) => target.FlowDirection = value;
}