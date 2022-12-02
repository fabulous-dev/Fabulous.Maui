using Microsoft.Maui;

namespace Fabulous.Maui.Controls.ImageSources;

public readonly struct FabFileImageSource: IFileImageSource
{
    public FabFileImageSource(string file)
    {
        File = file;
    }

    public string File { get; }

    public bool IsEmpty => false;
}