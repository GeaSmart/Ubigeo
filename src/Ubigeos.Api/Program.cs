using Microsoft.EntityFrameworkCore;
using Ubigeos.Application.Ubigeos;
using Ubigeos.Domain.Interfaces;
using Ubigeos.Infrastructure;
using Ubigeos.Infrastructure.Ubigeos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
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

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
