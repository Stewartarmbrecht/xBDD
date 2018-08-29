param([string]$ProjectName,[string]$ProjectRootName,[string]$DeployTools)
$CurrentLocation = Get-Location
$ProjectNamespace = $ProjectName -replace ' ', ''
$ProjectRoot = ($ProjectRootName -replace ' ','') -replace ' - ', '\.'

Set-Location $PSScriptRoot
If ($DeployTools -eq "true") {
    ./deploy-tools.ps1 
}

./code-clean-outline.ps1 "./../$ProjectRoot.Features.$ProjectNamespace/xBDDFeatureImport.txt"

Set-Location "$PSScriptRoot./../$ProjectRoot.Features.$ProjectNamespace/"

dotnet xbdd convert `
--source ./FeatureOutline.txt `
--source-format Text `
--text-indentation "`t" `
--default-outcome "Passed" `
--destination ./ `
--destination-format code `
--root-namespace "$ProjectRoot.Features.$ProjectNamespace" `
--features-only False `
--area-name-skip "$ProjectRootName - Features - $ProjectName - " `
--testrun-name "$ProjectRootName $ProjectName"

dotnet test

Set-Location $CurrentLocation