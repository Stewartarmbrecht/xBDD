Set-Location $PSScriptRoot
dotnet build ./../reporting/xBDD.Reporting.Test/xBDD.Reporting.Test.csproj 
dotnet test ./../reporting/xBDD.Reporting.Test/xBDD.Reporting.Test.csproj -v n --no-build