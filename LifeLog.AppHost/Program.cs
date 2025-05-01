var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithDataVolume(isReadOnly: false);

var postgresdb = postgres.AddDatabase("Marten");

var api = builder.AddProject<Projects.LifeLog_Api>("api")
    .WithHttpsHealthCheck("/health")
    .WithReference(postgresdb)
    .WaitFor(postgresdb);


builder.Build().Run();
