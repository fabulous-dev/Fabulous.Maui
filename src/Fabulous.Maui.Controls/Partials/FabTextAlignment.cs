using Microsoft.Maui;

namespace Fabulous.Maui
{
    public interface IFabTextAlignment : ITextAlignment
    {
        void SetHorizontalTextAlignment(TextAlignment value);
        void SetVerticalTextAlignment(TextAlignment value);
    }
}