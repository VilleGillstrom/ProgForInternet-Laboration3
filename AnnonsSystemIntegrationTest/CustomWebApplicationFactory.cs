using System;
using System.Collections.Generic;
using System.IO;
using AnnonsSystem;
using AnnonsSystem.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AnnonsSystemIntegrationTest
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                // Add a database context using an in-memory database
                services.AddDbContext<AnnonsContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                // Build the service provider.
                ServiceProvider sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database
                // context (AnnonsContext).
                using (var scope = sp.CreateScope())
                {
                    IServiceProvider scopedServices = scope.ServiceProvider;
                    AnnonsContext db = scopedServices.GetRequiredService<AnnonsContext>();

                    // Ensure the database is created.
                    db.Database.EnsureCreated();

                    try
                    {
                        // Seed the database with test data.
                        SeedData.InitializeDbForTests(db);
                    }
                    catch (Exception ex)
                    {
                        TextWriter errorWriter = Console.Error;
                        errorWriter.WriteLine(ex.Message);
                    }
                }
            });
        }
    }
}

public static class SeedData
{
    public static void InitializeDbForTests(AnnonsContext db)
    {
        var adList = new List<Ad>()
        {
            new Ad(){Rubrik = "foo1", Innehall = "bar1", PrisAnnons = 40, PrisVara = 111 },
            new Ad(){Rubrik = "foo2", Innehall = "bar2", PrisAnnons = 40, PrisVara = 222 },
            new Ad(){Rubrik = "foo3", Innehall = "bar3", PrisAnnons = 40, PrisVara = 333 }
        };

        db.Ads.AddRange(new List<Ad>(adList));

        db.SaveChanges();
    }
}
