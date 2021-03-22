Set UserSecretsId to '2cefd9c5-852a-4e28-b804-81f37d8e2299' for MSBuild project '/Users/carlos/Workspace/list-of-lists/list-of-lists-webapp/list-of-lists-webapp.csproj'.

dotnet user-secrets set ConnectionStrings:Lists "Data Source=77.75.120.158; Database=Lists; User Id=carlos; password=juliovoltio"

Connection string: 
Data Source=77.75.120.158; Database=Lists; User Id=carlos; password=juliovoltio

dotnet ef dbcontext scaffold Name=ConnectionStrings:Lists Microsoft.EntityFrameworkCore.SqlServer --context-dir Data --output-dir Data/Models


Continue reading: 
- https://docs.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-5.0&tabs=netcore-cli
- https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli
- https://docs.identityserver.io/en/latest/quickstarts/6_aspnet_identity.html

