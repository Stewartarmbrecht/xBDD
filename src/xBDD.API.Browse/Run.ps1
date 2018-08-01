dotnet build
dotnet publish

Set-Location $PSScriptRoot/bin/debug/netstandard2.0

func host start

