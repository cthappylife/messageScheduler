using System;
using MessageScheduler.Persistence;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MessageScheduler.Service;

[assembly: FunctionsStartup(typeof(MessageScheduler.Functions.Startup))]
namespace MessageScheduler.Functions
{
    public class Startup : FunctionsStartup
    {
        private IConfiguration _configuration;

        public override void Configure(IFunctionsHostBuilder builder)
        {
            InitConfiguration();
            var connectionString = _configuration.GetConnectionString("SqlServerDbConnectionString");

            builder.Services
                .AddOptions()
                .AddLogging()
                .AddDbContext<MessageSchedulerContext>(opt => opt.UseSqlServer(connectionString))
                .AddScoped<IMessagesQuery, MessagesQuery>();
        }

        private void InitConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            _configuration = configurationBuilder
                .SetBasePath(GetBasePath())
                .AddEnvironmentVariables()
                .Build();
        }

        private string GetBasePath()
        {
            if (IsDevelopmentEnvironment())
                return Environment.GetEnvironmentVariable("AzureWebJobsScriptRoot") ?? throw new ArgumentException("Missing environment variable 'AzureWebJobsScriptRoot'");
            var home = Environment.GetEnvironmentVariable("HOME") ?? throw new ArgumentException("Missing environment variable 'HOME'");
            return System.IO.Path.Combine(home, "site", "wwwroot");
        }

        private bool IsDevelopmentEnvironment() => 
            "Development".Equals(Environment.GetEnvironmentVariable("AZURE_FUNCTIONS_ENVIRONMENT"), StringComparison.OrdinalIgnoreCase);
    }
}
