using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Api;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.ViewModels
{
    public class TheMealDbViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TheMealDbRecipe> _recipes;

        public ObservableCollection<TheMealDbRecipe> Recipes
        {
            get { return _recipes; }
            set
            {
                _recipes = value;
                OnPropertyChanged();
            }
        }

        public TheMealDbViewModel()
        {
            Recipes = new ObservableCollection<TheMealDbRecipe>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async Task LoadRecipesAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                string apiUrl = "https://www.themealdb.com/api/json/v1/1/search.php?f=a";
                string json = await client.GetStringAsync(apiUrl);
                var result = JsonConvert.DeserializeObject<TheMealDbApiResponse>(json);

                if (result != null && result.Meals != null)
                {
                    Recipes.Clear();
                    foreach (var meal in result.Meals)
                    {
                        Recipes.Add(new TheMealDbRecipe
                        {
                            Id = meal.IdMeal,
                            Name = meal.StrMeal,
                            Category = meal.StrCategory,
                            Instructions = meal.StrInstructions
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
