using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Main
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public Hashtable chart_number_hash_table = new(15);
        public string filePath = "F:/PreviewCalculation/Main/Main";
        public HomePage()
        {
            InitializeComponent();
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            Display_Chart_Number();
            Reset_TextBlock.Content = "Reseted";
        }

        private static int TextBox_Check(string textBox_str)
        {
            string[] check_string_multi = textBox_str.Split(',');
            return check_string_multi.Length;
        }

        private bool Check_Repeat_Value(int value) => chart_number_hash_table.ContainsValue(value);

        private void Display_Chart_Number()
        {
            TableItems.Text = "";
            if (chart_number_hash_table == null) { return; }
            else
            {
                foreach (var value in chart_number_hash_table.Values)
                {
                    TableItems.Text += value + ",";
                }
                TableItems.Text = TableItems.Text[..^1];
            }
        }

        private async void Insert_sole_Click(object sender, RoutedEventArgs e)
        {
            int len = TextBox_Check(InsertTextBox.Text);
            switch (len)
            {
                case > 1:
                    ContentDialog single_dialog = new()
                    {
                        Title = "There are more than 1 charts.",
                        PrimaryButtonText = "Yes",
                        SecondaryButtonText = "No",
                        CloseButtonText = "Cancel",
                        DefaultButton = ContentDialogButton.Primary,
                        Content = "Are you want to proceed?"
                    };
                    if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 8))
                    {
                        single_dialog.XamlRoot = Content.XamlRoot;
                    }
                    var result = await single_dialog.ShowAsync();
                    switch (result)
                    {
                        case ContentDialogResult.None:
                            return;
                        case ContentDialogResult.Primary:
                            Insert_multi_Click(sender, e);
                            return;
                        case ContentDialogResult.Secondary:
                            return;
                        default:
                            break;
                    }
                    break;
                case <= 1:
                    Random ran = new();
                    int key = ran.Next();
                    try
                    {
                        int chart_number = Convert.ToInt32(InsertTextBox.Text);
                        if (Check_Repeat_Value(chart_number))
                        {
                            ContentDialog repeat_dialog = new()
                            {
                                Title = "There are repeated charts' number.",
                                PrimaryButtonText = "Yes",
                                DefaultButton = ContentDialogButton.Primary,
                                Content = $"repeat item: {chart_number}. Maybe there are not only one."
                            };
                            if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 8))
                            {
                                repeat_dialog.XamlRoot = Content.XamlRoot;
                            }
                            var result2 = await repeat_dialog.ShowAsync();
                            switch (result2)
                            {
                                case ContentDialogResult.None:
                                    return;
                                case ContentDialogResult.Primary:
                                    return;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            chart_number_hash_table.Add(key, chart_number);
                        }
                    }
                    catch (Exception)
                    {
                        ContentDialog text_dialog = new()
                        {
                            Title = "There is no charts.",
                            PrimaryButtonText = "No",
                            DefaultButton = ContentDialogButton.Primary,
                            Content = "Are you want to proceed?"
                        };
                        if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 8))
                        {
                            text_dialog.XamlRoot = Content.XamlRoot;
                        }
                        var result2 = await text_dialog.ShowAsync();
                        switch (result2)
                        {
                            case ContentDialogResult.None:
                                return;
                            case ContentDialogResult.Primary:
                                return;
                            default:
                                break;
                        }
                        break;
                    }
                    break;
                default:
            }
            Display_Chart_Number();
        }

        private void Delete_sole_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Alter_sole_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Update_multi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_multi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Alter_multi_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Insert_multi_Click(object sender, RoutedEventArgs e)
        {
            int len = TextBox_Check(InsertTextBox.Text);
            switch (len)
            {
                case > 1:
                    try
                    {
                        string[] check_string_multi = InsertTextBox.Text.Split(',');
                        for (int i = 0; i < len; i++)
                        {
                            Random ran = new();
                            int key = ran.Next();
                            int chart_number = Convert.ToInt32(check_string_multi[i]);
                            if (Check_Repeat_Value(chart_number))
                            {
                                ContentDialog repeat_dialog = new()
                                {
                                    Title = "There are repeated charts' number.",
                                    PrimaryButtonText = "Yes",
                                    DefaultButton = ContentDialogButton.Primary,
                                    Content = $"repeat item: {chart_number}. Maybe there are not only one."
                                };
                                if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 8))
                                {
                                    repeat_dialog.XamlRoot = Content.XamlRoot;
                                }
                                var result4 = await repeat_dialog.ShowAsync();
                                switch (result4)
                                {
                                    case ContentDialogResult.None:
                                        return;
                                    case ContentDialogResult.Primary:
                                        return;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                chart_number_hash_table.Add(key, chart_number);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        ContentDialog text_dialog = new()
                        {
                            Title = "Please check format error.",
                            PrimaryButtonText = "Back",
                            DefaultButton = ContentDialogButton.Primary,
                        };
                        if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 8))
                        {
                            text_dialog.XamlRoot = Content.XamlRoot;
                        }
                        var result3 = await text_dialog.ShowAsync();
                        switch (result3)
                        {
                            case ContentDialogResult.None:
                                return;
                            case ContentDialogResult.Primary:
                                return;
                            default:
                                break;
                        }
                        break;
                    }
                    break;
                case <= 1:
                    ContentDialog single_dialog = new()
                    {
                        Title = "There is only one chart or format error.",
                        PrimaryButtonText = "Back",
                        DefaultButton = ContentDialogButton.Primary,
                    };
                    if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 8))
                    {
                        single_dialog.XamlRoot = Content.XamlRoot;
                    }
                    var result2 = await single_dialog.ShowAsync();
                    switch (result2)
                    {
                        case ContentDialogResult.None:
                            return;
                        case ContentDialogResult.Primary:
                            return;
                        default:
                            break;
                    }
                    break;
                default:
            }
            Display_Chart_Number();
        }

        private void Reset_TextBlock_LostFocus(object sender, RoutedEventArgs e)
        {
            Reset_TextBlock.Content = "Reset text block";
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            DataCache cache = new(chart_number_hash_table);
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
    }
}