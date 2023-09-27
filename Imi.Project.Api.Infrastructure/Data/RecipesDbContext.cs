using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Infrastructure.Data.Seeding;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Imi.Project.Api.Infrastructure.Data;

public class RecipesDbContext : IdentityDbContext<User>
{
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Recipe> Recipes { get; set; }

    public RecipesDbContext(DbContextOptions<RecipesDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        IngredientSeeder.Seed(modelBuilder);
        UserSeeder.Seed(modelBuilder);
        RecipeSeeder.Seed(modelBuilder);

        modelBuilder.Entity<Recipe>()
            .HasMany(r => r.Ingredients)
            .WithMany(i => i.Recipes)
            .UsingEntity(x => x.HasData(
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000001"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000021") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000001"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000022") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000001"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000020") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000001"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000017") },

                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000002"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000013") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000002"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000014") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000002"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000015") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000002"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000016") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000002"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000017") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000002"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000011") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000002"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000006") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000002"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000007") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000002"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000008") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000002"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000004") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000002"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000036") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000002"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000037") },

                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000003"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000032") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000003"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000017") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000003"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000033") },

                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000004"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000038") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000004"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000039") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000004"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000040") },

                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000005"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000041") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000005"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000023") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000005"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000020") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000005"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000017") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000005"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000004") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000005"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000001") },

                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000006"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000042") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000006"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000031") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000006"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000020") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000006"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000017") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000006"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000006") },

                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000007"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000043") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000007"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000026") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000007"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000044") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000007"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000033") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000007"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000045") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000007"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000009") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000007"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000010") },

                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000008"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000046") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000008"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000026") },

                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000009"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000017") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000009"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000047") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000009"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000001") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000009"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000009") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000009"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000010") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000009"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000023") },

                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000010"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000048") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000010"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000049") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000010"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000003") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000010"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000018") },
                new { RecipesId = Guid.Parse("00000000-0000-0000-0000-000000000010"), IngredientsId = Guid.Parse("00000000-0000-0000-0000-000000000050") }

                ));
    }
}