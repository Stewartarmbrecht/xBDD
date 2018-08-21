dotnet build ./../MySample.Features/bin/Debug/netcoreapp2.1/Code/MySample.Features.csproj 
dotnet test ./../MySample.Features/bin/Debug/netcoreapp2.1/Code/MySample.Features.csproj -v n --no-build `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.Generated.Output.txt
