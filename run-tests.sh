#!/bin/sh
set -e
# TODO 
# 1.   Send 1 to break run when Unit Test fails
# 2.   Manage CodeCoverage>=80%
# 3.   Integrate SonarQube
dotnet sonarscanner begin /key:'Demo-App' /d:sonar.host.url='http://localhost:9000'  /d:sonar.login='sqp_9365634b1f82216740b1b1e14a9d5fad0cb02273'
dotnet build demo.api.sln
dotnet test ./demo.api.unit.tests/demo.api.unit.tests.csproj --logger trx --collect:"XPlat Code Coverage"
dotnet sonarscanner end /d:sonar.login="sqp_4622bd04ef8184cb318abf8e1a9f34676970a470"

exit $status