# JSON config Parser 

This is an application that parses json files and merges them to form a configuration file.

## Prerequesites

Requires installation of .net core toolchain to run and build the application.

## Install Dependencies

```bash
dotnet restore
```

## Build

```bash
dotnet build
```

## Run Tests

```bash
dotnet test
```

## Run App

```bash
cd Parser
dotnet run
```
## Project Structure

The project is separated in two parts, Parser and Parser.Tests

Parser contains config files, the code to load and process the json config files.
Parser.Tests contains a series of tests for the different parts of the application.
