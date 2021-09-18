[![NuGet](https://img.shields.io/nuget/v/Ardalis.ListStartupServices.svg)](https://www.nuget.org/packages/Ardalis.ListStartupServices)[![NuGet](https://img.shields.io/nuget/dt/Ardalis.ListStartupServices.svg)](https://www.nuget.org/packages/Ardalis.ListStartupServices)
[![Build Status](https://dev.azure.com/ardalis/AspNetCoreStartupServices/_apis/build/status/ardalis.AspNetCoreStartupServices?branchName=master)](https://dev.azure.com/ardalis/AspNetCoreStartupServices/_build/latest?definitionId=4&branchName=master)
![Test Status](https://img.shields.io/azure-devops/tests/ardalis/AspNetCoreStartupServices/4.svg)

# ASP.NET Core ListComponentRoutes Middleware Package

A middleware nuget package for listing all routeable components in an ASP.NET Core app.

# Getting Started

1. Install the nuget package.
1. Add the following at **the bottom of** Startup's `ConfigureServices` method:

```
// optional - default path to list services is /routes
services.AddListComponentRoutes('/my-list-route');
```
1. Add the following to your Configure method (in an if block so it only runs in dev environemnt)
```
if (env.IsDevelopment())
{
    app.UseShowAllServicesMiddleware();
    app.UseDeveloperExceptionPage();
}
```

If it's working you should see output like this showing all of your services:

![image](https://user-images.githubusercontent.com/782127/52003616-0e497b80-2493-11e9-856c-1d4ef9207be0.png)

# Reference

- [Original Sample Article](https://ardalis.com/how-to-list-all-services-available-to-an-asp-net-core-app)
- [Screencast of Extracting Middleware and Publishing to Nuget.org](https://www.youtube.com/watch?v=6-WcxBLyIes)
- [Follow ardalis on twitch.tv](https://www.twitch.tv/ardalis)

