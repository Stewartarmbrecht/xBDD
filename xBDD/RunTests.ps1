Param([string]$conn="")

if($conn -ne "")
{
	$env:Data:DefaultConnection:ConnectionString=$conn
}

dnu restore
dnx $PSScriptRoot\test\xBDD.Test test
.\xsltproc $PSScriptRoot\TestResults.xml $PSScriptRoot\NUnitXml.xslt $PSScriptRoot\NUnitTestResults.xml
