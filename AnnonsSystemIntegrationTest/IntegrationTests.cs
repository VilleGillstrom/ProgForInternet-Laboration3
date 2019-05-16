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
  

    public class IntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public IntegrationTests(CustomWebApplicationFactory<Startup> factory)
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
            HttpClient client =   _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task AdCreationAdInfo_home_endpoints_successfylly_raaable()
        {
            // Creates a client to handle redirects
            HttpClient client = _factory.CreateClient();
            var defaultPage = await client.GetAsync("/" );

            // Act
            var response = await client.SendAsync(
                (IHtmlFormElement)content.QuerySelector("form[id='messages']"),
                (IHtmlButtonElement)content.QuerySelector("button[id='deleteAllBtn']")
                );

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }


    }
}
