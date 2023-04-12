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
    public partial class ResultIntersectionSetsWindow : Window
    {
        public ResultIntersectionSetsWindow(int n, List<int[]> errors) // 1 задание
        {
            InitializeComponent();
            if (errors.Count == 1)
            {
                LBResult.Content = "В пункте ";
            }
            else
            {
                LBResult.Content = "В пунктах ";
            }
            for (int i = 0; i < errors.Count; i++) // Добавление букв под которыми сделаны ошибки
            {
                if (i == errors.Count - 1)
                {
                    LBResult.Content = "" + LBResult.Content + (Char)(65 + errors[i][0]);
                }
                else
                {
                    LBResult.Content = "" + LBResult.Content + (Char)(65 + errors[i][0]) + ", ";
                }
            }
            LBResult.Content = "" + LBResult.Content + " ты допустил ошибку";
            TextBlock header = new TextBlock() // Заголовок
            {
                Text = "Верный результат",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10),
            };
            SpTasks.Children.Add(header);
            EllipseGeneration ellipseGeneration = new EllipseGeneration();
            switch (n)
            {
                case 1:
                    WrapPanel wrapPanelOne = new WrapPanel()
                    {
                        HorizontalAlignment = HorizontalAlignment.Center
                    };// Вывод верного результата
                    SpTasks.Children.Add(wrapPanelOne);
                    for (int i = 0; i < errors.Count; i++)
                    {
                        Canvas canvas = new Canvas()
                        {
                            Width = 350,
                            Height = 250,
                        };
                        wrapPanelOne.Children.Add(canvas);
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
                    break;
                case 3:
                    WrapPanel wrapPanelThree = new WrapPanel()
                    {
                        HorizontalAlignment = HorizontalAlignment.Center
                    };// Вывод верного результата
                    SpTasks.Children.Add(wrapPanelThree);
                    for (int i = 0; i < errors.Count; i++)
                    {
                        Canvas canvas = new Canvas()
                        {
                            Width = 350,
                            Height = 250,
                        };
                        wrapPanelThree.Children.Add(canvas);
                        Label label = new Label()
                        {
                            Content = (Char)(65 + errors[i][0]) + ")",
                        };
                        canvas.Children.Add(label);
                        Ellipse ellipseOne = ellipseGeneration.getEllipse(errors[i][1], errors[i][2], errors[i][3], errors[i][4]); // Создание первого эллипса
                        canvas.Children.Add(ellipseOne);
                        Ellipse ellipseTwo = ellipseGeneration.getEllipse(errors[i][5], errors[i][6], errors[i][7], errors[i][8]); // Создание второго эллипса
                        canvas.Children.Add(ellipseTwo);
                        Ellipse ellipseThree = ellipseGeneration.getEllipse(errors[i][9], errors[i][10], errors[i][11], errors[i][12]); // Создание третьего эллипса
                        canvas.Children.Add(ellipseThree);
                        Path combinedPathOne = ellipseGeneration.getUnification(ellipseOne, ellipseTwo, GeometryCombineMode.Intersect); // Создание первого пересечения
                        canvas.Children.Add(combinedPathOne);
                        Path combinedPathTwo = ellipseGeneration.getUnification(ellipseOne, ellipseThree, GeometryCombineMode.Intersect); // Создание второго пересечения
                        canvas.Children.Add(combinedPathTwo);
                        Path combinedPathThree = ellipseGeneration.getUnification(ellipseTwo, ellipseThree, GeometryCombineMode.Intersect); // Создание третьего пересечения
                        canvas.Children.Add(combinedPathThree);
                        Path combinedPathFour = ellipseGeneration.getUnificationThree(ellipseOne, ellipseTwo, ellipseThree, GeometryCombineMode.Intersect); // Создание общего пересечения
                        combinedPathFour.Fill = Brushes.Yellow;
                        canvas.Children.Add(combinedPathFour);
                    }
                    break;
            }

        }

        public ResultIntersectionSetsWindow(List<int> errors, List<string> correctResult) // 4 задание
        {
            InitializeComponent();
            if (errors.Count == 1)
            {
                LBResult.Content = "Ты допустил одну ошибку ";
            }
            else
            {
                LBResult.Content = "Ты допустил две ошибки ";
            }
            TextBlock header = new TextBlock() // Заголовок
            {
                Text = "Верный результат",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10),
            };
            SpTasks.Children.Add(header);
            for (int i = 0; i < errors.Count; i++)
            {
                string text;
                if(errors[i] == 1)
                {
                    text = "Переместительное свойство: ";
                }
                else
                {
                    text = "Сочетательное свойство: ";
                }
                TextBlock textBlock = new TextBlock()
                {
                    Text = text + correctResult[errors[i]],
                    HorizontalAlignment = HorizontalAlignment.Center,
                };
                SpTasks.Children.Add(textBlock);
            }
        }

        public ResultIntersectionSetsWindow(List<string> intersectionSets) // 2 задание
        {
            InitializeComponent();
            LBResult.Content = "Задание решено не верно";
            TextBlock header = new TextBlock() // Заголовок
            {
                Text = "Правильное решение задания",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10),
            };
            SpTasks.Children.Add(header);
            Canvas canvas = new Canvas()
            {
                Height = 250,
                Width = 1000,
            };
            SpTasks.Children.Add(canvas);

            EllipseGeneration ellipseGeneration = new EllipseGeneration();
            Ellipse ellipseOne = ellipseGeneration.getEllipse(250, 200, 325, 20); // Создание первого эллипса
            ellipseOne.Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18");
            canvas.Children.Add(ellipseOne);
            Ellipse ellipseTwo = ellipseGeneration.getEllipse(250, 200, 425, 20); // Создание второго эллипса
            ellipseTwo.Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18");
            canvas.Children.Add(ellipseTwo);
            Path combinedPath = ellipseGeneration.getUnification(ellipseOne, ellipseTwo, GeometryCombineMode.Intersect); // Создание пересечения
            combinedPath.Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18");
            canvas.Children.Add(combinedPath);
            Label firstPlenty = new Label()
            {
                Content = "M",
                Margin = new Thickness(650, 10, 0, 0),
            };
            canvas.Children.Add(firstPlenty);
            Label secondPlenty = new Label()
            {
                Content = "K",
                Margin = new Thickness(325, 10, 0, 0),
            };
            canvas.Children.Add(secondPlenty);

            int s = 0;
            int j = 1;
            int kol = 0;
            for (int i = 0; i < intersectionSets.Count; i++)
            {
                Figure figure = new Figure(28, 0, 0);
                Geometry geometry = null;
                if (s % 4 == 0 && s != 0)
                {
                    s = 0;
                    if(j == 4)
                    {
                        j = 0;
                    }
                    else
                    {
                        j++;
                    }
                }
                switch (intersectionSets[i])
                {
                    case ("круг"):
                        geometry = figure.CreateCircle(430 + 35 * s, 45 * j);
                        break;
                    case ("треугольник"):
                        geometry = figure.CreateTriangle(430 + 35 * s, 45 * j);
                        break;
                    case ("квадрат"):
                        geometry = figure.CreateSquare(430 + 35 * s, 45 * j);
                        break;
                    case ("ромб"):
                        geometry = figure.CreateRhomb(430 + 35 * s, 45 * j);
                        break;
                    default:
                        geometry = figure.GetGeometryFromText(intersectionSets[i], 50, 430 + 35 * s, -60 + (45 * j));
                        break;
                }
                s++;
                if (combinedPath.Data.FillContainsWithDetail(geometry) != IntersectionDetail.FullyContains)
                {
                    i--;
                }
                else
                {
                    Path path = new Path()
                    {
                        StrokeThickness = Base.StrokeThickness,
                        Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18"),
                        Data = geometry,
                        Fill = Brushes.White,
                    };
                    canvas.Children.Add(path);
                    kol++;
                }
            }
        }
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
