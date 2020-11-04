using Xamarin.Forms;

namespace Zenimals
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //ZM: No need to register dependencies
            // we'll rely on Smart Resolve to take care of this

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
