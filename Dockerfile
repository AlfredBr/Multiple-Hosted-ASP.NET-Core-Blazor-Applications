# build
FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /app
RUN git clone https://github.com/AlfredBr/Multiple-Hosted-ASP.NET-Core-Blazor-Applications.git src
WORKDIR /app/src
RUN dotnet restore
RUN dotnet publish -c Release -o /app/out

# serve
FROM mcr.microsoft.com/dotnet/aspnet:latest AS serve
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 7000-7004
ENTRYPOINT [ "dotnet", "host.dll" ]
