using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Imi.Project.Api.Infrastructure.Data.Seeding;

public class IngredientSeeder
{
    // Too many possibilities for quantity (hoeveelheid) and MeasureUnit (maateenheid) exist for each ingedrient, so I'm not seeding those.

    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingredient>().HasData(
            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Name = "Melk"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Name = "Water"
            },
            
            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Name = "Knoflook"
            },
            
            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                Name = "Champignons"
            },
            
            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                Name = "Tomaten"
            },
            
            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                Name = "Gehakt"
            },
            
            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                Name = "Ajuin"
            },
            
            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                Name = "Spaghettikruiden"
            },
            
            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                Name = "Peper"
            },
            
            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                Name = "Zout"
            },
            
            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                Name = "Sambal Oelek"
            },
            
            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                Name = "Azijn"
            },
            
            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                Name = "Courgette"
            },
            
            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                Name = "Wortelen"
            },
            
            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000015"),
                Name = "Rode paprika"
            },
            
            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                Name = "Spaghetti"
            },
            
            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000017"),
                Name = "Boter"
            },
            
            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000018"),
                Name = "Olijfolie"
            },
            
            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000019"),
                Name = "Sojasaus"
            },
            
            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000020"),
                Name = "Aardappelen"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000021"),
                Name = "Worst(en)"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000022"),
                Name = "Appelmoes"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000023"),
                Name = "Nootmuskaat"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000024"),
                Name = "Kaas"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000025"),
                Name = "Ham"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000026"),
                Name = "Ei(eren)"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000027"),
                Name = "Kipfilet"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000028"),
                Name = "Suiker"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000029"),
                Name = "Komkommer"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000030"),
                Name = "Citroen"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000031"),
                Name = "Bonen"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000032"),
                Name = "Brochetten, gemarineerd"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000033"),
                Name = "Rijst"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000034"),
                Name = "Kipfilet"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000035"),
                Name = "Basilicum"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000036"),
                Name = "Tomatensaus"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000037"),
                Name = "Gemalen kaas"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000038"),
                Name = "Gebakken kip"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000039"),
                Name = "Couscous"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000040"),
                Name = "Ananassschijfjes"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000041"),
                Name = "Kabeljauw"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000042"),
                Name = "Paneermeel"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000043"),
                Name = "Kalfslap"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000044"),
                Name = "Broodkruimels"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000045"),
                Name = "Sojasaus"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000046"),
                Name = "Ham"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000047"),
                Name = "Bloem"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000048"),
                Name = "Kipfilet"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000049"),
                Name = "Citroensap"
            },

            new Ingredient
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000050"),
                Name = "Gemengde kruiden"
            }

            );
    }
}
