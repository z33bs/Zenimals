using System.Threading.Tasks;
using Zenimals.Models;
using ZenMvvm;
using ZenMvvm.Helpers;

namespace Zenimals.ViewModels
{
    public class AnimalDetailViewModel : ObservableObject, IOnViewNavigated<Animal>
    {
        public Animal Animal { get; private set; }

        public Task OnViewNavigatedAsync(Animal animal)
        {
            Animal = animal;
            OnPropertyChanged(nameof(Animal));
            return Task.CompletedTask;
        }
    }
}
