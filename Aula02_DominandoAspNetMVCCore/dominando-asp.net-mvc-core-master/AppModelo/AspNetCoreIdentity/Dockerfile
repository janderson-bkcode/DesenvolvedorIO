FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["AspNetCoreIdentity/AspNetCoreIdentity.csproj", "AspNetCoreIdentity/"]
RUN dotnet restore "AspNetCoreIdentity/AspNetCoreIdentity.csproj"
COPY . .
WORKDIR "/src/AspNetCoreIdentity"
RUN dotnet build "AspNetCoreIdentity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspNetCoreIdentity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspNetCoreIdentity.dll"]