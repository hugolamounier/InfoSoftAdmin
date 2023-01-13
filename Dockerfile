FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

WORKDIR /src
COPY ["./", "./"]
RUN dotnet restore "InfoSoftAdmin.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "InfoSoftAdmin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InfoSoftAdmin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InfoSoftAdmin.dll"]
