using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public interface IFabTextAlignment: ITextAlignment
{
    new TextAlignment HorizontalTextAlignment { get; set; }
    new TextAlignment VerticalTextAlignment { get; set; }
}

public static class FabTextAlignment
{
    public static void SetHorizontalTextAlignment(IFabTextAlignment target, TextAlignment value) => target.HorizontalTextAlignment = value;
    public static void SetVerticalTextAlignment(IFabTextAlignment target, TextAlignment value) => target.VerticalTextAlignment = value;
}