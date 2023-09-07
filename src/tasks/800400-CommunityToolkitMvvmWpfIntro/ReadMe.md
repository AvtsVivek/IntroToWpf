# Introduces Community Tool kit.

## References.
1. https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/

2. https://github.com/CommunityToolkit

3. https://www.youtube.com/watch?v=uVIzK2snugk

## How this app is built.
1. Start from the earlier example, 200220-ViewModelIntro

2. In the MainWindowViewModel, add ICommand along with their OnClick and CanClick delegates.
3. MainWindowViewModel should be impliment INotifyPropertyChanged.
4. Then Number property should be implimented in full.

```cs
private string number = "One";

public string Number
{
    get { return number; }
    set { 
        number = value; 
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(number)));
    }
}

public event PropertyChangedEventHandler? PropertyChanged;

``` 

6. In the MainWindow, change the main grid.

7. We want the user to be allowed to click only when the text "One" and not anything else.
   1. You can click only when the number is one, and not anything else

8. 
