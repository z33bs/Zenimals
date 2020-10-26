using System.Windows.Input;
using Zenimals.Models;
using ZenMvvm;
using ZenMvvm.Helpers;

namespace Zenimals.ViewModels
{
    public class AnimalsViewModel
    {
        public ICommand SelectionChangedCommand { get; }

        public AnimalsViewModel(INavigationService navigationService)
        {
            SelectionChangedCommand = new SafeCommand<Animal>(
                async (animal) =>
                    await navigationService.GoToAsync<Animal>($"details",animal));
        }
    }
}
