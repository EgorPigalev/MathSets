using MathSets.windows;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MathSets
{
    /// <summary>
    /// Логика взаимодействия для IntersectionSetsSolvingTasksPage.xaml
    /// </summary>
    public partial class IntersectionSetsSolvingTasksPage : Page
    {
        private Random _random = new Random();
        private List<Point> _pointsQuestionFirst = new List<Point>(); // Точки смещения для второго задания
        private Path _pathToMoved; // Фигура для перемещения
        private Point _oldMouseCoordinate; // Предыдущие координаты курсора (для перемещения фигуры)
        private List<string> _correctResultFourTask = new List<string>();

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
            try
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
                    Label subtaskText = new Label()
                    {
                        Content = (Char)(65 + i) + ")",
                    };
                    canvas.Children.Add(subtaskText);
                    Ellipse ellipseOne = ellipseGeneration.GetEllipse(_random.Next(50, 200), _random.Next(50, 200), _random.Next(40, 100), _random.Next(0, 50)); // Создание первого эллипса
                    ellipseOne.MouseDown += Ellipse_MouseDown;
                    canvas.Children.Add(ellipseOne);
                    Ellipse ellipseTwo = ellipseGeneration.GetEllipse(_random.Next(50, 200), _random.Next(50, 200), _random.Next(40, 100), _random.Next(0, 50)); // Создание второго эллипса
                    ellipseTwo.MouseDown += Ellipse_MouseDown;
                    canvas.Children.Add(ellipseTwo);
                    Path combinedPath = ellipseGeneration.GetUnification(ellipseOne, ellipseTwo, GeometryCombineMode.Intersect); // Создание пересечения
                    combinedPath.MouseDown += Ellipse_MouseDown;
                    canvas.Children.Add(combinedPath);
                }
            }
            catch
            {
                MessageBox.Show("При генерации задания 1 типа возникла ошибка", "Системное сообщение");
            }
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
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
            catch
            {
                MessageBox.Show("При обработке события возникла ошибка", "Системное сообщение");
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
            try
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
                            errors.Add(ellipseGeneration.GetDateEllipse(i, ellipseOne, ellipseTwo));
                        }
                    }
                    else if (ellipseOne.Fill != Brushes.White || ellipseTwo.Fill != Brushes.White || path.Fill != Brushes.Yellow) // Если выделено не только пересечение
                    {
                        errors.Add(ellipseGeneration.GetDateEllipse(i, ellipseOne, ellipseTwo));
                    }
                }
                if (errors.Count > 0) // Если есть ошибки, то открывается окно с правильным решением
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
            catch
            {
                MessageBox.Show("При проверки результата первого задания возникла ошибка", "Системное сообщение");
            }
        }

        private void MenuGuide_Click(object sender, RoutedEventArgs e)
        {
            MenuItem childMenuItem = (MenuItem)sender;
            MenuItem menuItem = (MenuItem)childMenuItem.Parent;
            switch (Convert.ToInt32(menuItem.Uid))
            {
                case 1:
                    new GuideWindow(5, 1).ShowDialog();
                    break;
                case 2:
                    new GuideWindow(5, 2).ShowDialog();
                    break;
                case 3:
                    new GuideWindow(5, 3).ShowDialog();
                    break;
                default:
                    new GuideWindow(5, 4).ShowDialog();
                    break;
            }
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

        private List<int> _indexCorrectResult = new List<int>(); // Индексы фигур для правильного результата
        private List<string> _intersectionSets = new List<string>(); // Фигуры, которые представляют собой пересечение множеств

        /// <summary>
        /// Генерация задания 2 типа (Нахождение пересечения двух множеств)
        /// </summary>
        private void NewTwoTask()
        {
            try
            {
                CVMainPlaceQuestionSecond.Children.Clear();
                CreateSetsQuestionSecond();
                List<string> firstSets = new List<string>(); // Первое множество
                List<string> secondSets = new List<string>(); // Второе множество
                bool b = true;
                while (b)
                {
                    firstSets = GetSets(); // Первое множество
                    secondSets = GetSets(); // Второе множество
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
                _intersectionSets = GetIntersectionSets(firstSets, secondSets); // Пересечение множеств
                List<string> combiningSets = GetCombiningSets(firstSets, secondSets); // Объединение множеств (для вывода всех фигур без повторений)
                _indexCorrectResult.Clear();
                foreach (string set in _intersectionSets)
                {
                    _indexCorrectResult.Add(combiningSets.IndexOf(set));
                }
                int column = 0; // Столбец
                int row = 1;
                for (int i = 0; i < combiningSets.Count; i++)
                {
                    Figure figure = new Figure(28, 0, 0);
                    Geometry geometry = null;
                    if (i == 9)
                    {
                        column = 0;
                        row = 2;
                    }
                    switch (combiningSets[i])
                    {
                        case ("круг"):
                            geometry = figure.CreateCircle(5 + 40 * column, 25 + (70 * row));
                            break;
                        case ("треугольник"):
                            geometry = figure.CreateTriangle(5 + 40 * column, 25 + (70 * row));
                            break;
                        case ("квадрат"):
                            geometry = figure.CreateSquare(5 + 40 * column, 25 + (70 * row));
                            break;
                        case ("ромб"):
                            geometry = figure.CreateRhomb(5 + 40 * column, 25 + (70 * row));
                            break;
                        default:
                            geometry = figure.GetGeometryFromText(combiningSets[i], 50, 5 + 40 * column, -30 + (70 * row));
                            break;
                    }
                    column++;
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
            catch
            {
                MessageBox.Show("При генерации задания 2 типа возникла ошибка", "Системное сообщение");
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
            try
            {
                List<string> _intersectionSets = new List<string>();
                foreach (string set in firstSets)
                {
                    foreach (string set2 in secondSets)
                    {
                        if (set.Equals(set2))
                        {
                            _intersectionSets.Add(set2);
                        }
                    }
                }
                return _intersectionSets;
            }
            catch
            {
                MessageBox.Show("При определение пересечения возникла ошибка", "Системное сообщение");
                return null;
            }
        }

        /// <summary>
        /// Получения объединения двух множеств
        /// </summary>
        /// <param name="firstSets">Первое множество</param>
        /// <param name="secondSets">Второе множество</param>
        /// <returns>Множество полученное в результате объединения</returns>
        private List<string> GetCombiningSets(List<string> firstSets, List<string> secondSets)
        {
            try
            {
                List<string> combiningSets = new List<string>();
                foreach (string set in firstSets)
                {
                    combiningSets.Add(set);
                }
                foreach (string set2 in secondSets)
                {
                    combiningSets.Add(set2);
                }
                combiningSets = combiningSets.Distinct().ToList();
                return combiningSets;
            }
            catch
            {
                MessageBox.Show("При определение объединения возникла ошибка", "Системное сообщение");
                return null;
            }
        }

        /// <summary>
        /// Вывод примера
        /// </summary>
        /// <param name="sets">Множество</param>
        /// <param name="textSet">Название множества</param>
        private void ShowPrimer(List<string> sets, char textSet)
        {
            try
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
            catch
            {
                MessageBox.Show("При выводе множества возникла ошибка", "Системное сообщение");
            }
        }

        /// <summary>
        /// Добавление фигуры
        /// </summary>
        /// <param name="setsM">Место куда добавить фигуру</param>
        /// <param name="geometry">Геометрия фигуры</param>
        private void ShowFigures(StackPanel setsM, Geometry geometry)
        {
            try
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
            catch
            {
                MessageBox.Show("При добавление фигуры возникла ошибка", "Системное сообщение");
            }
        }

        /// <summary>
        /// Добавления точки с запятой
        /// </summary>
        /// <param name="stackPanel">Место куда добавить</param>
        private void ShowComma(StackPanel stackPanel)
        {
            try
            {
                Label label = new Label()
                {
                    Content = ";",
                };
                stackPanel.Children.Add(label);
            }
            catch
            {
                MessageBox.Show("При генерации множества возникла ошибка", "Системное сообщение");
            }
        }

        /// <summary>
        /// Вывод фигуры
        /// </summary>
        /// <param name="sets">Множество</param>
        /// <param name="i">Номер эллемента в множестве</param>
        /// <param name="stackPanel">Место куда добавлять фигуру</param>
        /// <param name="height">Размер буквы</param>
        private void ShowSets(List<String> sets, int i, StackPanel stackPanel, int height)
        {
            try
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
            catch
            {
                MessageBox.Show("При добавление фигуры возникла ошибка", "Системное сообщение");
            }
        }

        /// <summary>
        /// Создаёт множество для второго задания
        /// </summary>
        private void CreateSetsQuestionSecond()
        {
            try
            {
                EllipseGeneration ellipseGeneration = new EllipseGeneration();
                Ellipse ellipseOne = ellipseGeneration.GetEllipse(250, 200, 400, 20); // Создание первого эллипса
                ellipseOne.Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18");
                CVMainPlaceQuestionSecond.Children.Add(ellipseOne);
                Ellipse ellipseTwo = ellipseGeneration.GetEllipse(250, 200, 500, 20); // Создание второго эллипса
                ellipseTwo.Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18");
                CVMainPlaceQuestionSecond.Children.Add(ellipseTwo);
                Path combinedPath = ellipseGeneration.GetUnification(ellipseOne, ellipseTwo, GeometryCombineMode.Intersect); // Создание пересечения
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
            catch
            {
                MessageBox.Show("При формирование множества для второго задания возникла ошибка", "Системное сообщение");
            }
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

        /// <summary>
        /// Устоновить новые координаты смещения фигуры
        /// </summary>
        /// <param name="id">Номер в списке координат фигур</param>
        /// <param name="actualCoordinate">Актуальные координаты курсора</param>
        private void SetOffsetFigure(int id, Point actualCoordinate)
        {
            try
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
            catch
            {
                MessageBox.Show("При установке новых координат смещения фигуры возникла ошибка", "Системное сообщение");
            }
        }

        
        private List<string> _list = new List<string> { "a", "б", "в", "г", "д", "е", "ж", "з", "треугольник", "квадрат", "круг", "ромб"}; // Допустимые символы из которых могут состоять множества
        /// <summary>
        /// Рандомно генерирует множество
        /// </summary>
        /// <returns></returns>
        private List<string> GetSets()
        {
            try
            {
                List<string> sets = new List<string>();
                int count = _random.Next(4, 8);
                List<string> listChoice = GetCopy(_list);
                int index;
                for (int i = 0; i < count; i++)
                {
                    index = _random.Next(listChoice.Count);
                    sets.Add(listChoice[index]);
                    listChoice.RemoveAt(index);
                }
                return sets;
            }
            catch
            {
                MessageBox.Show("При генерации множества возникла ошибка", "Системное сообщение");
                return null;
            }
        }

        private void BtnCheckQuestionSecond_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int kolResult = 0; // Колличество верно отвеченных
                bool result = true; // Результат (наличие ошибок)
                Path placeIntersection = (Path)CVMainPlaceQuestionSecond.Children[2]; // Фигура пересечения
                for (int i = 5; i < CVMainPlaceQuestionSecond.Children.Count; i++)
                {
                    Path path = (Path)CVMainPlaceQuestionSecond.Children[i];
                    if (placeIntersection.Data.FillContainsWithDetail(path.Data) == IntersectionDetail.FullyContains)
                    {
                        if (_indexCorrectResult.IndexOf(Convert.ToInt32(path.Uid)) == -1)
                        {
                            result = false;
                        }
                        else
                        {
                            kolResult++;
                        }
                    }
                }
                if (result && kolResult == _indexCorrectResult.Count)
                {
                    CorrectResult correctResult = new CorrectResult();
                    correctResult.ShowDialog();
                }
                else
                {
                    ResultIntersectionSetsWindow resultIntersectionSetsWindow = new ResultIntersectionSetsWindow(_intersectionSets);
                    resultIntersectionSetsWindow.ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show("При проверки результата во втором задание возникла ошибка", "Системное сообщение");
            }
        }

        /// <summary>
        /// Копирование списка
        /// </summary>
        /// <param name="list">Список для копирования</param>
        /// <returns>Скопированный список</returns>
        private List<string> GetCopy(List<string> list)
        {
            List<string> newList = new List<string>();
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
            try
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
                    Ellipse ellipseOne = ellipseGeneration.GetEllipse(_random.Next(100, 200), _random.Next(100, 125), _random.Next(20, 40), _random.Next(10, 20)); // Создание первого эллипса
                    ellipseOne.MouseDown += Ellipse_MouseDown;
                    canvas.Children.Add(ellipseOne);
                    Ellipse ellipseTwo = ellipseGeneration.GetEllipse(_random.Next(100, 200), _random.Next(100, 125), _random.Next(80, 100), _random.Next(0, 10)); // Создание второго эллипса
                    ellipseTwo.MouseDown += Ellipse_MouseDown;
                    canvas.Children.Add(ellipseTwo);
                    Ellipse ellipseThree = ellipseGeneration.GetEllipse(_random.Next(100, 200), _random.Next(100, 125), _random.Next(40, 60), _random.Next(40, 50)); // Создание третьего эллипса
                    ellipseThree.MouseDown += Ellipse_MouseDown;
                    canvas.Children.Add(ellipseThree);
                    Path combinedPathOne = ellipseGeneration.GetUnification(ellipseOne, ellipseTwo, GeometryCombineMode.Intersect); // Создание первого пересечения
                    combinedPathOne.MouseDown += Ellipse_MouseDown;
                    canvas.Children.Add(combinedPathOne);
                    Path combinedPathTwo = ellipseGeneration.GetUnification(ellipseOne, ellipseThree, GeometryCombineMode.Intersect); // Создание второго пересечения
                    combinedPathTwo.MouseDown += Ellipse_MouseDown;
                    canvas.Children.Add(combinedPathTwo);
                    Path combinedPathThree = ellipseGeneration.GetUnification(ellipseTwo, ellipseThree, GeometryCombineMode.Intersect); // Создание третьего пересечения
                    combinedPathThree.MouseDown += Ellipse_MouseDown;
                    canvas.Children.Add(combinedPathThree);
                    Path combinedPathFour = ellipseGeneration.GetUnificationThree(ellipseOne, ellipseTwo, ellipseThree, GeometryCombineMode.Intersect); // Создание общего пересечения
                    combinedPathFour.MouseDown += Ellipse_MouseDown;
                    canvas.Children.Add(combinedPathFour);
                }
            }
            catch
            {
                MessageBox.Show("При генерации 3 задания возникла ошибка", "Системное сообщение");
            }
        }

        private void BtnCheckQuestionThree_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EllipseGeneration ellipseGeneration = new EllipseGeneration();
                List<int[]> errors = new List<int[]>(); // Массив ошибок
                for (int i = 0; i < WPMainPlaceQuestionThree.Children.Count; i++) // Проверка каждого пункта
                {
                    Canvas canvas = (Canvas)WPMainPlaceQuestionThree.Children[i];
                    Ellipse ellipseOne = (Ellipse)canvas.Children[1];
                    Ellipse ellipseTwo = (Ellipse)canvas.Children[2];
                    Ellipse ellipseThree = (Ellipse)canvas.Children[3];
                    Path pathOne = (Path)canvas.Children[4];
                    Path pathTwo = (Path)canvas.Children[5];
                    Path pathThree = (Path)canvas.Children[6];
                    Path pathFour = (Path)canvas.Children[7];
                    if (pathFour.ActualWidth == 0) // Если объединение не существует, пересечение равно пустому множеству
                    {
                        if (ellipseOne.Fill != Brushes.White || ellipseTwo.Fill != Brushes.White || ellipseThree.Fill != Brushes.White || pathOne.Fill != Brushes.White || pathTwo.Fill != Brushes.White || pathThree.Fill != Brushes.White) // Если выделено лишнее
                        {
                            errors.Add(ellipseGeneration.GetDateEllipseThree(i, ellipseOne, ellipseTwo, ellipseThree));
                        }
                    }
                    else if (ellipseOne.Fill != Brushes.White || ellipseTwo.Fill != Brushes.White || ellipseThree.Fill != Brushes.White || pathOne.Fill != Brushes.White || pathTwo.Fill != Brushes.White || pathThree.Fill != Brushes.White || pathFour.Fill != Brushes.Yellow) // Если выделено не только пересечение
                    {
                        errors.Add(ellipseGeneration.GetDateEllipseThree(i, ellipseOne, ellipseTwo, ellipseThree));
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
            catch
            {
                MessageBox.Show("При проверки результата в 3 задание возникла ошибка", "Системное сообщение");
            }
        }

        /// <summary>
        /// Генерация задания 4 типа (Выбор ответа)
        /// </summary>
        private void NewFourTask()
        {
            try
            {
                _correctResultFourTask.Clear();
                SPMainPlaceQuestionFour.Children.Clear();
                Grid grid = new Grid();
                ColumnDefinition oneColumn = new ColumnDefinition();
                ColumnDefinition twoColumn = new ColumnDefinition();
                grid.ColumnDefinitions.Add(oneColumn);
                grid.ColumnDefinitions.Add(twoColumn);
                SPMainPlaceQuestionFour.Children.Add(grid);
                List<char> listChar = new List<char> { 'A', 'B', 'C', 'D', 'M', 'K', 'T' };
                List<char> chars = new List<char>();
                for (int i = 0; i < 3; i++)
                {
                    int row = _random.Next(listChar.Count);
                    chars.Add(listChar[row]);
                    listChar.Remove(listChar[row]);
                }
                List<string> movingProperty = new List<string>() { chars[1] + " ∩ " + chars[0], chars[1] + " ∩ " + chars[1], chars[0] + " ∩ " + chars[0], chars[0] + " ∩ " + chars[1] };
                _correctResultFourTask.Add(chars[0] + " ∩ " + chars[1] + " = " + movingProperty[0]);
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
                for (int i = 0; i < 4; i++)
                {
                    int row = _random.Next(movingProperty.Count);
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = movingProperty[row];
                    comboBoxFirst.Items.Add(comboBoxItem);
                    movingProperty.Remove(movingProperty[row]);
                }
                primerFirst.Children.Add(comboBoxFirst);
                grid.Children.Add(primerFirst);
                Grid.SetColumn(primerFirst, 0);

                List<string> combinationProperty = new List<string>() { chars[0] + " ∩ (" + chars[1] + " ∩ " + chars[2] + ")", "(" + chars[2] + " ∩ " + chars[1] + " ∩ " + chars[0] + ")", chars[0] + " ∩ (2 * " + chars[1] + ")", chars[0] + " ∩ " + chars[1] + " ∩ " + chars[2] };
                _correctResultFourTask.Add("(" + chars[0] + " ∩ " + chars[1] + ") ∩ " + chars[2] + " = " + combinationProperty[0]);
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
                    int row = _random.Next(combinationProperty.Count);
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = combinationProperty[row];
                    comboBoxSecond.Items.Add(comboBoxItem);
                    combinationProperty.Remove(combinationProperty[row]);
                }
                primerSecond.Children.Add(comboBoxSecond);
                grid.Children.Add(primerSecond);
                Grid.SetColumn(primerSecond, 1);
            }
            catch
            {
                MessageBox.Show("При генерации 4 задания возникла ошибка", "Системное сообщение");
            }
        }

        private void BtnCheckQuestionFour_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<int> errors = new List<int>();
                Grid grid = (Grid)SPMainPlaceQuestionFour.Children[0];
                for (int i = 0; i < grid.Children.Count; i++)
                {
                    StackPanel stackPanel = (StackPanel)grid.Children[i];
                    string text = "";
                    for (int row = 0; row < stackPanel.Children.Count; row++)
                    {
                        if (typeof(Label) == stackPanel.Children[row].GetType())
                        {
                            Label label = (Label)stackPanel.Children[row];
                            text += label.Content;
                        }
                        else if (typeof(ComboBox) == stackPanel.Children[row].GetType())
                        {
                            ComboBox comboBox = (ComboBox)stackPanel.Children[row];
                            text += comboBox.SelectionBoxItem;
                        }
                    }
                    if (_correctResultFourTask[i] != text)
                    {
                        errors.Add(i);
                    }
                }
                if (errors.Count == 0)
                {
                    CorrectResult correctResult = new CorrectResult();
                    correctResult.ShowDialog();
                }
                else
                {
                    ResultIntersectionSetsWindow resultIntersectionSetsWindow = new ResultIntersectionSetsWindow(errors, _correctResultFourTask);
                    resultIntersectionSetsWindow.ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show("При проверки результата в 4 задание возникла ошибка", "Системное сообщение");
            }
        }
    }
}