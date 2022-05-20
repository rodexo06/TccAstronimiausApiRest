#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /TccAstronimiausApiRest
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /OurWayApiRest
COPY ["OurWayApiRest.API/OurWayApiRest.API.csproj", "OurWayApiRest/OurWayApiRest.API/"]
COPY ["OurWayApiRest.BLL/OurWayApiRest.BLL.csproj", "building OurWayApiRest/OurWayApiRest.BLL/"]
COPY ["OurWayApiRest.DAL/OurWayApiRest.DAL.csproj", "building OurWayApiRest/OurWayApiRest.DAL/"]
COPY ["OurWayApiRest.Model/OurWayApiRest.Model.csproj", "building OurWayApiRest/OurWayApiRest.Model/"]

RUN dotnet restore "OurWayApiRest.API/OurWayApiRest.API.csproj"
COPY . .
WORKDIR "OurWayApiRest.API"
RUN dotnet build "OurWayApiRest.API.csproj" -c Release -o /TccAstronimiausApiRest/build

FROM build AS publish
RUN dotnet publish "OurWayApiRest.API.csproj" -c Release -o /TccAstronimiausApiRest/publish

FROM base AS final
WORKDIR /TccAstronimiausApiRest
COPY --from=publish /TccAstronimiausApiRest/publish .
ENTRYPOINT ["dotnet", "OurWayApiRest.API.dll"]