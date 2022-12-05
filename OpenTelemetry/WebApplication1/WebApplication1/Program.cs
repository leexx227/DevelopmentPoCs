using OpenTelemetry.Trace;
using Azure.Monitor.OpenTelemetry.Exporter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenTelemetryTracing((traceBuilder =>
{
    traceBuilder.AddAspNetCoreInstrumentation(options =>
    {
        options.Filter = (context =>
        {
            return context.Request.Method.Equals("POST");
        });
    })
    .AddAzureMonitorTraceExporter(options =>
    {
        options.ConnectionString = "connection_string";
    })
    .AddConsoleExporter();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
