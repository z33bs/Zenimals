//todo about and help zenmvvm
//todo templates separated into templates folder
//todo neat styles?
//todo ZM comments allround
//todo WirespecificViewModel -> both assembly q ualified and default. Document this feature.
//todo AnimalsPage uses VM more

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
