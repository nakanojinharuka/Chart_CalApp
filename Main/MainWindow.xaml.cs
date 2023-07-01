// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.Storage;
using Windows.UI.ViewManagement;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Main
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public Hashtable Chart_number_hash_table { get; set; } = new(15);
        public string filePath = "F:/PreviewCalculation/Main/Main";
        public MainWindow()
        {
            InitializeComponent();
            ExtendsContentIntoTitleBar = true;
            SetTitleBar(AppTitleBar);
            ContentPage.Navigate(typeof(WelcomePage));
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            switch (args.InvokedItem)
            {
                case "Home":
                    ContentPage.Navigate(typeof(HomePage));
                    break;
                case "Welcome":
                    ContentPage.Navigate(typeof(WelcomePage));
                    break;
                case "Parameters of evaluations":
                    ContentPage.Navigate(typeof(ParametersPage));
                    break;
                default:
                    break;
            }
        }

        private void Save_All_Click(object sender, RoutedEventArgs e)
        {
            FileStream file = new(filePath + "/hashset.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            file.SetLength(0);
            StreamWriter writer = new(file);
            foreach (var item in DataCache.Chart_table.Keys)
            {
                writer.Write(item.ToString() + "," + DataCache.Chart_table[item] + "\r\n");
            }
            writer.Close();
            file.Close();
        }

        private void Window_Activated(object sender, WindowActivatedEventArgs args)
        {
            ApplicationView.PreferredLaunchViewSize = new Size(1800, 900);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }
    }
}