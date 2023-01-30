using Microsoft.Maui.Primitives;
using Microsoft.Maui.Graphics;

namespace Microsoft.Maui.Handlers.Defaults;

public static class ViewDefaults
{
    public const string AutomationId = "";
    public const FlowDirection FlowDirection = Microsoft.Maui.FlowDirection.MatchParent;
    public const LayoutAlignment HorizontalLayoutAlignment = LayoutAlignment.Fill;
    public const LayoutAlignment VerticalLayoutAlignment = LayoutAlignment.Fill;
    public static Semantics CreateDefaultSemantics() => new();
    public const IShape? Clip = null;
    public const IShadow? Shadow = null;
    public const bool IsEnabled = true;
    public const Action<bool>? OnFocusChanged = null;
    public const bool IsFocused = false;
    public const Visibility Visibility = Microsoft.Maui.Visibility.Visible;
    public const double Opacity = 1.0;
    public const Paint? Background = null;
    public const double Width = Dimension.Unset;
    public const double MinimumWidth = Dimension.Unset;
    public const double MaximumWidth = Dimension.Maximum;
    public const double Height = Dimension.Unset;
    public const double MinimumHeight = Dimension.Unset;
    public const double MaximumHeight = Dimension.Maximum;
    public static Thickness CreateDefaultMargin() => Thickness.Zero;
    public const int ZIndex = 0;
    public const bool InputTransparent = false;
}