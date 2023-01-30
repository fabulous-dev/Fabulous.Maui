using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui
{
    public interface IFabWindow : IWindow, IFabTitledElement
    {
        void SetOnCreated(Action? value);
        void SetOnResumed(Action? value);
        void SetOnActivated(Action? value);
        void SetOnDeactivated(Action? value);
        void SetOnStopped(Action? value);
        void SetOnDestroying(Action? value);
        void SetOnBackgrounding(Action<IPersistedState>? value);
        void SetOnBackButtonClicked(Func<bool>? value);
        void SetOnDisplayDensityChanged(Action<float>? value);
        void SetOnFrameChanged(Action<Microsoft.Maui.Graphics.Rect>? value);
        void SetContent(IView value);
        void SetVisualDiagnosticsOverlay(IVisualDiagnosticsOverlay value);
        void SetX(double value);
        void SetY(double value);
        void SetWidth(double value);
        void SetMinimumWidth(double value);
        void SetMaximumWidth(double value);
        void SetHeight(double value);
        void SetMinimumHeight(double value);
        void SetMaximumHeight(double value);
        void SetFlowDirection(FlowDirection value);
    }
}

namespace Fabulous.Maui.Controls
{
    public class FabWindow : FabTitledElement, IFabWindow
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

        private Action? OnCreated { get; set; } = WindowDefaults.OnCreated;
        public void Created() => OnCreated?.Invoke();

        private Action? OnResumed { get; set; } = WindowDefaults.OnResumed;
        public void Resumed() => OnResumed?.Invoke();

        private Action? OnActivated { get; set; } = WindowDefaults.OnActivated;
        public void Activated() => OnActivated?.Invoke();

        private Action? OnDeactivated { get; set; } = WindowDefaults.OnDeactivated;
        public void Deactivated() => OnDeactivated?.Invoke();

        private Action? OnStopped { get; set; } = WindowDefaults.OnStopped;
        public void Stopped() => OnStopped?.Invoke();

        private Action? OnDestroying { get; set; } = WindowDefaults.OnDestroying;
        public void Destroying() => OnDestroying?.Invoke();

        private Action<IPersistedState>? OnBackgrounding { get; set; } = WindowDefaults.OnBackgrounding;
        public void Backgrounding(IPersistedState state) => OnBackgrounding?.Invoke(state);

        private Func<bool>? OnBackButtonClicked { get; set; } = WindowDefaults.OnBackButtonClicked;
        public bool BackButtonClicked() => OnBackButtonClicked?.Invoke() ?? true;

        private Action<float>? OnDisplayDensityChanged { get; set; } = WindowDefaults.OnDisplayDensityChanged;
        public void DisplayDensityChanged(float displayDensity) => OnDisplayDensityChanged?.Invoke(displayDensity);

        private Action<Microsoft.Maui.Graphics.Rect>? OnFrameChanged { get; set; } = WindowDefaults.OnFrameChanged;
        public void FrameChanged(Microsoft.Maui.Graphics.Rect frame) => OnFrameChanged?.Invoke(frame);

        public float RequestDisplayDensity()
        {
            var request = new DisplayDensityRequest();
            Handler?.Invoke(nameof(RequestDisplayDensity), request);
            return request.Result;
        }

        public IView Content { get; private set; } = WindowDefaults.Content;

        public IVisualDiagnosticsOverlay VisualDiagnosticsOverlay { get; private set; } =
            WindowDefaults.VisualDiagnosticsOverlay;

        public IReadOnlyCollection<IWindowOverlay> Overlays => _overlays;
        public double X { get; private set; } = WindowDefaults.X;
        public double Y { get; private set; } = WindowDefaults.Y;
        public double Width { get; private set; } = WindowDefaults.Width;
        public double MinimumWidth { get; private set; } = WindowDefaults.MinimumWidth;
        public double MaximumWidth { get; private set; } = WindowDefaults.MaximumWidth;
        public double Height { get; private set; } = WindowDefaults.Height;
        public double MinimumHeight { get; private set; } = WindowDefaults.MinimumHeight;
        public double MaximumHeight { get; private set; } = WindowDefaults.MaximumHeight;
        public FlowDirection FlowDirection { get; private set; } = WindowDefaults.CreateFlowDirection();
        public void SetOnCreated(Action? value) => OnCreated = value;
        public void SetOnResumed(Action? value) => OnResumed = value;
        public void SetOnActivated(Action? value) => OnActivated = value;
        public void SetOnDeactivated(Action? value) => OnDeactivated = value;
        public void SetOnStopped(Action? value) => OnStopped = value;
        public void SetOnDestroying(Action? value) => OnDestroying = value;
        public void SetOnBackgrounding(Action<IPersistedState>? value) => OnBackgrounding = value;
        public void SetOnBackButtonClicked(Func<bool>? value) => OnBackButtonClicked = value;
        public void SetOnDisplayDensityChanged(Action<float>? value) => OnDisplayDensityChanged = value;
        public void SetOnFrameChanged(Action<Rect>? value) => OnFrameChanged = value;
        public void SetContent(IView value) => Content = value;
        public void SetVisualDiagnosticsOverlay(IVisualDiagnosticsOverlay value) => VisualDiagnosticsOverlay = value;
        public void SetX(double value) => X = value;
        public void SetY(double value) => Y = value;
        public void SetWidth(double value) => Width = value;
        public void SetMinimumWidth(double value) => MinimumWidth = value;
        public void SetMaximumWidth(double value) => MaximumWidth = value;
        public void SetHeight(double value) => Height = value;
        public void SetMinimumHeight(double value) => MinimumHeight = value;
        public void SetMaximumHeight(double value) => MaximumHeight = value;
        public void SetFlowDirection(FlowDirection value) => FlowDirection = value;
    }
}