Set-Location $PSScriptRoot
dotnet build ./../reporting/xBDD.Reporting.Features/xBDD.Reporting.Features.csproj 
dotnet test ./../reporting/xBDD.Reporting.Features/xBDD.Reporting.Features.csproj -v n --no-build