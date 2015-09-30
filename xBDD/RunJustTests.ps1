Write-Host "Running xBDD.Test Tests"
Set-Location $PSScriptRoot\test\xBDD.Test
dnx test | Out-File xBDD.Test.Output.txt

Write-Host "Running xBDD.Core.Test Tests"
Set-Location $PSScriptRoot\test\xBDD.Core.Test 
dnx test | Out-File xBDD.Core.Test.Output.txt

Write-Host "Running xBDD.Reporting.Test Tests"
Set-Location $PSScriptRoot\test\xBDD.Reporting.Test 
dnx test | Out-File xBDD.Reporting.Test.Output.txt

Write-Host "Running xBDD.Reporting.Database.Test Tests"
Set-Location $PSScriptRoot\test\xBDD.Reporting.Database.Test 
dnx test | Out-File xBDD.Reporting.Database.Test.Output.txt

Set-Location $PSScriptRoot
