using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmTutorials.ToolkitIntro.Models;
using MvvmTutorials.ToolkitIntro.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace MvvmTutorials.ToolkitIntro.ViewModels;

public partial class LanguageManagerVM : ObservableObject
{
    private List<Language> langs = new List<Language>()
    {
        new Language()
        {
            Id = 0,
            ISO = "en-US",
        },
        new Language()
        {
            Id = 1,
            ISO = "ja",
        },
        new Language()
        {
            Id = 2,
            ISO = "zh-CN",
        },
    };


    [ObservableProperty]
    private int? _langItem;

    partial void OnLangItemChanged(int? value)
    {
        Language lang = langs.Find(item => item.Id == value);

        CultureInfo cultureInfo = new CultureInfo(lang.ISO);
        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        instanceX.OnPropertyChanged("Item[]");
    }

    [ObservableProperty]
    private int? _langItem1;

    private static readonly Lazy<LanguageManagerVM> lazy = new Lazy<LanguageManagerVM>(() => new LanguageManagerVM());
    //private static readonly LanguageManagerVM vm = new LanguageManagerVM();

    public static LanguageManagerVM instanceX => lazy.Value;
    //public static LanguageManagerVM InstanceX => vm;

    private readonly ResourceManager resourceManager;

    public LanguageManagerVM()
    {
        string langsPath = "MvvmTutorials.ToolkitIntro.Resources.Languages.Langs";

        resourceManager = new ResourceManager(langsPath, typeof(LanguageManagerVM).Assembly);

        _langItem = 0;
        _langItem1 = 0;
    }

    public string this[string name]
    {
        get
        {
            //if (name == null)
            //{
            //    throw new ArgumentNullException(nameof(name));
            //}

            return resourceManager.GetString(name) ?? "";
        }
    }
}