dnu restore
dnx $PSScriptRoot\test\xBDD.Test test
.\xsltproc $PSScriptRoot\TestResults.xml $PSScriptRoot\NUnitXml.xslt $PSScriptRoot\NUnitTestResults.xml
