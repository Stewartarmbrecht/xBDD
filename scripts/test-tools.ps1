Set-Location $PSScriptRoot
./deploy-tools.ps1
Remove-Item ./../MySample.Generated.Features/* -Recurse -Force
Set-Location ./../MySample.Generated.Features/
dotnet xbdd init MSTest
dotnet test
Set-Location $PSScriptRoot