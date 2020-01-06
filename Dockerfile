FROM microsoft/dotnet:2.2-sdk as build-env
WORKDIR /app

WORKDIR /Kanbersky.Authentication.Api
COPY *.csproj ./
RUN dotnet restore

COPY ../
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .

CMD ASPNETCORE_URL=http://*:$PORT dotnet Kanbersky.Authentication.Api.dll