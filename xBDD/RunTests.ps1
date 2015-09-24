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

dnx $PSScriptRoot\src\xBDD.Reporting.Database\ ef migration apply

Write-Host "Running xBDD.Test Tests"
dnx $PSScriptRoot\test\xBDD.Test test

Write-Host "Running xBDD.Core.Test Tests"
dnx $PSScriptRoot\test\xBDD.Core.Test test

Write-Host "Running xBDD.Reporting.Test Tests"
dnx $PSScriptRoot\test\xBDD.Reporting.Test test

Write-Host "Running xBDD.Reporting.Database.Test Tests"
dnx $PSScriptRoot\test\xBDD.Reporting.Database.Test test
