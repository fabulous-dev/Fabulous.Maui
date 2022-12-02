using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;
using Microsoft.Maui.Primitives;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui.Controls;

public interface IFabView : IView, IFabTransform
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

public class FabView: FabElement, IFabView
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

public static class FabViewSetters
{
    public static void SetAutomationId(FabElement target, string value) => ((IFabView)target).AutomationId = value;
    public static void SetFlowDirection(FabElement target, FlowDirection value) => ((IFabView)target).FlowDirection = value;
    public static void SetHorizontalLayoutAlignment(FabElement target, LayoutAlignment value) => ((IFabView)target).HorizontalLayoutAlignment = value;
    public static void SetVerticalLayoutAlignment(FabElement target, LayoutAlignment value) => ((IFabView)target).VerticalLayoutAlignment = value;
    public static void SetSemantics(FabElement target, Semantics value) => ((IFabView)target).Semantics = value;
    public static void SetClip(FabElement target, IShape value) => ((IFabView)target).Clip = value;
    public static void SetShadow(FabElement target, IShadow value) => ((IFabView)target).Shadow = value;
    public static void SetIsEnabled(FabElement target, bool value) => ((IFabView)target).IsEnabled = value;
    public static void SetIsFocused(FabElement target, bool value) => ((IFabView)target).IsFocused = value;
    public static void SetVisibility(FabElement target, Visibility value) => ((IFabView)target).Visibility = value;
    public static void SetOpacity(FabElement target, double value) => ((IFabView)target).Opacity = value;
    public static void SetBackground(FabElement target, Paint value) => ((IFabView)target).Background = value;
    public static void SetWidth(FabElement target, double value) => ((IFabView)target).Width = value;
    public static void SetMinimumWidth(FabElement target, double value) => ((IFabView)target).MinimumWidth = value;
    public static void SetMaximumWidth(FabElement target, double value) => ((IFabView)target).MaximumWidth = value;
    public static void SetHeight(FabElement target, double value) => ((IFabView)target).Height = value;
    public static void SetMinimumHeight(FabElement target, double value) => ((IFabView)target).MinimumHeight = value;
    public static void SetMaximumHeight(FabElement target, double value) => ((IFabView)target).MaximumHeight = value;
    public static void SetMargin(FabElement target, Thickness value) => ((IFabView)target).Margin = value;
    public static void SetZIndex(FabElement target, int value) => ((IFabView)target).ZIndex = value;
    public static void SetInputTransparent(FabElement target, bool value) => ((IFabView)target).InputTransparent = value;
}