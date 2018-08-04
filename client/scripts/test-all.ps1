Set-Location $PSScriptRoot

dotnet build ./../core/xBDD.Core.Test/xBDD.Core.Test.csproj 
dotnet test ./../core/xBDD.Core.Test/xBDD.Core.Test.csproj -v n --no-build

dotnet build ./../reporting/xBDD.Reporting.Test/xBDD.Reporting.Test.csproj
dotnet test ./../reporting/xBDD.Reporting.Test/xBDD.Reporting.Test.csproj -v n --no-build

dotnet build ./../reporting.database/xBDD.Reporting.Database.Test/xBDD.Reporting.Database.Test.csproj
dotnet test ./../reporting.database/xBDD.Reporting.Database.Test/xBDD.Reporting.Database.Test.csproj -v n --no-build

dotnet build ./../sample/xBDD.SampleApp.Test/xBDD.SampleApp.Test.csproj
dotnet test ./../sample/xBDD.SampleApp.Test/xBDD.SampleApp.Test.csproj -v n --no-build