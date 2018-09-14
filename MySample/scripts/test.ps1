Set-Location $PSScriptRoot

Set-Location "../"

dotnet build ./../xBDD.Tools/xBDD.Tools.csproj -c Release
dotnet tool uninstall -g dotnet-xbdd
dotnet tool install -g dotnet-xbdd --add-source ./../xBDD.Tools/bin/Release/ --version 0.0.8-alpha

dotnet test

dotnet xbdd solution summarize --config-file LocalTestSummaryConfig.json
dotnet xbdd solution summarize --config-file GithubTestSummaryConfig.json
