param([string]$ProjectName,[bool]$DeployTools)
$CurrentLocation = Get-Location
$ProjectNamespace = $ProjectName -replace ' ', ''

Set-Location $PSScriptRoot
If ($DeployTools) {
    ./deploy-tools.ps1 
}

./code-clean-outline.ps1 "./../xBDD.Features.$ProjectNamespace/FeatureOutline.txt"

Set-Location "$PSScriptRoot./../xBDD.Features.$ProjectNamespace/"

dotnet xbdd code -s ./FeatureOutline.txt -st Text -d ./ -i "`t" -rn "xBDD.Features.$ProjectNamespace" -fo False -sr "Not Tested" -ran "xBDD - Features - $ProjectName - "

dotnet test

Set-Location $CurrentLocation