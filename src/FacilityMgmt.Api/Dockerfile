FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 2213
EXPOSE 44320

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["FacilityMgmt.Api/FacilityMgmt.Api.csproj", "FacilityMgmt.Api/"]
RUN dotnet restore "FacilityMgmt.Api/FacilityMgmt.Api.csproj"
COPY . .
WORKDIR "/src/FacilityMgmt.Api"
RUN dotnet build "FacilityMgmt.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FacilityMgmt.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FacilityMgmt.Api.dll"]