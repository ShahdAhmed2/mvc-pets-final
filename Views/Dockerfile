# استخدم صورة .NET SDK لبناء المشروع
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# انسخ ملفات المشروع
COPY *.sln .
COPY mvc_pets/*.csproj ./mvc_pets/
RUN dotnet restore

# انسخ باقي الملفات وابني المشروع
COPY mvc_pets/. ./mvc_pets/
WORKDIR /app/mvc_pets
RUN dotnet publish -c Release -o /app/publish

# استخدم صورة .NET Runtime لتشغيل المشروع
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "mvc_pets.dll"]
