using Microsoft.AspNetCore.Http;
using Moq;
using Newtonsoft.Json;
using PetAdoptionWebsite.Models;
using System.Collections.Generic;
using Xunit;

public class PetSessionTests
{
    private readonly Mock<ISession> mockSession;
    private readonly PetSession petSession;
    private readonly List<Pet> samplePets;

    public PetSessionTests()
    {
        mockSession = new Mock<ISession>();
        petSession = new PetSession(mockSession.Object);
        samplePets = new List<Pet>
        {
            new Pet { Id = 1, Name = "Rex", Species = "Dog" },
            new Pet { Id = 2, Name = "Mittens", Species = "Cat" }
        };

        // Setup the session mock to simulate real session behavior
        mockSession.Setup(x => x.SetObject(PetListKey, It.IsAny<List<Pet>>()))
                   .Callback<string, List<Pet>>((key, value) => mockSession.Setup(s => s.GetObject<List<Pet>>(key)).Returns(value));

        mockSession.Setup(x => x.SetInt32(CountKey, It.IsAny<int>()))
                   .Callback<string, int>((key, value) => mockSession.Setup(s => s.GetInt32(key)).Returns(value));

        mockSession.Setup(x => x.Remove(It.IsAny<string>()))
                   .Callback<string>(key => mockSession.Setup(s => s.GetObject<List<Pet>>(key)).Returns(() => null));
    }

    [Fact]
    public void SetPetList_ShouldStorePetsAndCount()
    {
        // Act
        petSession.SetPetList(samplePets);

        // Assert
        mockSession.Verify(s => s.SetObject(PetListKey, samplePets), Times.Once);
        mockSession.Verify(s => s.SetInt32(CountKey, samplePets.Count), Times.Once);
    }

    [Fact]
    public void GetMyPets_ShouldReturnStoredPets()
    {
        // Arrange
        mockSession.Setup(s => s.GetObject<List<Pet>>(PetListKey)).Returns(samplePets);

        // Act
        var pets = petSession.GetMyPets();

        // Assert
        Assert.Equal(samplePets, pets);
    }

    [Fact]
    public void GetMyPetCount_ShouldReturnCorrectCount()
    {
        // Arrange
        mockSession.Setup(s => s.GetInt32(CountKey)).Returns(samplePets.Count);

        // Act
        var count = petSession.GetMyPetCount();

        // Assert
        Assert.Equal(samplePets.Count, count);
    }

    [Fact]
    public void RemoveMyPets_ShouldClearSessionData()
    {
        // Act
        petSession.RemoveMyPets();

        // Assert
        mockSession.Verify(s => s.Remove(PetListKey), Times.Once);
        mockSession.Verify(s => s.Remove(CountKey), Times.Once);
    }
}

