$Env:xBDD:HtmlReport:RemoveFromAreaNameStart="My Sample - Features - "
$Env:xBDD:HtmlReport:FailuresOnly="false"
$Env:xBDD:SortTestRun="true"
$Env:xBDD:FullySortTestRun="true"
$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.All.FullSorted.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.All.FullSorted.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.All.FullSorted.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.All.FullSorted.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.All.FullSorted.Output.txt
