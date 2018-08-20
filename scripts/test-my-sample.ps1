Set-Location $PSScriptRoot

dotnet build ./../MySample.Features/MySample.Features.csproj 

$Env:xBDD:HtmlReport:RemoveFromAreaNameStart="My Sample - Features - "
$Env:xBDD:SortTestRun="true"
$Env:xBDD:FullySortTestRun="false"
$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.FirstPassing.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.FirstPassing.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.FirstPassing.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.FirstPassing.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build --filter MyFirstFeature `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.FirstPassing.Output.txt

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

$Env:xBDD:HtmlReport:RemoveFromAreaNameStart="My Sample - Features - "
$Env:xBDD:HtmlReport:FailuresOnly="false"
$Env:xBDD:SortTestRun="true"
$Env:xBDD:FullySortTestRun="false"
$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.Passing.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.Passing.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.Passing.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.Passing.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build --filter MyArea_1 `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.Passing.Output.txt

$Env:xBDD:HtmlReport:RemoveFromAreaNameStart="My Sample - Features - "
$Env:xBDD:HtmlReport:FailuresOnly="true"
$Env:xBDD:SortTestRun="true"
$Env:xBDD:FullySortTestRun="false"
$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.PassingFailuresOnly.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.PassingFailuresOnly.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.PassingFailuresOnly.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.PassingFailuresOnly.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build --filter MyArea_1 `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.PassingFailuresOnly.Output.txt

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

$Env:xBDD:HtmlReport:RemoveFromAreaNameStart="My Sample - Features - "
$Env:xBDD:HtmlReport:FailuresOnly="false"
$Env:xBDD:SortTestRun="true"
$Env:xBDD:FullySortTestRun="false"
$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.Skipped.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.Skipped.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.Skipped.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.Skipped.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build --filter MyArea_2 `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.Skipped.Output.txt

$Env:xBDD:HtmlReport:RemoveFromAreaNameStart="My Sample - Features - "
$Env:xBDD:HtmlReport:FailuresOnly="true"
$Env:xBDD:SortTestRun="true"
$Env:xBDD:FullySortTestRun="false"
$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.SkippedFailuresOnly.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.SkippedFailuresOnly.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.SkippedFailuresOnly.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.SkippedFailuresOnly.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build --filter MyArea_2 `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.SkippedFailuresOnly.Output.txt

$Env:xBDD:HtmlReport:RemoveFromAreaNameStart="My Sample - Features - "
$Env:xBDD:HtmlReport:FailuresOnly="false"
$Env:xBDD:SortTestRun="true"
$Env:xBDD:FullySortTestRun="false"
$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.All.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.All.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.All.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.All.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.All.Output.txt

$Env:xBDD:HtmlReport:RemoveFromAreaNameStart="My Sample - Features - "
$Env:xBDD:HtmlReport:FailuresOnly="true"
$Env:xBDD:SortTestRun="true"
$Env:xBDD:FullySortTestRun="false"
$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.AllFailuresOnly.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.AllFailuresOnly.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.AllFailuresOnly.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.AllFailuresOnly.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.AllFailuresOnly.Output.txt

$Env:xBDD:HtmlReport:RemoveFromAreaNameStart="My Sample - Features - "
$Env:xBDD:HtmlReport:FailuresOnly="false"
$Env:xBDD:SortTestRun="false"
$Env:xBDD:FullySortTestRun="false"
$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.All.UnSorted.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.All.UnSorted.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.All.UnSorted.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.All.UnSorted.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.All.UnSorted.Output.txt

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

$Env:xBDD:HtmlReport:RemoveFromAreaNameStart="My Sample - Features - "
$Env:xBDD:HtmlReport:FailuresOnly="false"
$Env:xBDD:SortTestRun="true"
$Env:xBDD:FullySortTestRun="false"
$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.None.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.None.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.None.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.None.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build --filter NoMatchAtAll `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.None.Output.txt

$Env:xBDD:HtmlReport:RemoveFromAreaNameStart="My Sample - Features - "
$Env:xBDD:HtmlReport:FailuresOnly="false"
$Env:xBDD:FullySortTestRun="false"
$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.NoScenarios.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.NoScenarios.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.NoScenarios.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.NoScenarios.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build --filter NoScenarios `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.NoScenarios.Output.txt

dotnet build ./../MySample.Features/bin/Debug/netcoreapp2.1/Code/MySample.Features.csproj 
dotnet test ./../MySample.Features/bin/Debug/netcoreapp2.1/Code/MySample.Features.csproj -v n --no-build `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.Generated.Output.txt
