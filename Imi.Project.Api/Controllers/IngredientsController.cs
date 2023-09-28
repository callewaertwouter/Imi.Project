using Imi.Project.Api.Core.DTOs.Ingredient;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers
{
    //[Authorize]
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

        [HttpPost]
        public async Task<IActionResult> Add(IngredientRequestDto ingredientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
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
    }
}
