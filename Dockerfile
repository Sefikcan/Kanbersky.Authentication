FROM microsoft/dotnet:latest
COPY . /app
WORKDIR /app
 
RUN ["dotnet", "restore"]
RUN ["dotnet", "publish", "./Kanbersky.Authentication.Api.dll/"]

EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000

ENTRYPOINT ["dotnet","./Kanbersky.Authentication.Api/bin/Debug/netcoreapp2.2/publish/Kanbersky.Authentication.Api.dll"]