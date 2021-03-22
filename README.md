
Connection string: 
Data Source=77.75.120.158; Database=Lists; User Id=carlos; password=juliovoltio


dotnet user-secrets init
dotnet user-secrets set ConnectionStrings:Lists "Data Source=77.75.120.158; Database=Lists; User Id=carlos; password=juliovoltio"

dotnet ef dbcontext scaffold Name=ConnectionStrings:Lists Microsoft.EntityFrameworkCore.SqlServer --context-dir Data --output-dir Data/Models


Continue reading: 
- https://docs.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-5.0&tabs=netcore-cli
- https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli
- https://docs.identityserver.io/en/latest/quickstarts/6_aspnet_identity.html

