FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Microsoft.PWABuilder.IOS.Web/Microsoft.PWABuilder.IOS.Web.csproj", "Microsoft.PWABuilder.IOS.Web/"]
RUN dotnet restore "Microsoft.PWABuilder.IOS.Web/Microsoft.PWABuilder.IOS.Web.csproj"
COPY . .
WORKDIR "/src/Microsoft.PWABuilder.IOS.Web"
RUN dotnet build "Microsoft.PWABuilder.IOS.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microsoft.PWABuilder.IOS.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microsoft.PWABuilder.IOS.Web.dll"]

USER root
RUN chown -R appuser /app
