dotnet new sln --name "%~1"
dotnet new blazorwasm -o "%~1SPA"
dotnet sln "%~1.sln" add "./%~1SPA/%~1SPA.csproj"
