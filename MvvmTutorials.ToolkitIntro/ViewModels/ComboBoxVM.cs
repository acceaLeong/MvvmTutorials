using CommunityToolkit.Mvvm.ComponentModel;
using MvvmTutorials.ToolkitIntro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmTutorials.ToolkitIntro.ViewModels;

public partial class ComboBoxVM : ObservableObject
{
    [ObservableProperty]
    private List<string> _names = new List<string>()
    {
        "Joe",
        "Jane",
        "Jerry",
        "Mary",
        "Larry",
    };

    [ObservableProperty]
    private List<Person> _names1 = new List<Person>()
    {
        new Person()
        {
            Id = 1,
            Name = "Joe",
        },
        new Person()
        {
            Id = 2,
            Name = "Jane",
        },
        new Person()
        {
            Id = 3,
            Name = "Jerry",
        },
        new Person()
        {
            Id = 4,
            Name = "Mary",
        },
        new Person()
        {
            Id = 5,
            Name = "Larry",
        },
    };

    // SelectedIndex ( List<string> )
    [ObservableProperty]
    private int _index;

    partial void OnIndexChanged(int value)
    {
        Show(value.ToString());
    }

    // SelectedItem ( List<string> )
    [ObservableProperty]
    private string _item;

    partial void OnItemChanged(string value)
    {
        Show(value);
    }

    // SelectedValue ( List<string> )
    [ObservableProperty]
    private string _value;

    partial void OnValueChanged(string value)
    {
        Show(value);
    }

    // SelectedIndex ( List<Person> )
    [ObservableProperty]
    private int _index1;

    partial void OnIndex1Changed(int value)
    {
        Show(value.ToString());
    }

    // SelectedItem ( List<Person> )
    [ObservableProperty]
    private Person? _item1;

    partial void OnItem1Changed(Person? value)
    {
        Show(value?.Name ?? "");
    }

    // SelectedValue ( List<Person> )
    [ObservableProperty]
    private int _value1;

    partial void OnValue1Changed(int value)
    {
        Show(value.ToString());
    }

    public ComboBoxVM()
    {
        _index = 2;
        _item = "Jerry";
        _value = "Jerry";
        _index1 = 2;
        _item1 = _names1.Find(item => item.Id == 3);
        _value1 = 3;
    }

    [ObservableProperty]
    private string text = "";
    
    private void Show(string text)
    {
        Text = text;

        OnPropertyChanged(nameof(Caption));
    }

    public string Caption => $"Selected: {Text}";
}