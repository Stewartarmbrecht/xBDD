# C# Http Trigger Function for .NET Core 2.0
Http trigger function for Functions 2.0. Companion to blog post [Develop Azure Functions on any platform](http://blogs.msdn.microsoft.com/appserviceteam/2017/09/25/develop-azure-functions-on-any-platform/).


        npm i -g azure-functions-core-tools

        https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latestazure

Build the solution.

        dotnet build
        dotnet publish

Move to the build.

        cd bin/debug/netstandard2.0/

Test by running the function.

        func host start

Log into azure.

        az login

Create your resource group and azure function ap


        az group create -n xbddresourcegroup -l centralus
        az storage account create --name xbddstorage --location centralus --resource-group xbddresourcegroup --sku Standard_LRS
        az functionapp create --name publish.api.xbdd --storage-account xbddstorage  --resource-group xbddresourcegroup --consumption-plan-location centralus

Publish the function (the first step is to address an error that occurs when trying to publish to a function app targeting the beta platform (2.0))

        az functionapp config appsettings set --name xbdd-publish --resource-group xbddresourcegroup --settings FUNCTIONS_EXTENSION_VERSION=~1
        
        func azure functionapp publish xbdd-publish

        az functionapp config appsettings set --name xbdd-publish --resource-group xbddresourcegroup --settings FUNCTIONS_EXTENSION_VERSION=beta 
