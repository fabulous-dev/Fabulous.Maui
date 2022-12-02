using Microsoft.Maui.Graphics;

namespace Microsoft.Maui.Handlers.Defaults;

public static class ScrollViewDefaults
{
    public const Action? OnScrollFinished = null;
    public const ScrollBarVisibility HorizontalScrollBarVisibility = ScrollBarVisibility.Default;
    public const ScrollBarVisibility VerticalScrollBarVisibility = ScrollBarVisibility.Default;
    public const ScrollOrientation Orientation = ScrollOrientation.Vertical;
    public const double HorizontalOffset = 0.0;
    public const double VerticalOffset = 0.0;
    public static Size CreateContentSize() => Size.Zero;
}