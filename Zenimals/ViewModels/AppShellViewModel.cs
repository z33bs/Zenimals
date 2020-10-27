using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Zenimals.Data;
using Zenimals.Models;
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

            //ZM Instead of => new Command<string>(async (url) => await Launcher.OpenAsync(url));
            HelpCommand = new SafeCommand<string>(Launcher.OpenAsync, mustRunOnCurrentSyncContext: true);
            RandomPageCommand = new SafeCommand(NavigateToRandomPageAsync, mustRunOnCurrentSyncContext: true);
        }

        async Task NavigateToRandomPageAsync()
        {
            var rand = new Random();
            var destinationRoute = "details";

            var AnimalData = new Func<Animal>[] {
                ()=> MonkeyData.Monkeys.ElementAt(rand.Next(0, MonkeyData.Monkeys.Count)),
                ()=> BearData.Bears.ElementAt(rand.Next(0, BearData.Bears.Count)),
                ()=> CatData.Cats.ElementAt(rand.Next(0, CatData.Cats.Count)),
                ()=> DogData.Dogs.ElementAt(rand.Next(0, DogData.Dogs.Count)),
                ()=> ElephantData.Elephants.ElementAt(rand.Next(0, ElephantData.Elephants.Count)),
            };

            var animal = AnimalData.ElementAt(rand.Next(0, AnimalData.Length)).Invoke();

            ShellNavigationState state = navigationService.CurrentShell.CurrentState;
            await navigationService.GoToAsync<Animal>(
                $"{state.Location}/{destinationRoute}", animal);
            navigationService.CurrentShell.FlyoutIsPresented = false;
        }
    }
}
