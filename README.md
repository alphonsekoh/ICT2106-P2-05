## How it works

This is the main repository.

The [Area](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/areas?view=aspnetcore-6.0) feature in ASP.NET Core is used to separate the teams.

---

## Forking Workflow

- Each team will fork this repository and work inside their own forked repository.
- Make a Pull Request(PR) to the main repository when an update is ready to be integrated

## Points of Interest

- Add your Dbsets to [HospitalContext](./data/HospitalContext.cs)
- Create your own areas in [Areas](./Areas). Use Visual Studio to scaffold 👍
- Add your newly created Area route to [Startup.cs](./Startup.cs)

## Resources for

[Database Migration](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)
