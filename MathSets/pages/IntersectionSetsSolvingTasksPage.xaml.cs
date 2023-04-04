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
            twoColumn.Width = new GridLength(50); // Столбце под кнопку подсказка
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
                Style = (Style)FindResource("ButtonMainStyle"),
            };
            BtnHint.Click += BtnHint_Click;
            Grid.SetColumn(BtnHint, 1);
            grid.Children.Add(BtnHint);
            WrapPanel wrapPanel = new WrapPanel()
            {
                HorizontalAlignment = HorizontalAlignment.Center
            };
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
                EllipseGeneration ellipseGeneration = new EllipseGeneration();
                Label label = new Label()
                {
                    Content = (Char)(65 + i) + ")",
                };
                canvas.Children.Add(label);
                Ellipse ellipseOne = ellipseGeneration.getEllipse(random.Next(50, 200), random.Next(50, 200), random.Next(40, 100), random.Next(0, 50)); // Создание первого эллипса
                ellipseOne.MouseDown += Ellipse_MouseDown;
                canvas.Children.Add(ellipseOne);
                Ellipse ellipseTwo = ellipseGeneration.getEllipse(random.Next(50, 200), random.Next(50, 200), random.Next(40, 100), random.Next(0, 50)); // Создание второго эллипса
                ellipseTwo.MouseDown += Ellipse_MouseDown;
                canvas.Children.Add(ellipseTwo);
                Path combinedPath = ellipseGeneration.getUnification(ellipseOne, ellipseTwo, GeometryCombineMode.Intersect); // Создание пересечения
                combinedPath.MouseDown += Ellipse_MouseDown;
                canvas.Children.Add(combinedPath);
            }
            Button BtnResult = new Button() // Кнопка для проверки результата
            {
                Content = "Проверить",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Style = (Style)FindResource("ButtonMainStyle"),
            };
            BtnResult.Click += BtnResult_Click;
            SpTasks.Children.Add(BtnResult);
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
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
            Base.MainFrame.Navigate(new MainMenuPage());
        }

        private void BtnHint_Click(object sender, RoutedEventArgs e)
        {
            HintIntersectionSetsWindow hint = new HintIntersectionSetsWindow();
            hint.ShowDialog();
        }

        private void BtnResult_Click(object sender, RoutedEventArgs e)
        {
            EllipseGeneration ellipseGeneration = new EllipseGeneration();
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
                        errors.Add(ellipseGeneration.getDateEllipse(i, ellipseOne, ellipseTwo));
                    }
                }
                else if(ellipseOne.Fill != Brushes.White || ellipseTwo.Fill != Brushes.White || path.Fill != Brushes.Yellow) // Если выделено не только пересечение
                {
                    errors.Add(ellipseGeneration.getDateEllipse(i, ellipseOne, ellipseTwo));
                }
            }
            ResultOneTaskIntersectionSetsWindow resultOneTaskIntersectionSetsWindow = new ResultOneTaskIntersectionSetsWindow(errors); // Показ результата
            resultOneTaskIntersectionSetsWindow.ShowDialog();
        }

        private void BtnHint_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
