$Env:xBDD:HtmlReport:RemoveFromCapabilityNameStart="No Match"
$Env:xBDD:HtmlReport:FailuresOnly="false"
$Env:xBDD:SortTestRun="true"
$Env:xBDD:FullySortTestRun="false"
$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.NoCapabilityNameRemoval.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.NoCapabilityNameRemoval.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.NoCapabilityNameRemoval.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.NoCapabilityNameRemoval.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build --filter MyCapability_1 `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.NoCapabilityNameRemoval.Output.txt
