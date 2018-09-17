$Env:xBDD:HtmlReport:RemoveFromCapabilityNameStart="My Sample - Features - "
$Env:xBDD:HtmlReport:FailuresOnly="false"
$Env:xBDD:FullySortTestRun="false"
$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.NoScenarios.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.NoScenarios.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.NoScenarios.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.NoScenarios.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build --filter NoScenarios `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.NoScenarios.Output.txt

