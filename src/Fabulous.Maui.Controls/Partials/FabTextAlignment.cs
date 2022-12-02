using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public interface IFabTextAlignment: ITextAlignment
{
    new TextAlignment HorizontalTextAlignment { get; set; }
    new TextAlignment VerticalTextAlignment { get; set; }
}

public static class FabTextAlignmentSetters
{
    public static void SetHorizontalTextAlignment(FabElement target, TextAlignment value) => ((IFabTextAlignment)target).HorizontalTextAlignment = value;
    public static void SetVerticalTextAlignment(FabElement target, TextAlignment value) => ((IFabTextAlignment)target).VerticalTextAlignment = value;
}