dotnet new sln --name "%~1"
dotnet new blazor -o "%~1Server" -int Server
dotnet sln "%~1.sln" add "./%~1Server/%~1Server.csproj"
