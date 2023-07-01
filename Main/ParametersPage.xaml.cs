using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Main
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ParametersPage : Page
    {
        public Task task;
        public string filePath = "F:/PreviewCalculation/Main/Main";
        public ParametersPage()
        {
            InitializeComponent();
        }
        private static Chart Get_infomation_expert(int id)
        {
            return new(id, "expert");
        }

        private static Chart Get_infomation_special(int id)
        {
            return new(id, "special");
        }

        private async void MiddleParaButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= 510; i++)
            {
                Chart single_chart = await Task.Run(() => Get_infomation_expert(i));
                if (single_chart.EigenMatrix[0, 0] == 0)
                {
                    continue;
                }
                StatusBlock.Text = $"chart id:{i},difficulty: expert.\n{single_chart.CommonSolution}";
                eigen_matrix_1_1.Text = String.Format("{0}", single_chart.EigenMatrix[0, 0]);
                eigen_matrix_1_2.Text = String.Format("{0}", single_chart.EigenMatrix[0, 1]);
                eigen_matrix_1_3.Text = String.Format("{0}", single_chart.EigenMatrix[0, 2]);
                eigen_matrix_2_1.Text = String.Format("{0}", single_chart.EigenMatrix[1, 0]);
                eigen_matrix_2_2.Text = String.Format("{0}", single_chart.EigenMatrix[1, 1]);
                eigen_matrix_2_3.Text = String.Format("{0}", single_chart.EigenMatrix[1, 2]);
                eigen_matrix_3_1.Text = String.Format("{0}", single_chart.EigenMatrix[2, 0]);
                eigen_matrix_3_2.Text = String.Format("{0}", single_chart.EigenMatrix[2, 1]);
                eigen_matrix_3_3.Text = String.Format("{0}", single_chart.EigenMatrix[2, 2]);
                eigen_value_1.Text = String.Format("{0}", single_chart.EigenValue[0]);
                eigen_value_2.Text = String.Format("{0}", single_chart.EigenValue[1]);
                eigen_value_3.Text = String.Format("{0}", single_chart.EigenValue[2]);
                ResultBlock.Text += $"{i},expert,{single_chart.Level}," + eigen_value_1.Text + "," + eigen_value_2.Text + "," + eigen_value_3.Text + Environment.NewLine;
                try
                {
                    Chart single_chart2 = await Task.Run(() => Get_infomation_special(i));
                    if (single_chart2.EigenMatrix[0, 0] == 0)
                    {
                        continue;
                    }
                    StatusBlock.Text = $"chart id:{i},difficulty: special.\n{single_chart2.CommonSolution}";
                    eigen_matrix_1_1.Text = String.Format("{0}", single_chart2.EigenMatrix[0, 0]);
                    eigen_matrix_1_2.Text = String.Format("{0}", single_chart2.EigenMatrix[0, 1]);
                    eigen_matrix_1_3.Text = String.Format("{0}", single_chart2.EigenMatrix[0, 2]);
                    eigen_matrix_2_1.Text = String.Format("{0}", single_chart2.EigenMatrix[1, 0]);
                    eigen_matrix_2_2.Text = String.Format("{0}", single_chart2.EigenMatrix[1, 1]);
                    eigen_matrix_2_3.Text = String.Format("{0}", single_chart2.EigenMatrix[1, 2]);
                    eigen_matrix_3_1.Text = String.Format("{0}", single_chart2.EigenMatrix[2, 0]);
                    eigen_matrix_3_2.Text = String.Format("{0}", single_chart2.EigenMatrix[2, 1]);
                    eigen_matrix_3_3.Text = String.Format("{0}", single_chart2.EigenMatrix[2, 2]);
                    eigen_value_1.Text = String.Format("{0}", single_chart2.EigenValue[0]);
                    eigen_value_2.Text = String.Format("{0}", single_chart2.EigenValue[1]);
                    eigen_value_3.Text = String.Format("{0}", single_chart2.EigenValue[2]);
                    ResultBlock.Text += $"{i},special,{single_chart2.Level}," + eigen_value_1.Text + "," + eigen_value_2.Text + "," + eigen_value_3.Text + Environment.NewLine;
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }

        private void MiddleParaButton_LostFocus(object sender, RoutedEventArgs e)
        {
            
        }
    }
}