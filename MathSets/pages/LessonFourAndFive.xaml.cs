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
        private List<KeyFigure> _keysAnswers = new List<KeyFigure>();
        private List<KeyFigure> _keysFigures;
        private List<Geometry> _figures;
        private Geometry _set;
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
            ShowSet(CnvQuestionFirst);
            ShowFigures(CreateAnswersQuestionFirst(), SpFigures);
            ShowFigures(CreateFiguresQuestionFirst(), CnvQuestionFirst);
            SetHandlers(CnvQuestionFirst);
        }

        /// <summary>
        /// Генерирует множество в виде эллипса
        /// </summary>
        /// <param name="panel">контейнер</param>
        private void ShowSet(Panel panel)
        {
            double sizeFigure = CnvQuestionFirst.Height * 1.5;
            double xStart = (CnvQuestionFirst.Width / 2) + (CnvQuestionFirst.Width / 2 - sizeFigure) / 2;

            _set = new Figure((int)sizeFigure, (sizeFigure + 2) * 2, CnvQuestionFirst.Width / 2).
                CreateEllipseTransformY((int)xStart, true);

            panel.Children.Clear();

            panel.Children.Add(new Path()
            {
                StrokeThickness = Base.StrokeThickness,
                Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18"),
                Data = _set
            });
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
            Figure figures = new Figure(sizeFigures, (sizeFigures + 2) * 2, SpFigures.Width);
            List<CreateFiguresDelegate> createFiguresMethods = figures.GetAllCreateFiguresMethods();
            List<KeyFigure> tempKeys = Figure.ShuffleMethods(createFiguresMethods);

            _keysAnswers.Clear();
            for (int i = 0; i < 3; i++)
            {
                _keysAnswers.Add(tempKeys[i]);
            }

            List<Geometry> listFigures = new List<Geometry>();
            int x = 10;

            for (int i = 0; i < 3; i++)
            {
                listFigures.Add(_keysAnswers[i].Method(x, true));
            }

            SpFigures.Width = listFigures.Count * sizeFigures + (listFigures.Count + 1) * x;

            return listFigures;
        }

        /// <summary>
        /// Генерирует фигуры
        /// </summary>
        /// <returns>Коллекция фигур</returns>
        private List<Geometry> CreateFiguresQuestionFirst()
        {
            int sizeFigures = 50;
            Figure figures = new Figure(sizeFigures, CnvQuestionFirst.Height, CnvQuestionFirst.Width / 2);
            List<CreateFiguresDelegate> createFiguresMethods = figures.GetAllCreateFiguresMethods();
            _keysFigures = Figure.ShuffleMethods(createFiguresMethods);

            _figures = new List<Geometry>();
            int offset = figures.GetOffset(createFiguresMethods.Count);
            int x = 0;

            for (int i = 0; i < createFiguresMethods.Count; i++)
            {
                if (i % 2 == 0)
                {
                    _figures.Add(createFiguresMethods[i](x, true)); // Положение фигуры по вертикали сверху.
                }
                else
                {
                    _figures.Add(createFiguresMethods[i](x, false)); // Положение фигуры по вертикали снизу.
                    x += offset;
                }
            }

            for (int i = 0; i < _figures.Count; i++)
            {
                _points.Add(new Point(0, 0));
            }

            return _figures;
        }

        private void SetHandlers(Panel panel)
        {
            SpFirstQuestion.MouseUp += OnMouseUp;

            for (int i = 0; i < panel.Children.Count; i++)
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































        private void ShowExerciseSecond()
        {

        }

        private void ShowExerciseThree()
        {

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Base.MainFrame.Navigate(new MainMenuPage());
        }
    }
}