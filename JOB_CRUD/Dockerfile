#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["JOB_CRUD/JOB_CRUD.csproj", "JOB_CRUD/"]
RUN dotnet restore "JOB_CRUD/JOB_CRUD.csproj"
COPY . .
WORKDIR "/src/JOB_CRUD"
RUN dotnet build "JOB_CRUD.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JOB_CRUD.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JOB_CRUD.dll"]