$Env:xBDD:HtmlReport:RemoveFromCapabilityNameStart="My Sample - Features - "
$Env:xBDD:HtmlReport:FailuresOnly="false"
$Env:xBDD:SortTestRun="true"
$Env:xBDD:FullySortTestRun="false"
$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.None.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.None.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.None.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.None.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build --filter NoMatchAtAll `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.None.Output.txt

