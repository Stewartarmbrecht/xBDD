Set-Location $PSScriptRoot

dotnet build ./../shared/xBDD.Test/xBDD.Test.csproj 
dotnet test ./../shared/xBDD.Test/xBDD.Test.csproj -v n --no-build

dotnet build ./../core/xBDD.Core.Features/xBDD.Core.Features.csproj 
dotnet test ./../core/xBDD.Core.Features/xBDD.Core.Features.csproj -v n --no-build

dotnet build ./../reporting/xBDD.Reporting.Features/xBDD.Reporting.Features.csproj
dotnet test ./../reporting/xBDD.Reporting.Features/xBDD.Reporting.Features.csproj -v n --no-build

dotnet build ./../reporting.database/xBDD.Reporting.Database.Test/xBDD.Reporting.Database.Test.csproj
dotnet test ./../reporting.database/xBDD.Reporting.Database.Test/xBDD.Reporting.Database.Test.csproj -v n --no-build

dotnet build ./../sample/xBDD.SampleApp.Test/xBDD.SampleApp.Test.csproj
dotnet test ./../sample/xBDD.SampleApp.Test/xBDD.SampleApp.Test.csproj -v n --no-build