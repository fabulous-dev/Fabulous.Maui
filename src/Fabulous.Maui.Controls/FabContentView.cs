using Microsoft.Maui;
using Microsoft.Maui.Handlers.Defaults;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;

namespace Fabulous.Maui.Controls;

public interface IFabContentView: IContentView, IFabView, IFabPadding
{
    void SetContent(object? value);
    void SetPresentedContent(IView? value);
}

public class FabContentView: FabView, IFabContentView
{
    public Thickness Padding { get; private set; } = PaddingDefaults.CreateDefaultPadding();

    public virtual Size CrossPlatformMeasure(double widthConstraint, double heightConstraint)
    {
        return this.MeasureContent(widthConstraint, heightConstraint);
    }

    public virtual Size CrossPlatformArrange(Rect bounds)
    {
        this.ArrangeContent(bounds);
        return bounds.Size;
    }

    public object? Content { get; private set; } = ContentViewDefaults.Content;

    private IView? _presentedContent = ContentViewDefaults.PresentedContent;
    public IView? PresentedContent
    {
        get => _presentedContent ?? Content as IView;
        set => _presentedContent = value;
    }
    
    
    public void SetPadding(Thickness value) => Padding = value;
    public void SetContent(object? value) => Content = value;
    public void SetPresentedContent(IView? value) => PresentedContent = value;
}