using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmTutorials.ToolkitIntro.ViewModels;

public partial class ButtonVM : ObservableObject
{
    [ObservableProperty]
    private string _text = "Hello, world!";

    [RelayCommand]
    private void ButtonClick()
    {
        Text = "Goodbye!";
    }


    [ObservableProperty]
    private string _text1 = "1";

    [RelayCommand]
    private void Button1Click()
    {
        Text1 += "1";
    }
}