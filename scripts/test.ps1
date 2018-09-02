param([string]$ProjectFolder, [string]$FailuresOnly, [string]$DeployTools, [string]$FilterToNow)
Set-Location $PSScriptRoot

Write-Output "ProjectFolder: $ProjectFolder"
Write-Output "FailuresOnlyt: $FailuresOnly"
Write-Output "DeployTools: $DeployTools"
Write-Output "FilterToNow: $FilterToNow"

if($DeployTools -eq "true") {
    ./deploy-tools.ps1
} else {
    dotnet build ./../$ProjectFolder/$ProjectFolder.csproj 
}

if($FailuresOnly -eq "true") {
    $Env:xBDD:HtmlReport:FailuresOnly = "true"    
}

$Filter = ""

if($FilterToNow -eq "true") {
    $Filter = "--filter `"TestCategory=Now`""
}

Write-Output "dotnet test ./../$ProjectFolder/$ProjectFolder.csproj -v n --no-build $Filter "
iex "dotnet test ./../$ProjectFolder/$ProjectFolder.csproj -v n --no-build $Filter"
