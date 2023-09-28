using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Infrastructure;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories;

public class IngredientRepository : BaseRepository<Ingredient>, IIngredientRepository
{
    public IngredientRepository(RecipesDbContext dbContext) : base(dbContext)
    {
    }

    public override IQueryable<Ingredient> GetAll()
    {
        return _dbContext.Ingredients.Include(i => i.Recipes);
    }

    public override async Task<Ingredient> UpdateAsync(Ingredient ingredient)
    {
        if (ingredient != null) _dbContext.Set<Ingredient>().Update(ingredient);

        await _dbContext.SaveChangesAsync();

        return ingredient;
    }

    public async Task<IEnumerable<Ingredient>> SearchAsync(string search)
    {
        var ingredients = await GetAll()
                            .Where(i => i.Name.Contains(search.Trim().ToUpper()))
                            .ToListAsync();

        return ingredients;
    }
}
