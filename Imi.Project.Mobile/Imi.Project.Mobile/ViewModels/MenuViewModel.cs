using FreshMvvm;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class MenuViewModel : FreshBasePageModel
    {
        public MenuViewModel()
        {

        }

        public ICommand OpenRecipeCreationPageCommand => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<RecipeCreationViewModel>(true);
            }
            );

        public ICommand OpenMyRecipesPageCommand => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<MyRecipesViewModel>(true);
            }
            );

        public ICommand OpenRecipesPageCommand => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<RecipesViewModel>(true);
            }
            );

		public ICommand OpenTheMealDbPageCommand => new Command(
	        async () =>
	        {
                await CoreMethods.PushPageModel<TheMealDbViewModel>(true);
            }
	        );

		public ICommand CloseAppPageCommand => new Command(
            () =>
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
			}
            );               
    }
}
