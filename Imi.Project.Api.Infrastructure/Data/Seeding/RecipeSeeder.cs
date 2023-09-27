using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Imi.Project.Api.Infrastructure.Data.Seeding;

public class RecipeSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>().HasData(
            new Recipe
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Title = "Worst met appelmoes en patatten",
                Description = "Doe boter in een pan, bak de worst goed. Schil patatten en kook ze in water. Serveren met appelmoes.",
                UserId = "00000000-0000-0000-0000-000000000004"
            },

            new Recipe
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Title = "Spaghetti bolognaise",
                Description = "Snij de groenten in stukken, zo klein naar wens. Doe boter en ajuin in de pot, gooi de gesneden groenten achteraf in. Voeg tomatensaus en de kruiden toe. Bak gehakt in een pan en hak het in kleine stukken. Bak de spaghetti in een pot kokend water. Serveer met gemalen kaas.",
                UserId = "00000000-0000-0000-0000-000000000004"
            },

            new Recipe
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Title = "Brochetten met rijst en wortelen",
                Description = "Doe rijst in kokend water voor ongeveer 8 minuten. Plaats de gemarineerde brochetten in een ovenschaal met boter en zet het in de combioven op 180 graden voor 7 minuten en 30 seconden. Serveer met geraspte wortelen.",
                UserId = "00000000-0000-0000-0000-000000000004"
            },

            new Recipe
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                Title = "Gebakken kip met ananasschijfjes en couscous.",
                Description = "Typisch opwarm maaltijd. Zet de gebakken kip van de slager in de microgolfoven voor 5 minuten. Open het blik ananasschijfjes en leg een gewenste hoeveelheid op je bord. Gooi wat couscous in een schaaltje met water en warm op in microgolfoven voor 1 minuut. Smakelijk!",
                UserId = "00000000-0000-0000-0000-000000000005"
            },

            new Recipe
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                Title = "Puree met vis en gebakken champignons.",
                Description = "Warm boter op in de pan en leg de kabeljauw erin. Doe patatten in kokend water tot ze zacht zijn. Stamp ze tot een moes en mix er melk en nootmuskaat in. Snij champignons in stukken en bak ze in de pan. Breng op smaak met zout en peper.",
                UserId = "00000000-0000-0000-0000-000000000006"
            },

            new Recipe
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                Title = "Gehaktbrood met patatten en bonen",
                Description = "Kook de patatten. Doe boter in een pot, voeg ajuin en bonen aan toe. Zet het op een zacht vuurtje voor 20 minuten. Mix de gehakt met ajuin in een kom. Giet het vervolgens uit in een ovenschaal en vorm er een brood mee. Strooi paneermeel over het gehaktbrood en voeg er boter aan toe. Bak het vervolgens in de combioven voor 20 minuten aan 200 graden.",
                UserId = "00000000-0000-0000-0000-000000000007"
            },

            new Recipe
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                Title = "Vleeskommetje",
                Description = "Doop de kalfslap in een kom geklopte ei, daarna in broodkruimels. Bak het in de frituurpan tot het een mooie donkere kleur heeft. Kook ondertussen rijst. Doe de rijst in een kommetje, besprenkel met wat zout en peper. Doe 2 eieren in een pan en kluts het zachtjes voor wat textuur tot het zacht gebakken is. Leg de roerei over de rijst. Haal de kalfslap uit het frituurvet en snij het in gelijke stukken en plaats ze op het roerei. Kap er wat sojasaus over.",
                UserId = "00000000-0000-0000-0000-000000000008"
            },

            new Recipe
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                Title = "Eggs 'n bacon",
                Description = "Bak de ham, bak de eieren. Drink sinaasappelsap erbij voor max energie.",
                UserId = "00000000-0000-0000-0000-000000000004"
            },

            new Recipe
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                Title = "Witte saus",
                Description = "Maak een roux van de boter en de bloem. Dit doe je door de boter in een steelpannetje te smelten. Doe de bloem bij de boter en roer met de garde. Laat het mengsel een beetje opdrogen in het pannetje, tot je de geur van koekjes ruikt. Giet er beetje bij beetje de koude melk bij en roer telkens het mengsel glad. Breng al roerend aan de kook, op matig vuur. Laat de witte saus indikken en laat nog enkele minuten doorkoken zodat de bloemsmaak verdwijnt. Breng op smaak met nootmuskaat, peper en zout.",
                UserId = "00000000-0000-0000-0000-000000000009"
            },

            new Recipe
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                Title = "Gegrilde Kipfilet met Citroen en Kruiden",
                Description = "Een eenvoudig, smaakvol gerecht met sappige gegrilde kipfilets gemarineerd in citroensap, knoflook en kruiden.",
                UserId = "00000000-0000-0000-0000-000000000010"
            }

            );
    }
}
