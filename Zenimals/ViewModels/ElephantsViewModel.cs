using System.Windows.Input;
using ZenMvvm;
using ZenMvvm.Helpers;

namespace Zenimals.ViewModels
{
    public class ElephantsViewModel
    {
        public ICommand SelectionChangedCommand { get; }

        public ElephantsViewModel(INavigationService navigationService)
        {
            SelectionChangedCommand = new SafeCommand<string>(async (name) =>
                await navigationService.GoToAsync($"elephantdetails?name={name}"));
        }
    }
}
