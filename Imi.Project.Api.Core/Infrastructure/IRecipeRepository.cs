using Imi.Project.Api.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Infrastructure;

public interface IRecipeRepository : IBaseRepository<Recipe>
{
    Task<Recipe> GetByTitleAsync(string title);
    Task<IEnumerable<Recipe>> SearchAsync(string search);
}
