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

Register you OpenAI API key with [User secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-8.0&tabs=linux).
```shell
cd <PROJECT_ROOT>/SturdyGuide
dotnet user-secrets set "OAI:ApiKey" "key here"
```
this will be read a used from [Config.cs](./SturdyGuide/Config.cs)
this will register your API key with that name for this project.  

currently the driver config is defined in [AppSettings](./SturdyGuide/appsettings.json)