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

    [ObservableProperty]
    private string _text2 = "2";

    private int selected;

    [RelayCommand]
    private void Button1Click()
    {
        switch (selected)
        {
            case 1:
                Text1 += "1";

                break;
            case 2:
                Text2 += "2";

                break;
            default:
                MessageBox.Show(selected.ToString());

                break;
        }
    }

    [RelayCommand]
    private void GotFocus(object obj)
    {
        selected = Convert.ToInt16(obj.ToString() ?? "0");
    }
}