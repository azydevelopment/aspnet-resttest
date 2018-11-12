FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 50532
EXPOSE 44327

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Db/Db.csproj Db/
RUN dotnet restore Db/Db.csproj
COPY . .
WORKDIR /src/Db
RUN dotnet build Db.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Db.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Db.dll"]
