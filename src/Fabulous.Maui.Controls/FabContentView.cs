using Microsoft.Maui;
using Microsoft.Maui.Handlers.Defaults;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;

namespace Fabulous.Maui.Controls;

public interface IFabContentView: IContentView, IFabView, IFabPadding
{
    new object? Content { get; set; }
    new IView? PresentedContent { get; set; }
}

public partial class FabContentView: FabView, IFabContentView
{
    public Thickness Padding { get; set; } = PaddingDefaults.CreateDefaultPadding();
    
    public virtual Size CrossPlatformMeasure(double widthConstraint, double heightConstraint)
    {
        return this.MeasureContent(widthConstraint, heightConstraint);
    }

    public virtual Size CrossPlatformArrange(Rect bounds)
    {
        this.ArrangeContent(bounds);
        return bounds.Size;
    }

    public object? Content { get; set; } = ContentViewDefaults.Content;

    private IView? _presentedContent = ContentViewDefaults.PresentedContent;
    public IView? PresentedContent
    {
        get => _presentedContent ?? Content as IView;
        set => _presentedContent = value;
    }
}

public partial class FabContentView
{
    public static void SetContent(IFabContentView target, object? value) => target.Content = value;
    public static void SetPresentedContent(IFabContentView target, IView? value) => target.PresentedContent = value;
}