using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;
using Ubigeos.Application;
using Ubigeos.Domain;
using Ubigeos.Infrastructure;
using Ubigeos.Infrastructure.Ubigeos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
     {
         options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
         options.JsonSerializerOptions.MaxDepth = 64; // Aumentar profundidad si es necesario
         options.JsonSerializerOptions.WriteIndented = true; // Opcional, para debugging
     });
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("defaultConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IUbigeosRepository, UbigeosRepository>();
builder.Services.AddScoped<IUbigeosService, UbigeosService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
