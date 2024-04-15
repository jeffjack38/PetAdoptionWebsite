using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using PetAdoptionWebsite.Models;
using FluentAssertions;

namespace PetAdoptionWebsite.Test.Models
{
    public class AddPetViewModelTests
    {
        [Theory]
        [InlineData("", false)]
        [InlineData("Buddy", true)]
        [InlineData("adkcidkelakdicngioldithenidliwneildivneislivneiliesjnslkeliijfalk;dneiojrlijeoiejsdlkfjaldkjfeojfeoijf", false)]
        public void Name_Should_Validate_StringLength_And_Required(string name, bool expectedValidity)
        {
            // Arrange
            var model = new AddPetViewModel
            {
                Name = name,
                Species = "Dog",
                Age = 5,
                BondedBuddyStatus = "None",
                Description = "A friendly dog",
                SpecialCareInstructions = "No special care needed"
            };

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            var isValid = validationResults.Count == 0;
            isValid.Should().Be(expectedValidity);
        }

        [Theory]
        [InlineData(51, false)]
        [InlineData(0, true)]
        [InlineData(-1, false)]
        [InlineData(25, true)]
        public void Age_Should_Validate_Range(int age, bool expectedValidity)
        {
            // Arrange
            var model = new AddPetViewModel
            {
                Name = "Lucky",
                Species = "Cat",
                Age = age,
                BondedBuddyStatus = "None",
                Description = "A calm cat",
                SpecialCareInstructions = "Requires daily medication"
            };

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            var isValid = validationResults.Count == 0;
            isValid.Should().Be(expectedValidity);
        }

        private List<ValidationResult> ValidateModel(AddPetViewModel model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, serviceProvider: null, items: null);
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }
    }
}

