using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zenimals.Models;
using ZenMvvm;

namespace Zenimals.Controls
{
    public class AnimalSearchHandler : SearchHandler
    {
        public IList<Animal> Animals { get; set; }
        public Type SelectedItemNavigationTarget { get; set; }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = Animals
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
