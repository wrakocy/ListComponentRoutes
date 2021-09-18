# ListComponentRoutes Middleware Package

A middleware nuget package for listing all routeable Razor components in an ASP.NET Core app.

# Getting Started

1. Install NuGet package

```
PM> Install-Package Wrak.ListComponentRoutes
```
2. Add the following at **the bottom of** Startup's `ConfigureServices` method:

```
services.AddListComponentRoutes('/my-list-route'); // optional - default path to list is '/routes'
```
3. Add the following to Startup's Configure method (in an if block so it only runs in Development)
```
if (env.IsDevelopment())
{
    app.UseListComponentRoutes();
    app.UseDeveloperExceptionPage();
}
```
If it's working you should see output like this listing all of your routeable Razor components:

![screenshot](./docs/screenshot.png)

