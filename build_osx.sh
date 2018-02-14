#!/bin/sh

cd source

dotnet publish Hackernews.csproj --self-contained -f netcoreapp2.0 -r osx-x64 -o ../Build/OSX -c Release