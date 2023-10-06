using Imi.Project.Api.Core.Entities;
using Imi.Project.Blazor.Models.Mocking;
using Imi.Project.Blazor.Models;
using Imi.Project.Blazor.Services.Api;
using Imi.Project.Blazor.Services.Crud;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddTransient<ICRUDService<MockRecipe>, BlazorRecipeService>();
builder.Services.AddTransient<ICRUDService<MockUser>, BlazorUserService>();
builder.Services.AddTransient<ICRUDService<MockIngredient>, BlazorIngredientService>();

builder.Services.AddTransient<ICRUDService<User>, UserApiService>();
builder.Services.AddTransient<ICRUDService<Recipe>, RecipeApiService>();
builder.Services.AddTransient<ICRUDService<Ingredient>, IngredientApiService>();

builder.Services.AddMudServices();

builder.Services.AddScoped<HttpClient>();
builder.Services.AddSingleton<HttpClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

