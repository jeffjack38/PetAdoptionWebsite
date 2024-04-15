using PetAdoptionWebsite.Models;
using System.ComponentModel.DataAnnotations;
using Xunit;

public class RegisterViewModelTests
{
    [Fact]
    public void Should_Contain_Errors_When_Model_Is_Invalid()
    {
        // Arrange
        var model = new RegisterViewModel
        {
            // Intentionally leaving out required properties to trigger validation errors.
        };

        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(model);

        // Act
        var isValid = Validator.TryValidateObject(model, validationContext, validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.NotEmpty(validationResults); // Expecting validation errors.
    }
}
