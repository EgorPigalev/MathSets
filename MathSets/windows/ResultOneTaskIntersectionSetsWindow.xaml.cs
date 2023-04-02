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

namespace MathSets
{
    /// <summary>
    /// Логика взаимодействия для ResultOneTaskIntersectionSetsWindow.xaml
    /// </summary>
    public partial class ResultOneTaskIntersectionSetsWindow : Window
    {
        public ResultOneTaskIntersectionSetsWindow(List<int[]> errors)
        {
            InitializeComponent();
            if(errors.Count > 0) // Если есть ошибки
            {
                if(errors.Count == 1)
                {
                    LBResult.Content = "В пункте ";
                }
                else
                {
                    LBResult.Content = "В пунктах ";
                }
                for (int i = 0; i < errors.Count; i++) // Добавление букв под которыми сделаны ошибки
                {
                    if(i == errors.Count - 1)
                    {
                        LBResult.Content = "" + LBResult.Content + (Char)(65 + errors[i][0]);
                    }
                    else
                    {
                        LBResult.Content = "" + LBResult.Content + (Char)(65 + errors[i][0]) + ", ";
                    }
                }
                LBResult.Content = "" + LBResult.Content + " ты допустил ошибку";
                IMCorrectResult.Visibility = Visibility.Collapsed;
                SpTasks.Visibility = Visibility.Visible;
                TextBlock header = new TextBlock() // Заголовок
                {
                    Text = "Верный результат",
                    HorizontalAlignment = HorizontalAlignment.Center,
                };
                SpTasks.Children.Add(header);
                WrapPanel wrapPanel = new WrapPanel()
                {
                    HorizontalAlignment = HorizontalAlignment.Center
                };// Вывод верного результата
                EllipseGeneration ellipseGeneration = new EllipseGeneration();
                SpTasks.Children.Add(wrapPanel);
                for (int i = 0; i < errors.Count; i++)
                {
                    Canvas canvas = new Canvas()
                    {
                        Width = 350,
                        Height = 250,
                    };
                    wrapPanel.Children.Add(canvas);
                    Label label = new Label()
                    {
                        Content = (Char)(65 + errors[i][0]) + ")",
                    };
                    canvas.Children.Add(label);
                    Ellipse ellipseOne = ellipseGeneration.getEllipse(errors[i][1], errors[i][2], errors[i][3], errors[i][4]);
                    canvas.Children.Add(ellipseOne);
                    Ellipse ellipseTwo = ellipseGeneration.getEllipse(errors[i][5], errors[i][6], errors[i][7], errors[i][8]);
                    canvas.Children.Add(ellipseTwo);
                    Path combinedPath = ellipseGeneration.getUnification(ellipseOne, ellipseTwo, GeometryCombineMode.Intersect);
                    combinedPath.Fill = Brushes.Yellow;
                    canvas.Children.Add(combinedPath);
                }
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
