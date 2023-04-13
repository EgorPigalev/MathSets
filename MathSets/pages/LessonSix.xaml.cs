using MathSets.windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MathSets.pages
{
    /// <summary>
    /// Логика взаимодействия для LessonSix.xaml
    /// </summary>
    public partial class LessonSix : Page
    {
        private Random _random = new Random();

        // Поля для первого задания.
        private List<Button> _buttonsTaskFirst;
        private List<Geometry> _figuresTaskFirst;

        // Поля для второго задания.
        private int _sizeFiguresTaskSecond = 50; // Размер фигур.
        private List<int> _indexesAnswersSetA = new List<int>(); // Индексы верных ответов (верных фигур) для множества A.
        private List<int> _indexesAnswersSetB = new List<int>(); // Индексы верных ответов (верных фигур) для множества B.
        private List<Geometry> _figuresTaskSecond; // Фигуры.
        private List<Geometry> _setsTaskSecond; // Множества.
        private Path _pathToMoved; // Фигура для перемещения.
        private Point _oldMouseCoordinate; // Предыдущие координаты курсора (для перемещения фигуры).
        private List<Point> _pointsToMovedTaskFirst = new List<Point>(); // Точки для перемещения фигур.

        public LessonSix()
        {
            InitializeComponent();

            ShowTaskFirst();
            ShowTaskSecond();
        }

        private void ShowTaskFirst()
        {
            GridTaskFirst.Children.Clear();
            GridTaskFirst.ColumnDefinitions.Clear();
            GridTaskFirst.RowDefinitions.Clear();

            int countGridDefinitions = 2;
            int minSize = 50;
            _figuresTaskFirst = CreateFiguresTaskFirst(countGridDefinitions, minSize);
            Figure.ShowFigures(_figuresTaskFirst, GridTaskFirst);

            SetGridDefinitionsTaskFirst(countGridDefinitions);
        }

        private void ShowTaskSecond()
        {
            CnvTaskSecond.Children.Clear();
            SpFiguresTaskSecondSetA.Children.Clear();
            SpFiguresTaskSecondSetB.Children.Clear();

            int countRigthAnswersSetA = _random.Next(3, 6); // Количество элементов в изначально заданном множестве A, которое нужно отобразить (множестве по заданию).
            int countRigthAnswersSetB = _random.Next(1, 3); // Количество элементов в изначально заданном множестве B, которое нужно отобразить (множестве по заданию).

            _setsTaskSecond = CreateSetsTaskSecond(new Point(CnvTaskSecond.Width / 2, CnvTaskSecond.Height), CnvTaskSecond);


            InitializeSetsTaskSecond(out List<Geometry> figuresAnswersSetA, out List<Geometry> figuresAnswersSetB, countRigthAnswersSetA, countRigthAnswersSetB);

            Figure.ShowFigures(_setsTaskSecond, CnvTaskSecond);
            Figure.ShowFigures(figuresAnswersSetA, SpFiguresTaskSecondSetA);
            Figure.ShowFigures(figuresAnswersSetB, SpFiguresTaskSecondSetB);
            _figuresTaskSecond = CreateFiguresTaskSecond();
            Figure.ShowFigures(_figuresTaskSecond, CnvTaskSecond);

            SetHandlersTaskSecond();
        }

        /// <summary>
        /// Устанавливает события для panel, необходимые для перемещения фигур, для первого задания
        /// </summary>
        /// <param name="panel">Контейнер</param>
        private void SetHandlersTaskSecond()
        {
            SpTaskSecond.MouseUp += OnMouseUp;

            foreach (Path item in CnvTaskSecond.Children)
            {
                if (_figuresTaskSecond.Contains(item.Data))
                {
                    item.MouseMove += OnMouseMoveTaskFirst;
                    item.MouseDown += OnMouseDown;
                }
            }
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (_pathToMoved != null)
            {
                _pathToMoved.Fill = Brushes.White;
                _pathToMoved.ReleaseMouseCapture();
                _pathToMoved = null;
            }
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Path path = (Path)sender;

            if (path.Uid != string.Empty)
            {
                path.Fill = Base.ColorDraggableElement;
                _pathToMoved = path;
                _oldMouseCoordinate = e.GetPosition(CnvTaskSecond);
                _pathToMoved.CaptureMouse();
            }
        }

        private void OnMouseMoveTaskFirst(object sender, MouseEventArgs e)
        {
            if (_pathToMoved != null)
            {
                int id = Convert.ToInt32(_pathToMoved.Uid);

                _pointsToMovedTaskFirst[id] = GetOffsetFigure(_pointsToMovedTaskFirst[id], e.GetPosition(CnvTaskSecond));

                _pathToMoved.Data.Transform = new TranslateTransform(_pointsToMovedTaskFirst[id].X, _pointsToMovedTaskFirst[id].Y);
            }
        }

        /// <summary>
        /// Вычисляет новые координаты для перемещения фигуры
        /// </summary>
        /// <param name="point"> точка для изменения</param>
        /// <param name="actualCoordinate">актуальные координаты курсора</param>
        /// <returns></returns>
        private Point GetOffsetFigure(Point point, Point actualCoordinate)
        {
            if (actualCoordinate.Y > _oldMouseCoordinate.Y)
            {
                point.Y++;
            }
            else if (actualCoordinate.Y < _oldMouseCoordinate.Y)
            {
                point.Y--;
            }

            if (actualCoordinate.X > _oldMouseCoordinate.X)
            {
                point.X++;
            }
            else if (actualCoordinate.X < _oldMouseCoordinate.X)
            {
                point.X--;
            }

            _oldMouseCoordinate = actualCoordinate;

            return point;
        }

        /// <summary>
        /// Инициализирует множества-условия для второго задания.
        /// </summary>
        /// <param name="setFirst">первое множество</param>
        /// <param name="setSecond">второе множество</param>
        /// <param name="countFirst">количество элементов первого множества</param>
        /// <param name="countSecond">количество элементов второго множества</param>
        private void InitializeSetsTaskSecond(out List<Geometry> setFirst, out List<Geometry> setSecond, int countFirst, int countSecond)
        {
            while (true)
            {
                bool isInvalidSets = false; // Проверка наличия всех элементов setSecond в setFirst.

                setFirst = CreateAnswersTaskSecond(countFirst, _indexesAnswersSetA, SpFiguresTaskSecondSetA);
                setSecond = CreateAnswersTaskSecond(countSecond, _indexesAnswersSetB, SpFiguresTaskSecondSetB);

                foreach (int item in _indexesAnswersSetB)
                {
                    if (!_indexesAnswersSetA.Contains(item))
                    {
                        isInvalidSets = true;
                    }
                }

                if (!isInvalidSets)
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Генерирует фигуры-ответы для второго задания
        /// </summary>
        /// <returns>Список фигур</returns>
        private List<Geometry> CreateAnswersTaskSecond(int count, List<int> answers, Panel panel)
        {
            int sizeFigures = (int)TbTaskFirst.FontSize;
            Figure figures = new Figure(sizeFigures, (sizeFigures + 2) * 2, panel.Width);
            List<CreateFiguresDelegate> createFiguresMethods = figures.GetAllCreateFiguresMethods();
            List<int> tempIndexesFigures = Figure.ShuffleMethods(createFiguresMethods);

            answers.Clear();
            for (int i = 0; i < count; i++)
            {
                answers.Add(tempIndexesFigures[i]);
            }

            List<Geometry> listFigures = new List<Geometry>();
            int x = 10;

            for (int i = 0; i < count; i++)
            {
                listFigures.Add(createFiguresMethods[i](x, true));
            }

            panel.Width = listFigures.Count * sizeFigures + (listFigures.Count + 1) * x;

            return listFigures;
        }

        /// <summary>
        /// Генерирует фигуры для второго задания
        /// </summary>
        /// <returns>Коллекция фигур</returns>
        private List<Geometry> CreateFiguresTaskSecond()
        {
            Figure figure = new Figure(_sizeFiguresTaskSecond, CnvTaskSecond.Height, CnvTaskSecond.Width / 2);
            List<CreateFiguresDelegate> createFiguresMethods = figure.GetAllCreateFiguresMethods();
            List<int> indexesFigures = Figure.ShuffleMethods(createFiguresMethods);

            List<Geometry> figures = new List<Geometry>();
            int offset = figure.GetOffset(createFiguresMethods.Count);
            int xStart = Base.StrokeThickness;

            for (int i = 0; i < createFiguresMethods.Count; i++)
            {
                if (i == createFiguresMethods.Count - 1) // Размещаем последнюю фигуру в нижней части контейнера.
                {
                    figures.Add(createFiguresMethods[i](xStart, false));
                    break;
                }

                if (i % 2 == 0)
                {
                    figures.Add(createFiguresMethods[i](xStart, true)); // Положение фигуры по вертикали сверху.
                }
                else
                {
                    figures.Add(createFiguresMethods[i](xStart, false)); // Положение фигуры по вертикали снизу.
                    xStart += offset;
                }
            }

            _pointsToMovedTaskFirst.Clear();
            for (int i = 0; i < figures.Count; i++)
            {
                _pointsToMovedTaskFirst.Add(new Point(0, 0));
            }

            LessonFourAndFive.SortForDefaultPosition(figures, indexesFigures);

            return figures;
        }

        /// <summary>
        /// Создаёт множество с подмножеством
        /// </summary>
        /// <param name="maxSize">максимальные размеры главного множества</param>
        /// <param name="panel">контейнер</param>
        /// <returns>Список множеств</returns>
        private List<Geometry> CreateSetsTaskSecond(Point maxSize, Panel panel)
        {
            Point maxSizeSecondEllipse = new Point(CnvTaskSecond.Width / 2 * 0.7, CnvTaskSecond.Height * 0.7);
            Point sizeContainer = new Point(maxSize.X + 1, maxSize.Y + 1);
            List<Geometry> sets = new List<Geometry>();
            List<Geometry> namesOfSets = new List<Geometry>();

            while (true)
            {
                sets.Add(CreateEllipse(sizeContainer, maxSize, (int)CnvTaskSecond.Height - 1));

                sets.Add(CreateEllipse(sizeContainer, maxSizeSecondEllipse, Convert.ToInt32(_sizeFiguresTaskSecond * 2.5)));


                if (sets[0].FillContainsWithDetail(sets[1]) == IntersectionDetail.FullyContains)
                {
                    for (int i = 0; i < sets.Count; i++)
                    {
                        EllipseGeometry g = (EllipseGeometry)sets[i];

                        Point center = g.Center;
                        center.X += panel.Width / 2; // Смещение множества в правую часть контейнера.
                        g.Center = center;
                    }

                    if (!CheckIntersectionsNamesOfSets(sets, panel))
                    {
                        break;
                    }
                }

                sets.Clear();
            }

            return sets;
        }

        /// <summary>
        /// Создаёт названия множеств и проверяет их пересечения
        /// </summary>
        /// <param name="sets">список множеств</param>
        /// <param name="panel">контейнер</param>
        /// <returns>true, если пересечения найдены, в противном случае - false</returns>
        private bool CheckIntersectionsNamesOfSets(List<Geometry> sets, Panel panel)
        {
            List<Geometry> list = new List<Geometry>();

            for (int i = 0; i < sets.Count; i++)
            {
                EllipseGeometry g = (EllipseGeometry)sets[i];

                list.Add(new Figure(60, 0, 0).GetGeometryFromText(((char)(65 + i)).ToString(), Convert.ToInt32(g.Center.X - g.RadiusX - 40), Convert.ToInt32(g.Center.Y - g.RadiusY)));
            }

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i].FillContainsWithDetail(list[j]) != IntersectionDetail.Empty)
                    {
                        return true;
                    }
                }
            }

            Figure.ShowFigures(list, panel, Brushes.White, Brushes.Black);

            foreach (Path item in panel.Children)
            {
                Panel.SetZIndex(item, 100);
            }

            return false;
        }

        /// <summary>
        /// Создаёт фигуры для первого задания
        /// </summary>
        /// <param name="countDefinitions">количество строк и столбцов</param>
        /// <param name="minSize">минимальный размер фигур</param>
        /// <returns>Список фигур</returns>
        private List<Geometry> CreateFiguresTaskFirst(int countDefinitions, int minSize)
        {
            List<Geometry> figures = new List<Geometry>();

            while (true)
            {
                figures.Clear();

                Point sizeContainer = new Point(GridTaskFirst.Width / countDefinitions, GridTaskFirst.Height / countDefinitions - 60); // -60, чтобы кнопки снизу уместились.
                Point maxSize = new Point(sizeContainer.X / 2, sizeContainer.Y / 2);

                for (int i = 0; i < countDefinitions * 2; i++)
                {
                    figures.Add(CreateEllipse(sizeContainer, sizeContainer, minSize * 2));
                    figures.Add(CreateEllipse(sizeContainer, maxSize, minSize));
                }

                if (CheckContains(figures))
                {
                    break;
                }
            }

            return figures;
        }

        /// <summary>
        /// Создаёт эллипс
        /// </summary>
        /// <param name="sizeContainer">размер контейнера</param>
        /// <param name="maxSize">максимальные размеры</param>
        /// <param name="minSize">минимальный размер</param>
        /// <returns>Эллипс</returns>
        private Geometry CreateEllipse(Point sizeContainer, Point maxSize, int minSize)
        {
            int centerX = _random.Next(minSize / 2, (int)sizeContainer.X - minSize / 2);
            int centerY = _random.Next(minSize / 2, (int)sizeContainer.Y - minSize / 2);

            while (true)
            {
                EllipseGeometry g = new EllipseGeometry
                (
                    new Point
                    (
                        centerX,
                        centerY
                    ),
                    _random.Next(minSize, (int)maxSize.X) / 2 - Base.StrokeThickness * 4,
                    _random.Next(minSize, (int)maxSize.Y) / 2 - Base.StrokeThickness * 4
                );

                if (g.Center.X >= g.RadiusX && sizeContainer.X - g.Center.X >= g.RadiusX)
                {
                    if (g.Center.Y >= g.RadiusY && sizeContainer.Y - g.Center.Y >= g.RadiusY)
                    {
                        return g;
                    }
                }
            }
        }

        /// <summary>
        /// Проверяет наличие подмножеств
        /// </summary>
        /// <param name="figures">список фигур</param>
        /// <returns>True, если половина или более множеств содержат подмножества и есть хотя бы одно множество без подмножества. В противном случае - false</returns>
        private bool CheckContains(List<Geometry> figures)
        {
            int countSets = figures.Count / 2;
            int countRightSets = 0;

            for (int i = 0; i < figures.Count; i += 2)
            {
                if (figures[i].FillContainsWithDetail(figures[i + 1]) == IntersectionDetail.Intersects)
                {
                    return false;
                }

                if (figures[i].FillContainsWithDetail(figures[i + 1]) == IntersectionDetail.FullyContains)
                {
                    countRightSets++;
                }
            }

            if (countRightSets >= countSets / 2 && countSets - countRightSets >= 1)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Устанавливает нужные Grid.ColumnDefinitions и Grid.RowDefinitions элементам для первого задания
        /// </summary>
        /// <param name="countDefinitions">количество строк и столбцов</param>
        private void SetGridDefinitionsTaskFirst(int countDefinitions)
        {
            for (int i = 0; i < countDefinitions; i++)
            {
                GridTaskFirst.ColumnDefinitions.Add(new ColumnDefinition());
                GridTaskFirst.RowDefinitions.Add(new RowDefinition());
            }

            Grid.SetColumn(GridTaskFirst.Children[2], 1);
            Grid.SetColumn(GridTaskFirst.Children[3], 1);
            Grid.SetColumn(GridTaskFirst.Children[6], 1);
            Grid.SetColumn(GridTaskFirst.Children[7], 1);
            Grid.SetRow(GridTaskFirst.Children[4], 1);
            Grid.SetRow(GridTaskFirst.Children[5], 1);
            Grid.SetRow(GridTaskFirst.Children[6], 1);
            Grid.SetRow(GridTaskFirst.Children[7], 1);

            List<Border> borders = CreateBordersTaskFirst();
            foreach (Border item in borders)
            {
                GridTaskFirst.Children.Add(item);
            }

            Grid.SetColumn(borders[1], 1);
            Grid.SetColumn(borders[3], 1);
            Grid.SetRow(borders[2], 1);
            Grid.SetRow(borders[3], 1);

            List<StackPanel> buttons = CreateStackPanelsWithButtonsTaskFirst(countDefinitions * 2);
            foreach (StackPanel item in buttons)
            {
                GridTaskFirst.Children.Add(item);
            }

            Grid.SetColumn(buttons[1], 1);
            Grid.SetColumn(buttons[3], 1);
            Grid.SetRow(buttons[2], 1);
            Grid.SetRow(buttons[3], 1);
        }

        /// <summary>
        /// Создаёт обводку, чтобы можно было визуально разделить множества в первом задании
        /// </summary>
        /// <returns>Список обводок</returns>
        private List<Border> CreateBordersTaskFirst()
        {
            double thickness = Base.StrokeThickness / 2;

            return new List<Border>()
            {
                new Border()
                {
                   BorderBrush = Brushes.Black,
                   BorderThickness = new Thickness(0, 0, thickness, thickness)
                },
                new Border()
                {
                   BorderBrush = Brushes.Black,
                   BorderThickness = new Thickness(thickness, 0, 0, thickness)
                },
                new Border()
                {
                   BorderBrush = Brushes.Black,
                   BorderThickness = new Thickness(0, thickness, thickness, 0)
                },
                new Border()
                {
                   BorderBrush = Brushes.Black,
                   BorderThickness = new Thickness(thickness, thickness, 0, 0)
                }
            };
        }

        /// <summary>
        /// Создаёт список StakPanel с кнопками для каждой ячейки Grid
        /// </summary>
        /// <param name="count">количество StakPanel</param>
        /// <returns>Список StakPanel</returns>
        private List<StackPanel> CreateStackPanelsWithButtonsTaskFirst(int count)
        {
            _buttonsTaskFirst = new List<Button>();
            List<StackPanel> list = new List<StackPanel>();

            for (int i = 0; i < count; i++)
            {
                StackPanel sp = new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(0, 0, 0, 10)
                };

                Button btnIsThere = new Button
                {
                    Content = "Есть",
                    Margin = new Thickness(0, 0, 10, 0),
                    Style = (Style)Application.Current.Resources["ButtonMainStyle"],
                    Uid = i.ToString()
                };
                Button btnNot = new Button
                {
                    Content = "Нет",
                    Style = (Style)Application.Current.Resources["ButtonMainStyle"],
                    Uid = i.ToString()
                };

                btnIsThere.Click += ButtonClickTaskFirst;
                btnNot.Click += ButtonClickTaskFirst;
                _buttonsTaskFirst.Add(btnIsThere);
                _buttonsTaskFirst.Add(btnNot);

                sp.Children.Add(btnIsThere);
                sp.Children.Add(btnNot);
                list.Add(sp);
            }

            return list;
        }

        private void ButtonClickTaskFirst(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int id = Convert.ToInt32(btn.Uid);

            foreach (Button item in _buttonsTaskFirst.Where(x => Convert.ToInt32(x.Uid) == id))
            {
                item.Background = (SolidColorBrush)Application.Current.Resources["PrimaryColor"];
                item.Foreground = Brushes.Black;
            }

            btn.Background = (SolidColorBrush)Application.Current.Resources["SecondaryColor"];
            btn.Foreground = Brushes.White;
        }

        private void BtnCheckTaskFirst_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < _figuresTaskFirst.Count; i += 2)
            {
                if (_buttonsTaskFirst[i].Background == (SolidColorBrush)Application.Current.Resources["PrimaryColor"] &&
                    _buttonsTaskFirst[i + 1].Background == (SolidColorBrush)Application.Current.Resources["PrimaryColor"])
                {
                    new ResultLessonSix(GridTaskFirst, _figuresTaskFirst).ShowDialog();
                    return;
                }

                if (_figuresTaskFirst[i].FillContainsWithDetail(_figuresTaskFirst[i + 1]) != IntersectionDetail.FullyContains &&
                    _buttonsTaskFirst[i].Background == (SolidColorBrush)Application.Current.Resources["SecondaryColor"])
                {
                    new ResultLessonSix(GridTaskFirst, _figuresTaskFirst).ShowDialog();
                    return;
                }

                if (_figuresTaskFirst[i].FillContainsWithDetail(_figuresTaskFirst[i + 1]) == IntersectionDetail.FullyContains &&
                    _buttonsTaskFirst[i].Background != (SolidColorBrush)Application.Current.Resources["SecondaryColor"])
                {
                    new ResultLessonSix(GridTaskFirst, _figuresTaskFirst).ShowDialog();
                    return;
                }
            }

            new CorrectResult().ShowDialog();
        }

        private void BtnCheckTaskSecond_Click(object sender, RoutedEventArgs e)
        {
            if (Figure.CheckOccurrencesFiguresInSet(_indexesAnswersSetA, _figuresTaskSecond, _setsTaskSecond[0]) &&
                Figure.CheckOccurrencesFiguresInSet(_indexesAnswersSetB, _figuresTaskSecond, _setsTaskSecond[1]))
            {
                new CorrectResult().ShowDialog();
            }
            else
            {
                new ResultLessonSix(CnvTaskSecond, _indexesAnswersSetA, _indexesAnswersSetB, _sizeFiguresTaskSecond).ShowDialog();
            }
        }

        private void MenuRefresh_Click(object sender, RoutedEventArgs e)
        {
            MenuItem childMenuItem = (MenuItem)sender;
            MenuItem menuItem = (MenuItem)childMenuItem.Parent;

            switch (Convert.ToInt32(menuItem.Uid))
            {
                case 1:
                    ShowTaskFirst();
                    break;
                case 2:
                    ShowTaskSecond();
                    break;
                default:
                    break;
            }
        }

        private void MenuGuide_Click(object sender, RoutedEventArgs e)
        {
            MenuItem childMenuItem = (MenuItem)sender;
            MenuItem menuItem = (MenuItem)childMenuItem.Parent;

            new GuideWindow(4, Convert.ToInt32(menuItem.Uid)).ShowDialog();
        }

        private void BtnHint_Click(object sender, RoutedEventArgs e)
        {
            new HintLessonSix().ShowDialog();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Base.MainFrame.Navigate(new MainMenuPage());
        }
    }
}