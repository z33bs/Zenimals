using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Zenimals.Models;

namespace Zenimals.Views
{
    public partial class AnimalsView : ContentView
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

        public AnimalsView(string selectedColor = "Grey")
        {
            InitializeComponent();

            Resources.Add(
                new Style(typeof(Grid))
                {
                    Setters =
                    {
                        new Setter {
                            Property = VisualStateManager.VisualStateGroupsProperty,
                            Value = new VisualStateGroupList
                            {
                                new VisualStateGroup
                                {
                                    Name="CommonStates",
                                    States=
                                    {
                                        new VisualState
                                        {
                                            Name="Normal",
                                            Setters =
                                            {
                                                new Setter {
                                                    Property=BackgroundColorProperty,
                                                    Value= Color.Transparent }
                                            }
                                        },
                                        new VisualState
                                        {
                                            Name="Selected",
                                            Setters =
                                            {
                                                new Setter {
                                                    Property=BackgroundColorProperty,
                                                    Value= selectedColor }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                });
        }
    }
}
