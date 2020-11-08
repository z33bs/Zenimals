# ![Logo](https://raw.githubusercontent.com/z33bs/Zenimals/master/Zenimals.iOS/Resources/zenmvvm_icon.png)Zenimals
A refactored version of [Xaminals](https://docs.microsoft.com/en-us/samples/xamarin/xamarin-forms-samples/userinterface-xaminals/) (a Xamarin Sample App), 
demonstrating **ViewModel-First** navigation with [ZenMvvm](https://github.com/z33bs/zenmvvm#readme). ZenMvvm is a Lightweight **ViewModel-First MVVM** framework for Xamarin.Forms.

>*Tip: Search for `//ZM` in the solution to quickly jump to code comments explaining ZenMvvm => [click here to do this now](https://github.com/z33bs/zenimals-sample-app/search?q=%2F%2FZM)*

When browsing the code, look for:
* Simple. Almost nothing new to learn. Design pages as you normally would using Xamarin Forms.
* Cleaner, easier to understand architecture compared with Xaminals.
* Nothing in the code-behind files
* ViewModels don't have a dependency on Xamarin.Forms
* Buit-in dependency injection uses the convenient "[Smart Resolve](https://github.com/z33bs/SmartDi/wiki/Resolution#smart-resolve)" feature meaning you don't have to register dependenices (perfect for rapid prototyping).
* Passing data to another viewmodel is  easy. Example below passes an Animal object to the AnimalDetailViewModel:
```c#
await navigationService.GoToAsync($"details", animal);
```

For another sample app, see [ZenMvvm Sample App](https://github.com/z33bs/zenmvvm-sample-app#readme) which showcases more features, including navigation with `PushAsync<TViewModel>()`.

![screenshot](https://docs.microsoft.com/en-us/samples/xamarin/xamarin-forms-samples/userinterface-xaminals/media/01all.png)
