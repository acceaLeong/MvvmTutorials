using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmTutorials.ToolkitIntro.ViewModels;

public partial class CheckInternetVM : ObservableObject
{
    private static readonly HttpClient httpClient = new HttpClient();

    [RelayCommand]
    private async Task CheckInternetClick()
    {
        bool result = await CheckInternet();

        if (result == true)
        {
            MessageBox.Show("Yes");
        }
        else
        {
            MessageBox.Show("No");
        }
    }

    private async Task<bool> CheckInternet()
    {
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync("http://www.google.com");

            response.EnsureSuccessStatusCode();

            return true;
        }
        catch (HttpRequestException)
        {
            return false;
        }
    }
}
