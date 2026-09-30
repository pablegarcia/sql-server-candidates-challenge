using SyncAgent.Infrastructure.Options;
using SyncAgent.Worker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddOptions<PlatformOptions>()
    .Bind(builder.Configuration.GetSection("Platform"))
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddOptions<SyncOptions>()
    .Bind(builder.Configuration.GetSection("Sync"))
    .ValidateDataAnnotations()
    .ValidateOnStart();

var host = builder.Build();
host.Run();