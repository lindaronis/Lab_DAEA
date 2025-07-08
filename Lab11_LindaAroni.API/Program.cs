using Lab11_LindaAroni.API.Configuration; // Asegúrate de tener esta carpeta
using Lab11_LindaAroni.Infrastructure.Configuration; // Y para Infrastructure

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar servicios de la capa Application e Infrastructure
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddHangfireServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddControllers();

// 2. Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication(); // si es que configuras autenticación
app.UseAuthorization();

// Hangfire Dashboard y Jobs
app.UseHangfireDashboardAndJobs();

app.MapControllers();
app.Run();

// Modelo (puedes moverlo a una carpeta Models si prefieres)
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}