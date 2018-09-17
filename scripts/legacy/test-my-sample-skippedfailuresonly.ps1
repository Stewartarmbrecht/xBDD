$Env:xBDD:HtmlReport:RemoveFromCapabilityNameStart="My Sample - Features - "
$Env:xBDD:HtmlReport:FailuresOnly="true"
$Env:xBDD:SortTestRun="true"
$Env:xBDD:FullySortTestRun="false"
$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.SkippedFailuresOnly.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.SkippedFailuresOnly.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.SkippedFailuresOnly.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.SkippedFailuresOnly.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build --filter MyCapability_2 `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.SkippedFailuresOnly.Output.txt
