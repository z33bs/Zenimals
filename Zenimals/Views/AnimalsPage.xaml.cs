using System;

using Xamarin.Forms;
using Zenimals.Data;
using Zenimals.ViewModels;
using ZenMvvm;

namespace Zenimals.Views
{
    public partial class AnimalsPage : ContentPage
    {
        Color itemSelectedBackgroundColor;
        public Color ItemSelectedBackgroundColor
        {
            get => itemSelectedBackgroundColor;
            set
            {
                itemSelectedBackgroundColor = value;
                OnPropertyChanged(nameof(ItemSelectedBackgroundColor));
            }
        }

        public AnimalsPage()
        {
        }

        public AnimalsPage(string animal)
        {
            InitializeComponent();

            Title = animal;

            ItemSelectedBackgroundColor = animal switch
            {
                "Dogs" => Color.FromHex("#039BE6"),
                "Cats" => Color.FromHex("#039BE6"),
                "Bears" => Color.FromHex("#546DFE"),
                "Elephants" => Color.FromHex("#ED3B3B"),
                "Monkeys" => Color.FromHex("#689F39"),
                _ => throw new NotImplementedException()
            };
          
            BindingContext = animal switch
            {
                "Dogs" => DiContainer.Resolve<AnimalsViewModel<DogData>>(),
                "Cats" => DiContainer.Resolve<AnimalsViewModel<CatData>>(),
                "Bears" => DiContainer.Resolve<AnimalsViewModel<BearData>>(),
                "Elephants" => DiContainer.Resolve<AnimalsViewModel<ElephantData>>(),
                "Monkeys" => DiContainer.Resolve<AnimalsViewModel<MonkeyData>>(),
                _ => throw new NotImplementedException()
            };
        }
    }
}
