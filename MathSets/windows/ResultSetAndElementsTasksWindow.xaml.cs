using System.Windows;
using System.Windows.Controls;


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
                    Text = $"Верный ответ - {str}",
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
            Close();
        }
    }
}
