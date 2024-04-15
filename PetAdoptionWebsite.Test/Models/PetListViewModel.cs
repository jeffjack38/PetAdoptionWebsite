using Xunit;
using PetAdoptionWebsite.Models;
using System.Collections.Generic;

public class PetListViewModelTests
{
    [Fact]
    public void SpeciesProperty_ShouldPrependAll()
    {
        // Arrange
        var model = new PetListViewModel();

        // Act
        model.Species = new List<string> { "Dog", "Cat" };

        // Assert
        Assert.Equal("All", model.Species[0]);
        Assert.Contains("Dog", model.Species);
        Assert.Contains("Cat", model.Species);
    }

    [Fact]
    public void GetDistinctSpecies_ShouldReturnDistinctSpeciesWithAll()
    {
        // Arrange
        var model = new PetListViewModel
        {
            Pets = new List<Pet>
            {
                new Pet { Species = "Dog" },
                new Pet { Species = "Cat" },
                new Pet { Species = "Dog" }
            }
        };

        // Act
        var distinctSpecies = model.GetDistinctSpecies();

        // Assert
        Assert.Equal(3, distinctSpecies.Count);
        Assert.Equal("All", distinctSpecies[0]);
        Assert.Contains("Dog", distinctSpecies);
        Assert.Contains("Cat", distinctSpecies);
    }

    [Theory]
    [InlineData("dog", "active")]
    [InlineData("cat", "")]
    public void CheckActiveSpecies_ShouldReturnActiveWhenMatch(string species, string expected)
    {
        // Arrange
        var model = new PetListViewModel
        {
            ActiveSpecies = "dog"
        };

        // Act
        var result = model.CheckActiveSpecies(species);

        // Assert
        Assert.Equal(expected, result);
    }
}

