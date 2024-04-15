using System.ComponentModel.DataAnnotations;
using Xunit;
using PetAdoptionWebsite.Models;
using System.Collections.Generic;
using System.Linq;

public class LoginViewModelTests
{
    [Theory]
    [InlineData(null, null, false)] // Both fields are empty
    [InlineData("validUsername", null, false)] // Missing password
    [InlineData(null, "validPassword", false)] // Missing username
    [InlineData("validUsername", "validPassword", true)] // Both fields are valid
    public void ValidateLoginViewModel(string username, string password, bool expectedIsValid)
    {
        // Arrange
        var model = new LoginViewModel
        {
            Username = username,
            Password = password
        };

        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(model);

        // Act
        var isValid = Validator.TryValidateObject(model, validationContext, validationResults, true);

        // Assert
        Assert.Equal(expectedIsValid, isValid);

        // Additional detailed assert to check for specific error messages
        if (username == null)
        {
            Assert.Contains(validationResults.Select(e => e.ErrorMessage), m => m.Contains("Please enter a username."));
        }
        if (password == null)
        {
            Assert.Contains(validationResults.Select(e => e.ErrorMessage), m => m.Contains("Please enter a password."));
        }
    }
}
