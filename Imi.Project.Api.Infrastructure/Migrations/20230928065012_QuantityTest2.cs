using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Imi.Project.Api.Infrastructure.Migrations
{
    public partial class QuantityTest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HasApprovedTermsAndConditions = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    MeasureUnit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IngredientRecipe",
                columns: table => new
                {
                    IngredientsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientRecipe", x => new { x.IngredientsId, x.RecipesId });
                    table.ForeignKey(
                        name: "FK_IngredientRecipe_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientRecipe_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000001", "fda4e305-450d-4b07-a007-38678906e5b4", "Admin", "ADMIN" },
                    { "00000000-0000-0000-0000-000000000002", "ea08860d-4e81-4a8d-bc69-ff9b5f47f30a", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "HasApprovedTermsAndConditions", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000001", 0, "11b3e8bf-c561-4408-8548-161331b892bb", "user@imi.be", true, true, false, null, "USER@IMI.BE", "IMIUSER", "AQAAAAEAACcQAAAAEEaBwZcEWhyza4SybBAD1Axiw9B7MTbKKnbv/EmD6BD04NbpfkkCKvw2Hyzqhi5b7w==", null, false, "ac0474a2-b76d-4701-be54-5fce7ee5a53c", false, "ImiUser" },
                    { "00000000-0000-0000-0000-000000000002", 0, "5039c966-0e71-4f9b-8d2d-41aaeeda5a78", "refuser@imi.be", true, false, false, null, "REFUSER@IMI.BE", "IMIREFUSER", "AQAAAAEAACcQAAAAEPDjZGDN9rkPA5WNvZp5ymLQg7J6xIk+HeRmzPpazBvfMwebgreDBMuYwvR7g2eI7w==", null, false, "73d841b6-1284-4e6f-b417-3c7eea01453d", false, "ImiRefuser" },
                    { "00000000-0000-0000-0000-000000000003", 0, "c8d0a58b-947a-48c3-ab79-51888a7ac0c6", "admin@imi.be", true, false, false, null, "ADMIN@IMI.BE", "IMIADMIN", "AQAAAAEAACcQAAAAEPNbQ0jof5fKNWg4VYEvwIU0lcedoVjdaRoGacH1ypJtMmuV7AiGSq9V8POH3Z7Ixw==", null, false, "f17faf8b-3985-4670-ba77-4a127cf0ca55", false, "ImiAdmin" },
                    { "00000000-0000-0000-0000-000000000004", 0, "aa6d6b75-ab20-47bc-957e-e80dd781da3c", "woutercallewaert@gmail.com", true, true, false, null, "WOUTERCALLEWAERT@GMAIL.COM", "YUSIFER", "AQAAAAEAACcQAAAAEF60+L9RlH0dmXlGeTuVy2muVn+TdEMB27CoEcK7J84COFdqLfW3gT6g0S4G3jGUSw==", null, false, "a18189e0-67d1-42e3-9336-77821da7b386", false, "Yusifer" },
                    { "00000000-0000-0000-0000-000000000005", 0, "da76a27a-6f33-4261-a23a-d1215d792a7a", "alice@example.com", true, true, false, null, "ALICE@EXAMPLE.COM", "ALICE", "AQAAAAEAACcQAAAAEApq2SItojC7iZh/AStWq8GWRtqu9kBIMZr5UeurDTJdAWTaWE683/MF9wrpnzabeQ==", null, false, "ff046e96-ffff-4232-8915-408baae729e8", false, "Alice" },
                    { "00000000-0000-0000-0000-000000000006", 0, "82fd7b27-ebb6-4f67-91ea-5ac430291349", "bob@example.com", true, true, false, null, "BOB@EXAMPLE.COM", "BOB", "AQAAAAEAACcQAAAAEPi9ZJOC4mornxALLQ02Z3e9tTIZtKejCc1Z45fIhaku1HH76WCb2ClWUzHsKT27TQ==", null, false, "b705058f-ae16-48aa-a9e9-70642e8e165c", false, "Bob" },
                    { "00000000-0000-0000-0000-000000000007", 0, "3e5df598-d4f6-46bb-9e20-97007e4fee97", "charlie@example.com", true, true, false, null, "CHARLIE@EXAMPLE.COM", "CHARLIE", "AQAAAAEAACcQAAAAEJGdEGmLVpxhXRxZ8Zx5U89M4qq/8cabWseyJ9UPdLqZ8Ey/fZkesjhIBKqPmOlRXQ==", null, false, "df88f3c7-7d88-4815-8bb6-0b9db1bd05bf", false, "Charlie" },
                    { "00000000-0000-0000-0000-000000000008", 0, "65b06833-3fa3-43d8-95d0-26c0f949f584", "david@example.com", true, true, false, null, "DAVID@EXAMPLE.COM", "DAVID", "AQAAAAEAACcQAAAAEOKa+htHPYvEN6cE19q8q0O6BtwmFToqMYSErw1qFst9BCO6SNTqS6Po/vFoa252IA==", null, false, "a4ed60a8-1c3d-462a-a4ca-bb5600d2fff3", false, "David" },
                    { "00000000-0000-0000-0000-000000000009", 0, "c7434fa4-2b0b-41cb-b05d-b7dbc62d72c5", "eva@example.com", true, true, false, null, "EVA@EXAMPLE.COM", "EVA", "AQAAAAEAACcQAAAAEAVSQ54bAZQwvb+4Kh2gb4Z3NyHzk8GiLdm1bvcWjrsLffnzweDwSnLogGqbbbL6hg==", null, false, "6e3f3940-fa3b-4eab-bdf8-e5bbc6e6ce41", false, "Eva" },
                    { "00000000-0000-0000-0000-000000000010", 0, "49e9fd59-3be5-4ff8-a14b-df9b2a2b4b38", "fiona@example.com", true, true, false, null, "FIONA@EXAMPLE.COM", "FIONA", "AQAAAAEAACcQAAAAEMqCzZyaWxzb/gk9FGJ0nNii6iauY/dyztL4i6jrXUVyyq9cAiWGpQHlSnNlbcP8CA==", null, false, "e9416f0f-fbbf-41fc-9484-62f9925d64f8", false, "Fiona" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "MeasureUnit", "Name", "Quantity" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "<geen>", "Melk", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "<geen>", "Water", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "<geen>", "Knoflook", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "<geen>", "Champignons", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "<geen>", "Tomaten", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "<geen>", "Gehakt", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "<geen>", "Ajuin", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "<geen>", "Spaghettikruiden", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "<geen>", "Peper", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "<geen>", "Zout", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "<geen>", "Sambal Oelek", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "<geen>", "Azijn", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "<geen>", "Courgette", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "<geen>", "Wortelen", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000015"), "<geen>", "Rode paprika", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000016"), "<geen>", "Spaghetti", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000017"), "<geen>", "Boter", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000018"), "<geen>", "Olijfolie", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000019"), "<geen>", "Sojasaus", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000020"), "<geen>", "Aardappelen", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000021"), "<geen>", "Worst(en)", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000022"), "<geen>", "Appelmoes", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000023"), "<geen>", "Nootmuskaat", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000024"), "<geen>", "Kaas", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000025"), "<geen>", "Ham", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000026"), "<geen>", "Ei(eren)", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000027"), "<geen>", "Kipfilet", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000028"), "<geen>", "Suiker", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000029"), "<geen>", "Komkommer", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000030"), "<geen>", "Citroen", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "MeasureUnit", "Name", "Quantity" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000031"), "<geen>", "Bonen", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000032"), "<geen>", "Brochetten, gemarineerd", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000033"), "<geen>", "Rijst", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000034"), "<geen>", "Kipfilet", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000035"), "<geen>", "Basilicum", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000036"), "<geen>", "Tomatensaus", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000037"), "<geen>", "Gemalen kaas", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000038"), "<geen>", "Gebakken kip", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000039"), "<geen>", "Couscous", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000040"), "<geen>", "Ananassschijfjes", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000041"), "<geen>", "Kabeljauw", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000042"), "<geen>", "Paneermeel", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000043"), "<geen>", "Kalfslap", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000044"), "<geen>", "Broodkruimels", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000045"), "<geen>", "Sojasaus", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000046"), "<geen>", "Ham", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000047"), "<geen>", "Bloem", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000048"), "<geen>", "Kipfilet", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000049"), "<geen>", "Citroensap", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000050"), "<geen>", "Gemengde kruiden", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000002", "00000000-0000-0000-0000-000000000001" },
                    { "00000000-0000-0000-0000-000000000002", "00000000-0000-0000-0000-000000000002" },
                    { "00000000-0000-0000-0000-000000000001", "00000000-0000-0000-0000-000000000003" },
                    { "00000000-0000-0000-0000-000000000001", "00000000-0000-0000-0000-000000000004" },
                    { "00000000-0000-0000-0000-000000000002", "00000000-0000-0000-0000-000000000005" },
                    { "00000000-0000-0000-0000-000000000002", "00000000-0000-0000-0000-000000000006" },
                    { "00000000-0000-0000-0000-000000000002", "00000000-0000-0000-0000-000000000007" },
                    { "00000000-0000-0000-0000-000000000002", "00000000-0000-0000-0000-000000000008" },
                    { "00000000-0000-0000-0000-000000000002", "00000000-0000-0000-0000-000000000009" },
                    { "00000000-0000-0000-0000-000000000002", "00000000-0000-0000-0000-000000000010" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Doe boter in een pan, bak de worst goed. Schil patatten en kook ze in water. Serveren met appelmoes.", "Worst met appelmoes en patatten", "00000000-0000-0000-0000-000000000004" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Snij de groenten in stukken, zo klein naar wens. Doe boter en ajuin in de pot, gooi de gesneden groenten achteraf in. Voeg tomatensaus en de kruiden toe. Bak gehakt in een pan en hak het in kleine stukken. Bak de spaghetti in een pot kokend water. Serveer met gemalen kaas.", "Spaghetti bolognaise", "00000000-0000-0000-0000-000000000004" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Doe rijst in kokend water voor ongeveer 8 minuten. Plaats de gemarineerde brochetten in een ovenschaal met boter en zet het in de combioven op 180 graden voor 7 minuten en 30 seconden. Serveer met geraspte wortelen.", "Brochetten met rijst en wortelen", "00000000-0000-0000-0000-000000000004" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Typisch opwarm maaltijd. Zet de gebakken kip van de slager in de microgolfoven voor 5 minuten. Open het blik ananasschijfjes en leg een gewenste hoeveelheid op je bord. Gooi wat couscous in een schaaltje met water en warm op in microgolfoven voor 1 minuut. Smakelijk!", "Gebakken kip met ananasschijfjes en couscous.", "00000000-0000-0000-0000-000000000005" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Warm boter op in de pan en leg de kabeljauw erin. Doe patatten in kokend water tot ze zacht zijn. Stamp ze tot een moes en mix er melk en nootmuskaat in. Snij champignons in stukken en bak ze in de pan. Breng op smaak met zout en peper.", "Puree met vis en gebakken champignons.", "00000000-0000-0000-0000-000000000006" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Kook de patatten. Doe boter in een pot, voeg ajuin en bonen aan toe. Zet het op een zacht vuurtje voor 20 minuten. Mix de gehakt met ajuin in een kom. Giet het vervolgens uit in een ovenschaal en vorm er een brood mee. Strooi paneermeel over het gehaktbrood en voeg er boter aan toe. Bak het vervolgens in de combioven voor 20 minuten aan 200 graden.", "Gehaktbrood met patatten en bonen", "00000000-0000-0000-0000-000000000007" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Doop de kalfslap in een kom geklopte ei, daarna in broodkruimels. Bak het in de frituurpan tot het een mooie donkere kleur heeft. Kook ondertussen rijst. Doe de rijst in een kommetje, besprenkel met wat zout en peper. Doe 2 eieren in een pan en kluts het zachtjes voor wat textuur tot het zacht gebakken is. Leg de roerei over de rijst. Haal de kalfslap uit het frituurvet en snij het in gelijke stukken en plaats ze op het roerei. Kap er wat sojasaus over.", "Vleeskommetje", "00000000-0000-0000-0000-000000000008" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Bak de ham, bak de eieren. Drink sinaasappelsap erbij voor max energie.", "Eggs 'n bacon", "00000000-0000-0000-0000-000000000004" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Maak een roux van de boter en de bloem. Dit doe je door de boter in een steelpannetje te smelten. Doe de bloem bij de boter en roer met de garde. Laat het mengsel een beetje opdrogen in het pannetje, tot je de geur van koekjes ruikt. Giet er beetje bij beetje de koude melk bij en roer telkens het mengsel glad. Breng al roerend aan de kook, op matig vuur. Laat de witte saus indikken en laat nog enkele minuten doorkoken zodat de bloemsmaak verdwijnt. Breng op smaak met nootmuskaat, peper en zout.", "Witte saus", "00000000-0000-0000-0000-000000000009" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "Een eenvoudig, smaakvol gerecht met sappige gegrilde kipfilets gemarineerd in citroensap, knoflook en kruiden.", "Gegrilde Kipfilet met Citroen en Kruiden", "00000000-0000-0000-0000-000000000010" }
                });

            migrationBuilder.InsertData(
                table: "IngredientRecipe",
                columns: new[] { "IngredientsId", "RecipesId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000018"), new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000021"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000022"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000023"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000023"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000026"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000026"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000031"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000032"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000033"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000033"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000036"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000037"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000038"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000039"), new Guid("00000000-0000-0000-0000-000000000004") }
                });

            migrationBuilder.InsertData(
                table: "IngredientRecipe",
                columns: new[] { "IngredientsId", "RecipesId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000040"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000041"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000042"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000043"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000044"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000045"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000046"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000047"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000048"), new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000049"), new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000050"), new Guid("00000000-0000-0000-0000-000000000010") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientRecipe_RecipesId",
                table: "IngredientRecipe",
                column: "RecipesId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserId",
                table: "Recipes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "IngredientRecipe");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
