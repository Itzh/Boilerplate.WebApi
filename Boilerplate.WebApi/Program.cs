using Boilerplate.WebApi;
using Serilog;

CreateHostBuilder(args).Build().Run();

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .UseSerilog()
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.ConfigureKestrel(options => options.AddServerHeader = false)
                .UseStartup<Startup>();
        })
        .ConfigureAppConfiguration(appConfig => appConfig.AddJsonFile("appsettings.json")
            .AddEnvironmentVariables());
}

// needed for Test exposure https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0#basic-tests-with-the-default-webapplicationfactory
public partial class Program { } 