FROM mcr.microsoft.com/vscode/devcontainers/dotnet:2.0.5-8.0-bookworm

RUN apt-get update && apt-get install -y \
        mono-complete \
    && rm -rf /var/lib/apt/lists/*
