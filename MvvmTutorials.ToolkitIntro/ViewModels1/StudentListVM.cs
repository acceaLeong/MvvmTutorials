using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using MvvmTutorials.ToolkitIntro.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace MvvmTutorials.ToolkitIntro.ViewModels1;

public partial class StudentListVM : ObservableRecipient, IRecipient<ValueChangedMessage<Student>>
{
    [ObservableProperty]
    private List<string> _langs = new List<string>()
    {
        "en-US",
        "ja",
        "zh-CN",
    };

    [ObservableProperty]
    private string _langItem = "en-US";

    partial void OnLangItemChanged(string value)
    {
        CultureInfo cultureInfo = new CultureInfo(value);
        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        InstanceF.OnPropertyChanged("item[]");
    }

    private static readonly Lazy<StudentListVM> _lazyZ = new Lazy<StudentListVM>(() => new StudentListVM());

    public static StudentListVM InstanceF => _lazyZ.Value;

    private readonly ResourceManager _resourceManagerS;

    public string this[string name]
    {
        get
        {
            //if (name == null)
            //{
            //    throw new ArgumentNullException(nameof(name));
            //}

            return _resourceManagerS.GetString(name) ?? "";
        }
    }





    public ObservableCollection<Student> Students { get; } = new();

    [ObservableProperty]
    private bool allowAddNew;

    public int StudentCount => Students?.Count ?? 0;

    public StudentListVM()
    {
        _resourceManagerS = new ResourceManager("MvvmTutorials.ToolkitIntro.Resources.Languages.Langs", typeof(StudentListVM).Assembly);

        Students.CollectionChanged += (_, _) => OnPropertyChanged(nameof(StudentCount));
    }

    partial void OnAllowAddNewChanged(bool value)
    {
        WeakReferenceMessenger.Default.Send(new ValueChangedMessage<bool>(value));
    }

    public void Receive(ValueChangedMessage<Student> message)
    {
        Students.Add(message.Value);
    }
}