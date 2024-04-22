using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace MvvmTutorials.ToolkitIntro;

//public partial class LanguageManager : INotifyPropertyChanged
public partial class LanguageManager : ObservableObject
{
    [ObservableProperty]
    private List<string> _langs = new List<string>()
    {
        "en-US",
        "ja",
    };

    [ObservableProperty]
    private string _langItem = "en-US";

    partial void OnLangItemChanged(string value)
    {
        CultureInfo cultureInfo = new CultureInfo(value);
        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;
    }




    private readonly ResourceManager _resourceManager;

    private static readonly Lazy<LanguageManager> _lazy = new Lazy<LanguageManager>(() => new LanguageManager());

    //[ObservableProperty]
    public static LanguageManager Instance1 => _lazy.Value;

    //public event PropertyChangedEventHandler? PropertyChanged;

    public LanguageManager()
    {
        _resourceManager = new ResourceManager("MvvmTutorials.ToolkitIntro.Resources.Lang1", typeof(LanguageManager).Assembly);
    }

    public string this[string name]
    {
        get
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return _resourceManager.GetString(name);
        }
    }

    //public void ChangeLanguage(CultureInfo cultureInfo)
    //{
    //    CultureInfo.CurrentCulture = cultureInfo;
    //    CultureInfo.CurrentUICulture = cultureInfo;

    //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("item[]"));
    //}
}
