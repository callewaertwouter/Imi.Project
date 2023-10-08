using FreshMvvm;
using Imi.Project.Mobile.ViewModels;
using Xamarin.Forms;

namespace Imi.Project.Mobile
{
	public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

			MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<MenuViewModel>());
		}

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
