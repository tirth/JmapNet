# JmapNet

[![Nuget](https://img.shields.io/nuget/v/JmapNet?color=%235CDB94&label=JmapNet&logo=nuget)](https://www.nuget.org/packages/JmapNet) [![Nuget](https://img.shields.io/nuget/v/JmapNet.Client?color=%235CDB94&label=JmapNet.Client&logo=nuget)](https://www.nuget.org/packages/JmapNet.Client) [![Nuget](https://img.shields.io/nuget/v/JmapNet.Dns?color=%235CDB94&label=JmapNet.Dns&logo=nuget)](https://www.nuget.org/packages/JmapNet.Dns)

A modern .NET library for [JMAP](https://jmap.io/) - [RFC8620](https://www.rfc-editor.org/rfc/rfc8620), [RFC8621](https://www.rfc-editor.org/rfc/rfc8621)

This repository contains [the JMAP data model](https://github.com/tirth/JmapNet/tree/master/JmapNet), [a client to interact with JMAP APIs](https://github.com/tirth/JmapNet/tree/master/JmapNet.Client), and [functionality for DNS autodiscovery of the API endpoint](https://github.com/tirth/JmapNet/tree/master/JmapNet.Dns).

This is still very much a work in progress, the basic `/get`, `/changes`, `/set`, and `/query` methods have been implemented, along with binary uploads and downloads.

## Building/Contributing

Contributions are welcome, everything builds with a simple `dotnet build`, or in a recent version of Visual Studio.

## TODO:
- `FilterOperator` for sorting
- `PatchObject` for updates
- `/queryChanges`
- Push notifications
- Replace `Microsoft.Extensions.Logging.Abstractions` with an internal `ILogger`?
- Tests
- Documentation
- Website

## Ideas:
- LINQ `IQueryable` implementation
- JSON source generator
- ASP.NET Core JMAP server
