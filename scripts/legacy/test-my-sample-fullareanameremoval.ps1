$Env:xBDD:HtmlReport:RemoveFromAreaNameStart="My Sample - Features - My Area 1 All Passing"
$Env:xBDD:HtmlReport:FailuresOnly="false"
$Env:xBDD:SortTestRun="true"
$Env:xBDD:FullySortTestRun="false"
$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.FullAreaNameRemoval.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.FullAreaNameRemoval.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.FullAreaNameRemoval.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.FullAreaNameRemoval.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build --filter MyArea_1 `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.FullAreaNameRemoval.Output.txt
