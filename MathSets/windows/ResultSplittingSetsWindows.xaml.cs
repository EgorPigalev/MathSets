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
    /// Логика взаимодействия для ResultSplittingSetsWindows.xaml
    /// </summary>
    public partial class ResultSplittingSetsWindows : Window
    {
        public ResultSplittingSetsWindows(List<string> errors)
        {
            InitializeComponent();
            if(errors.Count > 1)
            {
                LBResult.Content = "Ты допустил ошибки в " + errors.Count + " примерах";
            }
            else
            {
                LBResult.Content = "Ты допустил ошибку в " + errors.Count + " примере";
            }
            TextBlock header = new TextBlock() // Заголовок
            {
                Text = "Верный результат",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10),
            };
            SpTasks.Children.Add(header);
            WrapPanel wrapPanel = new WrapPanel()
            {
                Orientation = Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Center
            };// Вывод верного результата
            SpTasks.Children.Add(wrapPanel);
            foreach (string error in errors)
            {
                TextBlock errorTextBlock = new TextBlock()
                {
                    Text = error,
                };
                wrapPanel.Children.Add(errorTextBlock);
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
