using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmTutorials.ToolkitIntro.ViewModels;

public partial class TextBoxVM : ObservableObject
{
    // Without UpdateSourceTrigger=PropertyChanged 
    [ObservableProperty]
    private string _text = "Hello, world!";

    partial void OnTextChanged(string value)
    {
        OnPropertyChanged(nameof(Caption));
    }

    public string Caption => $"Caption: {Text}";

    // With UpdateSourceTrigger=PropertyChanged
    [ObservableProperty]
    private string _text1 = "Hello, world!";

    partial void OnText1Changed(string value)
    {
        OnPropertyChanged(nameof(Caption1));
    }

    public string Caption1 => $"Caption: {Text1}";
}