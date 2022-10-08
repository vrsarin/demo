#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base

RUN dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI

WORKDIR /src
COPY ["demo.api.bdd.tests/demo.api.bdd.tests.csproj", "demo.api.bdd.tests/"]
COPY ["demo.api/demo.api.csproj", "demo.api/"]
RUN dotnet restore "demo.api.bdd.tests/demo.api.bdd.tests.csproj"
COPY . .
WORKDIR "/src/demo.api.bdd.tests"
RUN dotnet build "demo.api.bdd.tests.csproj" -c Release -o /app/build

RUN mkdir -p TestReport

CMD ["/root/.dotnet/tools/livingdoc","test-assembly", "./bin/debug/net6.0/demo.api.bdd.tests.dll", "-t", "./bin/debug/net6.0/TestExecution.json"]
