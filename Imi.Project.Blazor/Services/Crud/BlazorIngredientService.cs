using Imi.Project.Blazor.Models.Mocking;
using Imi.Project.Blazor.Pages;

namespace Imi.Project.Blazor.Services.Crud
{
    public class BlazorIngredientService : ICRUDService<MockIngredient>
    {
        static List<MockIngredient> ingredients = new List<MockIngredient>
        {
            new MockIngredient() { Id =  Guid.NewGuid(), Name = "liter" },
            new MockIngredient() { Id =  Guid.NewGuid(), Name = "gram" },
            new MockIngredient() { Id =  Guid.NewGuid(), Name = "kilogram" },
            new MockIngredient() { Id =  Guid.NewGuid(), Name = "centiliter" },
            new MockIngredient() { Id =  Guid.NewGuid(), Name = "takje(s)" }
        };

        public Task<MockIngredient> Get(Guid id)
        {
            return Task.FromResult(
                ingredients.SingleOrDefault(x => x.Id == id)
                );
        }

        public Task<IQueryable<MockIngredient>> GetAll()
        {
            return Task.FromResult(
                ingredients.Select(x => new MockIngredient()
                {
                    Id = x.Id,
                    Name = x.Name,
                }).AsQueryable()
                );
        }

        public Task Create(MockIngredient item)
        {
            item.Id = Guid.NewGuid();
            ingredients.Add(item);
            return Task.CompletedTask;
        }

        public Task Update(MockIngredient item)
        {
            var ingredient = ingredients.SingleOrDefault(x => x.Id == item.Id);

            if (ingredient == null) throw new ArgumentException("Ingredient not found...");

            ingredient.Name = item.Name;

            return Task.CompletedTask;
        }

        public Task Delete(Guid id)
        {
            var ingredient = ingredients.SingleOrDefault(x => x.Id == id);

            if (ingredient == null) throw new ArgumentException("Ingredient not found...");

            ingredients.Remove(ingredient);
            return Task.CompletedTask;
        }
    }
}
