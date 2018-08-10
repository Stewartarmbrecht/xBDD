Set-Location $PSScriptRoot

dotnet build ./../Amazon.Features/Amazon.Features.csproj
dotnet test ./../Amazon.Features/Amazon.Features.csproj -v n --no-build | Out-File -FilePath ./../Amazon.Features/bin/Debug/netcoreapp2.1/Amazon.Features.TestOutput.txt
