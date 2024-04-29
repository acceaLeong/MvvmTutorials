using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
using System.Xml.Linq;

namespace MvvmTutorials.ToolkitIntro;

public partial class LanguageManager : ObservableObject
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

    private static readonly Lazy<LanguageManager> _lazyZ = new Lazy<LanguageManager>(() => new LanguageManager());
    //private static readonly LanguageManager _lazyZ = new LanguageManager();

    public static LanguageManager InstanceF => _lazyZ.Value;
    //public static LanguageManager InstanceF => _lazyZ;

    private readonly ResourceManager _resourceManagerS;

    public LanguageManager()
    {
        _resourceManagerS = new ResourceManager("MvvmTutorials.ToolkitIntro.Resources.Lang1", typeof(LanguageManager).Assembly);
    }

    public string this[string name]
    {
        get
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return _resourceManagerS.GetString(name);
        }
    }

    [ObservableProperty]
    private string _textY = "Testing 123";
}