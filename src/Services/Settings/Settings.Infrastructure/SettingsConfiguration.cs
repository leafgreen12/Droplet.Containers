using System.IO;
using Microsoft.Extensions.Configuration;

namespace Settings.Infrastructure
{
    public static class SettingsConfiguration
    {
        public static IConfiguration Configuration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables();
            return builder.Build();
        }
    }
}