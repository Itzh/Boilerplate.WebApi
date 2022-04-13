#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Boilerplate.WebApi/Boilerplate.WebApi.csproj", "Boilerplate.WebApi/"]
RUN dotnet restore "Boilerplate.WebApi/Boilerplate.WebApi.csproj"
COPY . .
WORKDIR "/src/Boilerplate.WebApi"
RUN dotnet build "Boilerplate.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Boilerplate.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Boilerplate.WebApi.dll"]