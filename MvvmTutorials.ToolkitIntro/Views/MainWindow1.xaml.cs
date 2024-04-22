using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MvvmTutorials.ToolkitIntro.Views;

/// <summary>
/// Interaction logic for MainWindow1.xaml
/// </summary>
public partial class MainWindow1 : Window
{
    public MainWindow1()
    {
        InitializeComponent();

        //LanguageList.ItemsSource = new List<string>
        //{
        //    "en-US",
        //    "ja",
        //};
    }

    //private void LanguageList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //{
    //    LanguageManager.Instance.ChangeLanguage(new CultureInfo((sender as ComboBox).SelectedItem.ToString()));
    //}
}
