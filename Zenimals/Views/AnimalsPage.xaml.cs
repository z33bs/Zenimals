using Xamarin.Forms;

namespace Zenimals.Views
{
    public partial class AnimalsPage : ContentPage
    {

        public AnimalsPage()
        {
            //Paramaterless ctor to avoid intellisense errors on xaml
        }

        public AnimalsPage(string animal)
        {
            InitializeComponent();
            Title = animal;
        }
    }
}
