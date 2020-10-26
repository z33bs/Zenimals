using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zenimals.Models;
using Zenimals.Views;
using ZenMvvm;

namespace Zenimals.Controls
{
    public class AnimalSearchHandler : SearchHandler
    {

        public Type SelectedItemNavigationTarget { get; set; }

        public static readonly BindableProperty DataProperty = BindableProperty.Create("Data", typeof(IEnumerable<Animal>), typeof(AnimalSearchHandler));
        public IEnumerable<Animal> Data
        {
            get => GetValue(DataProperty) as IEnumerable<Animal>;
            set => SetValue(DataProperty, value);
        }

        public AnimalSearchHandler()
        {
            Placeholder = "Enter search term";
            ShowsResults = true;
            SelectedItemNavigationTarget = typeof(DogDetailPage);

            ItemTemplate = Application.Current.Resources["AnimalSearchTemplate"] as DataTemplate;
        }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = Data
                    .Where(animal => animal.Name.ToLower().Contains(newValue.ToLower()))
                    .ToList();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            var navigationService = DiContainer.Resolve<INavigationService>();

            base.OnItemSelected(item);
            await Task.Delay(1000);

            if (SelectedItemNavigationTarget == typeof(Views.ElephantDetailPage))
                await navigationService.GoToAsync($"{GetNavigationTarget()}?name={(item as Animal).Name}");
            else
                await navigationService.GoToAsync($"{GetNavigationTarget()}",(Animal)item);
        }

        string GetNavigationTarget() =>
            (Shell.Current as AppShell).Routes.FirstOrDefault(route => route.Value.Equals(SelectedItemNavigationTarget)).Key;
    }
}
