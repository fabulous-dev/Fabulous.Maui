using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public static class ImageSourcePartDefaults
{
    public const IImageSource? Source = null;
}

public interface IImageSourcePartSetter
{
    void SetSource(IImageSource? value);
}