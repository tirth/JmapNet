# JmapNet.Dns

A small utility built on the excellent [DnsClient](https://github.com/MichaCo/DnsClient.NET) to retrieve a JMAP API url given a host name. 

Currently provides a single static method:
```csharp
var (uri, error) = await JmapNetDns.GetJmapUri("fastmail.com");
```
