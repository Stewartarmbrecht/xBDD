$Env:xBDD:HtmlReport:RemoveFromAreaNameStart="My Sample - Features - "
$Env:xBDD:HtmlReport:FailuresOnly="false"
$Env:xBDD:SortTestRun="true"
$Env:xBDD:FullySortTestRun="false"
$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.Skipped.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.Skipped.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.Skipped.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.Skipped.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build --filter MyArea_2 `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.Skipped.Output.txt
