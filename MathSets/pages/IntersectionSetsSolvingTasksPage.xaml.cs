using MathSets.windows;
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
        Random random = new Random();
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

            NewOneTask();
            NewTwoTask();
            NewThreeTask();

        }
        /// <summary>
        /// Генерация задания 1 типа (выделить пересечение множеств)
        /// </summary>
        private void NewOneTask()
        {
            WPMainPlaceQuestionFirst.Children.Clear();
            for (int i = 0; i < 4; i++)
            {
                Canvas canvas = new Canvas()
                {
                    Width = 350,
                    Height = 250,
                };
                WPMainPlaceQuestionFirst.Children.Add(canvas);
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

        private void BtnCheckQuestionFirst_Click(object sender, RoutedEventArgs e)
        {
            EllipseGeneration ellipseGeneration = new EllipseGeneration();
            List<int[]> errors = new List<int[]>(); // Массив ошибок
            for (int i = 0; i < WPMainPlaceQuestionFirst.Children.Count; i++) // Проверка каждого пункта
            {
                Canvas canvas = (Canvas)WPMainPlaceQuestionFirst.Children[i];
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
            if(errors.Count > 0) // Если есть ошибки, то открывается окно с правильным решением
            {
                ResultIntersectionSetsWindow resultIntersectionSetsWindow = new ResultIntersectionSetsWindow(1, errors);
                resultIntersectionSetsWindow.ShowDialog();
            }
            else
            {
                CorrectResult correctResult = new CorrectResult();
                correctResult.ShowDialog();
            }
        }

        private void MenuSaved_Click(object sender, RoutedEventArgs e)
        {
            MenuItem childMenuItem = (MenuItem)sender;
            MenuItem menuItem = (MenuItem)childMenuItem.Parent;
        }

        private void MenuOpenSaved_Click(object sender, RoutedEventArgs e)
        {
            MenuItem childMenuItem = (MenuItem)sender;
            MenuItem menuItem = (MenuItem)childMenuItem.Parent;
        }

        private void MenuRefresh_Click(object sender, RoutedEventArgs e)
        {
            MenuItem childMenuItem = (MenuItem)sender;
            MenuItem menuItem = (MenuItem)childMenuItem.Parent;

            switch (Convert.ToInt32(menuItem.Uid))
            {
                case 1:
                    NewOneTask();
                    break;
                case 2:
                    NewTwoTask();
                    break;
                case 3:
                    NewThreeTask();
                    break;
                default:
                    break;
            }
        }



        /// <summary>
        /// Генерация задания 2 типа (Нахождение пересечения двух множеств)
        /// </summary>
        private void NewTwoTask()
        {
            /*
            WPMainPlaceQuestionSecond.Children.Clear();
            for(int i = 0; i < 2; i++)
            {
                StackPanel stackPanel = new StackPanel();
                WPMainPlaceQuestionSecond.Children.Add(stackPanel);
                List<String> firstSets;
                List<String> secondSets;
                while (true)
                {
                    firstSets = getSets(); // Первое множество
                    secondSets = getSets(); // Второе множество
                    foreach(string set in firstSets) // Проверка на то, что в двух множествах есть хотя бы одно пересечение
                    {
                        foreach(string set2 in secondSets)
                        {
                            if(set.Equals(set2))
                            {
                                break;
                            }
                        }
                    }
                }
                StackPanel setsM = new StackPanel()
                {
                    Orientation = Orientation.Horizontal
                };
                stackPanel.Children.Add(setsM);
                int sizeFigures = (int)TBHeader.FontSize;
                Figure figure = new Figure(sizeFigures, (sizeFigures + 2) * 2, setsM.Width);
                Label textSetsM = new Label()
                {
                    Content = "M = {"
                };
                setsM.Children.Add(textSetsM);
                foreach(string set in firstSets)
                {
                    if(set.Equals("треугольник"))
                    {
                        //figure.CreateTriangle()
                    }
                }

                Label label = new Label()
                {
                    Content = (Char)(65 + i) + ")",
                };

            }
            */
        }

        List<String> list = new List<string> { "a", "б", "в", "г", "д", "е", "ж", "з", "звезда", "треугольник", "круг" }; // Допустимые символы из которых могут состоять множества
        /// <summary>
        /// Рандомно генерирует множество
        /// </summary>
        /// <returns></returns>
        private List<String> getSets()
        {
            List<String> sets = new List<String>();
            int count = random.Next(2,5);
            int index = 0;
            for (int i = 0; i < count; i++)
            {
                index = random.Next(12);
                sets.Add(list[index]);
            }
            return sets;
        }

        private void BtnCheckQuestionSecond_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Генерация задания 3 типа (Нахождение пересечения двух множеств)
        /// </summary>
        private void NewThreeTask()
        {
            WPMainPlaceQuestionThree.Children.Clear();
            for (int i = 0; i < 4; i++)
            {
                Canvas canvas = new Canvas()
                {
                    Width = 350,
                    Height = 250,
                };
                WPMainPlaceQuestionThree.Children.Add(canvas);
                EllipseGeneration ellipseGeneration = new EllipseGeneration();
                Label label = new Label()
                {
                    Content = (Char)(65 + i) + ")",
                };
                canvas.Children.Add(label);
                Ellipse ellipseOne = ellipseGeneration.getEllipse(random.Next(100, 200), random.Next(100, 125), random.Next(20, 40), random.Next(10, 20)); // Создание первого эллипса
                ellipseOne.MouseDown += Ellipse_MouseDown;
                canvas.Children.Add(ellipseOne);
                Ellipse ellipseTwo = ellipseGeneration.getEllipse(random.Next(100, 200), random.Next(100, 125), random.Next(80, 100), random.Next(0, 10)); // Создание второго эллипса
                ellipseTwo.MouseDown += Ellipse_MouseDown;
                canvas.Children.Add(ellipseTwo);
                Ellipse ellipseThree = ellipseGeneration.getEllipse(random.Next(100, 200), random.Next(100, 125), random.Next(40, 60), random.Next(40, 50)); // Создание третьего эллипса
                ellipseThree.MouseDown += Ellipse_MouseDown;
                canvas.Children.Add(ellipseThree);
                Path combinedPathOne = ellipseGeneration.getUnification(ellipseOne, ellipseTwo, GeometryCombineMode.Intersect); // Создание первого пересечения
                combinedPathOne.MouseDown += Ellipse_MouseDown;
                canvas.Children.Add(combinedPathOne);
                Path combinedPathTwo = ellipseGeneration.getUnification(ellipseOne, ellipseThree, GeometryCombineMode.Intersect); // Создание второго пересечения
                combinedPathTwo.MouseDown += Ellipse_MouseDown;
                canvas.Children.Add(combinedPathTwo);
                Path combinedPathThree = ellipseGeneration.getUnification(ellipseTwo, ellipseThree, GeometryCombineMode.Intersect); // Создание третьего пересечения
                combinedPathThree.MouseDown += Ellipse_MouseDown;
                canvas.Children.Add(combinedPathThree);
                Path combinedPathFour = ellipseGeneration.getUnificationThree(ellipseOne, ellipseTwo, ellipseThree, GeometryCombineMode.Intersect); // Создание общего пересечения
                combinedPathFour.MouseDown += Ellipse_MouseDown;
                canvas.Children.Add(combinedPathFour);
            }
        }

        private void BtnCheckQuestionThree_Click(object sender, RoutedEventArgs e)
        {
            EllipseGeneration ellipseGeneration = new EllipseGeneration();
            List<int[]> errors = new List<int[]>(); // Массив ошибок
            for (int i = 0; i < WPMainPlaceQuestionThree.Children.Count; i++) // Проверка каждого пункта
            {
                Canvas canvas = (Canvas)WPMainPlaceQuestionThree.Children[i];
                Ellipse ellipseOne = (Ellipse)canvas.Children[1];
                Ellipse ellipseTwo = (Ellipse)canvas.Children[2];
                Ellipse ellipseThree= (Ellipse)canvas.Children[3];
                Path pathOne = (Path)canvas.Children[4];
                Path pathTwo = (Path)canvas.Children[5];
                Path pathThree = (Path)canvas.Children[6];
                Path pathFour = (Path)canvas.Children[7];
                if (pathFour.ActualWidth == 0) // Если объединение не существует, пересечение равно пустому множеству
                {
                    if (ellipseOne.Fill != Brushes.White || ellipseTwo.Fill != Brushes.White || ellipseThree.Fill != Brushes.White || pathOne.Fill != Brushes.White || pathTwo.Fill != Brushes.White || pathThree.Fill != Brushes.White) // Если выделено лишнее
                    {
                        errors.Add(ellipseGeneration.getDateEllipseThree(i, ellipseOne, ellipseTwo, ellipseThree));
                    }
                }
                else if (ellipseOne.Fill != Brushes.White || ellipseTwo.Fill != Brushes.White || ellipseThree.Fill != Brushes.White || pathOne.Fill != Brushes.White || pathTwo.Fill != Brushes.White || pathThree.Fill != Brushes.White || pathFour.Fill != Brushes.Yellow) // Если выделено не только пересечение
                {
                    errors.Add(ellipseGeneration.getDateEllipseThree(i, ellipseOne, ellipseTwo, ellipseThree));
                }
            }
            if (errors.Count > 0) // Если есть ошибки, то открывается окно с правильным решением
            {
                ResultIntersectionSetsWindow resultIntersectionSetsWindow = new ResultIntersectionSetsWindow(3, errors);
                resultIntersectionSetsWindow.ShowDialog();
            }
            else
            {
                CorrectResult correctResult = new CorrectResult();
                correctResult.ShowDialog();
            }
        }
    }
}
