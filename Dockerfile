FROM microsoft/dotnet:2.2-sdk as build

ARG BUILDCONFIG=RELEASE
ARG VERSION=1.0.0

COPY Kanbersky.Authentication.Api.csproj /build/
RUN dotnet restore ./build/Kanbersky.Authentication.Api.csproj
 
COPY . ./build/
WORKDIR /build/

RUN dotnet publish ./Kanbersky.Authentication.Api.csproj -c $BUILDCONFIG -o out /p:Version=$VERSION

FROM microsoft/dotnet:2.2-aspnetcore-runtime

WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["dotnet","Kanbersky.Authentication.Api.dll"]