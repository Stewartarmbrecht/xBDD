Set-Location $PSScriptRoot

dotnet build ./../xBDD.Features/xBDD.Features.csproj 
dotnet test ./../xBDD.Features/xBDD.Features.csproj -v n --no-build

dotnet build ./../xBDD.Features.DefiningFeatures/xBDD.Features.DefiningFeatures.csproj 
dotnet test ./../xBDD.Features.DefiningFeatures/xBDD.Features.DefiningFeatures.csproj -v n --no-build

dotnet build ./../xBDD.Features.AutomatingUITEsting/xBDD.Features.AutomatingUITEsting.csproj 
dotnet test ./../xBDD.Features.AutomatingUITEsting/xBDD.Features.AutomatingUITEsting.csproj -v n --no-build

dotnet build ./../xBDD.Features.GeneratingCode/xBDD.Features.GeneratingCode.csproj 
dotnet test ./../xBDD.Features.GeneratingCode/xBDD.Features.GeneratingCode.csproj -v n --no-build

dotnet build ./../xBDD.Features.GeneratingReports/xBDD.Features.GeneratingReports.csproj 
dotnet test ./../xBDD.Features.GeneratingReports/xBDD.Features.GeneratingReports.csproj -v n --no-build

dotnet build ./../xBDD.Features.ImportingScenarios/xBDD.Features.ImportingScenarios.csproj 
dotnet test ./../xBDD.Features.ImportingScenarios/xBDD.Features.ImportingScenarios.csproj -v n --no-build

