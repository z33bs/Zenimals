using System.Threading.Tasks;
using Zenimals.Models;
using ZenMvvm;
using ZenMvvm.Helpers;

namespace Zenimals.ViewModels
{
    //ZM: ViewModel must Implement IOnViewNavigated<Animal> to recieve the
    // animal data. Use IOnViewNavigated<object> if you need to handle several
    // different types of data.
    public class AnimalDetailViewModel : ObservableObject, IOnViewNavigated<Animal>
    {
        public Animal Animal { get; private set; }

        //ZM: Recieves the data from GotoAsync
        public Task OnViewNavigatedAsync(Animal animal)
        {
            Animal = animal;
            OnPropertyChanged(nameof(Animal));
            return Task.CompletedTask;
        }
    }
}
