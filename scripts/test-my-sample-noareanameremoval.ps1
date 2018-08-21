$Env:xBDD:HtmlReport:RemoveFromAreaNameStart="No Match"
$Env:xBDD:HtmlReport:FailuresOnly="false"
$Env:xBDD:SortTestRun="true"
$Env:xBDD:FullySortTestRun="false"
$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.NoAreaNameRemoval.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.NoAreaNameRemoval.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.NoAreaNameRemoval.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.NoAreaNameRemoval.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build --filter MyArea_1 `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.NoAreaNameRemoval.Output.txt
