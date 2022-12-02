using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public interface IFabImageSourcePart: IImageSourcePart
{
    new IImageSource? Source { get; set; }
}

public static class FabImageSourcePartSetters
{
    public static void SetSource(FabElement target, IImageSource? value) => ((IFabImageSourcePart)target).Source = value;
}