# Xomega.Tutorial
Current repository contains examples for building .Net Blazor apps with Xomega technology and frameworks that were created by following [Xomega walkthrough tutorial](https://xomega.net/docs/tutorial/get-started).

The examples demonstrate working multi-tier applications based on the sample AdventureWorks database in the following technologies:
- **Blazor Server** application;
- **Blazor WebAssembly** application;

Most of the code, including views, view models, business service contracts and service implementations are generated from the Xomega model, with custom code added on top of it to make up the fully functional applications. 

## Prerequisites
To run these examples you need to have the following software installed:
- Visual Studio 2019.
- [AdventureWorks2016 sample database](https://github.com/Microsoft/sql-server-samples/releases/download/adventureworks/AdventureWorks2016.bak) running on your local or network SQL server.
- [Xomega.Net for VS2019](https://xomega.net/System/Download.aspx) with a valid license for working with the model project, and regenerating the model.

## Setting up your projects
You need to make the following updates to be able to run the examples.
- Update connection string in the `db.config` file in the `AdventureWorks.Services.Entities` project to point to your AdventureWorks DB.

## Running the apps
* **Blazor Server** - select `AdventureWorks.Client.Blazor.Server` as the startup project and run the solution.
* **Blazor WebAssembly** - open solution properties, and select multiple startup projects as follows, and run the solution.
  * `AdventureWorks.Client.Blazor.Wasm` with 'Start' action.
  * `AdventureWorks.Services.Rest` with 'Start' action.

Use an email address for a person from the AdventureWorks DB as the user name (e.g. ken0@adventure-works.com), and the word 'password' as the password.
