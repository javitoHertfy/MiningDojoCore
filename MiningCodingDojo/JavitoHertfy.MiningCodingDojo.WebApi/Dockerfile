FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR .
EXPOSE 80 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1
COPY ./ /src/
WORKDIR /src/

ENV ASPNETCORE_URLS="http://*:80;https://*:443;"

EXPOSE 80/tcp
EXPOSE 443/tcp
ENTRYPOINT ["dotnet","JavitoHertfy.MiningCodingDojo.WebApi.dll"]