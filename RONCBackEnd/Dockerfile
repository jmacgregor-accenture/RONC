FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY RONCBackEnd.WebApi/*.csproj ./BackEndApp/
RUN dotnet restore ./BackEndApp/RONCBackEnd.WebApi.csproj

# copy everything else and build app
COPY RONCBackEnd.WebApi/. ./BackEndApp/
WORKDIR /app/BackEndApp/RONCBackEnd.WebApi/
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build /app/BackEndApp/out ./
ENTRYPOINT ["dotnet", "RONCBackEnd.WebApi.dll"]

# Dockerfile guide
# https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/docker/building-net-docker-images?view=aspnetcore-2.2

# Portforwarding breakthru
# https://www.codemag.com/Article/1905091/Using-JetBrains-Rider-to-Develop-ASP.NET-Core-Applications-on-Docker


# The yesterday GARBAGE

#FROM microsoft/dotnet:sdk AS build-env
#WORKDIR /app

# Copy csproj and restore as distinct layers
#COPY ./RevengeOfNewsChallengerBackEnd.WebAPI/RevengeOfNewsChallengerBackEnd.WebAPI.csproj ./
#RUN dotnet restore

# Copy everything else and build
#COPY . ./
#RUN dotnet publish RevengeOfNewsChallengerBackEnd.WebAPI -c Release -o "out"

# Build runtime image
#FROM microsoft/dotnet:aspnetcore-runtime
#WORKDIR /app
# ENTRYPOINT ["dotnet", "RevengeOfNewsChallengerBackEnd.WebAPI.dll"]
# COPY --from=build-env out .
# RUN dotnet run
