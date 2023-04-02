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
                WrapPanel wrapPanel = new WrapPanel(); // Вывод верного результата
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
                    int xOneEllipse = errors[i][3];
                    int yOneEllipse = errors[i][4];
                    Ellipse ellipseOne = new Ellipse();
                    ellipseOne.Width = errors[i][1];
                    ellipseOne.Height = errors[i][2];
                    ellipseOne.Stroke = Brushes.Black;
                    ellipseOne.StrokeThickness = 2;
                    ellipseOne.Margin = new Thickness(xOneEllipse, yOneEllipse, 0, 0);
                    ellipseOne.Fill = Brushes.White;
                    canvas.Children.Add(ellipseOne);
                    int xTwoEllipse = errors[i][7];
                    int yTwoEllipse = errors[i][8];
                    Ellipse ellipseTwo = new Ellipse();
                    ellipseTwo.Width = errors[i][5];
                    ellipseTwo.Height = errors[i][6];
                    ellipseTwo.Stroke = Brushes.Black;
                    ellipseTwo.StrokeThickness = 2;
                    ellipseTwo.Margin = new Thickness(xTwoEllipse, yTwoEllipse, 0, 0);
                    ellipseTwo.Fill = Brushes.White;
                    canvas.Children.Add(ellipseTwo);
                    EllipseGeometry pathGeometryOne = new EllipseGeometry()
                    {
                        RadiusX = ellipseOne.Width / 2,
                        RadiusY = ellipseOne.Height / 2,
                        Center = new Point(xOneEllipse + (ellipseOne.Width / 2), yOneEllipse + (ellipseOne.Height / 2)),
                    };
                    EllipseGeometry pathGeometryTwo = new EllipseGeometry()
                    {
                        RadiusX = ellipseTwo.Width / 2,
                        RadiusY = ellipseTwo.Height / 2,
                        Center = new Point(xTwoEllipse + (ellipseTwo.Width / 2), yTwoEllipse + (ellipseTwo.Height / 2)),
                    };
                    CombinedGeometry combinedGeometry = new CombinedGeometry(GeometryCombineMode.Intersect, pathGeometryOne, pathGeometryTwo);
                    Path combinedPath = new Path();
                    combinedPath.Data = combinedGeometry;
                    combinedPath.Fill = Brushes.Yellow;
                    combinedPath.Stroke = Brushes.Black;
                    combinedPath.StrokeThickness = 2;
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
