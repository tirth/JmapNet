namespace JmapNet.Dns.Tests;

public class MainTests : LoggingTestsBase
{
    public MainTests(ITestOutputHelper output) : base(output)
    {
    }

    [Theory]
    [InlineData("fastmail.com", "https://api.fastmail.com.")]
    public async Task TestDnsAutoDiscovery(string serverAddress, string expectedUri)
    {
        var (uri, message) = await JmapNetDns.GetJmapUri(serverAddress);

        Assert.True(uri != null, message);
        Assert.Equal(new Uri(expectedUri), uri);
    }
}
