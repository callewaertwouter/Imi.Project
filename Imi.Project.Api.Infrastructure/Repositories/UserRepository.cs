using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Infrastructure;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(RecipesDbContext dbContext) : base(dbContext)
    {
    }

    public override IQueryable<User> GetAll()
    {
        return _dbContext.Users.Include(u => u.Recipes);
    }

    public async Task<IEnumerable<User>> SearchAsync(string search)
    {
        var users = await GetAll()
                            .Where(u => u.Email.Contains(search.Trim().ToUpper()))
                            .ToListAsync();

        return users;
    }
}
