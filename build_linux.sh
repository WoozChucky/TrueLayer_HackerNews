#!/bin/sh

cd Hackernews

dotnet publish Hackernews.Main/Hackernews.Main.csproj --self-contained -f netcoreapp2.0 -r linux-x64 -o ../Build/Linux -c Release