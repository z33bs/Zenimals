using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Zenimals.Data;
using Zenimals.Models;

namespace Zenimals.Views
{
    public partial class AnimalsPage : ContentPage
    {
        IEnumerable<Animal> data;
        public IEnumerable<Animal> Data
        {
            get => data;
            set
            {
                data = value;
                OnPropertyChanged(nameof(Data));
            }
        }

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


        public AnimalsPage(string animal)
        {
            InitializeComponent();

            ItemSelectedBackgroundColor = animal switch
            {
                "Dogs" => Color.FromHex("#039BE6"),
                "Cats" => Color.FromHex("#039BE6"),
                "Bears" => Color.FromHex("#546DFE"),
                "Elephants" => Color.FromHex("#ED3B3B"),
                "Monkeys" => Color.FromHex("#689F39"),
                _ => throw new NotImplementedException()
            };

            Data = animal switch
            {
                "Dogs" => DogData.Dogs,
                "Cats" => CatData.Cats,
                "Bears" => BearData.Bears,
                "Elephants" => ElephantData.Elephants,
                "Monkeys" => MonkeyData.Monkeys,
                _ => throw new NotImplementedException()
            };

            //Resources.Add(new Style(typeof(Grid))
            //{
            //    Setters = {
            //        new Setter
            //        {
            //            Property=VisualStateManager.VisualStateGroupsProperty,
            //            Value = new VisualStateGroupList
            //            {
            //                new VisualStateGroup
            //                {
            //                    Name="CommonStates",
            //                    States = {
            //                        //new VisualState {
            //                        //    Name="Normal",
            //                        //    Setters =
            //                        //    {
            //                        //        new Setter
            //                        //        {
            //                        //            Property=BackgroundColorProperty,
            //                        //            Value= "Transparent"
            //                        //        }
            //                        //    }
            //                        //},
            //                        new VisualState {
            //                            Name="Selected",
            //                            Setters =
            //                            {
            //                                new Setter
            //                                {
            //                                    Property=BackgroundColorProperty,
            //                                    Value= "#039BE6"
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //});
        }
    }
}
