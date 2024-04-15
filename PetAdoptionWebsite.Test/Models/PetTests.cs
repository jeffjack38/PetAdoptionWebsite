using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using PetAdoptionWebsite.Models;
using System.Linq;

public class PetTests
{
    [Theory]
    [InlineData("", "Dog", 5, "Yes", "Healthy pet", "No special care", false)] // Invalid name
    [InlineData("Buddy", "", 5, "No", "Calm and friendly", "Regular vet visits", false)] // Invalid species
    [InlineData("Buddy", "Dog", 55, "Yes", "Old and wise", "Senior care needed", false)] // Invalid age
    [InlineData("Buddy", "Dog", 5, "", "Loves to play", "Feed twice a day", false)] // Invalid bonded buddy status
    [InlineData("Buddy", "Dog", 5, "No", "", "No special care", false)] // Invalid description
    [InlineData("Buddy", "Dog", 5, "Yes", "Very active", "", false)] // Invalid special care instructions
    [InlineData("Buddy", "Dog", 5, "No", "Friendly and energetic", "Allergies to grain", true)] // All valid
    public void ValidatePet(string name, string species, int age, string bondedBuddyStatus, string description, string specialCareInstructions, bool expectedIsValid)
    {
        // Arrange
        var pet = new Pet
        {
            Name = name,
            Species = species,
            Age = age,
            BondedBuddyStatus = bondedBuddyStatus,
            Description = description,
            SpecialCareInstructions = specialCareInstructions
        };

        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(pet);

        // Act
        var isValid = Validator.TryValidateObject(pet, validationContext, validationResults, true);

        // Assert
        Assert.Equal(expectedIsValid, isValid);

        // Check for specific error messages if validation fails
        if (!isValid)
        {
            if (string.IsNullOrEmpty(name))
            {
                Assert.Contains(validationResults.Select(e => e.ErrorMessage), m => m.Contains("Please enter a name for the pet."));
            }
            if (string.IsNullOrEmpty(species))
            {
                Assert.Contains(validationResults.Select(e => e.ErrorMessage), m => m.Contains("Please enter a species for the pet."));
            }
            if (age > 50 || age < 0)
            {
                Assert.Contains(validationResults.Select(e => e.ErrorMessage), m => m.Contains("Please enter an age less than 50."));
            }
            if (string.IsNullOrEmpty(bondedBuddyStatus))
            {
                Assert.Contains(validationResults.Select(e => e.ErrorMessage), m => m.Contains("Please enter a bonded buddy status"));
            }
            if (string.IsNullOrEmpty(description))
            {
                Assert.Contains(validationResults.Select(e => e.ErrorMessage), m => m.Contains("Please enter a description for the pet."));
            }
            if (string.IsNullOrEmpty(specialCareInstructions))
            {
                Assert.Contains(validationResults.Select(e => e.ErrorMessage), m => m.Contains("Please enter special care instructions."));
            }
        }
    }
}

