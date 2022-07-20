FROM mcr.microsoft.com/dotnet/sdk:6.0 AS serverbuild
WORKDIR /src
COPY myCmsServer /src
RUN dotnet publish -c Release -o release

FROM node:16.3.0-alpine AS clientbuild
WORKDIR /src
COPY myCmsClient /src
RUN npm install
RUN npm run build

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=serverbuild /src/release /app
COPY --from=clientbuild /src/build /app/wwwroot/

ENV DB_CONNECTION_STRING="Server=emgpw21sql.database.windows.net;Database=htndb;User Id=emergesql;Password=NF6eZMwn8p;"
ENV ASPNETCORE_URLS="http://*:5000"
ENV ADMIN_API_KEY="MyPasswordIsLong"

CMD [ "/app/myCmsServer"]