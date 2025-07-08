using Lab11_LindaAroni.Application.Services.Interfaces;
using Lab11_LindaAroni.Application.Services.Jobs;
using Lab11_LindaAroni.Application.Services.Notifications;
using Lab11_LindaAroni.Domain.Interfaces.Repositories;
using Lab11_LindaAroni.Domain.Interfaces.UnitOfWork;
using Lab11_LindaAroni.Infrastructure.Context;
using Lab11_LindaAroni.Infrastructure.Persistence.Repositories;
using Lab11_LindaAroni.Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lab11_LindaAroni.Infrastructure.Configuration;

public static class InfrastructureServicesExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) 
    { 
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<Lab11DbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
        
        services.AddTransient<NotificationService>();
        
        services.AddTransient<ITicketCleanupService, TicketCleanupService>();

        
        return services;
    }
}