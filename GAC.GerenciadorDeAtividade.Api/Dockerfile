#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["GAC.GerenciadorDeAtividade.Api/GAC.GerenciadorDeAtividade.Api.csproj", "GAC.GerenciadorDeAtividade.Api/"]
RUN dotnet restore "GAC.GerenciadorDeAtividade.Api/GAC.GerenciadorDeAtividade.Api.csproj"
COPY . .
WORKDIR "/src/GAC.GerenciadorDeAtividade.Api"
RUN dotnet build "GAC.GerenciadorDeAtividade.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GAC.GerenciadorDeAtividade.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GAC.GerenciadorDeAtividade.Api.dll"]