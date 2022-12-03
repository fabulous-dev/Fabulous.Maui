using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public interface IFabImageSourcePart: IImageSourcePart
{
    new IImageSource? Source { get; set; }
}

public static class FabImageSourcePart
{
    public static void SetSource(IFabImageSourcePart target, IImageSource? value) => target.Source = value;
}