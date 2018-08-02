$microserviceName = "TestRun"
$loggingPrefix = "$microserviceName Build"

Set-Location "$PSSCriptRoot/../"

. ./../scripts/functions.ps1

$directoryStart = Get-Location

Set-Location "$directoryStart\src\xBDD.$microserviceName"
$results = ExecuteCommand "dotnet build" $loggingPrefix "Building the solution."