using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public interface IFabText: IText, IFabTextStyle
{
    void SetText(string value);
}