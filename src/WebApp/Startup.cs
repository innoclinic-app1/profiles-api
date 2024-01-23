using WebApp.Extensions;
using WebApp.Middlewares;

namespace WebApp;

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .SetupControllers()
            .SetupRepositories()
            .SetupMapper()
            .SetupServices()
            .SetupDatabase(Configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.UseEndpoints(endpoints  => endpoints.MapControllers());
    }
}
