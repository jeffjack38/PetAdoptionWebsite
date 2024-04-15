using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using PetAdoptionWebsite.Models; 

public class PetModelTests
{
    [Fact]
    public void PetModel_ValidationDetectsRequiredFields()
    {
        // Arrange
        var pet = new Pet();
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(pet);

        // Act
        var isValid = Validator.TryValidateObject(pet, validationContext, validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, v => v.ErrorMessage.Contains("Please enter a name for the pet."));
        Assert.Contains(validationResults, v => v.ErrorMessage.Contains("Please enter a species for the pet."));
        Assert.Contains(validationResults, v => v.ErrorMessage.Contains("Please enter a bonded buddy status"));
        Assert.Contains(validationResults, v => v.ErrorMessage.Contains("Please enter a description for the pet."));
        Assert.Contains(validationResults, v => v.ErrorMessage.Contains("Please enter special care instructions."));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(51)]
    public void PetModel_ValidationDetectsAgeOutOfRange(int invalidAge)
    {
        // Arrange
        var pet = new Pet { Age = invalidAge };
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(pet);

        // Act
        var isValid = Validator.TryValidateObject(pet, validationContext, validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, v => v.ErrorMessage.Contains("Please enter an age less than 50."));
    }
}
