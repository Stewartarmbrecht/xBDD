Set-Location $PSScriptRoot
dotnet build ./../core/xBDD.Core.Test/xBDD.Core.Test.csproj 
dotnet test ./../core/xBDD.Core.Test/xBDD.Core.Test.csproj -v n --no-build