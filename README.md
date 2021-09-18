# ASP.NET Core ListComponentRoutes Middleware Package

A middleware nuget package for listing all routeable components in an ASP.NET Core app.

# Getting Started

1. Install the nuget package.
1. Add the following at **the bottom of** Startup's `ConfigureServices` method:

```
// optional - default path to list services is /routes
services.AddListComponentRoutes('/my-list-route');
```
1. Add the following to your Configure method (in an if block so it only runs in development)
```
if (env.IsDevelopment())
{
    app.UseListComponentRoutes();
    app.UseDeveloperExceptionPage();
}
```

If it's working you should see output like this showing all of your services:

![image](https://user-images.githubusercontent.com/782127/52003616-0e497b80-2493-11e9-856c-1d4ef9207be0.png)

