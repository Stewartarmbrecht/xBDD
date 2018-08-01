Param([string]$conn="")

$env:Environment="Publish"

if($conn -ne "")
{
	$env:Data:DefaultConnection:ConnectionString=$conn
	Write-Host "Connection string set."
}
else
{
	Write-Host "Connection string NOT set."
}

Write-Host "Upgrading the database"
Set-Location $PSScriptRoot\test\xBDD.Test
dotnet build
dotnet ef database update -s xBDD.Test.csproj -p ../../src/xBDD.Reporting.Database/xBDD.Reporting.Database.csproj -c DatabaseContext

Write-Host "Running xBDD.Test Tests"
Set-Location $PSScriptRoot\test\xBDD.Test
dotnet build
dotnet test -v n --no-build --no-restore

Write-Host "Running xBDD.Core.Test Tests"
Set-Location $PSScriptRoot\test\xBDD.Core.Test 
dotnet build
dotnet test -v n --no-build --no-restore

Write-Host "Running xBDD.Reporting.Test Tests"
Set-Location $PSScriptRoot\test\xBDD.Reporting.Test 
dotnet build
dotnet test -v n --no-build --no-restore

Write-Host "Running xBDD.Reporting.Database.Test Tests"
Set-Location $PSScriptRoot\test\xBDD.Reporting.Database.Test 
dotnet build
dotnet test -v n --no-build --no-restore

Set-Location $PSScriptRoot
