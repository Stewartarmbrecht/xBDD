$Env:xBDD:HtmlReport:RemoveFromCapabilityNameStart="My Sample - Features - "
$Env:xBDD:SortTestRun="true"
$Env:xBDD:FullySortTestRun="false"
$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.FirstPassing.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.FirstPassing.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.FirstPassing.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.FirstPassing.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build --filter MyFirstFeature `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.FirstPassing.Output.txt

