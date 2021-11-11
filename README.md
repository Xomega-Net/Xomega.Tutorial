# Xomega.Examples
Current repository contains examples for building .Net web and desktop apps with Xomega technology and frameworks.

The examples demonstrate working multi-tier applications based on the sample AdventureWorks database in the following technologies:
- **Blazor Server** application;
- **Blazor WebAssembly** application;
- **Single Page Application** in TypeScript with a REST middle tier based on ASP.NET Core
- **ASP.NET WebForms** application;
- **WPF Core 2-tier** application;
- **WPF Core multi-tier** application with a **REST middle tier** based on ASP.NET Core;
- **WPF Core multi-tier** application with a **WCF middle tier**;

Most of the code, including views, view models, business service contracts and service implementations are generated from the Xomega model, with custom code added on top of it to make up the fully functional applications. The business services are async, and use EntityFrameworkCore, but allow switching to EF 6.4, which also supports .NET Core.

AdventureWorks Xomega examples were initially created by following the [comprehensive Xomega tutorial](https://xomega.net/Tutorials/WalkThrough.aspx).

## Prerequisites
To run these examples you need to have the following software installed:
- Visual Studio 2019 with latest updates and TypeScript support.
- [AdventureWorks2016 sample database](https://github.com/Microsoft/sql-server-samples/releases/download/adventureworks/AdventureWorks2016.bak) running on your local or network SQL server.
- [Xomega.Net for VS2019](https://xomega.net/System/Download.aspx) with a valid license for working with the model project, and regenerating the model.

## Setting up your projects
You need to make the following updates to be able to run the examples.
- Reinstall 3rd party NuGet packages, by opening _Tools > NuGet Package Manager > Package Manager Console_, and running the following command: `Update-Package -Reinstall -IgnoreDependencies -FileConflictAction Ignore`
- Update connection string in the `db.config` file in the `AdventureWorks.Services.Entities` project to point to your AdventureWorks DB.
- On the properties of the AdventureWorks.Services.Wcf project select "Don't open a page" option as a Start Action under the Web tab.

## Running the apps
* **Blazor Server** - select `AdventureWorks.Client.Blazor.Server` as the startup project and run the solution.
* **Blazor WebAssembly** - open solution properties, and select multiple startup projects as follows, and run the solution.
  * `AdventureWorks.Client.Blazor.Wasm` with 'Start' action.
  * `AdventureWorks.Services.Rest` with 'Start' action.
* **SPA** - open solution properties, and select multiple startup projects as follows, and run the solution.
  * `AdventureWorks.Client.Spa` with 'Start without Debugging' action. (Debugging will be in the browser)
  * `AdventureWorks.Services.Rest` with 'Start' action.
* **ASP.NET WebForms** - select `AdventureWorks.Client.Web` as the startup project and run the solution.
* **WPF 2-Tier** - set TWO_TIER conditional constant in the AdventureWorks.Client.Wpf project properties.
  Then select `AdventureWorks.Client.Wpf` as the startup project and run the solution.
* **WPF Multi-Tier with REST middle tier** - set REST conditional constant in the `AdventureWorks.Client.Wpf` project properties.
  Then open solution properties, and select multiple startup projects as follows, and run the solution.
  * `AdventureWorks.Client.Wpf` with 'Start' action.
  * `AdventureWorks.Services.Rest` with 'Start' action.
* **WPF Multi-Tier with WCF middle tier** - set WCF conditional constant in the `AdventureWorks.Client.Wpf` project properties.
  Then open solution properties, and select multiple startup projects as follows, and run the solution.
  * `AdventureWorks.Client.Wpf` with 'Start' action.
  * `AdventureWorks.Services.Wcf` with 'Start' action.
* **Any app above using Entity Framework 6.4** - set EF6 conditional constant in the properties of the `AdventureWorks.Services.Entities`
  and the startup projects, and run the solution.

Use an email address for a person from the AdventureWorks DB as the user name (e.g. ken0@adventure-works.com), and the word 'password' as the password.
