namespace StarkEx.Client.SDK.Tests.Helpers;

public sealed class DefaultHttpClientFactory : IHttpClientFactory, IDisposable
{
    private readonly Lazy<HttpMessageHandler> handlerLazy = new(() => new HttpClientHandler());

    public HttpClient CreateClient(string name) => new(handlerLazy.Value, disposeHandler: false);

    public void Dispose()
    {
        if (handlerLazy.IsValueCreated)
        {
            handlerLazy.Value.Dispose();
        }
    }
}
