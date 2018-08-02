$microserviceName = "TestRun"
$loggingPrefix = "$microserviceName Test"

Set-Location "$PSSCriptRoot/../"

. ./../scripts/functions.ps1

$directoryStart = Get-Location

Set-Location "$directoryStart\src\xBDD.$microserviceName"
$results = ExecuteCommand "dotnet build" $loggingPrefix "Building the solution."

Set-Location "$directoryStart\src\xBDD.$microserviceName\xBDD.$microserviceName.services.tests"
$results = ExecuteCommand "dotnet test --logger ""trx;logFileName=testResults.trx""" $loggingPrefix "Testing the solution."

