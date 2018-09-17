Set-Location $PSScriptRoot

./build-my-sample.ps1

./test-my-sample-firstpassing.ps1

./test-my-sample-firstfailing.ps1

./test-my-sample-passing.ps1

./test-my-sample-passingfailuresonly.ps1

./test-my-sample-nocapabilitynameremoval.ps1

./test-my-sample-fullcapabilitynameremoval.ps1

./test-my-sample-skipped.ps1

./test-my-sample-skippedfailuresonly.ps1

Remove-Item ./../MySample.Features/bin/Debug/netcoreapp2.1/Code/* -Recurse -Force

./test-my-sample-all.ps1

./test-my-sample-generated.ps1

./test-my-sample-allfailuresonly.ps1

./test-my-sample-allunsorted.ps1

./test-my-sample-allfullsorted.ps1

./test-my-sample-none.ps1

./test-my-sample-noscenarios.ps1

