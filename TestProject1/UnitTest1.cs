using System.Net;
using System.Threading.Tasks;
using OponeoViewsAndAuth.Start;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace TestProject1;

public class UnitTest1
{
    [Fact]
    public async Task Test1()
    {
        // Arrange
        var app = new WebApplicationFactory<Startup>();
        
        app.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                // swap dbcontext with in memory
                // services.AddDbContext<object>().AddEntityFrameworkInMemoryDatabase();
            });
        });

        var client = app.CreateClient();
        
        // Act
        var result = await client.GetAsync("Home/Index");
        
        // Assert
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }
}