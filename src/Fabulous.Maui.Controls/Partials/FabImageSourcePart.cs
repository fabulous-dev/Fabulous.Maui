using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public interface IFabImageSourcePart: IImageSourcePart
{
    void SetSource(IImageSource? value);
}