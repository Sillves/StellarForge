var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.StellarForge_ApiService>("apiservice");

builder.AddProject<Projects.StellarForge_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
