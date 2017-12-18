## Database Setup

    dotnet ef migrations add Initialize -s xBDD.Reporting.Test.csproj -p ../../src/xBDD.Reporting.Database/xBDD.Reporting.Database.csproj -c DatabaseContext
    
    dotnet ef database update -s xBDD.Reporting.Test.csproj -p ../../src/xBDD.Reporting.Database/xBDD.Reporting.Database.csproj -c DatabaseContext

http://database.guide/how-to-install-sql-server-on-a-mac/

    docker run -d --name sql_server_demo -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=reallyStrongPwd123' -p 1433:1433 microsoft/mssql-server-linux

    docker restart 469dd9ad0fa0a57ad7a121cbf062cbaceca5d066d9fc23ee9acb19cc12cce748

    $env:Data:DefaultConnection:ConnectionString="Server=.;Database=xBDDTestResults;User Id=sa;Password=<YourPassword>"

    ./RunTests.ps1 "Server=.;Database=<YourPassword>;User Id=sa;Password=reallyStrongPwd123"



##Windows Docker Setup

    https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker

    docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<password>" -p 1433:1433 --name SqlServer -d microsoft/mssql-server-linux:2017-latest

    docker exec -it SqlServer /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "oldpwd" -Q "ALTER LOGIN SA WITH PASSWORD='newpwd'"

## Publishing to Nuget
    dotnet pack
    nuget setApiKey <YourAPIKey>
    nuget push ./bin/debug/xBDD.Core.1.0.0-alpha.nupkg -Source https://api.nuget.org/v3/index.json