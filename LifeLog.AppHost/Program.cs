var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.LifeLog_Api>("api")
    .WithHttpsHealthCheck("/health");

builder.AddProject<Projects.LifeLog_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpsHealthCheck("/health")
    .WithReference(api)
    .WaitFor(api);

builder.Build().Run();
