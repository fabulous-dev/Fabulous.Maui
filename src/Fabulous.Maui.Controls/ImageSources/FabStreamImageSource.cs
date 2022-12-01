using Microsoft.Maui;

namespace Fabulous.Maui.Controls.ImageSources;

public class FabStreamImageSource: IStreamImageSource
{
    private readonly Stream _stream;
    
    public FabStreamImageSource(Stream stream)
    {
        _stream = stream;
    }

    public bool IsEmpty => false;
    
    public Task<Stream> GetStreamAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.FromResult(_stream);
    }
}