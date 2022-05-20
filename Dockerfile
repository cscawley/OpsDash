# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore
# Copy everything else and build
COPY ../engine/examples ./
RUN dotnet publish -c Release -o out

FROM node AS build-node
WORKDIR /src
COPY ./ClientApp /src/
RUN npm install
RUN npm build

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
COPY --from=node-builder /src/build ./wwwroot
ENTRYPOINT ["dotnet", "aspnetapp.dll"]