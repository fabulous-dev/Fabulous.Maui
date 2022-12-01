using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public static class ImageDefaults
{
    public const bool IsAnimationPlaying = false;
    public const Aspect Aspect = Microsoft.Maui.Aspect.AspectFit;
    public const bool IsOpaque = false;
}

public class FabImage: FabView, IImage, IImageSourcePartSetter
{
    public void UpdateIsLoading(bool isLoading)
    {
        throw new NotImplementedException();
    }

    public IImageSource? Source { get; set; } = ImageSourcePartDefaults.Source;
    public bool IsAnimationPlaying { get; set; } = ImageDefaults.IsAnimationPlaying;
    public Aspect Aspect { get; set; } = ImageDefaults.Aspect;
    public bool IsOpaque { get; set; } = ImageDefaults.IsOpaque;
    
    public void SetSource(IImageSource? value) => Source = value;
}