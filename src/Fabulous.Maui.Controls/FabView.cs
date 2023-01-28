using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;
using Microsoft.Maui.Primitives;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui.Controls;

public interface IFabView : IView, IFabElement, IFabTransform
{
    void SetAutomationId(string value);
    void SetFlowDirection(FlowDirection value);
    void SetHorizontalLayoutAlignment(LayoutAlignment value);
    void SetVerticalLayoutAlignment(LayoutAlignment value);
    void SetSemantics(Semantics? value);
    void SetClip(IShape? value);
    void SetShadow(IShadow? value);
    void SetIsEnabled(bool value);
    void SetIsFocused(bool value);
    void SetVisibility(Visibility value);
    void SetOpacity(double value);
    void SetBackground(Paint? value);
    void SetWidth(double value);
    void SetMinimumWidth(double value);
    void SetMaximumWidth(double value);
    void SetHeight(double value);
    void SetMinimumHeight(double value);
    void SetMaximumHeight(double value);
    void SetMargin(Thickness value);
    void SetZIndex(int value);
    void SetInputTransparent(bool value);
}

public class FabView: FabElement, IFabView
{
    public Rect Frame { get; set; }
    public Size DesiredSize { get; private set; }
    
    public double TranslationX { get; private set; } = TransformDefaults.TranslationX;
    public double TranslationY { get; private set; } = TransformDefaults.TranslationY;
    public double Scale { get; private set; } = TransformDefaults.Scale;
    public double ScaleX { get; private set; } = TransformDefaults.ScaleX;
    public double ScaleY { get; private set; } = TransformDefaults.ScaleY;
    public double Rotation { get; private set; } = TransformDefaults.Rotation;
    public double RotationX { get; private set; } = TransformDefaults.RotationX;
    public double RotationY { get; private set; } = TransformDefaults.RotationY;
    public double AnchorX { get; private set; } = TransformDefaults.AnchorX;
    public double AnchorY { get; private set; } = TransformDefaults.AnchorY;
    
    public Size Arrange(Rect bounds)
    {
        Frame = this.ComputeFrame(bounds);
        Handler?.PlatformArrange(Frame);
        return Frame.Size;
    }

    public virtual Size Measure(double widthConstraint, double heightConstraint)
    {
        DesiredSize = this.ComputeDesiredSize(widthConstraint, heightConstraint);
        return DesiredSize;
    }
    
    public virtual void InvalidateMeasure()
    {
        Handler?.Invoke(nameof(InvalidateMeasure));
    }

    public void InvalidateArrange()
    {
        Handler?.Invoke(nameof(InvalidateArrange));
    }

    public bool Focus()
    {
        throw new NotImplementedException();
    }

    public void Unfocus()
    {
        throw new NotImplementedException();
    }

    public string AutomationId { get; private set; } = ViewDefaults.AutomationId;
    public FlowDirection FlowDirection { get; private set; } = ViewDefaults.FlowDirection;
    public LayoutAlignment HorizontalLayoutAlignment { get; private set; } = ViewDefaults.HorizontalLayoutAlignment;
    public LayoutAlignment VerticalLayoutAlignment { get; private set; } = ViewDefaults.VerticalLayoutAlignment;
    public Semantics? Semantics { get; private set; } = ViewDefaults.CreateDefaultSemantics();
    public IShape? Clip { get; private set; } = ViewDefaults.Clip;
    public IShadow? Shadow { get; private set; } = ViewDefaults.Shadow;
    public bool IsEnabled { get; private set; } = ViewDefaults.IsEnabled;
    public bool IsFocused { get; set; } = ViewDefaults.IsFocused;
    public Visibility Visibility { get; private set; } = ViewDefaults.Visibility;
    public double Opacity { get; private set; } = ViewDefaults.Opacity;
    public Paint? Background { get; private set; } = ViewDefaults.Background;
    public double Width { get; private set; } = ViewDefaults.Width;
    public double MinimumWidth { get; private set; } = ViewDefaults.MinimumWidth;
    public double MaximumWidth { get; private set; } = ViewDefaults.MaximumWidth;
    public double Height { get; private set; } = ViewDefaults.Height;
    public double MinimumHeight { get; private set; } = ViewDefaults.MinimumHeight;
    public double MaximumHeight { get; private set; } = ViewDefaults.MaximumHeight;
    public Thickness Margin { get; private set; } = ViewDefaults.CreateDefaultMargin();
    public int ZIndex { get; private set; } = ViewDefaults.ZIndex;

    public new IViewHandler? Handler
    {
        get => base.Handler as IViewHandler;
        set => base.Handler = value;
    }
    
    public bool InputTransparent { get; private set; } = ViewDefaults.InputTransparent;
    
    public void SetTranslationX(double value) => TranslationX = value;
    public void SetTranslationY(double value) => TranslationY = value;
    public void SetScale(double value) => Scale = value;
    public void SetScaleX(double value) => ScaleX = value;
    public void SetScaleY(double value) => ScaleY = value;
    public void SetRotation(double value) => Rotation = value;
    public void SetRotationX(double value) => RotationX = value;
    public void SetRotationY(double value) => RotationY = value;
    public void SetAnchorX(double value) => AnchorX = value;
    public void SetAnchorY(double value) => AnchorY = value;
    public void SetAutomationId(string value) => AutomationId = value;
    public void SetFlowDirection(FlowDirection value) => FlowDirection = value;
    public void SetHorizontalLayoutAlignment(LayoutAlignment value) => HorizontalLayoutAlignment = value;
    public void SetVerticalLayoutAlignment(LayoutAlignment value) => VerticalLayoutAlignment = value;
    public void SetSemantics(Semantics? value) => Semantics = value;
    public void SetClip(IShape? value) => Clip = value;
    public void SetShadow(IShadow? value) => Shadow = value;
    public void SetIsEnabled(bool value) => IsEnabled = value;
    public void SetIsFocused(bool value) => IsFocused = value;
    public void SetVisibility(Visibility value) => Visibility = value;
    public void SetOpacity(double value) => Opacity = value;
    public void SetBackground(Paint? value) => Background = value;
    public void SetWidth(double value) => Width = value;
    public void SetMinimumWidth(double value) => MinimumWidth = value;
    public void SetMaximumWidth(double value) => MaximumWidth = value;
    public void SetHeight(double value) => Height = value;
    public void SetMinimumHeight(double value) => MinimumHeight = value;
    public void SetMaximumHeight(double value) => MaximumHeight = value;
    public void SetMargin(Thickness value) => Margin = value;
    public void SetZIndex(int value) => ZIndex = value;
    public void SetInputTransparent(bool value) => InputTransparent = value;
}