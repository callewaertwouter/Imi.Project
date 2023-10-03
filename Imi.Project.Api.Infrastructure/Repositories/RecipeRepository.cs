using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Infrastructure;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories;

public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
{
    public RecipeRepository(RecipesDbContext dbContext) : base(dbContext)
    {
    }

    public override IQueryable<Recipe> GetAll()
    {
        return _dbContext.Recipes.Include(r => r.Ingredients)
                                 .Include(r => r.User);
    }

    public async override Task<IEnumerable<Recipe>> ListAllAsync()
    {
        var recipes = await GetAll().ToListAsync();

        return recipes;
    }

    public async override Task<Recipe> GetByIdAsync(Guid id)
    {
        var recipe = await GetAll().SingleOrDefaultAsync(r => r.Id.Equals(id));

        return recipe;
    }

    public async Task<Recipe> GetByTitleAsync(string title)
    {
        return await _dbContext.Set<Recipe>().SingleOrDefaultAsync(r => r.Title == title);
    }

    public async Task<IEnumerable<Recipe>> SearchAsync(string search)
    {
        var recipes = await GetAll()
                            .Where(r => r.Title.Contains(search.Trim().ToUpper()) || r.User.Email.Contains(search.Trim().ToUpper()))
                            .ToListAsync();

        return recipes;
    }


}
