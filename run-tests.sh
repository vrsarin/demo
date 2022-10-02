#!/bin/sh
set -e

dotnet test ./demo.api.unit.tests/demo.api.unit.tests.csproj --logger trx --collect:"XPlat Code Coverage" -v quiet
status=$?

echo $status
# TODO 
# 1.   Send 1 to break run when Unit Test fails
# 2.   Manage CodeCoverage>=80%
# 3.   Integrate SonarQube
exit $status