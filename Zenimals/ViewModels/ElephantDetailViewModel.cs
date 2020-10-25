using System;
using System.Linq;
using Xamarin.Forms;
using Zenimals.Data;
using Zenimals.Models;
using ZenMvvm.Helpers;

namespace Zenimals.ViewModels
{
    [QueryProperty("Name", "name")]
    public class ElephantDetailViewModel : ObservableObject
    {
        public Animal Elephant { get; private set; }

        public string Name
        {
            set
            {
                Elephant = ElephantData.Elephants.FirstOrDefault(m => m.Name == Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(Elephant));

            }
        }
    }
}
