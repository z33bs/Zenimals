using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Zenimals.Data;
using Zenimals.Models;
using ZenMvvm;
using ZenMvvm.Helpers;

namespace Zenimals.ViewModels
{
    //ZM: We've refactored to have one ViewModel, avoiding code duplication
    public class AnimalsViewModel : ObservableObject
    {
        public ICommand SelectionChangedCommand { get; }

        string title;
        public string Title
        {
            get => title;
            set
            {
                //Customise appearence and data based on Title
                SetProperty(ref title, value, onChanged: () =>
                 {
                     Data = value switch
                     {
                         "Dogs" => DiContainer.Resolve<DogData>().Data,
                         "Cats" => DiContainer.Resolve<CatData>().Data,
                         "Bears" => DiContainer.Resolve<BearData>().Data,
                         "Elephants" => DiContainer.Resolve<ElephantData>().Data,
                         "Monkeys" => DiContainer.Resolve<MonkeyData>().Data,
                         _ => throw new NotImplementedException()
                     };
                     ItemSelectedBackgroundColor = value switch
                     {
                         "Dogs" => Color.FromHex("#039BE6"),
                         "Cats" => Color.FromHex("#039BE6"),
                         "Bears" => Color.FromHex("#546DFE"),
                         "Elephants" => Color.FromHex("#ED3B3B"),
                         "Monkeys" => Color.FromHex("#689F39"),
                         _ => throw new NotImplementedException()
                     };
                 });                
            }
        }

        IEnumerable<Animal> data;
        public IEnumerable<Animal> Data
        {
            get => data;
            set => SetProperty(ref data, value);
        }

        Color itemSelectedBackgroundColor;
        public Color ItemSelectedBackgroundColor
        {
            get => itemSelectedBackgroundColor;
            set => SetProperty(ref itemSelectedBackgroundColor, value);
        }

        //ZM: Dependency injection in action. INavigationService will be
        // resolved as a Singleton
        public AnimalsViewModel(INavigationService navigationService)
        {
            //ZM: Example of route navigation that passes data to
            // the ViewModel with GoToAsync
            async Task NavigateAsync(Animal animal)
                => await navigationService
                    .GoToAsync($"details", animal);

            //ZM: SafeCommand avoids the need for async void lambdas
            // async (animal) => await NavigateAsync(animal);
            SelectionChangedCommand = new SafeCommand<Animal>(NavigateAsync);
        }
    }
}
