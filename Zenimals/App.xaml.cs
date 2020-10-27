//todo vm-first approach : open generics applied to viewModel. And manual wiring.
//todo remove elephants
//todo about and help zenmvvm
//todo templates separated
//todo neat styles?
//todo ZM comments allround

using Xamarin.Forms;

namespace Zenimals
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
