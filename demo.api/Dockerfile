#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.


FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

ARG BUILD_CONFIG
ENV CONFIGURATION=${BUILD_CONFIG:-Release}

WORKDIR /src

RUN echo $CONFIGURATION

COPY ["demo.api/demo.api.csproj", "demo.api/"]
RUN dotnet restore "demo.api/demo.api.csproj"
COPY . .
WORKDIR "/src/demo.api"

RUN dotnet build "demo.api.csproj" -c $CONFIGURATION -o /app/build


FROM build AS publish
RUN dotnet publish "demo.api.csproj" -c $CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "demo.api.dll"]