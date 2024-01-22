using System.Reflection;
using System.Text.Json;
using Infrastructure;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Interfaces.Services;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection SetupDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContextPool<DataContext>(options => options.UseNpgsql(connectionString));

        return services;
    }

    public static IServiceCollection SetupRepositories(this IServiceCollection services)
    {
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IReceptionistRepository, ReceptionistRepository>();

        return services;
    }
    
    public static IServiceCollection SetupServices(this IServiceCollection services)
    {
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IReceptionistService, ReceptionistService>();

        return services;
    }

    public static IServiceCollection SetupControllers(this IServiceCollection services)
    {
        services
            .AddControllers()
            .AddJsonOptions(o => o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);
        
        return services;
    }

    public static IServiceCollection SetupMapper(this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

        return services;
    }
}
