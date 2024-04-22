﻿using MvvmTutorials.ToolkitIntro.ViewModels;
using System;
using System.Collections.Generic;
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

namespace MvvmTutorials.ToolkitIntro.Windows;

/// <summary>
/// Interaction logic for Button.xaml
/// </summary>
public partial class Button : Window
{
    public Button()
    {
        DataContext = new ButtonVM();

        InitializeComponent();
    }
}