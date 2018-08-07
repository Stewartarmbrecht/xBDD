Set-Location $PSScriptRoot
dotnet build ./../core/xBDD.Core.Features/xBDD.Core.Features.csproj 
dotnet test ./../core/xBDD.Core.Features/xBDD.Core.Features.csproj -v n --no-build