FROM microsoft/dotnet:2.0-sdk AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore ./Hackernews.csproj

# copy everything else and build
COPY . ./
RUN dotnet publish ./Hackernews.csproj -c Release -o out

# build runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime-bionic 
WORKDIR /app
COPY --from=build-env /app/out ./
ENTRYPOINT ["dotnet hackernews.dll -- --posts 5"]