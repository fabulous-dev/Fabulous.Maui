using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public interface IFabTextAlignment: ITextAlignment
{
    void SetHorizontalTextAlignment(TextAlignment value);
    void SetVerticalTextAlignment(TextAlignment value);
}