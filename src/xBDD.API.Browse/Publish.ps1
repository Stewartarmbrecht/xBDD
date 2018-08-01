param([string]$u="",[string]$p="")

dotnet build
dotnet publish

Set-Location $PSScriptRoot/bin/debug/netstandard2.0

az login -u $u -p $p

az functionapp config appsettings set --name xbdd-browse --resource-group xbddresourcegroup --settings FUNCTIONS_EXTENSION_VERSION=~1

func azure functionapp publish xbdd-browse

az functionapp config appsettings set --name xbdd-browse --resource-group xbddresourcegroup --settings FUNCTIONS_EXTENSION_VERSION=beta 

Set-Location $PSScriptRoot
