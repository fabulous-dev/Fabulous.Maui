using Microsoft.Maui;

namespace Fabulous.Maui.Controls.ImageSources;

public record struct FabFileImageSource(string File): IFileImageSource
{
    public bool IsEmpty => false;
}