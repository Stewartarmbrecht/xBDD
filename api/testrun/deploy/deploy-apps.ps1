param([String]$namePrefix,[String]$region)
if (!$namePrefix) {
    $namePrefix = $Env:namePrefix
}
if (!$region) {
    $region = $Env:region
}
$loggingPrefix = "TestRun Deployment ($namePrefix)"
$resourceGroupName = "$namePrefix-testrun"
$apiName = "$namePrefix-testrun-api"
$apiFilePath = "./xBDD.TestRun.Api.zip"

Set-Location "$PSSCriptRoot"

. ./../../scripts/functions.ps1

if (!$namePrefix) {
    D "Either pass in the '-namePrefix' parameter when calling this script or 
    set and environment variable with the name: 'namePrefix'." $loggingPrefix
}
if (!$region) {
    D "Either pass in the '-region' parameter when calling this script or 
    set and environment variable with the name: 'region'." $loggingPrefix
}
# Audio Microservice Deploy

$command = "az webapp deployment source config-zip --resource-group $resourceGroupName --name $apiName --src $apiFilePath"
$result = ExecuteCommand $command $loggingPrefix "Deploying the API application."