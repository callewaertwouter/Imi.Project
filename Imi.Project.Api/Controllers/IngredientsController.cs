using Imi.Project.Api.Core.DTOs.Ingredient;
using Imi.Project.Api.Core.DTOs.Recipe;
using Imi.Project.Api.Core.DTOs.User;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Infrastructure;
using Imi.Project.Api.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers
{
    [Authorize]
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientsController(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;   
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ingredients = await _ingredientRepository.ListAllAsync();
            var ingredientDto = ingredients.Select(r => new IngredientResponseDto
            {
                Id = r.Id,
                Name = r.Name,
                Quantity = r.Quantity,
                MeasureUnit = r.MeasureUnit
            });

            return Ok(ingredientDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var ingredient = await _ingredientRepository.GetByIdAsync(id);

            if (ingredient == null) return NotFound($"No ingredient found with an id of {id}.");

            var ingredientDto = new IngredientResponseDto
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Quantity = ingredient.Quantity,
                MeasureUnit = ingredient.MeasureUnit
            };

            return Ok(ingredientDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(IngredientRequestDto ingredientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ingredientEntity = new Ingredient
            {
                Name = ingredientDto.Name
            };

            await _ingredientRepository.AddAsync(ingredientEntity);

            return Ok("Ingredient added successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> Update(IngredientRequestDto ingredientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var ingredientEntity = await _ingredientRepository.GetByIdAsync(ingredientDto.Id);

            if (ingredientEntity == null)
            {
                return NotFound($"No ingredient with an id of {ingredientDto.Id}");
            }

            ingredientEntity.Name = ingredientDto.Name;

            await _ingredientRepository.UpdateAsync(ingredientEntity);

            return Ok("Ingredient updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ingredientEntity = await _ingredientRepository.GetByIdAsync(id);

            if (ingredientEntity == null)
            {
                return NotFound($"No ingedrient with an id of {id}");
            }

            await _ingredientRepository.DeleteAsync(ingredientEntity);

            return Ok("Ingredient deleted successfully.");
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string searchQuery)
        {
            var searchResults = await _ingredientRepository.SearchAsync(searchQuery);

            var searchResultsDto = searchResults.Select(s => new SearchIngredientResponseDto
            {
                Name = s.Name
            });

            return Ok(searchResultsDto);
        }
    }
}
