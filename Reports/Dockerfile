#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Reports/Reports.csproj", "Reports/"]
RUN dotnet restore "Reports/Reports.csproj"
COPY . .
WORKDIR "/src/Reports"
RUN dotnet build "Reports.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Reports.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reports.dll"]