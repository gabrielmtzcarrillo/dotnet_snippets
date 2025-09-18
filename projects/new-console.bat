dotnet new sln --name "%~1"
dotnet new console -o "%~1"
dotnet sln "%~1.sln" add "./%~1/%~1.csproj"
