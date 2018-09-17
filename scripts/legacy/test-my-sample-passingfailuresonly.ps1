$Env:xBDD:HtmlReport:RemoveFromCapabilityNameStart="My Sample - Features - "
$Env:xBDD:HtmlReport:FailuresOnly="true"
$Env:xBDD:SortTestRun="true"
$Env:xBDD:FullySortTestRun="false"
$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.PassingFailuresOnly.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.PassingFailuresOnly.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.PassingFailuresOnly.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.PassingFailuresOnly.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build --filter MyCapability_1 `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.PassingFailuresOnly.Output.txt

