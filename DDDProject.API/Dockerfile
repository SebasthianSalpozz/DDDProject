# Usar la imagen oficial de .NET SDK para build (ahora versión 8.0)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar archivos de solución y restaurar
COPY *.sln .
COPY DDDProject.API/*.csproj ./DDDProject.API/
COPY DDDProject.Application/*.csproj ./DDDProject.Application/
COPY DDDProject.Domain/*.csproj ./DDDProject.Domain/
COPY DDDProject.Infrastructure/*.csproj ./DDDProject.Infrastructure/
RUN dotnet restore

# Copiar el resto del código y compilar
COPY . .
WORKDIR /app/DDDProject.API
RUN dotnet publish -c Release -o out

# Imagen runtime con .NET 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/DDDProject.API/out ./
ENTRYPOINT ["dotnet", "DDDProject.API.dll"]
