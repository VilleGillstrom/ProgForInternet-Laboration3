using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AnnonsSystem;
using AnnonsSystem.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Newtonsoft.Json.Serialization;
using Xunit;

namespace AnnonsSystemIntegrationTest
{
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


    public class IntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public IntegrationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }


        [Theory]
        [InlineData("/")]
        [InlineData("/Home/Index")]
        [InlineData("/Home/Privacy")]
        public async Task AdCreationAdInfo_home_endpoints_successfylly_reachable(string url)
        {
            // Creates a client to handle redirects
            HttpClient client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",response.Content.Headers.ContentType.ToString());
        }



    }
}
