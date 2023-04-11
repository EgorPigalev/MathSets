using MathSets.windows;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Media.Media3D;
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
        List<Point> _pointsQuestionFirst = new List<Point>(); // Точки смещения для второго задания
        private Path _pathToMoved; // Фигура для перемещения
        private Point _oldMouseCoordinate; // Предыдущие координаты курсора (для перемещения фигуры)
        private List<string> correctResultFourTask = new List<string>();

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
            NewFourTask();
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
                if (path.ActualWidth == 0) // Если объединение не существует, пересечение равно пустому множеству
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
                    NewFourTask();
                    break;
            }
        }

        List<int> indexCorrectResult = new List<int>(); // Индексы фигур для правильного результата
        List<string> intersectionSets = new List<string>(); // Фигуры, которые представляют собой пересечение множеств


        /// <summary>
        /// Генерация задания 2 типа (Нахождение пересечения двух множеств)
        /// </summary>
        private void NewTwoTask()
        {
            CVMainPlaceQuestionSecond.Children.Clear();
            CreateSetsQuestionSecond();
            List<String> firstSets = new List<string>(); // Первое множество
            List<String> secondSets = new List<string>(); // Второе множество
            bool b = true;
            while (b)
            {
                firstSets = getSets(); // Первое множество
                secondSets = getSets(); // Второе множество
                foreach (string set in firstSets) // Проверка на то, что в двух множествах есть хотя бы одно пересечение
                {
                    foreach (string set2 in secondSets)
                    {
                        if (set.Equals(set2))
                        {
                            b = false;
                        }
                    }
                }
            }
            SPPrimer.Children.Clear();
            ShowPrimer(firstSets, 'M');
            ShowPrimer(secondSets, 'K');

            intersectionSets = GetIntersectionSets(firstSets, secondSets); // Пересечение множеств
            List<string> combiningSets = GetCombiningSets(firstSets, secondSets); // Объединение множеств (для вывода всех фигур без повторений)
            indexCorrectResult.Clear();
            foreach (string set in intersectionSets)
            {
                indexCorrectResult.Add(combiningSets.IndexOf(set));
            }

            int s = 0;
            int j = 1;
            for (int i = 0; i < combiningSets.Count; i++)
            {
                Figure figure = new Figure(28, 0, 0);
                Geometry geometry = null;
                if(i == 9)
                {
                    s = 0;
                    j = 2;
                }
                switch (combiningSets[i])
                {
                    case ("круг"):
                        geometry = figure.CreateCircle(5 + 40 * s, 25 + (70 * j));
                        break;
                    case ("треугольник"):
                        geometry = figure.CreateTriangle(5 + 40 * s, 25 +(70 * j));
                        break;
                    case ("квадрат"):
                        geometry = figure.CreateSquare(5 + 40 * s, 25 + (70 * j));
                        break;
                    case ("ромб"):
                        geometry = figure.CreateRhomb(5 + 40 * s, 25 + (70 * j));
                        break;
                    default:
                        geometry = figure.GetGeometryFromText(combiningSets[i], 50, 5 + 40 * s, -30 + (70 * j));
                        break;
                }
                s++;
                Path path = new Path()
                {
                    StrokeThickness = Base.StrokeThickness,
                    Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18"),
                    Data = geometry,
                    Fill = Brushes.White,
                };
                path.MouseDown += OnMouseDown;
                path.MouseMove += OnMouseMove;
                path.Uid = i.ToString();
                CVMainPlaceQuestionSecond.Children.Add(path);
            }

            _pointsQuestionFirst.Clear();
            for (int i = 0; i < combiningSets.Count; i++) // Заполнение точек смещения
            {
                _pointsQuestionFirst.Add(new Point(0, 0));
            }
        }

        /// <summary>
        /// Получения пересечения двух множеств
        /// </summary>
        /// <param name="firstSets">Первое множество</param>
        /// <param name="secondSets">Второе множество</param>
        /// <returns>Множество полученное в результате пересечения</returns>
        private List<string> GetIntersectionSets(List<string> firstSets, List<string> secondSets)
        {
            List<string> intersectionSets = new List<string>();
            foreach (string set in firstSets)
            {
                foreach (string set2 in secondSets)
                {
                    if (set.Equals(set2))
                    {
                        intersectionSets.Add(set2);
                    }
                }
            }
            return intersectionSets;
        }

        /// <summary>
        /// Получения объединения двух множеств
        /// </summary>
        /// <param name="firstSets">Первое множество</param>
        /// <param name="secondSets">Второе множество</param>
        /// <returns>Множество полученное в результате объединения</returns>
        private List<string> GetCombiningSets(List<string> firstSets, List<string> secondSets)
        {
            List<string> combiningSets = new List<string>();
            foreach (string set in firstSets)
            {
                combiningSets.Add(set);
            }
            foreach(string set2 in secondSets)
            {
                combiningSets.Add(set2);
            }
            combiningSets = combiningSets.Distinct().ToList();
            return combiningSets;
        }

        private void ShowPrimer(List<string> sets, char textSet)
        {
            StackPanel setsM = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
            SPPrimer.Children.Add(setsM);
            Label textSetsMOne = new Label()
            {
                Content = textSet + " = {"
            };
            setsM.Children.Add(textSetsMOne);
            for (int i = 0; i < sets.Count; i++)
            {
                ShowSets(sets, i, setsM, 35);
            }
            Label textSetsMTwo = new Label()
            {
                Content = "}"
            };
            setsM.Children.Add(textSetsMTwo);
        }

        private void ShowFigures(StackPanel setsM, Geometry geometry)
        {
            Path pathFigure = new Path()
            {
                StrokeThickness = Base.StrokeThickness,
                Stroke = Brushes.Black,
                Data = geometry,
                Fill = Brushes.White,
            };
            setsM.Children.Add(pathFigure);
        }

        private void ShowComma(StackPanel stackPanel)
        {
            Label label = new Label()
            {
                Content = ";",
            };
            stackPanel.Children.Add(label);
        }

        private void ShowSets(List<String> sets, int i, StackPanel stackPanel, int height)
        {
            Figure figure = new Figure(28, 0, 0);
            Geometry geometry = null;
            switch (sets[i])
            {
                case ("круг"):
                    geometry = figure.CreateCircle(10, height);
                    ShowFigures(stackPanel, geometry);
                    if (i != sets.Count - 1)
                    {
                        ShowComma(stackPanel);
                    }
                    break;
                case ("треугольник"):
                    geometry = figure.CreateTriangle(10, height);
                    ShowFigures(stackPanel, geometry);
                    if (i != sets.Count - 1)
                    {
                        ShowComma(stackPanel);
                    }
                    break;
                case ("квадрат"):
                    geometry = figure.CreateSquare(10, height);
                    ShowFigures(stackPanel, geometry);
                    if (i != sets.Count - 1)
                    {
                        ShowComma(stackPanel);
                    }
                    break;
                case ("ромб"):
                    geometry = figure.CreateRhomb(10, height);
                    ShowFigures(stackPanel, geometry);
                    if (i != sets.Count - 1)
                    {
                        ShowComma(stackPanel);
                    }
                    break;
                default:
                    if (i == sets.Count - 1)
                    {
                        geometry = figure.GetGeometryFromText(sets[i], 28, 10, 0);

                    }
                    else
                    {
                        geometry = figure.GetGeometryFromText(sets[i] + ";", 28, 10, 0);
                    }
                    Path path = new Path()
                    {
                        StrokeThickness = Base.StrokeThickness,
                        Data = geometry,
                        Fill = Brushes.Black,
                    };
                    stackPanel.Children.Add(path);
                    break;
            }
        }

        /// <summary>
        /// Создаёт множество для второго задания
        /// </summary>
        private void CreateSetsQuestionSecond()
        {
            EllipseGeneration ellipseGeneration = new EllipseGeneration();
            Ellipse ellipseOne = ellipseGeneration.getEllipse(250, 200, 400, 20); // Создание первого эллипса
            ellipseOne.Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18");
            CVMainPlaceQuestionSecond.Children.Add(ellipseOne);
            Ellipse ellipseTwo = ellipseGeneration.getEllipse(250, 200, 500, 20); // Создание второго эллипса
            ellipseTwo.Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18");
            CVMainPlaceQuestionSecond.Children.Add(ellipseTwo);
            Path combinedPath = ellipseGeneration.getUnification(ellipseOne, ellipseTwo, GeometryCombineMode.Intersect); // Создание пересечения
            combinedPath.Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18");
            CVMainPlaceQuestionSecond.Children.Add(combinedPath);
            Label firstPlenty = new Label()
            {
                Content = "M",
                Margin = new Thickness(400, 10, 0, 0),
            };
            CVMainPlaceQuestionSecond.Children.Add(firstPlenty);
            Label secondPlenty = new Label()
            {
                Content = "K",
                Margin = new Thickness(730, 10, 0, 0),
            };
            CVMainPlaceQuestionSecond.Children.Add(secondPlenty);
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            for (int i = 5; i < CVMainPlaceQuestionSecond.Children.Count; i++)
            {
                Path p = (Path)CVMainPlaceQuestionSecond.Children[i];
                p.Fill = Brushes.White;
                _pathToMoved = null;
                p.ReleaseMouseCapture();
            }
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Path path = (Path)sender;

            if (path.Uid != string.Empty)
            {
                path.Fill = Brushes.Gray;
                _pathToMoved = path;
                _oldMouseCoordinate = e.GetPosition(CVMainPlaceQuestionSecond);
                path.CaptureMouse(); // Захватывание мыши
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_pathToMoved != null)
            {
                if (_pathToMoved.Uid != "")
                {
                    int id = Convert.ToInt32(_pathToMoved.Uid);
                    SetOffsetFigure(id, e.GetPosition(CVMainPlaceQuestionSecond));
                    _pathToMoved.Data.Transform = new TranslateTransform(_pointsQuestionFirst[id].X, _pointsQuestionFirst[id].Y);
                }
            }
        }

        private void SetOffsetFigure(int id, Point actualCoordinate)
        {
            Point tempPoint = _pointsQuestionFirst[id];

            if (actualCoordinate.Y > _oldMouseCoordinate.Y)
            {
                tempPoint.Y++;
            }
            else if (actualCoordinate.Y < _oldMouseCoordinate.Y)
            {
                tempPoint.Y--;
            }

            if (actualCoordinate.X > _oldMouseCoordinate.X)
            {
                tempPoint.X++;
            }
            else if (actualCoordinate.X < _oldMouseCoordinate.X)
            {
                tempPoint.X--;
            }

            _pointsQuestionFirst[id] = tempPoint;

            _oldMouseCoordinate = actualCoordinate;
        }

        
        List<String> list = new List<string> { "a", "б", "в", "г", "д", "е", "ж", "з", "треугольник", "квадрат", "круг", "ромб"}; // Допустимые символы из которых могут состоять множества
        /// <summary>
        /// Рандомно генерирует множество
        /// </summary>
        /// <returns></returns>
        private List<String> getSets()
        {
            List<String> sets = new List<String>();
            int count = random.Next(4,8);
            List<String> listChoice = getCopy(list);
            int index = 0;
            for (int i = 0; i < count; i++)
            {
                index = random.Next(listChoice.Count);
                sets.Add(listChoice[index]);
                listChoice.RemoveAt(index);
            }
            return sets;
        }

        private void BtnCheckQuestionSecond_Click(object sender, RoutedEventArgs e)
        {
            int kolResult = 0; // Колличество верно отвеченных
            bool result = true; // Результат (наличие ошибок)
            Path placeIntersection = (Path)CVMainPlaceQuestionSecond.Children[2]; // Фигура пересечения
            for (int i = 5; i < CVMainPlaceQuestionSecond.Children.Count; i++)
            {
                Path path = (Path)CVMainPlaceQuestionSecond.Children[i];
                if (placeIntersection.Data.FillContainsWithDetail(path.Data) == IntersectionDetail.FullyContains)
                {
                    if(indexCorrectResult.IndexOf(Convert.ToInt32(path.Uid)) == -1)
                    {
                        result = false;
                    }
                    else
                    {
                        kolResult++;
                    }
                }
            }
            if(result && kolResult == indexCorrectResult.Count)
            {
                CorrectResult correctResult = new CorrectResult();
                correctResult.ShowDialog();
            }
            else
            {
                ResultIntersectionSetsWindow resultIntersectionSetsWindow = new ResultIntersectionSetsWindow(intersectionSets);
                resultIntersectionSetsWindow.ShowDialog();
            }

        }

        private List<String> getCopy(List<String> list)
        {
            List<String> newList = new List<string>();
            foreach (string str in list)
            {
                newList.Add(str);
            }
            return newList;
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

        /// <summary>
        /// Генерация задания 4 типа (Выбор ответа)
        /// </summary>
        private void NewFourTask()
        {
            Random random = new Random();
            correctResultFourTask.Clear();
            SPMainPlaceQuestionFour.Children.Clear();
            Grid grid = new Grid();
            ColumnDefinition oneColumn = new ColumnDefinition();
            ColumnDefinition twoColumn = new ColumnDefinition();
            grid.ColumnDefinitions.Add(oneColumn);
            grid.ColumnDefinitions.Add(twoColumn);
            SPMainPlaceQuestionFour.Children.Add(grid);
            List<char> listChar = new List<char> { 'A', 'B', 'C', 'D', 'M', 'K', 'T'};
            List<char> chars = new List<char>();
            for(int i = 0; i < 3; i++)
            {
                int j = random.Next(listChar.Count);
                chars.Add(listChar[j]);
                listChar.Remove(listChar[j]);    
            }
            List<string> movingProperty = new List<string>() { chars[1] + " ∩ " + chars[0], chars[1] + " ∩ " + chars[1], chars[0] + " ∩ " + chars[0], chars[0] + " ∩ " + chars[1]};
            correctResultFourTask.Add(chars[0] + " ∩ " + chars[1] + " = " + movingProperty[0]);
            StackPanel primerFirst = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            Label labelFirst = new Label()
            {
                Content = chars[0] + " ∩ " + chars[1] + " = "
            };
            primerFirst.Children.Add(labelFirst);
            ComboBox comboBoxFirst = new ComboBox()
            {
                Width = 100
            };
            for(int i = 0; i < 4; i++)
            {
                int j = random.Next(movingProperty.Count);
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = movingProperty[j];
                comboBoxFirst.Items.Add(comboBoxItem);
                movingProperty.Remove(movingProperty[j]);
            }
            primerFirst.Children.Add(comboBoxFirst);
            grid.Children.Add(primerFirst);
            Grid.SetColumn(primerFirst, 0);

            List<string> combinationProperty = new List<string>() { chars[0] + " ∩ (" + chars[1] + " ∩ " + chars[2] + ")", "(" + chars[2] + " ∩ " + chars[1] + " ∩ " + chars[0] + ")", chars[0] + " ∩ (2 * " + chars[1] + ")", chars[0] + " ∩ " + chars[1] + " ∩ " + chars[2] };
            correctResultFourTask.Add("(" + chars[0] + " ∩ " + chars[1] + ") ∩ " + chars[2] + " = " + combinationProperty[0]);
            StackPanel primerSecond = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            Label labelSecond = new Label()
            {
                Content = "(" + chars[0] + " ∩ " + chars[1] + ") ∩ " + chars[2] + " = "
            };
            primerSecond.Children.Add(labelSecond);
            ComboBox comboBoxSecond = new ComboBox()
            {
                Width = 160
            };
            for (int i = 0; i < 4; i++)
            {
                int j = random.Next(combinationProperty.Count);
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = combinationProperty[j];
                comboBoxSecond.Items.Add(comboBoxItem);
                combinationProperty.Remove(combinationProperty[j]);
            }
            primerSecond.Children.Add(comboBoxSecond);
            grid.Children.Add(primerSecond);
            Grid.SetColumn(primerSecond, 1);
        }

        private void BtnCheckQuestionFour_Click(object sender, RoutedEventArgs e)
        {
            List<int> errors = new List<int>();
            Grid grid = (Grid)SPMainPlaceQuestionFour.Children[0];
            for(int i = 0; i < grid.Children.Count; i++)
            {
                StackPanel stackPanel = (StackPanel)grid.Children[i];
                string text = "";
                for (int j = 0; j < stackPanel.Children.Count; j++)
                {
                    if (typeof(Label) == stackPanel.Children[j].GetType())
                    {
                        Label label = (Label)stackPanel.Children[j];
                        text += label.Content;
                    }
                    else if (typeof(ComboBox) == stackPanel.Children[j].GetType())
                    {
                        ComboBox comboBox = (ComboBox)stackPanel.Children[j];
                        text += comboBox.SelectionBoxItem;
                    }
                }
                if (correctResultFourTask[i] != text)
                {
                    errors.Add(i);
                }
            }
            if(errors.Count == 0)
            {
                CorrectResult correctResult = new CorrectResult();
                correctResult.ShowDialog();
            }
            else
            {
                ResultIntersectionSetsWindow resultIntersectionSetsWindow = new ResultIntersectionSetsWindow(errors, correctResultFourTask);
                resultIntersectionSetsWindow.ShowDialog();
            }
        }
    }
}