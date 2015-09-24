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

dnu restore

Write-Host "Upgrading the database"
Set-Location $PSScriptRoot\src\xBDD.Reporting.Database
dnx ef database update

Write-Host "Running xBDD.Test Tests"
Set-Location $PSScriptRoot\test\xBDD.Test
dnx test

Write-Host "Running xBDD.Core.Test Tests"
Set-Location $PSScriptRoot\test\xBDD.Core.Test 
dnx test

Write-Host "Running xBDD.Reporting.Test Tests"
Set-Location $PSScriptRoot\test\xBDD.Reporting.Test 
dnx test

Write-Host "Running xBDD.Reporting.Database.Test Tests"
Set-Location $PSScriptRoot\test\xBDD.Reporting.Database.Test 
dnx test

Set-Location $PSScriptRoot
