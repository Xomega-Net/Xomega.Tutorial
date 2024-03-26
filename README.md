# Xomega.Tutorial
Current repository contains examples for building .Net Blazor apps with Xomega technology and frameworks that were created by following [Xomega walkthrough tutorial](https://xomega.net/docs/tutorial/get-started.html).

The examples demonstrate working multi-tier applications based on the sample AdventureWorks database in the following technologies:
- **Blazor Server** application;
- **Blazor WebAssembly** application;
- **Blazor Auto** application with auto-transition from *Blazor Server* to *WebAssembly* after the latter is loaded;

Most of the code, including views, view models, business service contracts and service implementations are generated from the Xomega model, with custom code added on top of it to make up the fully functional applications. 

## Prerequisites
To run these examples you need to have the following software installed:
- Visual Studio 2022.
- [AdventureWorks2022 sample database](https://github.com/Microsoft/sql-server-samples/releases/download/adventureworks/AdventureWorks2022.bak) running on your local or network SQL server.
- [Xomega.Net for VS2022](https://xomega.net/product/download) with a valid license for working with the model project, and regenerating the model.

## Setting up your projects
You need to make the following updates to be able to run the examples.
- Update connection string in the `db.config` file in the `AdventureWorks.Services.Entities` project to point to your AdventureWorks DB.

## Running the apps
To run the application select `AdventureWorks.Client.Blazor` as the startup project and run the solution.

Use an email address for a person from the AdventureWorks DB as the user name (e.g. ken0@adventure-works.com), and the word 'password' as the password.

You can use various interactive rendering modes to run it as **Blazor Server**, **Blazor WebAssembly** or both in the **Auto** mode. To change the mode update the `RenderModeForPage` value in the `App.razor` file of the `AdventureWorks.Client.Blazor.Common` project.
