using MathSets.windows;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MathSets.pages
{
    /// <summary>
    /// Логика взаимодействия для LessonFourAndFive.xaml
    /// </summary>
    public partial class LessonFourAndFive : Page
    {
        private Random _random = new Random();
        private Path _pathToMoved; // Фигура для перемещения.
        private Point _oldMouseCoordinate; // Предыдущие координаты курсора (для перемещения фигуры).

        // Поля для первого задания
        private int _sizeFiguresTaskFirst = 70; // Размер фигур.
        private List<int> _indexesAnswersTaskFirst = new List<int>(); // Индексы верных ответов (верных фигур).
        private List<Geometry> _figuresTaskFirst; // Фигуры.
        private Geometry _setTaskFirst; // Множество.
        private List<Point> _pointsToMovedTaskFirst = new List<Point>(); // Точки для перемещения фигур.

        // Поля для второго задания
        private List<Geometry> _figuresTaskSecond; // Фигуры.
        private List<Geometry> _setsTaskSecond; // Множества.

        // Поля для третьего задания
        private int _sizeFiguresTaskThree = 50; // Размер фигур.
        private List<Geometry> _figuresTaskThree; // Фигуры.
        private List<Geometry> _setsTaskThree; // Множества.
        private List<Point> _pointsToMovedTaskThree = new List<Point>(); // Точки для перемещения фигур.

        public LessonFourAndFive()
        {
            InitializeComponent();

            ShowExerciseFirst();
            ShowExerciseSecond();
            ShowExerciseThree();
        }

        /// <summary>
        /// Отображает на экране первое упражнение
        /// </summary>
        private void ShowExerciseFirst()
        {
            CnvTaskFirst.Children.Clear();
            SpFiguresTaskFirst.Children.Clear();

            int countRigthAnswers = 3; // Количество элементов в изначально заданном множестве, которое нужно отобразить (множестве по заданию).

            _setTaskFirst = CreateSet(CnvTaskFirst);
            _figuresTaskFirst = CreateFiguresTaskFirst();

            Figure.ShowFigures(CreateAnswersTaskFirst(countRigthAnswers), SpFiguresTaskFirst);
            Figure.ShowFigures(new List<Geometry>() { _setTaskFirst }, CnvTaskFirst);
            Figure.ShowFigures(_figuresTaskFirst, CnvTaskFirst);

            SetHandlersTaskFirst();
        }

        /// <summary>
        /// Отображает на экране второе упражнение
        /// </summary>
        private void ShowExerciseSecond()
        {
            CnvTaskSecond.Children.Clear();
            SpTaskSecondSetA.Children.Clear();
            SpTaskSecondSetB.Children.Clear();

            int countNumbers = 5; // Количество элементов множества.

            _setsTaskSecond = CreateSets(CnvTaskSecond);
            _figuresTaskSecond = CreateFiguresTaskSecond(countNumbers);

            Figure.ShowFigures(_setsTaskSecond, CnvTaskSecond);
            Figure.ShowFigures(_figuresTaskSecond, CnvTaskSecond);

            ShowStackPanelAnswersTaskSecond(SpTaskSecondSetA, 'A', countNumbers);
            ShowStackPanelAnswersTaskSecond(SpTaskSecondSetB, 'B', countNumbers);
        }

        /// <summary>
        /// Отображает на экране третье упражнение
        /// </summary>
        private void ShowExerciseThree()
        {
            CnvTaskThree.Children.Clear();
            SpTaskThreeSetA.Children.Clear();
            SpTaskThreeSetB.Children.Clear();

            int countNumbers = 5; // Количество элементов множества.

            _setsTaskThree = CreateSets(CnvTaskThree);
            _figuresTaskThree = CreateFiguresTaskThree(countNumbers);

            Figure.ShowFigures(_setsTaskThree, CnvTaskThree);
            Figure.ShowFigures(_figuresTaskThree, CnvTaskThree);

            ShowConditionsTaskThree(SpTaskThreeSetA, 'A', countNumbers);
            ShowConditionsTaskThree(SpTaskThreeSetB, 'B', countNumbers);

            SetHandlersTaskThree();
        }

        /// <summary>
        /// Генерирует множество в виде эллипса
        /// </summary>
        /// <param name="panel">контейнер</param>
        /// <returns>Эллипс (множество)</returns>
        private Geometry CreateSet(Panel panel)
        {
            double sizeFigure = panel.Height * 1.5 - Base.StrokeThickness * 2; // 1.5, потому что одна ось больше другой в 1.5 раза.
            double xStart = panel.Width / 2 + (panel.Width / 2 - sizeFigure) / 2;

            Figure.ShowFigures(new List<Geometry>()
            {
                new Figure(60, 0, 0).GetGeometryFromText("A", (int)panel.Width - 60, -20)
            },
            CnvTaskFirst,
            Brushes.White,
            Brushes.Black);

            return new Figure((int)sizeFigure, (sizeFigure + 2) * 2, panel.Width / 2).
                CreateEllipseTransformY((int)xStart, true);
        }

        /// <summary>
        /// Генерирует ответы (3 фигуры) для первого задания
        /// </summary>
        /// <returns>Список структур, представляющий из себя пару: ключ - фигура, где ключ - целочисленный индекс из первоначального списка методов</returns>
        private List<Geometry> CreateAnswersTaskFirst(int count)
        {
            int sizeFigures = (int)TbTaskFirst.FontSize;
            Figure figures = new Figure(sizeFigures, (sizeFigures + 2) * 2, SpFiguresTaskFirst.Width);
            List<CreateFiguresDelegate> createFiguresMethods = figures.GetAllCreateFiguresMethods();
            List<int> tempIndexesFigures = Figure.ShuffleMethods(createFiguresMethods);

            _indexesAnswersTaskFirst.Clear();
            for (int i = 0; i < count; i++)
            {
                _indexesAnswersTaskFirst.Add(tempIndexesFigures[i]);
            }

            List<Geometry> listFigures = new List<Geometry>();
            int x = 10;

            for (int i = 0; i < count; i++)
            {
                listFigures.Add(createFiguresMethods[i](x, true));
            }

            SpFiguresTaskFirst.Width = listFigures.Count * sizeFigures + (listFigures.Count + 1) * x;

            return listFigures;
        }

        /// <summary>
        /// Генерирует фигуры для первого задания
        /// </summary>
        /// <returns>Коллекция фигур</returns>
        private List<Geometry> CreateFiguresTaskFirst()
        {
            Figure figure = new Figure(_sizeFiguresTaskFirst, CnvTaskFirst.Height, CnvTaskFirst.Width / 2);
            List<CreateFiguresDelegate> createFiguresMethods = figure.GetAllCreateFiguresMethods();
            List<int> indexesFigures = Figure.ShuffleMethods(createFiguresMethods);

            List<Geometry> figures = new List<Geometry>();
            int offset = figure.GetOffset(createFiguresMethods.Count);
            int xStart = Base.StrokeThickness;

            for (int i = 0; i < createFiguresMethods.Count; i++)
            {
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

            SortForDefaultPosition(figures, indexesFigures);

            return figures;
        }

        /// <summary>
        /// Сортирует список фигур в соответствии с первоначальным списком методов их создания
        /// </summary>
        /// <param name="figures">списико фигур</param>
        /// <param name="currentIndexes">индексы фигур в соответствии с первоначальным списком методов их создания</param>
        private void SortForDefaultPosition(List<Geometry> figures, List<int> currentIndexes)
        {
            List<Geometry> tempList = new List<Geometry>();
            tempList.AddRange(figures);
            figures.Clear();

            int count = tempList.Count;

            for (int i = 0; i < count; i++)
            {
                figures.Add(tempList[currentIndexes.IndexOf(i)]);
            }
        }

        /// <summary>
        /// Устанавливает события для panel, необходимые для перемещения фигур, для первого задания
        /// </summary>
        /// <param name="panel">Контейнер</param>
        private void SetHandlersTaskFirst()
        {
            SpTaskFirst.MouseUp += OnMouseUp;

            for (int i = 2; i < CnvTaskFirst.Children.Count; i++) // i = 2, так как вторым элементом списка является само множество, а первым - его название.
            {
                CnvTaskFirst.Children[i].MouseMove += OnMouseMoveTaskFirst;
                CnvTaskFirst.Children[i].MouseDown += OnMouseDown;
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
                _oldMouseCoordinate = e.GetPosition(CnvTaskFirst);
                _pathToMoved.CaptureMouse();
            }
        }

        private void OnMouseMoveTaskFirst(object sender, MouseEventArgs e)
        {
            if (_pathToMoved != null)
            {
                int id = Convert.ToInt32(_pathToMoved.Uid);

                _pointsToMovedTaskFirst[id] = GetOffsetFigure(_pointsToMovedTaskFirst[id], e.GetPosition(CnvTaskFirst));

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

        private void BtnCheckTaskFirst_Click(object sender, RoutedEventArgs e)
        {
            if (Figure.CheckOccurrencesFiguresInSet(_indexesAnswersTaskFirst, CnvTaskFirst))
            {
                new CorrectResult().ShowDialog();
            }
            else
            {
                new ResultLessonFourAndFive(CnvTaskFirst, _indexesAnswersTaskFirst, _sizeFiguresTaskFirst).ShowDialog();
            }
        }

        /// <summary>
        /// Создаёт элементы для выбора ответа у второго задания
        /// </summary>
        /// <param name="panel">контейнер</param>
        /// <param name="set">название множества</param>
        /// <param name="count">общее количество элементов множеств</param>
        private void ShowStackPanelAnswersTaskSecond(StackPanel panel, char set, int count)
        {
            for (int i = 0; i < count; i++)
            {
                StackPanel sp = new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(0, 10, 0, 10)
                };

                sp.Children.Add(new TextBlock() // Цифра.
                {
                    Text = (i + 1).ToString(),
                    FontFamily = new FontFamily(Base.FontFamily),
                    Width = 20,
                    Margin = new Thickness(0, 0, 10, 0),
                    VerticalAlignment = VerticalAlignment.Center
                });

                ComboBox cb = new ComboBox() // Знаки "принадлежит" и "не принадлежит".
                {
                    Margin = new Thickness(0, 0, 10, 0),
                    MinWidth = 50,
                    MinHeight = 35,
                    VerticalAlignment = VerticalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Top
                };
                cb.Items.Add(new ComboBoxItem()
                {
                    Content = "∈"
                });
                cb.Items.Add(new ComboBoxItem()
                {
                    Content = "∉"
                });
                sp.Children.Add(cb);

                sp.Children.Add(new TextBlock() // Наименование множества.
                {
                    Text = set.ToString(),
                    FontFamily = new FontFamily(Base.FontFamily),
                    Margin = new Thickness(0, 0, 10, 0),
                    VerticalAlignment = VerticalAlignment.Center
                });

                panel.Children.Add(sp);
            }
        }

        /// <summary>
        /// Генерирует множества в виде эллипсов
        /// </summary>
        /// <param name="panel">контейнер</param>
        /// <returns>Список множеств</returns>
        private List<Geometry> CreateSets(Panel panel)
        {
            double sizeFigure = panel.Height * 0.7 * 1.5 - Base.StrokeThickness * 2;                    // 1.5, потому что одна ось меньше другой в 1.5 раза,
            double xStart = Base.StrokeThickness + (panel.Width - panel.Width / 2 + 100 - 100 * 2) / 2; // 0.7 - для уменьшения размеров множества, придуманное число.
                                                                                                        // 100 - для смещения эллипса вправо, придуманное число.
            List<Geometry> sets = new List<Geometry>
            {
                new Figure((int)sizeFigure, (sizeFigure + Base.StrokeThickness) * 2, panel.Width / 2).
                CreateEllipseTransformY((int)xStart, true, -20),
                new Figure((int)sizeFigure, (sizeFigure + Base.StrokeThickness) * 2, panel.Width / 2).
                CreateEllipseTransformY((int)xStart + 100, true, -20)
            };

            for (int i = 0; i < sets.Count; i++)
            {
                sets[i].Transform = new TranslateTransform(0, (panel.Height - sizeFigure / 1.5) / 2); // 1.5, потому что одна ось меньше другой в 1.5 раза.
            }

            sets.Add(new CombinedGeometry(GeometryCombineMode.Intersect, sets[0], sets[1]));

            Figure figure = new Figure(60, 0, 0); // 0, потому что эти параметры не пригодятся для объекта в данной ситуации.

            Figure.ShowFigures(new List<Geometry>()
            {
                figure.GetGeometryFromText("A", 65, 0),
                figure.GetGeometryFromText("B", 455, 0)
            },
            panel,
            Brushes.White,
            Brushes.Black);

            return sets;
        }

        /// <summary>
        /// Генерирует фигуры из цифр для второго задания
        /// </summary>
        /// <returns>Коллекция фигур</returns>
        private List<Geometry> CreateFiguresTaskSecond(int countFigures)
        {
            int sizeFigures = 50;
            Figure figure = new Figure(sizeFigures, CnvTaskSecond.Height, CnvTaskSecond.Width);

            List<Geometry> figures = new List<Geometry>();

            for (int i = 0; i < countFigures; i++)
            {
                figures.Add(figure.GetGeometryFromText((i + 1).ToString()));
            }

            _setsTaskSecond.Add(((Path)CnvTaskSecond.Children[0]).Data); // Добавление названий множеств, чтобы цифры их не перекрывали.
            _setsTaskSecond.Add(((Path)CnvTaskSecond.Children[1]).Data);

            while (Figure.CheckIntersectionsFiguresAndSets(figures, _setsTaskSecond))
            {
                figures.Clear();

                for (int i = 0; i < countFigures; i++)
                {
                    figures.Add(figure.GetGeometryFromText((i + 1).ToString()));
                }
            }

            _setsTaskSecond.Remove(((Path)CnvTaskSecond.Children[0]).Data); // Удаление добавленных названий множеств
            _setsTaskSecond.Remove(((Path)CnvTaskSecond.Children[1]).Data);

            return figures;
        }

        private void BtnCheckTaskSecond_Click(object sender, RoutedEventArgs e)
        {
            List<List<int>> indexesErrors = new List<List<int>>()
            {
                GetErrorsTaskSecond(SpTaskSecondSetA, _setsTaskSecond[0]),
                GetErrorsTaskSecond(SpTaskSecondSetB, _setsTaskSecond[1])
            };

            if (indexesErrors[0].Count == 0 && indexesErrors[1].Count == 0)
            {
                new CorrectResult().ShowDialog();
            }
            else
            {
                new ResultLessonFourAndFive(CnvTaskSecond, indexesErrors, _figuresTaskSecond).ShowDialog();
            }
        }

        /// <summary>
        /// Получает индексы неверно выбранных овтетов для 2-го задания
        /// </summary>
        /// <param name="panel">контейнер</param>
        /// <param name="set">множество</param>
        /// <returns>Список неверных индексов</returns>
        private List<int> GetErrorsTaskSecond(Panel panel, Geometry set)
        {
            List<int> indexesErrors = new List<int>();

            for (int i = 0; i < panel.Children.Count; i++)
            {
                StackPanel sp = (StackPanel)panel.Children[i];
                ComboBox cb = (ComboBox)sp.Children[1];

                if (cb.SelectedIndex == 0 && set.FillContainsWithDetail(_figuresTaskSecond[i]) != IntersectionDetail.FullyContains)
                {
                    indexesErrors.Add(i);
                }
                else if (cb.SelectedIndex == 1 && set.FillContainsWithDetail(_figuresTaskSecond[i]) != IntersectionDetail.Empty)
                {
                    indexesErrors.Add(i);
                }
                else if (cb.SelectedIndex == -1)
                {
                    indexesErrors.Add(i);
                }
            }

            return indexesErrors;
        }

        /// <summary>
        /// Генерирует фигуры из цифр для третьего задания
        /// </summary>
        /// <returns>Коллекция фигур</returns>
        private List<Geometry> CreateFiguresTaskThree(int countFigures)
        {
            int x = Base.StrokeThickness + 200;
            int offset = 40;
            Figure figure = new Figure(_sizeFiguresTaskThree, 0, 0);
            List<Geometry> figures = new List<Geometry>();

            for (int i = 0; i < countFigures; i++)
            {
                figures.Add(figure.GetGeometryFromText((i + 1).ToString(), x, (int)CnvTaskThree.Height - _sizeFiguresTaskThree - Base.StrokeThickness * 4));
                x += offset;
            }

            _pointsToMovedTaskThree.Clear();
            for (int i = 0; i < figures.Count; i++)
            {
                _pointsToMovedTaskThree.Add(new Point(0, 0));
            }

            return figures;
        }

        /// <summary>
        /// Создаёт условие для второго задания
        /// </summary>
        /// <param name="panel">контейнер</param>
        /// <param name="set">название множества</param>
        /// <param name="count">общее количество элементов множеств</param>
        private void ShowConditionsTaskThree(StackPanel panel, char set, int count)
        {
            for (int i = 0; i < count; i++)
            {
                StackPanel sp = new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(0, 10, 0, 10)
                };

                sp.Children.Add(new TextBlock() // Цифра.
                {
                    Text = (i + 1).ToString(),
                    FontFamily = new FontFamily(Base.FontFamily),
                    Width = 20,
                    Margin = new Thickness(0, 0, 10, 0),
                    VerticalAlignment = VerticalAlignment.Center
                });


                sp.Children.Add(new TextBlock() // Знак "принадлежит" или "не принадлежит".
                {
                    Text = _random.Next(0, 2) == 0 ? "∈" : "∉",
                    Margin = new Thickness(0, 0, 10, 0),
                    FontFamily = new FontFamily(Base.FontFamily),
                    VerticalAlignment = VerticalAlignment.Center
                });

                sp.Children.Add(new TextBlock() // Наименование множества.
                {
                    Text = set.ToString(),
                    FontFamily = new FontFamily(Base.FontFamily),
                    Margin = new Thickness(0, 0, 10, 0),
                    VerticalAlignment = VerticalAlignment.Center
                });

                panel.Children.Add(sp);
            }
        }

        /// <summary>
        /// Устанавливает события для panel, необходимые для перемещения фигур, для третьего задания
        /// </summary>
        /// <param name="panel">Контейнер</param>
        private void SetHandlersTaskThree() // 2, так как вторым элементом списка является само множество, а первым - его название.
        {
            SpTaskThree.MouseUp += OnMouseUp;

            for (int i = 5; i < CnvTaskThree.Children.Count; i++) // i = 5, так как сами фигуры начинаются с 5-й позиции.
            {
                CnvTaskThree.Children[i].MouseMove += OnMouseMoveTaskThree;
                CnvTaskThree.Children[i].MouseDown += OnMouseDown;
            }
        }

        private void OnMouseMoveTaskThree(object sender, MouseEventArgs e)
        {
            if (_pathToMoved != null)
            {
                if (_pathToMoved.Uid != "")
                {
                    int id = Convert.ToInt32(_pathToMoved.Uid);

                    _pointsToMovedTaskThree[id] = GetOffsetFigure(_pointsToMovedTaskThree[id], e.GetPosition(CnvTaskThree));

                    _pathToMoved.Data.Transform = new TranslateTransform(_pointsToMovedTaskThree[id].X, _pointsToMovedTaskThree[id].Y);
                }
            }
        }

        private void BtnCheckTaskThree_Click(object sender, RoutedEventArgs e)
        {
            if (CheckTaskThree(SpTaskThreeSetA, _setsTaskThree[0]) && CheckTaskThree(SpTaskThreeSetB, _setsTaskThree[1]))
            {
                new CorrectResult().ShowDialog();
            }
            else
            {
                new ResultLessonFourAndFive(CnvTaskThree, SpCondition, _sizeFiguresTaskThree).ShowDialog();
            }
        }

        /// <summary>
        /// Получает индексы неверно выбранных овтетов для 3-го задания
        /// </summary>
        /// <param name="panel">контейнер</param>
        /// <param name="set">множество</param>
        /// <returns>Список неверных индексов</returns>
        private bool CheckTaskThree(Panel panel, Geometry set)
        {
            for (int i = 0; i < panel.Children.Count; i++)
            {
                StackPanel sp = (StackPanel)panel.Children[i];
                TextBlock tb = (TextBlock)sp.Children[1];

                if (tb.Text == "∈" && set.FillContainsWithDetail(_figuresTaskThree[i]) != IntersectionDetail.FullyContains)
                {
                    return false;
                }
                else if (tb.Text == "∉" && set.FillContainsWithDetail(_figuresTaskThree[i]) != IntersectionDetail.Empty)
                {
                    return false;
                }
            }

            return true;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Base.MainFrame.Navigate(new MainMenuPage());
        }

        private void BtnHint_Click(object sender, RoutedEventArgs e)
        {
            new HintLessonFourAndFive().ShowDialog();
        }

        private void MenuGuide_Click(object sender, RoutedEventArgs e)
        {
            MenuItem childMenuItem = (MenuItem)sender;
            MenuItem menuItem = (MenuItem)childMenuItem.Parent;

            switch (Convert.ToInt32(menuItem.Uid))
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                default:
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
                    ShowExerciseFirst();
                    break;
                case 2:
                    ShowExerciseSecond();
                    break;
                case 3:
                    ShowExerciseThree();
                    break;
                default:
                    break;
            }
        }
    }
}