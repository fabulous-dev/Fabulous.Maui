using Microsoft.Maui;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui.Controls;

public interface IFabImage: IImage, IFabImageSourcePart
{
    new bool IsAnimationPlaying { get; set; }
    new Aspect Aspect { get; set; }
    new bool IsOpaque { get; set; }
}

public class FabImage: FabView, IFabImage
{
    public void UpdateIsLoading(bool isLoading)
    {
        throw new NotImplementedException();
    }

    public IImageSource? Source { get; set; } = ImageSourcePartDefaults.Source;
    public bool IsAnimationPlaying { get; set; } = ImageDefaults.IsAnimationPlaying;
    public Aspect Aspect { get; set; } = ImageDefaults.Aspect;
    public bool IsOpaque { get; set; } = ImageDefaults.IsOpaque;
}

public static class FabImageSetters
{
    public static void SetIsAnimationPlaying(FabElement target, bool value) => ((IFabImage)target).IsAnimationPlaying = value;
    public static void SetAspect(FabElement target, Aspect value) => ((IFabImage)target).Aspect = value;
    public static void SetIsOpaque(FabElement target, bool value) => ((IFabImage)target).IsOpaque = value;
}