FROM mcr.microsoft.com/dotnet/aspnet AS base
EXPOSE 5051
COPY /bin/Release/net5.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "LibreriaWebApi.dll"]

# dotnet publish -c Release
# docker build -t [name] -f Dockerfile .
# docker run --restart unless-stopped --log-opt max-size=10m -p 5051:80 [name]
### Procedure di Push in Docker Hub
# docker login
# docker tag [name image]:[tag] [name docker hub repository]:[tag]
# docker push [name image]:[tag]
### Procedura di Push in ACR
#az acr login --name alphashopregistry
#docker tag [name image]:[tag] alphashopregistry.azurecr.io/[name image]:[tag]