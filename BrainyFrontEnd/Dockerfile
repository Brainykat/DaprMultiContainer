#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BrainyFrontEnd/BrainyFrontEnd.csproj", "BrainyFrontEnd/"]
RUN dotnet restore "BrainyFrontEnd/BrainyFrontEnd.csproj"
COPY . .
WORKDIR "/src/BrainyFrontEnd"
RUN dotnet build "BrainyFrontEnd.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BrainyFrontEnd.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BrainyFrontEnd.dll"]