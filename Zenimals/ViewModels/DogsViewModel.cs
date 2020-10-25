using System.Windows.Input;
using Zenimals.Models;
using ZenMvvm;
using ZenMvvm.Helpers;

namespace Zenimals.ViewModels
{
    public class DogsViewModel
    {
        public ICommand SelectionChangedCommand { get; }

        public DogsViewModel(INavigationService navigationService)
        { 
            SelectionChangedCommand = new SafeCommand<Animal>(
                async (dog) => await navigationService.GoToAsync("dogdetails", dog));
            // "dogdetails" works because route names are unique in this application. The full route is "//animals/domestic/dogs/dogdetails?name={dogName}");
        }
    }
}
