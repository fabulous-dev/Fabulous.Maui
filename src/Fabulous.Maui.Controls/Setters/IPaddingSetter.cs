using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public static class PaddingDefaults
{
    public static Thickness CreateDefaultPadding() => Thickness.Zero;
}

public interface IPaddingSetter
{
    void SetPadding(Thickness value);
}