using WebApp.Extensions;

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
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.UseEndpoints(endpoints  => endpoints.MapControllers());
    }
}
