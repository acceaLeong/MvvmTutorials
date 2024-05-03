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
    [ObservableProperty]
    private int? _langItem;



    partial void OnLangItemChanged(int? value)
    {
        string langCode;

        switch (value)
        {
            case 1:
                langCode = "ja";

                break;
            case 2:
                langCode = "zh-CN";

                break;
            default:
                langCode = "en-US";

                break;
        }

        CultureInfo cultureInfo = new CultureInfo(langCode);
        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        instanceX.OnPropertyChanged("Item[]");
    }

    private static readonly Lazy<LanguageManagerVM> lazy = new Lazy<LanguageManagerVM>(() => new LanguageManagerVM());
    //private static readonly LanguageManagerVM vm = new LanguageManagerVM();

    public static LanguageManagerVM instanceX => lazy.Value;
    //public static LanguageManagerVM InstanceX => vm;

    private readonly ResourceManager resourceManager;

    public LanguageManagerVM()
    {
        resourceManager = new ResourceManager("MvvmTutorials.ToolkitIntro.Resources.Langs", typeof(LanguageManagerVM).Assembly);

        _langItem = 0;
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