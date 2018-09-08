Set-Location $PSScriptRoot

Set-Location "../"

dotnet build ./../xBDD.Tools/xBDD.Tools.csproj -c Release
dotnet tool uninstall -g dotnet-xbdd
dotnet tool install -g dotnet-xbdd --add-source ./../xBDD.Tools/bin/Release/ --version 0.0.8-alpha

dotnet test

dotnet xbdd solution summarize `
--output MySample.TestSummary.html `
--name "My Sample - Features" `
--testrun-name-clip "My Sample - Features - " `
--reason-order "Untested,Committed,Ready,Defining" `
./MySample.Features.TestRun1Passing/test-results/MySample.Features.TestRun1Passing.Results.json `
./MySample.Features.TestRun1Passing/test-results/MySample.Features.TestRun1Passing.Results.html `
./MySample.Features.TestRun2SkippedUntested/test-results/MySample.Features.TestRun2SkippedUntested.Results.json `
./MySample.Features.TestRun2SkippedUntested/test-results/MySample.Features.TestRun2SkippedUntested.Results.html `
./MySample.Features.TestRun3SkippedCommitted/test-results/MySample.Features.TestRun3SkippedCommitted.Results.json `
./MySample.Features.TestRun3SkippedCommitted/test-results/MySample.Features.TestRun3SkippedCommitted.Results.html `
./MySample.Features.TestRun4SkippedReady/test-results/MySample.Features.TestRun4SkippedReady.Results.json `
./MySample.Features.TestRun4SkippedReady/test-results/MySample.Features.TestRun4SkippedReady.Results.html `
./MySample.Features.TestRun5SkippedDefining/test-results/MySample.Features.TestRun5SkippedDefining.Results.json `
./MySample.Features.TestRun5SkippedDefining/test-results/MySample.Features.TestRun5SkippedDefining.Results.html `
./MySample.Features.TestRun6Failed/test-results/MySample.Features.TestRun6Failed.Results.json `
./MySample.Features.TestRun6Failed/test-results/MySample.Features.TestRun6Failed.Results.html

