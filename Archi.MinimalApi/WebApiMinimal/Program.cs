var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();

var app = builder.Build();

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

app.RegisterPipelineComponents();

app.Run();
