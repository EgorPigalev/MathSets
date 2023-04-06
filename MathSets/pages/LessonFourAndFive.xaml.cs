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
        private int _countRigthAnswers = 3; // Количество элементов в изначально заданном множестве, которое нужно изобразить.
        private List<int> _indexesAnswersQuestionFirst = new List<int>(); // Индексы верных ответов (верных фигур) для первого задания.
        private List<Geometry> _figuresQuestionFirst; // Фигуры для первого задания.
        private Geometry _setQuestionFirst; // Множество для первого задания.
        List<Point> _pointsQuestionFirst = new List<Point>(); // Точки для первого задания.
        private Path _pathToMoved; // Фигура для перемещения.
        private Point _oldMouseCoordinate; // Предыдущие координаты курсора (для перемещения фигуры)

        private List<Geometry> _figuresQuestionSecond; // Фигуры для второго задания.
        private List<Geometry> _setsQuestionSecond; // Множества для второго задания.

        public LessonFourAndFive()
        {
            InitializeComponent();

            ShowExerciseFirst();
            ShowExerciseSecond();
            ShowExerciseThree();
        }

        /// <summary>
        /// Отображает на экране первое упражнение.
        /// </summary>
        private void ShowExerciseFirst()
        {
            CnvQuestionFirst.Children.Clear();
            SpFiguresQuestionFirst.Children.Clear();

            _setQuestionFirst = CreateSetQuestionFirst(CnvQuestionFirst);
            _figuresQuestionFirst = CreateFiguresQuestionFirst();


            ShowFigures(CreateAnswersQuestionFirst(), SpFiguresQuestionFirst);
            ShowFigures(new List<Geometry>() { _setQuestionFirst }, CnvQuestionFirst);
            ShowFigures(_figuresQuestionFirst, CnvQuestionFirst);

            SetHandlers(CnvQuestionFirst);
        }

        /// <summary>
        /// Отображает на экране второе упражнение.
        /// </summary>
        private void ShowExerciseSecond()
        {
            CnvQuestionSecond.Children.Clear();

            _setsQuestionSecond = CreateSetsQuestionSecond(CnvQuestionSecond);
            _figuresQuestionSecond = CreateFiguresQuestionSecond();

            ShowFigures(_setsQuestionSecond, CnvQuestionSecond);
            ShowFigures(_figuresQuestionSecond, CnvQuestionSecond);
        }

        /// <summary>
        /// Генерирует множества в виде эллипсов для второго задания
        /// </summary>
        /// <param name="panel">контейнер</param>
        /// <returns>Список множеств</returns>
        public static List<Geometry> CreateSetsQuestionSecond(Panel panel)
        {
            double sizeFigure = panel.Height * 0.7 * 1.5 - Base.StrokeThickness * 2; // 1.5, потому что одна ось меньше другой в 1.5 раза,
            double xStart = Base.StrokeThickness + 100;                              // 0.7 - для уменьшения размеров множества, придуманное число.
                                                                                     // 100 - для смещения эллипса вправо, придуманное число.
            List<Geometry> sets = new List<Geometry>
            {
                new Figure((int)sizeFigure, (sizeFigure + Base.StrokeThickness) * 2, panel.Width / 2).
                CreateEllipseTransformY((int)xStart, true),
                new Figure((int)sizeFigure, (sizeFigure + Base.StrokeThickness) * 2, panel.Width / 2).
                CreateEllipseTransformY((int)xStart + 100, true)
            };

            for (int i = 0; i < sets.Count; i++)
            {
                sets[i].Transform = new TranslateTransform(0, (panel.Height - sizeFigure / 1.5) / 2); // 1.5, потому что одна ось меньше другой в 1.5 раза,
            }

            sets.Add(new CombinedGeometry(GeometryCombineMode.Intersect, sets[0], sets[1]));

            return sets;
        }

        /// <summary>
        /// Генерирует фигуры из цифр для второго задания
        /// </summary>
        /// <returns>Коллекция фигур</returns>
        private List<Geometry> CreateFiguresQuestionSecond()
        {
            int sizeFigures = 30;
            Figure figure = new Figure(sizeFigures, CnvQuestionSecond.Height, CnvQuestionSecond.Width);

            int countFigures = 5;
            List<Geometry> figures = new List<Geometry>();

            for (int i = 0; i < countFigures; i++)
            {
                if (i % 2 == 0)
                {
                    figures.Add(figure.GetGeometryFromText((i + 1).ToString())); // Положение фигуры по вертикали сверху.
                }
                else
                {
                    figures.Add(figure.GetGeometryFromText((i + 1).ToString())); // Положение фигуры по вертикали снизу.
                }
            }

            while(CheckIntersectionsFiguresAndSets(figures, _setsQuestionSecond))
            {
                figures.Clear();

                for (int i = 0; i < countFigures; i++)
                {
                    if (i % 2 == 0)
                    {
                        figures.Add(figure.GetGeometryFromText((i + 1).ToString()));
                    }
                    else
                    {
                        figures.Add(figure.GetGeometryFromText((i + 1).ToString()));
                    }
                }
            }

            return figures;
        }

        /// <summary>
        /// Проверяет пересечение множеств и фигур
        /// </summary>
        /// <param name="figures">список фигур</param>
        /// <param name="sets">список множеств</param>
        /// <returns>true, если пересечения множеств и фигур найдены, в противном случае - false</returns>
        private bool CheckIntersectionsFiguresAndSets(List<Geometry> figures, List<Geometry> sets)
        {
            for (int i = 0; i < figures.Count; i++)
            {
                for (int j = i + 1; j < figures.Count; j++)
                {
                    if (figures[i].FillContainsWithDetail(figures[j]) == IntersectionDetail.Intersects)
                    {
                        return true;
                    }
                }

                foreach (Geometry set in sets)
                {
                    if (figures[i].FillContainsWithDetail(set) == IntersectionDetail.Intersects)
                    {
                        return true;
                    }
                }
            }

            return false;
        }







        /// <summary>
        /// Отображает на экране третье упражнение.
        /// </summary>
        private void ShowExerciseThree()
        {

        }

        /// <summary>
        /// Генерирует множество в виде эллипса для первого задания
        /// </summary>
        /// <param name="panel">контейнер</param>
        /// <returns>Эллипс (множество)</returns>
        public static Geometry CreateSetQuestionFirst(Panel panel)
        {
            double sizeFigure = panel.Height * 1.5 - Base.StrokeThickness * 2; // 1.5, потому что одна ось больше другой в 1.5 раза.
            double xStart = panel.Width / 2 + (panel.Width / 2 - sizeFigure) / 2;

            return new Figure((int)sizeFigure, (sizeFigure + 2) * 2, panel.Width / 2).
                CreateEllipseTransformY((int)xStart, true);
        }

        /// <summary>
        /// Добавляет созданные фигуры в контейнер
        /// </summary>
        /// <param name="figures">коллекция фигур</param>
        /// <param name="panel">контейнер</param>
        private void ShowFigures(List<Geometry> figures, Panel panel)
        {
            for (int i = 0; i < figures.Count; i++)
            {
                panel.Children.Add(new Path()
                {
                    StrokeThickness = Base.StrokeThickness,
                    Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18"),
                    Data = figures[i],
                    Fill = Brushes.White,
                    Uid = i.ToString()
                });
            }
        }

        /// <summary>
        /// Генерирует ответы (3 фигуры) для первого вопроса
        /// </summary>
        /// <returns>Список структур, представляющий из себя пару: ключ - фигура, где ключ - целочисленный индекс из первоначального списка методов</returns>
        private List<Geometry> CreateAnswersQuestionFirst()
        {
            int sizeFigures = (int)TbQuestionFirst.FontSize;
            Figure figures = new Figure(sizeFigures, (sizeFigures + 2) * 2, SpFiguresQuestionFirst.Width);
            List<CreateFiguresDelegate> createFiguresMethods = figures.GetAllCreateFiguresMethods();
            List<int> tempIndexesFigures = Figure.ShuffleMethods(createFiguresMethods);

            _indexesAnswersQuestionFirst.Clear();
            for (int i = 0; i < _countRigthAnswers; i++)
            {
                _indexesAnswersQuestionFirst.Add(tempIndexesFigures[i]);
            }

            List<Geometry> listFigures = new List<Geometry>();
            int x = 10;

            for (int i = 0; i < _countRigthAnswers; i++)
            {
                listFigures.Add(createFiguresMethods[i](x, true));
            }

            SpFiguresQuestionFirst.Width = listFigures.Count * sizeFigures + (listFigures.Count + 1) * x;

            return listFigures;
        }

        /// <summary>
        /// Генерирует фигуры для первого задания
        /// </summary>
        /// <returns>Коллекция фигур</returns>
        private List<Geometry> CreateFiguresQuestionFirst()
        {
            int sizeFigures = 50;
            Figure figure = new Figure(sizeFigures, CnvQuestionFirst.Height, CnvQuestionFirst.Width / 2);
            List<CreateFiguresDelegate> createFiguresMethods = figure.GetAllCreateFiguresMethods();

            List<Geometry> figures = new List<Geometry>();
            int offset = figure.GetOffset(createFiguresMethods.Count);
            int xStart = 0;

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

            _pointsQuestionFirst.Clear();
            for (int i = 0; i < figures.Count; i++)
            {
                _pointsQuestionFirst.Add(new Point(0, 0));
            }

            return figures;
        }

        /// <summary>
        /// Устанавливает события для panel, необходимые для перемещения фигур
        /// </summary>
        /// <param name="panel">Контейнер</param>
        private void SetHandlers(Panel panel)
        {
            SpQuestionFirst.MouseUp += OnMouseUp;

            for (int i = 1; i < panel.Children.Count; i++) // i = 1, так как первым элементом списка является само множество.
            {
                panel.Children[i].MouseMove += OnMouseMove;
                panel.Children[i].MouseDown += OnMouseDown;
            }
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < CnvQuestionFirst.Children.Count; i++)
            {
                Path p = (Path)CnvQuestionFirst.Children[i];
                p.Fill = Brushes.White;
                _pathToMoved = null;
            }
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Path path = (Path)sender;

            if (path.Uid != string.Empty)
            {
                path.Fill = Brushes.Gray;
                _pathToMoved = path;
                _oldMouseCoordinate = e.GetPosition(CnvQuestionFirst);
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_pathToMoved != null)
            {
                if (_pathToMoved.Uid != "")
                {
                    int id = Convert.ToInt32(_pathToMoved.Uid);

                    SetOffsetFigure(id, e.GetPosition(CnvQuestionFirst));

                    _pathToMoved.Data.Transform = new TranslateTransform(_pointsQuestionFirst[id].X, _pointsQuestionFirst[id].Y);
                }
            }
        }

        /// <summary>
        /// Вычисляет новые координаты для перемещения фигуры
        /// </summary>
        /// <param name="id">Id фигуры</param>
        /// <param name="actualCoordinate">Актуальные координаты курсора</param>
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

        private void BtnCheckQuestionFirst_Click(object sender, RoutedEventArgs e)
        {
            if (Figure.CheckOccurrencesFigures(_indexesAnswersQuestionFirst, CnvQuestionFirst))
            {
                new CorrectResult().ShowDialog();
            }
            else
            {
                new ResultLessonFourAndFive(CnvQuestionFirst, _indexesAnswersQuestionFirst).ShowDialog();
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Base.MainFrame.Navigate(new MainMenuPage());
        }

        private void BtnHint_Click(object sender, RoutedEventArgs e)
        {
            new HintLessonFourAndFive().ShowDialog();
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