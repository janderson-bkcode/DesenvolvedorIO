FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 80

RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf
RUN sed -i 's/MinProtocol = TLSv1.2/MinProtocol = TLSv1/g' /etc/ssl/openssl.cnf
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /usr/lib/ssl/openssl.cnf
RUN sed -i 's/MinProtocol = TLSv1.2/MinProtocol = TLSv1/g' /usr/lib/ssl/openssl.cnf

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS basesdk
WORKDIR /src
COPY Nuget.config Nuget.config
COPY UI.Site.csproj .

COPY ./entrypoint.sh .
RUN chmod +x ./entrypoint.sh

ENV PATH="${PATH}:/root/.dotnet/tools" 

RUN dotnet tool install --global dotnet-ef --version 3.0.0
RUN dotnet clean
RUN dotnet restore --configfile Nuget.config UI.Site.csproj

COPY . .

FROM basesdk AS build
ARG ASSEMBLY_VERSION="1.0.0"
RUN dotnet build /src/UI.Site.csproj -c Release /p:Version=${ASSEMBLY_VERSION}

FROM build AS publish
RUN dotnet publish UI.Site.csproj --no-build -c Release -o /app 

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "UI.Site.dll"]


CMD /bin/bash ./entrypoint.sh