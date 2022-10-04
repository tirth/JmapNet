using JmapNet.Client;
using JmapNet.Dns;
using JmapNet.Models.Core;
using JmapNet.Models.Mail;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using NLog.Layouts;
using LogLevel = NLog.LogLevel;

Console.WriteLine("yo");

#region Logging

LogManager.Setup().LoadConfiguration(builder =>
{
    builder.ForLogger().FilterMinLevel(LogLevel.Debug).WriteToConsole("${level:uppercase=true} | ${message:withexception=true} | ${logger}");
    builder.ForLogger().FilterMinLevel(LogLevel.Debug).WriteToFile("jmap_client-${shortdate}.txt", new JsonLayout
    {
        Attributes =
        {
            new JsonAttribute("time", "${longdate}"),
            new JsonAttribute("level", "${level:upperCase=true}"),
            new JsonAttribute("message", "${message}")
        },
        IncludeEventProperties = true
    });
});

var loggerFactory = LoggerFactory.Create(builder => builder.AddNLog());

var logger = loggerFactory.CreateLogger("main");
var jmapLogger = loggerFactory.CreateLogger<JmapClient>();

#endregion

// stuff
var dnsAutoDiscover = false;
var baseUri = dnsAutoDiscover
    ? (await JmapNetDns.GetJmapUri("fastmail.com")).uri ??
      throw new InvalidOperationException("couldn't get URI from DNS")
    : new Uri("https://api.fastmail.com");

var token = File.ReadAllText("jmap_access_token.txt");

using var jmap = await JmapClient.Init(baseUri, token, jmapLogger)
                 ?? throw new InvalidOperationException("client is null");

var filter = new JmapEmailQueryFilter
{
    Subject = "dev"
};

var sort = new List<JmapComparator>
{
    JmapComparator.Desc(nameof(JmapEmail.ReceivedAt))
};

var emails = await jmap.GetEmails(filter, sort);

foreach (var email in emails)
{
    logger.LogInformation("{receivedAt} - {subject} - {keywords} - {size}, {hasAttachment}",
        email.ReceivedAt?.ToLocalTime(),
        email.Subject,
        string.Join(", ", email.Keywords?.Keys ?? Enumerable.Empty<string>()),
        email.Size,
        email.HasAttachment);
}
