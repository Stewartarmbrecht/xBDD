Set-Location $PSScriptRoot

dotnet build ./../MySample.Features/MySample.Features.csproj 

$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.FirstPassing.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.FirstPassing.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.FirstPassing.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.FirstPassing.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build --filter MyFirstFeature `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.FirstPassing.Output.txt

$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.FirstFailing.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.FirstFailing.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.FirstFailing.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.FirstFailing.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build --filter MyFirstFailingFeature `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.FirstFailing.Output.txt

$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.Passing.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.Passing.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.Passing.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.Passing.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build --filter MyArea_1 `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.Passing.Output.txt

$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.Skipped.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.Skipped.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.Skipped.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.Skipped.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build --filter MyArea_2 `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.Skipped.Output.txt

$Env:xBDD:HtmlReport:FileName="MySample.Features.Results.All.html"
$Env:xBDD:JsonReport:FileName="MySample.Features.Results.All.json"
$Env:xBDD:TextReport:FileName="MySample.Features.Results.All.txt"
$Env:xBDD:OutlineReport:FileName="MySample.Features.Results.All.opml"

dotnet test ./../MySample.Features/MySample.Features.csproj -v n --no-build `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.All.Output.txt

dotnet build ./../MySample.Features/bin/Debug/netcoreapp2.1/Code/MySample.Features.csproj 
dotnet test ./../MySample.Features/bin/Debug/netcoreapp2.1/Code/MySample.Features.csproj -v n --no-build `
| Out-File -FilePath ./../MySample.Features/test-results/MySample.Features.Results.Generated.Output.txt
