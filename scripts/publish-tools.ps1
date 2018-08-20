Set-Location $PSScriptRoot
dotnet build ./../xBDD.Tools/xBDD.Tools.csproj -c Release
Set-Location $PSScriptRoot/../xBDD.Tools/bin/Release/
dotnet nuget push dotnet-xbdd.$Env:VERSION.nupkg -k $Env:PUBLISH_KEY -s https://api.nuget.org/v3/index.json