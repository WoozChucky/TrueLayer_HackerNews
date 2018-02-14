#!/bin/sh

cd source

dotnet publish Hackernews.csproj --self-contained -f netcoreapp2.0 -r linux-x64 -o ../Build/Linux -c Release