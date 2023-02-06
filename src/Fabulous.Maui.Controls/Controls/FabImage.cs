using Microsoft.Maui;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui
{
    public interface IFabImage : Microsoft.Maui.IImage, IFabView, IFabImageSourcePart
    {
        void SetIsAnimationPlaying(bool value);
        void SetAspect(Aspect value);
        void SetIsOpaque(bool value);
    }
}

namespace Fabulous.Maui.Controls
{
    public class FabImage : FabView, IFabImage
    {
        private bool _isLoading; // TODO: What is this for?

        public void UpdateIsLoading(bool isLoading)
        {
            _isLoading = isLoading;
        }

        public IImageSource? Source { get; private set; } = ImageSourcePartDefaults.Source;
        public bool IsAnimationPlaying { get; private set; } = ImageDefaults.IsAnimationPlaying;
        public Aspect Aspect { get; private set; } = ImageDefaults.Aspect;
        public bool IsOpaque { get; private set; } = ImageDefaults.IsOpaque;

        public void SetSource(IImageSource? value) => Source = value;
        public void SetIsAnimationPlaying(bool value) => IsAnimationPlaying = value;
        public void SetAspect(Aspect value) => Aspect = value;
        public void SetIsOpaque(bool value) => IsOpaque = value;
    }
}