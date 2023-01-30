using Microsoft.Maui;

namespace Fabulous.Maui
{
    public interface IFabImageSourcePart : IImageSourcePart
    {
        void SetSource(IImageSource? value);
    }
}