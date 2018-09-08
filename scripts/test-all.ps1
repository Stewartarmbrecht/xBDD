Set-Location $PSScriptRoot

Set-Location "../"

dotnet test

dotnet xbdd solution summarize `
--output xBDD.Features.Summary.html `
--name "xBDD - Features" `
--testrun-name-clip "xBDD - Features - " `
--reason-order "Removing,Untested,Committed,Ready,Defining" `
./xBDD.Features.GeneratingCode/test-results/xBDD.Features.GeneratingCode.Results.json `
./xBDD.Features.GeneratingCode/test-results/xBDD.Features.GeneratingCode.Results.html `
./xBDD.Features.DefiningFeatures/test-results/xBDD.Features.DefiningFeatures.Results.json `
./xBDD.Features.DefiningFeatures/test-results/xBDD.Features.DefiningFeatures.Results.html `
./xBDD.Features.AutomatingUITesting/test-results/xBDD.Features.AutomatingUITesting.Results.json `
./xBDD.Features.AutomatingUITesting/test-results/xBDD.Features.AutomatingUITesting.Results.html `
./xBDD.Features.StreamliningAPITesting/test-results/xBDD.Features.StreamliningAPITesting.Results.json `
./xBDD.Features.StreamliningAPITesting/test-results/xBDD.Features.StreamliningAPITesting.Results.html `
./xBDD.Features.RunningScenarios/test-results/xBDD.Features.RunningScenarios.Results.json `
./xBDD.Features.RunningScenarios/test-results/xBDD.Features.RunningScenarios.Results.html `
./xBDD.Features.GeneratingReports/test-results/xBDD.Features.GeneratingReports.Results.json `
./xBDD.Features.GeneratingReports/test-results/xBDD.Features.GeneratingReports.Results.html