#!/bin/sh

cd Hackernews

dotnet publish Hackernews.Main/Hackernews.Main.csproj --self-contained -f netcoreapp2.0 -r osx-x64 -o ../Build/OSX -c Release