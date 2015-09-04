Param([string]$conn="")

if($conn -ne "")
{
	$env:Data:DefaultConnection:ConnectionSrting=$conn
	$env:Data:DefaultConnection:ConnectionSrting
}

dnu restore
dnx $PSScriptRoot\test\xBDD.Test test
.\xsltproc $PSScriptRoot\TestResults.xml $PSScriptRoot\NUnitXml.xslt $PSScriptRoot\NUnitTestResults.xml
