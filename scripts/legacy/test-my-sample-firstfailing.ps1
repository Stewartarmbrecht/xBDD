$Env:xBDD:HtmlReport:RemoveFromAreaNameStart="My Sample - Features - "
$Env:xBDD:HtmlReport:FailuresOnly="false"
$Env:xBDD:SortTestRun="true"
$Env:xBDD:FullySortTestRun="false"
$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.FirstFailing.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.FirstFailing.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.FirstFailing.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.FirstFailing.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build --filter MyFirstFailingFeature `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.FirstFailing.Output.txt
