FROM microsoft/dotnet:latest
COPY . /app
WORKDIR /app
 
RUN ["dotnet", "restore"]
RUN ["dotnet", "./Kanbersky.Authentication.Api.dll/"]

EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000

ENTRYPOINT ["dotnet","./bin/Debug/netcoreapp2.2/Kanbersky.Authentication.Api.dll"]