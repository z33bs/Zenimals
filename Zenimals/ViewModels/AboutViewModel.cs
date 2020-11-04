using System.Windows.Input;
using Xamarin.Essentials;
using ZenMvvm.Helpers;

namespace Zenimals.ViewModels
{
    public class AboutViewModel
    {
        public ICommand TapCommand
            => new SafeCommand<string>(Launcher.OpenAsync, mustRunOnCurrentSyncContext:true);
    }
}
