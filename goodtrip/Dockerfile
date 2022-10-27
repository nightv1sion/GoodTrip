FROM mcr.microsoft.com/dotnet/aspnet:6.0 as base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /src
COPY ["goodtrip.csproj", "./"]
RUN dotnet restore "./goodtrip.csproj"
COPY . .
RUN dotnet build "goodtrip.csproj" -c Release -o /app

FROM build as publish
RUN dotnet publish "goodtrip.csproj" -c Release -o /app

FROM base as final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "goodtrip.dll"]