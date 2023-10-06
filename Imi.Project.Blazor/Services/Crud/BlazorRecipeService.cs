using Imi.Project.Api.Core.Entities;
using Imi.Project.Blazor.Models.Mocking;

namespace Imi.Project.Blazor.Services.Crud
{
    public class BlazorRecipeService : ICRUDService<MockRecipe>
    {
        static List<MockRecipe> recipes = new List<MockRecipe>
        {
            new MockRecipe() { Id=Guid.NewGuid(), Title="Gehaktbrood", Description="Meng gehakt en ajuin in een schaal en mix ze. Smijt de mix in een ovenpan en herschaap het tot een brood. Doe er vervolgens paneermeel en boter over. 20 minuten in de combi-oven. Kook de patatten en de bonen. Smakelijk." },
            new MockRecipe() { Id=Guid.NewGuid(), Title="Witte saus", Description="Maak een roux van de boter en de bloem. Dit doe je door de boter in een steelpannetje te smelten. Doe de bloem bij de boter en roer met de garde. Laat het mengsel een beetje opdrogen in het pannetje, tot je de geur van koekjes ruikt. Giet er beetje bij beetje de koude melk bij en roer telkens het mengsel glad. Breng al roerend aan de kook, op matig vuur. Laat de witte saus indikken en laat nog enkele minuten doorkoken zodat de bloemsmaak verdwijnt. Breng op smaak met nootmuskaat, peper en zout." },
            new MockRecipe() { Id=Guid.NewGuid(), Title="Hamburger", Description="Wortelen snijden en koken. Kook de patatten. Doe de hamburger in een pan en laat het bakken. Easy-peasy." }
        };

        public Task<MockRecipe> Get(Guid id)
        {
            return Task.FromResult(
                recipes.SingleOrDefault(x => x.Id == id)
                );
        }

        public Task<IQueryable<MockRecipe>> GetAll()
        {
            return Task.FromResult(
                recipes.Select(x => new MockRecipe()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description
                }).AsQueryable()
                );
        }

        public Task Create(MockRecipe item)
        {
            //item.Id = recipes.Count() > 0 ? recipes.Max(x => x.Id) + 1 : 1;
            item.Id = Guid.NewGuid();
            recipes.Add(item);
            return Task.CompletedTask;
        }

        public Task Update(MockRecipe item)
        {
            var recipe = recipes.SingleOrDefault(x => x.Id == item.Id);

            if (recipe == null) throw new ArgumentException("Recipe not found...");

            recipe.Title = item.Title;
            recipe.Description = item.Description;

            return Task.CompletedTask;
        }

        public Task Delete(Guid id)
        {
            var recipe = recipes.SingleOrDefault(x => x.Id == id);

            if (recipe == null) throw new ArgumentException("Recipe not found...");

            recipes.Remove(recipe);
            return Task.CompletedTask;
        }
    }
}