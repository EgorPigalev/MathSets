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

namespace MathSets.windows
{
    /// <summary>
    /// Логика взаимодействия для ResultEqualSetsSolvengTasksWindow.xaml
    /// </summary>
    public partial class ResultEqualSetsSolvengTasksWindow : Window
    {
        public ResultEqualSetsSolvengTasksWindow(string str, string text1, string text2)
        {
            InitializeComponent();
            SpTasks.Children.Clear();
            if (str.Length > 0) // Если есть ошибки
            {
                LBResult.Content = "Ты допустил ошибку";
                SpTasks.Visibility = Visibility.Visible;
                TextBlock header = new TextBlock() // Заголовок
                {
                    Text = $"Верный ответ - {text1} {str} {text2}",
                    HorizontalAlignment = HorizontalAlignment.Center,
                };
                SpTasks.Children.Add(header);
            }
        }

        public ResultEqualSetsSolvengTasksWindow(string str, string str2, string text1, string text2, string text11, string text22)
        {
            InitializeComponent();
            SpTasks.Children.Clear();
            if (str.Length > 0) // Если есть ошибки
            {
                LBResult.Content = "Ты допустил ошибку";
                SpTasks.Visibility = Visibility.Visible;
                TextBlock header = new TextBlock() // Заголовок
                {
                    Text = $"Верный ответ - {text1} {str} {text2}\nВерный ответ - {text11} {str2} {text22}",
                    HorizontalAlignment = HorizontalAlignment.Center,
                };
                SpTasks.Children.Add(header);
            }
        }

        public ResultEqualSetsSolvengTasksWindow(string str, string str2, string str3, string str4,  string text1, string text2, string text11, string text22, string text3, string text33,
             string text4, string text44)
        {
            InitializeComponent();
            SpTasks.Children.Clear();
            if (str.Length > 0) // Если есть ошибки
            {
                LBResult.Content = "Ты допустил ошибку";
                SpTasks.Visibility = Visibility.Visible;
                TextBlock header = new TextBlock() // Заголовок
                {
                    Text = $"Верный ответ - {text1} {str} {text2}\nВерный ответ - {text11} {str2} {text22}\nВерный ответ - {text3} {str3} {text33}\nВерный ответ - {text4} {str4} {text44}",
                    HorizontalAlignment = HorizontalAlignment.Center,
                };
                SpTasks.Children.Add(header);
            }
        }

        public ResultEqualSetsSolvengTasksWindow(string str, string str2, string str3,  string text1, string text2, string text11, string text22, string text3, string text33)
        {
            InitializeComponent();
            SpTasks.Children.Clear();
            if (str.Length > 0) // Если есть ошибки
            {
                LBResult.Content = "Ты допустил ошибку";
                SpTasks.Visibility = Visibility.Visible;
                TextBlock header = new TextBlock() // Заголовок
                {
                    Text = $"Верный ответ - {text1} {str} {text2}\nВерный ответ - {text11} {str2} {text22}\nВерный ответ - {text3} {str3} {text33}",
                    HorizontalAlignment = HorizontalAlignment.Center,
                };
                SpTasks.Children.Add(header);
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
