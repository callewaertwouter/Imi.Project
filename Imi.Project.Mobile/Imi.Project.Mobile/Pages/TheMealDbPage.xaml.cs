using Imi.Project.Mobile.ViewModels;
using Xamarin.Forms;

namespace Imi.Project.Mobile.Pages
{
    public partial class TheMealDbPage : ContentPage
    {
        private TheMealDbViewModel viewModel;

        public TheMealDbPage()
        {
            InitializeComponent();
            viewModel = new TheMealDbViewModel();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.LoadRecipesAsync();
        }
    }
}
