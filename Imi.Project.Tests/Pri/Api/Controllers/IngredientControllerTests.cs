using Imi.Project.Api.Controllers;
using Imi.Project.Api.Core.DTOs.Ingredient;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Infrastructure;
using Moq;
using Xunit;

namespace Imi.Project.Tests.Pri.Api.Controllers;

public class IngredientControllerTests
{
    private readonly Mock<IIngredientRepository> ingredientRepository;

    public IngredientControllerTests()
    {
        ingredientRepository = new Mock<IIngredientRepository>();
    }

    [Fact]
    public async Task AddIngredient_WithValidInput_ReturnOk()
    {
        // Arrange
        var controller = new IngredientsController(ingredientRepository.Object);

        var ingredient = new IngredientRequestDto
        {
            Id = Guid.NewGuid(),
            Name = "TestIngredient"
        };

        // Act
        var result = await controller.Add(ingredient);

        // Assert
        ingredientRepository.Verify(repo => repo.AddAsync(It.IsAny<Ingredient>()), Times.Once);
    }
}
