#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AuthJWT.WebAPI/AuthJWT.WebAPI.csproj", "AuthJWT.WebAPI/"]
RUN dotnet restore "AuthJWT.WebAPI/AuthJWT.WebAPI.csproj"
COPY . .
WORKDIR "/src/AuthJWT.WebAPI"
RUN dotnet build "AuthJWT.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthJWT.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthJWT.WebAPI.dll"]