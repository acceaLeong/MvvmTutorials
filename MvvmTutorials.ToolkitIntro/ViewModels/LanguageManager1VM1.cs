using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmTutorials.ToolkitIntro.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace MvvmTutorials.ToolkitIntro.ViewModels;

public partial class LanguageManager1VM : ObservableObject
{
    private readonly ResourceManager resourceManager;

    private static readonly Lazy<LanguageManager1VM> lazy = new Lazy<LanguageManager1VM>(() => new LanguageManager1VM());
    
    public static LanguageManager1VM instance => lazy.Value;

    public LanguageManager1VM() 
    {
        string langsPath = "MvvmTutorials.ToolkitIntro.Resources.Languages.Langs";

        resourceManager = new ResourceManager(langsPath, typeof(LanguageManager1VM).Assembly);
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

    [RelayCommand]
    private void ChangeLanguage()
    {
        CultureInfo cultureInfo = new CultureInfo("en");
        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        instance.OnPropertyChanged("Item[]");
    }

    [RelayCommand]
    private void ChangeLanguageJA()
    {
        CultureInfo cultureInfo = new CultureInfo("ja");
        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        instance.OnPropertyChanged("Item[]");
    }

    [RelayCommand]
    private void ChangeLanguageCN()
    {
        CultureInfo cultureInfo = new CultureInfo("zh-CN");
        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        instance.OnPropertyChanged("Item[]");
    }
}
