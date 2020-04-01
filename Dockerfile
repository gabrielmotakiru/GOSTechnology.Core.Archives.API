FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
WORKDIR /source

EXPOSE 80
EXPOSE 443

COPY . /source
RUN dotnet restore
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS base
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "GOSTechnology.Core.Archives.Api.dll"]
