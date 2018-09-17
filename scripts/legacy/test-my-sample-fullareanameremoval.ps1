$Env:xBDD:HtmlReport:RemoveFromCapabilityNameStart="My Sample - Features - My Capability 1 All Passing"
$Env:xBDD:HtmlReport:FailuresOnly="false"
$Env:xBDD:SortTestRun="true"
$Env:xBDD:FullySortTestRun="false"
$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.FullCapabilityNameRemoval.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.FullCapabilityNameRemoval.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.FullCapabilityNameRemoval.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.FullCapabilityNameRemoval.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build --filter MyCapability_1 `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.FullCapabilityNameRemoval.Output.txt
