dotnet sonarscanner begin /k:"Demo-App" /d:sonar.host.url="http://localhost:9000"  /d:sonar.login="sqp_9365634b1f82216740b1b1e14a9d5fad0cb02273"
dotnet build demo.api.sln
dotnet test ./demo.api.unit.tests/demo.api.unit.tests.csproj --collect:"Code Coverage"
dotnet-coverage collect 'dotnet test ./demo.api.unit.tests/demo.api.unit.tests.csproj' -f xml  -o 'coverage.xml'
dotnet sonarscanner end /d:sonar.login="sqp_9365634b1f82216740b1b1e14a9d5fad0cb02273"