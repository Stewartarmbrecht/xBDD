param([string]$ProjectName,[string]$DeployTools)
$CurrentLocation = Get-Location
$ProjectNamespace = $ProjectName -replace ' ', ''

Set-Location $PSScriptRoot
If ($DeployTools -eq "true") {
    ./deploy-tools.ps1 
}

./code-clean-outline.ps1 "./../xBDD.Features.$ProjectNamespace/FeatureOutline.txt"

Set-Location "$PSScriptRoot./../xBDD.Features.$ProjectNamespace/"

dotnet xbdd code -s ./FeatureOutline.txt -st Text -d ./ -i "`t" -rn "xBDD.Features.$ProjectNamespace" -fo False -sr "Untested" -ran "xBDD - Features - $ProjectName - " -trn "xBDD $ProjectName"

dotnet test

Set-Location $CurrentLocation