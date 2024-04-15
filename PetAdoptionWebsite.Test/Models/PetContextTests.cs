using Microsoft.EntityFrameworkCore;
using Xunit;
using PetAdoptionWebsite.Models;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System;

public class PetContextTests
{
    private readonly IServiceProvider _serviceProvider;

    public PetContextTests()
    {
        var services = new ServiceCollection();
        services.AddDbContext<PetContext>(options =>
            options.UseInMemoryDatabase("TestDatabase"), ServiceLifetime.Transient);

        _serviceProvider = services.BuildServiceProvider();
    }

    [Fact]
    public void ShouldSeedPetsCorrectly()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<PetContext>();

            // Trigger the seeding
            context.Database.EnsureCreated();

            // Assert
            Assert.Equal(20, context.Pets.Count()); 
            var firstPet = context.Pets.FirstOrDefault(p => p.Id == 1);
            Assert.NotNull(firstPet);
            Assert.Equal("Fluffy", firstPet.Name);
            Assert.Equal("Cat", firstPet.Species);
        }

        // Clean up in-memory database
        using (var scope = _serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<PetContext>();
            context.Database.EnsureDeleted();
        }
    }
}

