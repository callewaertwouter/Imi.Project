using Imi.Project.Api.Core.Entities;
using Imi.Project.Blazor.Models;

namespace Imi.Project.Blazor.Services.Crud
{
    public class BlazorUserService : ICRUDService<MockUser>
    {
        static List<MockUser> users = new List<MockUser>
        {
            new MockUser() { Id=Guid.NewGuid(), Name="Wouter Callewaert"},
            new MockUser() { Id=Guid.NewGuid(), Name="David Norenberg"},
            new MockUser() { Id=Guid.NewGuid(), Name="Admin"},
        };

        public Task<MockUser> Get(Guid id)
        {
            return Task.FromResult(
                users.SingleOrDefault(x => x.Id == id)
                );
        }

        public Task<IQueryable<MockUser>> GetAll()
        {
            return Task.FromResult(
                users.Select(x => new MockUser()
                {
                    Id = x.Id,
                    Name = x.Name
                }).AsQueryable()
                );
        }

        public Task Create(MockUser item)
        {
            //item.Id = users.Count() > 0 ? users.Max(x => x.Id) + 1 : 1;
            item.Id = Guid.NewGuid();
            users.Add(item);
            return Task.CompletedTask;
        }

        public Task Update(MockUser item)
        {
            var user = users.SingleOrDefault(x => x.Id == item.Id);

            if (user == null) throw new ArgumentException("User not found...");

            user.Name = item.Name;
            // I don't think a new user will have created recipes already, so not including those

            return Task.CompletedTask;
        }

        public Task Delete(Guid id)
        {
            var user = users.SingleOrDefault(x => x.Id == id);

            if (user == null) throw new ArgumentException("User not found...");

            users.Remove(user);
            return Task.CompletedTask;
        }
    }
}
