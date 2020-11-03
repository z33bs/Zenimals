using System.Collections.Generic;
using System.Windows.Input;
using Zenimals.Data;
using Zenimals.Models;
using ZenMvvm;
using ZenMvvm.Helpers;

namespace Zenimals.ViewModels
{
    public class AnimalsViewModel<T> : ObservableObject
    {
        public ICommand SelectionChangedCommand { get; }

        IEnumerable<Animal> data;
        public IEnumerable<Animal> Data
        {
            get => data;
            set => SetProperty(ref data, value);
        }

        public AnimalsViewModel(INavigationService navigationService, T animalData)
        {
            Data = (animalData as IData).Data;
            SelectionChangedCommand = new SafeCommand<Animal>(
                async (animal) =>
                    await navigationService
                    .GoToAsync<Animal>($"details",animal));
        }
    }
}
