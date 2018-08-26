param([string]$ProjectName,[string]$ProjectRoot,[string]$DeployTools)
$CurrentLocation = Get-Location
$ProjectNamespace = $ProjectName -replace ' ', ''
$ProjectAreaNameSkipRoot = $ProjectRoot -replace '.',' - '

Set-Location $PSScriptRoot
If ($DeployTools -eq "true") {
    ./deploy-tools.ps1 
}

./code-clean-outline.ps1 "./../$ProjectRoot.Features.$ProjectNamespace/FeatureOutline.txt"

Set-Location "$PSScriptRoot./../$ProjectRoot.Features.$ProjectNamespace/"

dotnet xbdd convert `
--source ./FeatureOutline.txt `
--source-format Text `
--text-indentation "`t" `
--default-skipped-reason "Untested" `
--destination ./ `
--destination-format code `
--root-namespace "$ProjectRoot.Features.$ProjectNamespace" `
--features-only True `
--area-name-skip "$ProjectAreaNameSkipRoot - Features - $ProjectName - " `
--testrun-name "$ProjectRoot $ProjectName"

dotnet test

Set-Location $CurrentLocation