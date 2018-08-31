param([string]$ProjectFolder)
Set-Location $PSScriptRoot

dotnet build ./../$ProjectFolder/$ProjectFolder.csproj 
dotnet test ./../$ProjectFolder/$ProjectFolder.csproj -v n --no-build
