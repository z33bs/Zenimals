using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Zenimals.Views;

namespace Zenimals
{
    public partial class AppShell : Shell
    {

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        void RegisterRoutes()
        {
            var routes = new Dictionary<string, Type>
            {
                { "details", typeof(AnimalDetailPage) }
            };

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }


        void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {
            // Cancel any back navigation
            //if (e.Source == ShellNavigationSource.Pop)
            //{
            //    e.Cancel();
            //}
        }

        void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {
        }
    }
}
