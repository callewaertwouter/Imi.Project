using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace Imi.Project.Mobile.ViewModels
{
	public class RecipesViewModel : FreshBasePageModel
	{
		public ObservableCollection<string> Recipes { get; set; }

		public RecipesViewModel()
		{
			Recipes = new ObservableCollection<string>();
			LoadRecipes();
		}

		private async void LoadRecipes()
		{
			try
			{
				using (var httpClient = new HttpClient())
				{
					var apiUrl = "https://localhost:5001/api/Recipes";
					var response = await httpClient.GetAsync(apiUrl);

					if (response.IsSuccessStatusCode)
					{
						var content = await response.Content.ReadAsStringAsync();
						var recipes = JsonConvert.DeserializeObject<List<Recipe>>(content);

						foreach (var recipe in recipes)
						{
							Recipes.Add(recipe.Title);
						}
					}
					else
					{
						await CoreMethods.DisplayAlert("Probleem", "Iets misgelopen.", "OK");
					}
				}
			}
			catch (HttpRequestException ex)
			{
				await CoreMethods.DisplayAlert("Error", "An error occurred: " + ex.Message + ex.InnerException, "OK");
			}
		}
	}
}
