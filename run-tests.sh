#!/bin/sh
set -e

dotnet test ./demo.api.unit.tests/demo.api.unit.tests.csproj --logger trx --collect:"XPlat Code Coverage"

exit $?