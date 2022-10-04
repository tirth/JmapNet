# JmapNet.Client

A high performance modern client library for JMAP APIs, built on `HttpClient` and `System.Text.Json`.

## Initialization

All API calls require an access token, acquiring one is currently out of scope for this library.

The client can be initialized with the token, which creates an `HttpClient` instance with bearer authentication headers set:

``` csharp
var baseUri = new Uri("https://api.fastmail.com");
var token = "";

var jmap = await JmapClient.Init(baseUri, token);
```

Otherwise, if you've already got a configured `HttpClient` you can initialize with it directly:

``` csharp
var httpClient = ... // pre-configured for authentication

var jmap = await JmapClient.Init(httpClient);
```

The `Init` methods also take an optional `ILogger<JmapClient>` for more info.

## Usage

There are helper extension methods on `JmapClient` that provide high level access to the API:

```csharp
var filter = new JmapEmailQueryFilter
{
    Subject = "dev"
};

var emails = await jmap.GetEmails(filter);
```

[These methods](https://github.com/tirth/JmapNet/blob/master/JmapNet.Client/JmapClientExtensions.cs) provide a good example of how to use the lower level functionality for arbitrary queries.

Additionally, there are examples of method calls in `JmapNet.Client.Tests`.

