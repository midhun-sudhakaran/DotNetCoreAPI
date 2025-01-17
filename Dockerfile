FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["CoreWebAPI/CoreWebAPI.csproj", "CoreWebAPI/"]
RUN dotnet restore "CoreWebAPI/CoreWebAPI.csproj"
COPY . .
WORKDIR "/src/CoreWebAPI"
RUN dotnet build "CoreWebAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CoreWebAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CoreWebAPI.dll"]