var builder = DistributedApplication.CreateBuilder(args);

var sneakpeekApi = builder.AddProject<Projects.SneakPeek>("sneakpeek-api");

builder.Build().Run();
