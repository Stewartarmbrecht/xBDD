$Env:xBDD:HtmlReport:RemoveFromCapabilityNameStart="My Sample - Features - "
$Env:xBDD:HtmlReport:FailuresOnly="true"
$Env:xBDD:SortTestRun="true"
$Env:xBDD:FullySortTestRun="false"
$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.AllFailuresOnly.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.AllFailuresOnly.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.AllFailuresOnly.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.AllFailuresOnly.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.AllFailuresOnly.Output.txt
