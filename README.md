# ![Logo](https://raw.githubusercontent.com/z33bs/Zenimals/master/Zenimals.iOS/Resources/zenmvvm_icon.png)Zenimals
A refactored version of [Xaminals](https://docs.microsoft.com/en-us/samples/xamarin/xamarin-forms-samples/userinterface-xaminals/) (a Xamarin Sample App), 
demonstrating **ViewModel-First** navigation with [ZenMvvm](https://github.com/z33bs/zenmvvm). ZenMvvm is a Lightweight **ViewModel-First MVVM** framework for Xamarin.Forms.

>*Tip: Search for `//ZM` in the solution to quickly jump to code comments explaining ZenMvvm*

When browsing the code, look for:
* Simpler, easier to understand architecture compared with Xaminals.
* Dependency injection uses the convenient "Smart Resolve" feature meaning you don't have to register dependenices. Perfect for rapid prototyping.
* Views wire-up to their corresponding ViewModels simply by adding:
```c#
mvvm:ViewModelLocator.AutoWireViewModel="True"
```
* Navigation from AnimalsViewModel that passes an Item object to the NewItemViewModel:
```c#
await navigationService.GoToAsync($"details", animal);
```

See [ZenMvvmSampleApp](https://github.com/z33bs/zenmvvmsampleapp) for an example that showcases more features, including navigation with `PushAsync<TViewModel>()`.

![screenshot](https://docs.microsoft.com/en-us/samples/xamarin/xamarin-forms-samples/userinterface-xaminals/media/01all.png)
