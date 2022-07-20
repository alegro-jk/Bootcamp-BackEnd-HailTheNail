FROM mcr.microsoft.com/dotnet/sdk:6.0 AS serverbuild
WORKDIR /src
COPY htnWebsiteServer /src
RUN dotnet publish -c Release -o release

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=serverbuild /src/release /app

ENV DB_CONNECTION_STRING="Server=emgpw21sql.database.windows.net;Database=htndb;User Id=emergesql;Password=NF6eZMwn8p;"
ENV ASPNETCORE_URLS="http://*:5000"

CMD [ "/app/htnWebsiteServer" ]