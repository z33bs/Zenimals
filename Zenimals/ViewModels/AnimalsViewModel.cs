using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Zenimals.Data;
using Zenimals.Models;
using ZenMvvm;
using ZenMvvm.Helpers;

namespace Zenimals.ViewModels
{
    public class AnimalsViewModel : ObservableObject
    {
        public ICommand SelectionChangedCommand { get; }

        string title;
        public string Title
        {
            get => title;
            set
            {
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

        public AnimalsViewModel(INavigationService navigationService)
        {
            SelectionChangedCommand = new SafeCommand<Animal>(
                async (animal) =>
                    await navigationService
                    .GoToAsync<Animal>($"details",animal));
        }
    }
}
