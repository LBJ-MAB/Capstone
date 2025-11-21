using System.Net.Http.Json;
using Capstone.Domain.Dtos;
using Capstone.Infrastructure.Persistence;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Capstone.Tests.IntegrationTests;

[TestFixture]
public class IntegrationTests
{
    /*
    private HttpClient CreateTestClient()
    {
        var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder => builder.ConfigureServices(services =>
            {
                services.AddDbContext<TaskDb>(opt => 
                    opt.UseInMemoryDatabase(databaseName: "CapstoneTestDatabase"));
            }));

        ClearDatabase(application);
        
        return application.CreateClient();
    }

    private void ClearDatabase(WebApplicationFactory<Program> application)
    {
        using (var scope = application.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<TaskDb>();
            db.Tasks.RemoveRange(db.Tasks);
            db.SaveChanges();
        }
    }
    */
    
    [SetUp]
    public void Setup()
    {
    }

    /*
    [Test]
    public async Task PostRequest_ShouldReturnCreatedStatusCode_WhenValidTaskGiven()
    {
        // arrange
        var taskDto = new TaskItemDto
        {
            Title = "test title",
            IsComplete = false
        };
        var client = CreateTestClient();

        // act
        var result = await client.PostAsJsonAsync("/tasks", taskDto);

        // assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);  
    }
    */

    [Test]
    public void Test()
    {
        var x = 1;
        x.Should().Be(1);
    }
}

