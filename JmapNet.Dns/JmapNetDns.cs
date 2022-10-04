using DnsClient;

namespace JmapNet.Dns;

/// <summary>
///     A static class to hold DNS functionality.
/// </summary>
public static class JmapNetDns
{
    /// <summary>
    ///     Make a DNS request to automatically discover the JMAP API endpoint from the server address.
    /// </summary>
    /// <param name="serverAddress">The base address of the server.</param>
    /// <returns>The URI result and a message indicating errors.</returns>
    public static async Task<(Uri? uri, string message)> GetJmapUri(string serverAddress)
    {
        var dnsResponse = await new LookupClient().QueryAsync($"{JmapConstants.JmapDnsPrefix}.{serverAddress}", QueryType.SRV);
        if (dnsResponse.HasError)
            return (null, $"DNS error: {dnsResponse.ErrorMessage}");

        var srvRecord = dnsResponse.Answers.SrvRecords().SingleOrDefault();
        return srvRecord == null
            ? (null, "no SRV record found")
            : (new UriBuilder("https", srvRecord.Target, srvRecord.Port).Uri, "");
    }
}
