using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmTutorials.ToolkitIntro.Models;
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

public partial class LanguageManagerVM : ObservableObject
{
    [ObservableProperty]
    private List<Language> _langs = new List<Language>();

    [ObservableProperty]
    private Language? _langItem;

    partial void OnLangItemChanged(Language? value)
    {
        CultureInfo cultureInfo = new CultureInfo(value?.LangCode ?? "");
        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        instanceX.OnPropertyChanged("item[]");
    }

    private static readonly Lazy<LanguageManagerVM> lazy = new Lazy<LanguageManagerVM>(() => new LanguageManagerVM());
    //private static readonly LanguageManagerVM vm = new LanguageManagerVM();

    public static LanguageManagerVM instanceX => lazy.Value;
    //public static LanguageManagerVM InstanceX => vm;

    private readonly ResourceManager resourceManager;

    public LanguageManagerVM()
    {
        resourceManager = new ResourceManager("MvvmTutorials.ToolkitIntro.Resources.Langs", typeof(LanguageManagerVM).Assembly);

        _langs.Add(new Language()
        {
            LangCode = "en-US",
            Lang = resourceManager.GetString("en-US"),
        });

        _langs.Add(new Language()
        {
            LangCode = "ja",
            Lang = resourceManager.GetString("ja"),
        });

        _langs.Add(new Language()
        {
            LangCode = "zh-CN",
            Lang = resourceManager.GetString("zh-CN"),
        });

        _langItem = _langs.Find(item => item.LangCode == "en-US");
    }

    public string this[string name]
    {
        get
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return resourceManager.GetString(name);
        }
    }
}