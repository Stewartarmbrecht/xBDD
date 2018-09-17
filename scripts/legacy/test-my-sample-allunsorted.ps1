$Env:xBDD:HtmlReport:RemoveFromCapabilityNameStart="My Sample - Features - "
$Env:xBDD:HtmlReport:FailuresOnly="false"
$Env:xBDD:SortTestRun="false"
$Env:xBDD:FullySortTestRun="false"
$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.All.UnSorted.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.All.UnSorted.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.All.UnSorted.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.All.UnSorted.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.All.UnSorted.Output.txt

