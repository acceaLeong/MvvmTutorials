using CommunityToolkit.Mvvm.ComponentModel;
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
    [NotifyPropertyChangedFor(nameof(Caption))]
    private string _text = "Hello, world!";

    public string Caption => $"Caption: {Text}";

    // With UpdateSourceTrigger=PropertyChanged
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Caption1))]
    private string _text1 = "Hello, world!";

    public string Caption1 => $"Caption: {Text1}";
}