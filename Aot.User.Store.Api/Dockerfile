#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Aot.User.Store.Api/Aot.User.Store.Api.csproj", "Aot.User.Store.Api/"]
RUN dotnet restore "Aot.User.Store.Api/Aot.User.Store.Api.csproj"
COPY . .
WORKDIR "/src/Aot.User.Store.Api"
RUN dotnet build "Aot.User.Store.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aot.User.Store.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aot.User.Store.Api.dll"]