mkdir "%~1"
Cd "%~1"
dotnet new sln --name "%~1"
cd ..
dotnet new console -o "%~1"
dotnet sln "%~1/%~1.sln" add "./%~1/%~1.csproj"
