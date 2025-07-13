var builder = DistributedApplication.CreateBuilder(args);

var server = builder.AddProject<Projects.StellarForge_Server>("server");

builder.AddProject<Projects.StellarForge_Client>("client")
       .WithReference(server);

builder.Build().Run();
