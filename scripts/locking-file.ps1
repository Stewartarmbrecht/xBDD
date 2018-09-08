Set-Location $PSScriptRoot
IF((Test-Path -Path "./../xBDD.Features/bin/Debug/netcoreapp2.1/chromedriver.exe") -eq $false) {
    Write-Warning "File or directory does not exist."       
}
Else {
    $LockingProcess = CMD /C "openfiles /query /fo table | find /I ""$FileOrFolderPath"""
    Write-Host $LockingProcess
}