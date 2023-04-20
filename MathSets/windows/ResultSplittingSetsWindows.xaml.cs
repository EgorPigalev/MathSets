using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MathSets.windows
{
    /// <summary>
    /// Логика взаимодействия для ResultSplittingSetsWindows.xaml
    /// </summary>
    public partial class ResultSplittingSetsWindows : Window
    {
        public ResultSplittingSetsWindows(List<string> errors, int taskNumber)
        {
            InitializeComponent();
            try
            {
                if (taskNumber == 1) // 1 Задание
                {
                    if (errors.Count > 1)
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
                else // 2 Задание
                {
                    LBResult.Content = "Ты допустил ошибки в решение задания";
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
                    TextBlock firstPoint = new TextBlock() // Первый вопрос
                    {
                        Text = "Множество состоит из следующих частей: " + errors[0],
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Margin = new Thickness(10),
                    };
                    wrapPanel.Children.Add(firstPoint);
                    TextBlock titleTrueEqualities = new TextBlock() // Заголовок верные равенства
                    {
                        Text = "Верные равенства:",
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Margin = new Thickness(10),
                    };
                    wrapPanel.Children.Add(titleTrueEqualities);
                    for (int i = 1; i < errors.Count; i++)
                    {
                        TextBlock errorTextBlock = new TextBlock()
                        {
                            Text = errors[i],
                            HorizontalAlignment = HorizontalAlignment.Center,
                        };
                        wrapPanel.Children.Add(errorTextBlock);
                    }
                }
            }
            catch
            {
                MessageBox.Show("При выводе результата возникла ошибка", "Системное сообщение");
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
