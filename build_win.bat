@echo off

cd Hackernews

echo Building Application...

dotnet restore Hackernews.Main/Hackernews.Main.csproj
dotnet publish Hackernews.Main/Hackernews.Main.csproj --self-contained -f netcoreapp2.0 -r win-x64 -o ../Build/Windows -c Release

pause