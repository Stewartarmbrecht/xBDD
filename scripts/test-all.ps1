Set-Location $PSScriptRoot

./deploy-tools.ps1

Set-Location "../"

dotnet test

dotnet xbdd solution summarize --config-file .\LocalTestSummaryConfig.json

dotnet xbdd solution summarize --config-file .\GithubTestSummaryConfig.json