using Microsoft.Maui;

namespace Fabulous.Maui
{
    public interface IFabText : IText, IFabTextStyle
    {
        void SetText(string value);
    }
}