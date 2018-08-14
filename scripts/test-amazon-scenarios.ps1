Set-Location $PSScriptRoot

dotnet build ./../Amazon.Features/Amazon.Features.csproj 

dotnet test ./../Amazon.Features/Amazon.Features.csproj -v n --no-build `
--filter FullyQualifiedName=Amazon.Features.SearchingProducts.SearchingAllProducts.SearchWithSearchButton `
| Out-file -FilePath ./../Amazon.Features/test-output/MSTestFirstPassingScenarioOutput.txt

dotnet test ./../Amazon.Features/Amazon.Features.csproj -v n --no-build `
--filter FullyQualifiedName=Amazon.Features.SearchingProducts.SearchingAllProducts_Failing.SearchWithSearchButton_Failing `
| Out-file -FilePath ./../Amazon.Features/test-output/MSTestFirstFailingScenarioOutput.txt
