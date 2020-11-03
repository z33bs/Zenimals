using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Zenimals.Data;
using ZenMvvm;
using ZenMvvm.Helpers;

namespace Zenimals.ViewModels
{
    public class AppShellViewModel
    {
        readonly INavigationService navigationService;

        public ICommand HelpCommand { get; }
        public ICommand RandomPageCommand { get; }            

        public AppShellViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            //ZM Instead of => new Command<string>(
            // async (url) => await Launcher.OpenAsync(url));
            HelpCommand = new SafeCommand<string>(
                Launcher.OpenAsync, mustRunOnCurrentSyncContext: true);
            RandomPageCommand = new SafeCommand(
                NavigateToRandomPageAsync, mustRunOnCurrentSyncContext: true);
        }

        async Task NavigateToRandomPageAsync()
        {
            var random = new Random();
            var alldata = DiContainer
                .Resolve<IEnumerable<IData>>();
            var randomAnimalData = alldata
                .ElementAt(random.Next(0, alldata.Count()))
                .Data;
            var animal = randomAnimalData
                .ElementAt(random.Next(0, randomAnimalData.Count));

            var state = navigationService.CurrentShell.CurrentState;
            await navigationService.GoToAsync(
                $"{state.Location}/details", animal);
            navigationService.CurrentShell.FlyoutIsPresented = false;
        }
    }
}
