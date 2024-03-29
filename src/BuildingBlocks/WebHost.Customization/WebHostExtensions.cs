﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;
using System;

namespace WebHost.Customization
{
    public static class WebHostExtensions
    {
        public static IHost MigrateDbContext<TContext>(this IHost webHost, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
        {
            using var scope = webHost.Services.CreateScope();
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<TContext>>();
            var context = services.GetRequiredService<TContext>();

            try
            {
                logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(TContext).Name);

                const int retries = 10;
                var retry = Policy.Handle<SqlException>()
                    .WaitAndRetry(
                        retries,
                        retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                        (exception, _, i, _) =>
                        {
                            logger.LogWarning(exception,
                                "[{prefix}] Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retries}",
                                nameof(TContext), exception.GetType().Name, exception.Message, i, retries);
                        });
                retry.Execute(() => InvokeSeeder(seeder, context, services));

                logger.LogInformation("Migrated database associated with context {DbContextName}", typeof(TContext).Name);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(TContext).Name);
            }

            return webHost;
        }

        private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder,
            TContext context, IServiceProvider services) where TContext : DbContext
        {
            context.Database.Migrate();
            seeder(context, services);
        }
    }
}