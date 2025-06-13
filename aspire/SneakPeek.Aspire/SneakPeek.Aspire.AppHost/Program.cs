var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.SneakPeek>("api").WithExternalHttpEndpoints();

builder.Build().Run();
