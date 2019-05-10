using System;
using System.IO;
using AnnonsSystem;
using AnnonsSystem.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AnnonsSystemIntegrationTest
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Startup> 
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