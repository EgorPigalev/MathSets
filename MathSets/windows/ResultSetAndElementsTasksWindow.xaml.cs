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
    /// Логика взаимодействия для ResultSetAndElementsTasksWindow.xaml
    /// </summary>
    public partial class ResultSetAndElementsTasksWindow : Window
    {
        public ResultSetAndElementsTasksWindow(string str)
        {
            InitializeComponent();
            if (str.Length > 0) // Если есть ошибки
            {
                LBResult.Content = "Ты допустил ошибку";
                SpTasks.Visibility = Visibility.Visible;
                TextBlock header = new TextBlock() // Заголовок
                {
                    Text =   $"Верный ответ - {str}",
                    HorizontalAlignment = HorizontalAlignment.Center,
                };
                SpTasks.Children.Add(header);
            }
        }


        public ResultSetAndElementsTasksWindow()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
