## Prerequisites
* Download and install [Docker](https://www.docker.com/community-edition#/download)
* Make sure Docker in registered in __PATH__ (This is normally automatic if installing from the link above)

## Building the source
* Execute the Dockerfile script found in Hackernews/Hackernews.Main/ directory.

```bash
docker build . -t hackernews
```

## Running
```bash
docker run hackernews:latest
```