using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmTutorials.ToolkitIntro.ViewModels;

public partial class CheckBoxVM : ObservableObject
{
    //----- -----//
    /* // Without CommunityToolkit.Mvvm Framework
    private string title = "Hello, world!";

    public string Title
    {
        get => title;
        set => SetProperty(ref title, value);
    }

    private bool isEnabled;

    public bool IsEnabled
    {
        get => isEnabled;
        set
        {
            SetProperty(ref isEnabled, value);

            ButtonClickCommand.NotifyCanExecuteChanged();
        }
    }

    public RelayCommand ButtonClickCommand { get; init; }

    public MainWindowViewModel()
    {
        ButtonClickCommand = new RelayCommand(() => Title = "Goodbye!", () => IsEnabled);
    }
    */

    // Sync
    [ObservableProperty]
    private string _text = "Hello, world!";

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ButtonClickCommand))]
    private bool _isEnabled;

    [RelayCommand(CanExecute = nameof(IsEnabled))]
    private void ButtonClick()
    {
        Text = "Goodbye!";
    }

    // Async
    [ObservableProperty]
    private string _text1 = "Hello, world!";

    [RelayCommand]
    private async Task ButtonClick1Async()
    {
        await Task.Delay(1500);

        Text1 = "Goodbye!";
    }
}