using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Zenimals.Data;
using Zenimals.Views;
using ZenMvvm;
using ZenMvvm.Helpers;

namespace Zenimals
{
    public partial class AppShell : Shell
    {
        public ICommand HelpCommand { get; }
        public ICommand RandomPageCommand { get; }

        public AppShell()
        {
            InitializeComponent();

            RegisterRoutes();

            //ZM: SafeCommand avoids the need for async void lambdas
            // async (url) => await Launcher.OpenAsync(url)
            // async () => await NavigateToRandomPageAsync()
            HelpCommand = new SafeCommand<string>(
                Launcher.OpenAsync, mustRunOnCurrentSyncContext: true);
            // mustRunOnCurrentSyncContext: true ensures the command
            // runs on the UI thread 
            RandomPageCommand = new SafeCommand(
                NavigateToRandomPageAsync, mustRunOnCurrentSyncContext: true);

            BindingContext = this;
        }

        void RegisterRoutes()
        {
            var routes = new Dictionary<string, Type>
            {
                { "details", typeof(AnimalDetailPage) }
            };

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }

        async Task NavigateToRandomPageAsync()
        {
            Random random = new Random();
            INavigationService navigationService = DiContainer.Resolve<INavigationService>();

            //ZM: Resolve<IEnumerable<IData>> returns all classes that
            // implement IData in an enumerable
            var alldata = DiContainer
                .Resolve<IEnumerable<IData>>();
            var randomAnimalData = alldata
                .ElementAt(random.Next(0, alldata.Count()))
                .Data;
            var animal = randomAnimalData
                .ElementAt(random.Next(0, randomAnimalData.Count));

            await navigationService.GoToAsync(
                $"{CurrentState.Location}/details", animal);

            FlyoutIsPresented = false;
        }

        void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {
            // Cancel any back navigation
            //if (e.Source == ShellNavigationSource.Pop)
            //{
            //    e.Cancel();
            //}
        }

        void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {
        }
    }
}
