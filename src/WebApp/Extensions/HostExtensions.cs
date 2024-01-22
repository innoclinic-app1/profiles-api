using Serilog;

namespace WebApp.Extensions;

public static class HostExtensions
{
    public static IHostBuilder SetupSerilog(this IHostBuilder hostBuilder)
    {
        return hostBuilder.UseSerilog((context, provider, config) => config
            .ReadFrom.Configuration(context.Configuration)
            .ReadFrom.Services(provider)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File(
                "logs/log.txt", rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 7, fileSizeLimitBytes: 10485760, buffered: true)
        );
    }
}
