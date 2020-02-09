# StronkGame

To run:
   1. Install .Net Core 3.1 SDK.
   2. Run `dotnet restore` to install all NuGet dependencies.
   3. Run `dotnet ef database update` to apply migrations to the database.
      `stronkgame.db`(SQLite 3 DB) will be automatically created in project root.
   4. Run with `dotnet run`, through Visual Studio or Visual Studio Code.
   5. Go to `http://localhost:5000` or `https://localhost:5001` in a browser.