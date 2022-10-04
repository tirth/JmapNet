using System.Text;
using JmapNet.Models.Core;
using JmapNet.Models.Mail;

namespace JmapNet.Client.Tests;

public class MainTests : LoggingTestsBase<JmapClient>, IAsyncLifetime
{
    private JmapClient _jmap = null!;

    public MainTests(ITestOutputHelper output) : base(output)
    {
    }

    public async Task InitializeAsync()
    {
        var uri = new Uri("https://api.fastmail.com");
        var token = await File.ReadAllTextAsync("jmap_access_token.txt") ?? throw new InvalidOperationException("couldn't get token");

        _jmap = await JmapClient.Init(uri, token, Logger) ?? throw new InvalidOperationException("couldn't init client");
    }

    public Task DisposeAsync()
    {
        _jmap.Dispose();

        return Task.CompletedTask;
    }

    [Fact]
    public void TestSession()
    {
        var session = _jmap.Session;

        Output.WriteLine($"{Util.JsonStr(session)}");
    }

    [Fact]
    public async Task TestEcho()
    {
        var echoRequest = new JmapCoreEchoRequest("a")
        {
            Thing = "beep"
        };

        var echoQuery = echoRequest.Invoke("a");

        var res = await _jmap.SendRequest(echoQuery);

        var echoResponse = res.GetFirstArg<JmapCoreEchoResponse>(echoQuery);
        Assert.Equal(echoRequest.Thing, echoResponse?.Thing?.ToString());
    }

    [Fact]
    public async Task TestMailboxQuery()
    {
        var filter = new JmapMailboxQueryFilter
        {
            Name = "Inbox"
        };

        var mailboxes = await _jmap.GetMailboxes(filter);

        foreach (var mailbox in mailboxes)
        {
            Output.WriteLine($"{mailbox.Id}: {mailbox.Name} - {mailbox.TotalEmails}");
        }
    }

    [Fact]
    public async Task TestMailboxChanges()
    {
        var mailboxGet = new JmapMailboxGetRequest(_jmap.DefaultAccountId)
        {
            Ids = new List<string>
            {
                ""
            }
        }.Invoke("a");

        var getResponse = await _jmap.SendRequest(mailboxGet);

        var res = getResponse.GetFirstArg<JmapGetResponse<JmapMailbox>>(mailboxGet);
        if (res != null)
        {
            var mailboxChangesRequest = new JmapMailboxChangesRequest(_jmap.DefaultAccountId)
            {
                SinceState = res.State
            }.Invoke("b");

            var changesResponse = await _jmap.SendRequest(mailboxChangesRequest);

            var changes = changesResponse.GetFirstArg<JmapMailboxChangesResponse>(mailboxChangesRequest);

            Output.WriteLine($"{Util.Joined(changes?.UpdatedProperties)}");
        }
    }

    [Fact]
    public async Task TestMailboxSet()
    {
        var mailboxSet = new JmapMailboxSetRequest(_jmap.DefaultAccountId)
        {
            Create = new Dictionary<string, JmapMailbox>
            {
                { "a", new JmapMailbox { Name = "Test" } }
            }
        }.Invoke("a");

        var res = await _jmap.SendRequest(mailboxSet);

        var setResponse = res.GetFirstArg<JmapMailboxSetResponse>(mailboxSet);

        Output.WriteLine($"{Util.JsonStr(setResponse)}");
    }

    [Fact]
    public async Task TestThreadGet()
    {
        var threadGet = new JmapThreadGetRequest(_jmap.DefaultAccountId)
        {
            Ids = new List<string> { "" }
        }.Invoke("a");

        var getResponse = await _jmap.SendRequest(threadGet);

        var threadInfo = getResponse.GetItems<JmapThread>(threadGet);

        Output.WriteLine($"{Util.JsonStr(threadInfo)}");
    }

    [Fact]
    public async Task TestEmailQuery()
    {
        var filter = new JmapEmailQueryFilter
        {
            Subject = "My Cool Email"
        };

        var sort = new List<JmapComparator>
        {
            JmapComparator.Desc(nameof(JmapEmail.ReceivedAt))
        };

        var emails = await _jmap.GetEmails(filter, sort);

        foreach (var email in emails)
        {
            Output.WriteLine("{0} - {1} - {2} - {3}, {4}: {5}",
                email.ReceivedAt?.ToLocalTime(),
                email.Subject,
                string.Join(", ", email.Keywords?.Keys ?? Enumerable.Empty<string>()),
                email.Size,
                email.HasAttachment,
                email.Id);
        }
    }

    [Fact]
    public async Task TestEmailSet()
    {
        var emailSet = new JmapEmailSetRequest(_jmap.DefaultAccountId)
        {
            Create = new Dictionary<string, JmapEmail>
            {
                {
                    "em1", new JmapEmail
                    {
                        MailboxIds = new Dictionary<string, bool>
                        {
                            { "", true }
                        },
                        Keywords = new Dictionary<string, bool>
                        {
                            { "$seen", true },
                            { "$draft", true }
                        },
                        From = new List<JmapEmailAddress>
                        {
                            new("Tirth", "test@tirth.xyz")
                        },
                        Subject = "My Cool Email",
                        SentAt = DateTime.Now,
                        BodyStructure = new JmapEmailBodyPart
                        {
                            Type = "text/plain",
                            PartId = "bp1"
                        },
                        BodyValues = new Dictionary<string, JmapEmailBodyValue>
                        {
                            {
                                "bp1", new JmapEmailBodyValue
                                {
                                    Value = "Check out this sweet email."
                                }
                            }
                        }
                    }
                }
            }
        }.Invoke("a");

        var res = await _jmap.SendRequest(emailSet);

        var emailSetResponse = res.GetFirstArg<JmapEmailSetResponse>(emailSet);

        Assert.NotEmpty(emailSetResponse?.Created ?? new Dictionary<string, JmapEmail>());
    }

    [Fact]
    public async Task TestEmailUpdate()
    {
        var emailSet = new JmapEmailSetRequest(_jmap.DefaultAccountId)
        {
            Update = new Dictionary<string, object>
            {
                {
                    "", new
                    {

                    }
                }
            }
        };
    }

    [Fact]
    public async Task TestEmailSubmission()
    {
        var emailSubmissionSet = new JmapEmailSubmissionSetRequest(_jmap.DefaultAccountId)
        {
            Create = new Dictionary<string, JmapEmailSubmission>
            {
                {
                    "em1", new JmapEmailSubmission
                    {
                        IdentityId = "",
                        EmailId = ""
                    }
                }
            }
        }.Invoke("a");

        var res = await _jmap.SendRequest(emailSubmissionSet);

        var submissionSetResponse = res.GetFirstArg<JmapEmailSubmissionSetResponse>(emailSubmissionSet);
    }

    [Fact]
    public async Task TestSearchSnippets()
    {
        var filter = new JmapEmailQueryFilter
        {
            Subject = ""
        };

        var sort = new List<JmapComparator>
        {
            JmapComparator.Desc(nameof(JmapEmail.ReceivedAt))
        };

        var emailQuery = new JmapEmailQueryRequest(_jmap.DefaultAccountId)
        {
            Filter = filter,
            Sort = sort,
            Limit = 10
        }.Invoke("a");

        var searchSnippetGet = new JmapSearchSnippetGetRequest(_jmap.DefaultAccountId)
        {
            Filter = filter,
            References = new Dictionary<string, JmapResultReference>
            {
                { "#emailIds", emailQuery.GetRef("/ids/*") }
            },
        }.Invoke("b");

        var res = await _jmap.SendRequest(emailQuery, searchSnippetGet);

        var searchSnippets = res.GetItems<JmapSearchSnippet>(searchSnippetGet);

        foreach (var searchSnippet in searchSnippets)
        {
            Output.WriteLine($"{searchSnippet.Subject} - {searchSnippet.Preview}");
        }
    }

    [Fact]
    public async Task TestIdentityGet()
    {
        var identityGet = new JmapIdentityGetRequest(_jmap.DefaultAccountId)
        {
        }.Invoke("a");

        var res = await _jmap.SendRequest(identityGet);

        var identities = res.GetItems<JmapIdentity>(identityGet);

        foreach (var identity in identities)
        {
            Output.WriteLine($"{identity.Id}: {identity.Name} - {identity.Email}");
        }
    }

    [Fact]
    public async Task TestBinaryUpload()
    {
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes("some cool testing bytes"));
        
        var response = await _jmap.UploadBinaryData(stream);

        Output.WriteLine($"{Util.JsonStr(response)}");
    }

    [Fact]
    public async Task TestBinaryDownload()
    {
        var blobId = "";

        var data = await _jmap.DownloadBinaryData(blobId);
        if (data is MemoryStream mem)
        {
            Output.WriteLine($"{Encoding.UTF8.GetString(mem.ToArray())}");
        }
    }
}
