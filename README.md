# Welcome!
This repo is an exploration of Semantic Kernel and Neo4j.

this project is built with [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
```shell
dotnet --version
```

Install packages from root dir
```shell
dotnet restore .
```

Register you OpenAI API key & Neo4j password with [User secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-8.0&tabs=linux).
```shell
cd <PROJECT_ROOT>/SturdyGuide
dotnet user-secrets set "OAI:ApiKey" "key here"
dotnet user-secrets set "neo4j:password" "neo4j password here"
```
this will be read a used from [Config.cs](./SturdyGuide/Config.cs) & in [example notebook](./example.ipynb)
this will register your API key & Password for usage with secret id: `2a78a9a7-426d-457c-b4d0-42438d70fa71` (this can be seen in both [.csproj](./SturdyGuide/SturdyGuide.csproj) & [example notebook](./example.ipynb))
