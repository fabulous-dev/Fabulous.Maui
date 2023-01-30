using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Font = Microsoft.Maui.Font;

namespace Fabulous.Maui
{
    public interface IFabTextStyle : ITextStyle
    {
        void SetTextColor(Color? value);
        void SetFont(Font value);
        void SetCharacterSpacing(double value);
    }
}