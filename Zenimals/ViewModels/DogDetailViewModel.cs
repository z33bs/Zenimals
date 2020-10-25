using System.Threading.Tasks;
using Zenimals.Models;
using ZenMvvm;
using ZenMvvm.Helpers;

namespace Zenimals.ViewModels
{
    public class DogDetailViewModel : ObservableObject, IOnViewNavigated<Animal>
    {
        public Animal Dog { get; private set; }

        public Task OnViewNavigatedAsync(Animal dog)
        {
            Dog = dog;
            OnPropertyChanged(nameof(Dog));
            return Task.CompletedTask;
        }
    }
}
