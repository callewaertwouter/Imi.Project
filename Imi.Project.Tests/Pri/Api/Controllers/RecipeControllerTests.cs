using Imi.Project.Api.Controllers;
using Imi.Project.Api.Core.DTOs.Ingredient;
using Imi.Project.Api.Core.DTOs.Recipe;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Imi.Project.Tests.Pri.Api.Controllers;

public class RecipeControllerTests
{
    private readonly Mock<IRecipeRepository> recipeRepository;
    private readonly Mock<IIngredientRepository> ingredientRepository;

    public RecipeControllerTests()
    {
        recipeRepository = new Mock<IRecipeRepository>();
        ingredientRepository = new Mock<IIngredientRepository>();
    }

    [Fact]
    public async Task AddRecipe_WithExistingAndNewIngredients_AddsRecipe()
    {
        // Arrange
        var controller = new RecipesController(recipeRepository.Object, ingredientRepository.Object);

        var existingIngredient = new Ingredient
        {
            Id = Guid.NewGuid(),
            Name = "Existing Ingredient",
        };
        ingredientRepository.Setup(repo => repo.GetByNameAsync(existingIngredient.Name))
            .ReturnsAsync(existingIngredient);

        ingredientRepository.Setup(repo => repo.AddAsync(It.IsAny<Ingredient>()))
            .ReturnsAsync((Ingredient newIngredient) =>
            {
                newIngredient.Id = Guid.NewGuid();
                return newIngredient;
            });

        var recipeDto = new RecipeRequestDto
        {
            Title = "Test Recipe",
            Description = "Test Description",
            ListOfIngredients = new List<IngredientRequestDto>
                {
                    new IngredientRequestDto
                    {
                        Name = "Existing Ingredient",
                        Quantity = 2.0,
                        MeasureUnit = "grams",
                    },
                    new IngredientRequestDto
                    {
                        Name = "New Ingredient",
                        Quantity = 1.0,
                        MeasureUnit = "cups",
                    },
                },
        };

        // Act
        var result = await controller.Add(recipeDto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Recipe added successfully.", okResult.Value);

        recipeRepository.Verify(repo => repo.AddAsync(It.IsAny<Recipe>()), Times.Once);
        recipeRepository.Verify(repo => repo.AddAsync(It.Is<Recipe>(r => r.Ingredients.Contains(existingIngredient))), Times.Once);
        ingredientRepository.Verify(repo => repo.AddAsync(It.IsAny<Ingredient>()), Times.Once);
    }
}
