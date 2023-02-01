using Microsoft.Maui;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui
{
    public interface IFabImageButton: IImageButton, IFabButton, IFabImage
    {

    }
}

namespace Fabulous.Maui.Controls
{
    public class FabImageButton : FabButton, IFabImageButton
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