using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;
using Microsoft.Maui.Primitives;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui.Controls;

public interface IFabView : IView, IFabElement, IFabTransform
{
    new string AutomationId { get; set; }
    new FlowDirection FlowDirection { get; set; }
    new LayoutAlignment HorizontalLayoutAlignment { get; set; }
    new LayoutAlignment VerticalLayoutAlignment { get; set; }
    new Semantics? Semantics { get; set; }
    new IShape? Clip { get; set; }
    new IShadow? Shadow { get; set; }
    new bool IsEnabled { get; set; }
    new bool IsFocused { get; set; }
    new Visibility Visibility { get; set; }
    new double Opacity { get; set; }
    new Paint? Background { get; set; }
    new double Width { get; set; }
    new double MinimumWidth { get; set; }
    new double MaximumWidth { get; set; }
    new double Height { get; set; }
    new double MinimumHeight { get; set; }
    new double MaximumHeight { get; set; }
    new Thickness Margin { get; set; }
    new int ZIndex { get; set; }
    new bool InputTransparent { get; set; }
}

public partial class FabView: FabElement, IFabView
{
    public Rect Frame { get; set; }
    public Size DesiredSize { get; private set; }
    
    public double TranslationX { get; set; } = TransformDefaults.TranslationX;
    public double TranslationY { get; set; } = TransformDefaults.TranslationY;
    public double Scale { get; set; } = TransformDefaults.Scale;
    public double ScaleX { get; set; } = TransformDefaults.ScaleX;
    public double ScaleY { get; set; } = TransformDefaults.ScaleY;
    public double Rotation { get; set; } = TransformDefaults.Rotation;
    public double RotationX { get; set; } = TransformDefaults.RotationX;
    public double RotationY { get; set; } = TransformDefaults.RotationY;
    public double AnchorX { get; set; } = TransformDefaults.AnchorX;
    public double AnchorY { get; set; } = TransformDefaults.AnchorY;
    
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

    public string AutomationId { get; set; } = ViewDefaults.AutomationId;
    public FlowDirection FlowDirection { get; set; } = ViewDefaults.FlowDirection;
    public LayoutAlignment HorizontalLayoutAlignment { get; set; } = ViewDefaults.HorizontalLayoutAlignment;
    public LayoutAlignment VerticalLayoutAlignment { get; set; } = ViewDefaults.VerticalLayoutAlignment;
    public Semantics? Semantics { get; set; } = ViewDefaults.CreateDefaultSemantics();
    public IShape? Clip { get; set; } = ViewDefaults.Clip;
    public IShadow? Shadow { get; set; } = ViewDefaults.Shadow;
    public bool IsEnabled { get; set; } = ViewDefaults.IsEnabled;
    public bool IsFocused { get; set; } = ViewDefaults.IsFocused;
    public Visibility Visibility { get; set; } = ViewDefaults.Visibility;
    public double Opacity { get; set; } = ViewDefaults.Opacity;
    public Paint? Background { get; set; } = ViewDefaults.Background;
    public double Width { get; set; } = ViewDefaults.Width;
    public double MinimumWidth { get; set; } = ViewDefaults.MinimumWidth;
    public double MaximumWidth { get; set; } = ViewDefaults.MaximumWidth;
    public double Height { get; set; } = ViewDefaults.Height;
    public double MinimumHeight { get; set; } = ViewDefaults.MinimumHeight;
    public double MaximumHeight { get; set; } = ViewDefaults.MaximumHeight;
    public Thickness Margin { get; set; } = ViewDefaults.CreateDefaultMargin();
    public int ZIndex { get; set; } = ViewDefaults.ZIndex;

    public new IViewHandler? Handler
    {
        get => base.Handler as IViewHandler;
        set => base.Handler = value;
    }
    
    public bool InputTransparent { get; set; } = ViewDefaults.InputTransparent;
}

public partial class FabView
{
    public static void SetAutomationId(IFabView target, string value) => target.AutomationId = value;
    public static void SetFlowDirection(IFabView target, FlowDirection value) => target.FlowDirection = value;
    public static void SetHorizontalLayoutAlignment(IFabView target, LayoutAlignment value) => target.HorizontalLayoutAlignment = value;
    public static void SetVerticalLayoutAlignment(IFabView target, LayoutAlignment value) => target.VerticalLayoutAlignment = value;
    public static void SetSemantics(IFabView target, Semantics value) => target.Semantics = value;
    public static void SetClip(IFabView target, IShape value) => target.Clip = value;
    public static void SetShadow(IFabView target, IShadow value) => target.Shadow = value;
    public static void SetIsEnabled(IFabView target, bool value) => target.IsEnabled = value;
    public static void SetIsFocused(IFabView target, bool value) => target.IsFocused = value;
    public static void SetVisibility(IFabView target, Visibility value) => target.Visibility = value;
    public static void SetOpacity(IFabView target, double value) => target.Opacity = value;
    public static void SetBackground(IFabView target, Paint value) => target.Background = value;
    public static void SetWidth(IFabView target, double value) => target.Width = value;
    public static void SetMinimumWidth(IFabView target, double value) => target.MinimumWidth = value;
    public static void SetMaximumWidth(IFabView target, double value) => target.MaximumWidth = value;
    public static void SetHeight(IFabView target, double value) => target.Height = value;
    public static void SetMinimumHeight(IFabView target, double value) => target.MinimumHeight = value;
    public static void SetMaximumHeight(IFabView target, double value) => target.MaximumHeight = value;
    public static void SetMargin(IFabView target, Thickness value) => target.Margin = value;
    public static void SetZIndex(IFabView target, int value) => target.ZIndex = value;
    public static void SetInputTransparent(IFabView target, bool value) => target.InputTransparent = value;
}