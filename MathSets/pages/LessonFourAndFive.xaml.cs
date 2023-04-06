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
        private int _countRigthAnswers = 3;
        private List<int> _indexesAnswersQuestionFirst = new List<int>();
        private List<Geometry> _figuresQuestionFirst;
        private Geometry _setQuestionFirst;
        List<Point> _points = new List<Point>();
        private Path _pathToMoved;
        private Point _oldMouseCoordinate;

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

            _setQuestionFirst = Figure.CreateSet(CnvQuestionFirst);
            _figuresQuestionFirst = CreateFiguresQuestionFirst();


            ShowFigures(CreateAnswersQuestionFirst(), SpFiguresQuestionFirst);
            ShowFigures(new List<Geometry>() { _setQuestionFirst }, CnvQuestionFirst);
            ShowFigures(_figuresQuestionFirst, CnvQuestionFirst);

            SetHandlers(CnvQuestionFirst);
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
        /// Генерирует фигуры
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

            _points.Clear();
            for (int i = 0; i < figures.Count; i++)
            {
                _points.Add(new Point(0, 0));
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

                    _pathToMoved.Data.Transform = new TranslateTransform(_points[id].X, _points[id].Y);
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
            Point tempPoint = _points[id];

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

            _points[id] = tempPoint;

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

        /// <summary>
        /// Отображает на экране второе упражнение.
        /// </summary>
        private void ShowExerciseSecond()
        {

        }

        /// <summary>
        /// Отображает на экране третье упражнение.
        /// </summary>
        private void ShowExerciseThree()
        {

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