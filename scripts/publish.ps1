Set-Location $PSScriptRoot
dotnet build ./../xBDD/xBDD.csproj -c Release
Set-Location $PSScriptRoot/../xBDD/bin/Release/
dotnet nuget push xBDD.$Env:VERSION.nupkg -k $Env:PUBLISH_KEY -s https://api.nuget.org/v3/index.json