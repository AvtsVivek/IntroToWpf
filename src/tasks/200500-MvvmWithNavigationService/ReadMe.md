# Basic Wpf App with Mvvm and a Navigation service.

1. This is based on the earlier example. 300500-BasicMvvm

2. When you launch the app, you see that there is no default View assigned to the ContentControl in MainWindow as CurrentView in MainWindowViewModel. 

3. If you want a default View applied, then there are a few ways to do it.

4. One way is to add the following navigation to the ctor of MainWindowViewModel
```cs
Navigation.NavigateTo<UserControl1ViewModel>();
```

5. The second way is to assign CurrentView property of NavigationService, inside the ctor of NavigationService

```cs
CurrentView = _viewModelFactory.Invoke(typeof(UserControl1ViewModel));
```

This would not work. The reason is, the following is trying to get an instance of UserControl1ViewModel. But UserControl1ViewModel itself has a dependency on NavigationService. So is a cyclic dependency. This would not work.


6. 
