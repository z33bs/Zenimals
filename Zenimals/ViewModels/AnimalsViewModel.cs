using System.Windows.Input;
using Xamarin.Forms;
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
            SelectionChangedCommand = new SafeCommand<CollectionView>(
                async (collection) =>
                {
                    await navigationService.GoToAsync(
                        collection.StyleId, //use StyleId to pass route
                        (Animal)collection.SelectedItem);
                });
        }
    }
}
