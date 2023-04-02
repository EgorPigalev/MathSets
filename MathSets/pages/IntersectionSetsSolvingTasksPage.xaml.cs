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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MathSets
{
    /// <summary>
    /// Логика взаимодействия для IntersectionSetsSolvingTasksPage.xaml
    /// </summary>
    public partial class IntersectionSetsSolvingTasksPage : Page
    {
        public IntersectionSetsSolvingTasksPage()
        {
            InitializeComponent();
            NewTasks();
        }

        /// <summary>
        /// Генерация заданий разных типов
        /// </summary>
        private void NewTasks()
        {
            int n = 1; // Номер задания
            NewOneTask(n);
            n++;

        }
        /// <summary>
        /// Генерация задания 1 типа (выделить пересечение множеств)
        /// </summary>
        /// <param name="n">Номер задания</param>
        private void NewOneTask(int n)
        {
            Grid grid = new Grid(); // Добавления grid для вывода формулировки задания
            ColumnDefinition oneColumn = new ColumnDefinition();
            ColumnDefinition twoColumn = new ColumnDefinition();
            twoColumn.Width = new GridLength(50);
            grid.ColumnDefinitions.Add(oneColumn);
            grid.ColumnDefinitions.Add(twoColumn);
            TextBlock taskStatement = new TextBlock() // Формулировка задания
            {
                Text = n + ") На каждом рисунке закрась пересечение множеств (если пересечение отсутствует, то ничего закрашивать не нужно).",
                TextWrapping = TextWrapping.Wrap,
            };
            SpTasks.Children.Add(grid);
            grid.Children.Add(taskStatement);
            Grid.SetColumn(taskStatement, 0);
            Button BtnHint = new Button() // Кнопка для подсказки
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Content = "?",
            };
            BtnHint.Click += BtnHint_Click;
            Grid.SetColumn(BtnHint, 1);
            grid.Children.Add(BtnHint);
            WrapPanel wrapPanel = new WrapPanel();
            SpTasks.Children.Add(wrapPanel);
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                Canvas canvas = new Canvas()
                {
                    Width = 350,
                    Height = 250,
                };
                wrapPanel.Children.Add(canvas);
                Label label = new Label()
                {
                    Content = (Char)(65 + i) + ")",
                };
                canvas.Children.Add(label);
                int xOneEllipse = random.Next(40, 100); // На сколько отступить для первого эллипса по горизонтале (40 - это для вывода подпункта)
                int yOneEllipse = random.Next(0, 50); // На сколько отступить для первого эллипса по вертикале
                Ellipse ellipseOne = new Ellipse(); // Создание 1 эллипса
                ellipseOne.Width = random.Next(50, 200);
                ellipseOne.Height = random.Next(50, 200);
                ellipseOne.Stroke = Brushes.Black;
                ellipseOne.StrokeThickness = 2;
                ellipseOne.Margin = new Thickness(xOneEllipse, yOneEllipse, 0, 0);
                ellipseOne.Fill = Brushes.White;
                ellipseOne.MouseDown += ellipse_MouseDown;
                canvas.Children.Add(ellipseOne);
                int xTwoEllipse = random.Next(40, 100);
                int yTwoEllipse = random.Next(0, 50);
                Ellipse ellipseTwo = new Ellipse(); // Создание второго эллипса
                ellipseTwo.Width = random.Next(100, 200);
                ellipseTwo.Height = random.Next(100, 200);
                ellipseTwo.Stroke = Brushes.Black;
                ellipseTwo.StrokeThickness = 2;
                ellipseTwo.Margin = new Thickness(xTwoEllipse, yTwoEllipse, 0, 0);
                ellipseTwo.Fill = Brushes.White;
                ellipseTwo.MouseDown += ellipse_MouseDown;
                canvas.Children.Add(ellipseTwo);
                EllipseGeometry pathGeometryOne = new EllipseGeometry() // Создание EllipseGeometry, который равен первому эллипсу (он нужен для нахождения объединения)
                {
                    RadiusX = ellipseOne.Width / 2,
                    RadiusY = ellipseOne.Height / 2,
                    Center = new Point(xOneEllipse + (ellipseOne.Width / 2), yOneEllipse + (ellipseOne.Height / 2)),
                };
                EllipseGeometry pathGeometryTwo = new EllipseGeometry() // Создание EllipseGeometry, который равен второму эллипсу 
                {
                    RadiusX = ellipseTwo.Width / 2,
                    RadiusY = ellipseTwo.Height / 2,
                    Center = new Point(xTwoEllipse + (ellipseTwo.Width / 2), yTwoEllipse + (ellipseTwo.Height / 2)),
                };
                CombinedGeometry combinedGeometry = new CombinedGeometry(GeometryCombineMode.Intersect, pathGeometryOne, pathGeometryTwo); // Объединение двух эллипсов
                Path combinedPath = new Path();
                combinedPath.Data = combinedGeometry;
                combinedPath.Fill = Brushes.White;
                combinedPath.Stroke = Brushes.Black;
                combinedPath.StrokeThickness = 2;
                combinedPath.MouseDown += ellipse_MouseDown;
                canvas.Children.Add(combinedPath);
            }
            Button BtnResult = new Button() // Кнопка для проверки результата
            {
                Content = "Проверить",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            BtnResult.Click += BtnResult_Click;
            SpTasks.Children.Add(BtnResult);
        }

        private void ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (typeof(Ellipse) == sender.GetType()) // Если нажали на эллипс, то его закрашиваем
            {
                Ellipse ellipse = sender as Ellipse;
                if (ellipse.Fill == Brushes.Yellow) // Если уже закрашен, то возвращаем обратно белый фон
                {
                    ellipse.Fill = Brushes.White;
                }
                else
                {
                    ellipse.Fill = Brushes.Yellow;
                }
            }
            else // Если нажали не на эллипс
            {
                Path ellipse = sender as Path;
                if (ellipse.Fill == Brushes.Yellow) // Если уже закрашен, то возвращаем обратно белый фон
                {
                    ellipse.Fill = Brushes.White;
                }
                else
                {
                    ellipse.Fill = Brushes.Yellow;
                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new IntersectionSetsPage());
        }

        private void BtnHint_Click(object sender, RoutedEventArgs e)
        {
            HintIntersectionSetsWindow hint = new HintIntersectionSetsWindow();
            hint.ShowDialog();
        }

        private void BtnResult_Click(object sender, RoutedEventArgs e)
        {
            List<int[]> errors = new List<int[]>(); // Массив ошибок
            WrapPanel wrapPanel = (WrapPanel)SpTasks.Children[1]; // Получение области, где хранятся Canvas
            for (int i = 0; i < wrapPanel.Children.Count; i++) // Проверка каждого пункта
            {
                Canvas canvas = (Canvas)wrapPanel.Children[i];
                Ellipse ellipseOne = (Ellipse)canvas.Children[1];
                Ellipse ellipseTwo = (Ellipse)canvas.Children[2];
                Path path = (Path)canvas.Children[3];
                if(path.ActualWidth == 0) // Если объединение не существует, пересечение равно пустому множеству
                {
                    if (ellipseOne.Fill != Brushes.White || ellipseTwo.Fill != Brushes.White) // Если выделено лишнее
                    {
                        int[] massive = new int[9]; // Информация для вывода верного ответа
                        massive[0] = i;
                        massive[1] = Convert.ToInt32(ellipseOne.Width);
                        massive[2] = Convert.ToInt32(ellipseOne.Height);
                        massive[3] = Convert.ToInt32(ellipseOne.Margin.Left);
                        massive[4] = Convert.ToInt32(ellipseOne.Margin.Top);
                        massive[5] = Convert.ToInt32(ellipseTwo.Width);
                        massive[6] = Convert.ToInt32(ellipseTwo.Height);
                        massive[7] = Convert.ToInt32(ellipseTwo.Margin.Left);
                        massive[8] = Convert.ToInt32(ellipseTwo.Margin.Top);
                        errors.Add(massive);
                    }
                }
                else if(ellipseOne.Fill != Brushes.White || ellipseTwo.Fill != Brushes.White || path.Fill != Brushes.Yellow) // Если выделено не только пересечение
                {
                    int[] massive = new int[9]; // Информация для вывода верного ответа
                    massive[0] = i;
                    massive[1] = Convert.ToInt32(ellipseOne.Width);
                    massive[2] = Convert.ToInt32(ellipseOne.Height);
                    massive[3] = Convert.ToInt32(ellipseOne.Margin.Left);
                    massive[4] = Convert.ToInt32(ellipseOne.Margin.Top);
                    massive[5] = Convert.ToInt32(ellipseTwo.Width);
                    massive[6] = Convert.ToInt32(ellipseTwo.Height);
                    massive[7] = Convert.ToInt32(ellipseTwo.Margin.Left);
                    massive[8] = Convert.ToInt32(ellipseTwo.Margin.Top);
                    errors.Add(massive);
                }
            }
            ResultOneTaskIntersectionSetsWindow resultOneTaskIntersectionSetsWindow = new ResultOneTaskIntersectionSetsWindow(errors); // Показ результата
            resultOneTaskIntersectionSetsWindow.ShowDialog();
        }
    }
}
