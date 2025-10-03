var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.SneakPeek>("sneakpeek-api");

builder.Build().Run();
