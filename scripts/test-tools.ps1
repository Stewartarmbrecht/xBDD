Set-Location $PSScriptRoot
./deploy-tools.ps1
Remove-Item ./../MySample.Generated/* -Recurse -Force
Set-Location ./../MySample.Generated/
dotnet xbdd init
dotnet test
Set-Location $PSScriptRoot