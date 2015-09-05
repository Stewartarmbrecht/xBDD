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

dnx $PSScriptRoot\src\xBDD.Database\ ef migration apply

if(Test-Path $PSScriptRoot\TestResults.xml)
{
	Write-Host "Removing TestResults.xml"
	Remove-Item $PSScriptRoot\TestResults.xml
}

if(Test-Path $PSScriptRoot\NUnitTestResults.xml)
{
	Write-Host "Removing NUnitTestResults.xml"
	Remove-Item $PSScriptRoot\NUnitTestResults.xml
}

Write-Host "Running Tests"
dnx $PSScriptRoot\test\xBDD.Test test

Write-Host "Converting TestResults.xml to NUnitTestResults.xml"
.\xsltproc $PSScriptRoot\TestResults.xml $PSScriptRoot\NUnitXml.xslt $PSScriptRoot\NUnitTestResults.xml
