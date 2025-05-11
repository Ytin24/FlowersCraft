var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("Mssql")
                 .WithDataVolume()
                 .WithLifetime(ContainerLifetime.Persistent);

var initScript = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Sql", "init.sql"));

var db = sql.AddDatabase("FlowersCraft")
            .WithCreationScript(initScript);

builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.FlowersCraft_ApiService>("apiservice")
        .WithReference(db)
       .WaitFor(db);

builder.Build().Run();
