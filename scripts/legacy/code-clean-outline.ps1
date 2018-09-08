param([string]$filePath)
Set-Location $PSScriptRoot
#(Get-Content ./../xBDD.Features.DefiningFeatures/FeatureOutline.txt) -replace [environment]::NewLine + "`- ", [environment]::NewLine | 
#    Set-Content ./../xBDD.Features.DefiningFeatures/FeatureOutline.txt
(Get-Content $filePath -Raw) -replace "`n`- ", "`n" | 
    Set-Content $filePath
(Get-Content $filePath) -replace "  `- ", "`t" | 
    Set-Content $filePath
(Get-Content $filePath) -replace "  ", "`t" | 
    Set-Content $filePath