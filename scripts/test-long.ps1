Set-Location $PSScriptRoot

dotnet build ./../xBDD.Features/xBDD.Features.csproj 
dotnet test ./../xBDD.Features/xBDD.Features.csproj -v n --no-build --filter TestCategory=Long
