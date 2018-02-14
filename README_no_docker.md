## Prerequisites
* Download [.NET Core SDK v2.x](https://www.microsoft.com/net/download)
* Make sure dotnet in registered in __PATH__ (This is automatic if installing from the link above)

## Building the source
* Execute the proper build script found in the root directory
    - __build_win.bat__ for a Windows x64 version
    - __build_linux.sh__ for a Linux x64 version
    - __build_osx.sh__ for a OSX x64 version

## Running
* After build the source, the executable will be available in the git root directory Hackernews/Build/[OS]/hackernews[.exe]
* To run the program just execute it via Terminal/CommandLine with the required arguments.
    * __Example:__
    ```bash
     ./hackernews --posts 10
    ```
* If you wish to run the programm without having to be in the executable directory just make sure to add the executable directory in the __PATH__ and run:
     ```bash
     ./hackernews --posts <arg>
    ```