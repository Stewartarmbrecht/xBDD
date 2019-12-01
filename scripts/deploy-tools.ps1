Set-Location $PSScriptRoot
dotnet build ./../xBDD.Tools/xBDD.Tools.csproj -c Release
dotnet tool uninstall -g dotnet-xbdd
dotnet tool install -g dotnet-xbdd --add-source ./../xBDD.Tools/bin/Release/ --version $Env:VERSION