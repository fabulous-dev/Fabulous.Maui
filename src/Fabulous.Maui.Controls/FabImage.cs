using Microsoft.Maui;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui.Controls;

public interface IFabImage: IImage, IFabImageSourcePart
{
    new bool IsAnimationPlaying { get; set; }
    new Aspect Aspect { get; set; }
    new bool IsOpaque { get; set; }
}

public partial class FabImage: FabView, IFabImage
{
    private bool _isLoading; // TODO: What is this for?
    public void UpdateIsLoading(bool isLoading)
    {
        _isLoading = isLoading;
    }

    public IImageSource? Source { get; set; } = ImageSourcePartDefaults.Source;
    public bool IsAnimationPlaying { get; set; } = ImageDefaults.IsAnimationPlaying;
    public Aspect Aspect { get; set; } = ImageDefaults.Aspect;
    public bool IsOpaque { get; set; } = ImageDefaults.IsOpaque;
}

public partial class FabImage
{
    public static void SetIsAnimationPlaying(IFabImage target, bool value) => target.IsAnimationPlaying = value;
    public static void SetAspect(IFabImage target, Aspect value) => target.Aspect = value;
    public static void SetIsOpaque(IFabImage target, bool value) => target.IsOpaque = value;
}