using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui
{
    public interface IFabButton : IButton, IFabView, IFabPadding, IFabButtonStroke
    {
        void SetOnPressed(Action? value);
        void SetOnReleased(Action? value);
        void SetOnClicked(Action? value);
    }
}

namespace Fabulous.Maui.Controls
{
    public abstract class FabButton : FabView, IFabButton
    {
        public Thickness Padding { get; private set; } = PaddingDefaults.CreateDefaultPadding();
        public Color StrokeColor { get; private set; } = ButtonStrokeDefaults.StrokeColor;
        public double StrokeThickness { get; private set; } = ButtonStrokeDefaults.StrokeThickness;
        public int CornerRadius { get; private set; } = ButtonStrokeDefaults.CornerRadius;

        private Action? OnPressed { get; set; } = ButtonDefaults.OnPressed;
        private Action? OnReleased { get; set; } = ButtonDefaults.OnReleased;
        private Action? OnClicked { get; set; } = ButtonDefaults.OnClicked;
        
        public void Pressed() => OnPressed?.Invoke();
        public void Released() => OnReleased?.Invoke();
        public void Clicked() => OnClicked?.Invoke();
        
        
        
        public void SetPadding(Thickness value) => Padding = value;
        public void SetStrokeColor(Color value) => StrokeColor = value;
        public void SetStrokeThickness(double value) => StrokeThickness = value;
        public void SetCornerRadius(int value) => CornerRadius = value;
        public void SetOnPressed(Action? value) => OnPressed = value;
        public void SetOnReleased(Action? value) => OnReleased = value;
        public void SetOnClicked(Action? value) => OnClicked = value;
    }
}