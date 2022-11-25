using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public static class TextAlignmentDefaults
{
    public const TextAlignment HorizontalTextAlignment = TextAlignment.Start;
    public const TextAlignment VerticalTextAlignment = TextAlignment.Start;
}

public interface ITextAlignmentSetter
{
    void SetHorizontalTextAlignment(TextAlignment alignment);
    void SetVerticalTextAlignment(TextAlignment alignment);
}