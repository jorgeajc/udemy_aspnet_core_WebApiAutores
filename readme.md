# open cmd
### view all list of templates
``` dotnet new --list ```


# install project webapiautores
``` dotnet new webapi -o WebApiAutores ```

# run app
``` dotnet run ```

# install entity framework core
```
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.0
    dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.0
```

# migrations
### install before
``` dotnet tool install --global dotnet-ef ``` 
### run migrations
``` dotnet ef migrations add "set name" ```
``` dotnet ef database update ```
