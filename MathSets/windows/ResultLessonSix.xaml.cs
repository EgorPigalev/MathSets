using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml;

namespace MathSets.windows
{
    /// <summary>
    /// Логика взаимодействия для ResultLessonSix.xaml
    /// </summary>
    public partial class ResultLessonSix : Window
    {
        public ResultLessonSix(Grid grid, List<Geometry> figures)
        {
            InitializeComponent();

            StringReader stringReader = new StringReader(XamlWriter.Save(grid));
            XmlReader xmlReader = XmlReader.Create(stringReader);
            Grid newGrid = (Grid)XamlReader.Load(xmlReader);

            UploadGridTaskFirst(newGrid, figures);

            SpResult.Children.Add(newGrid);
        }

        public ResultLessonSix(Canvas canvas, List<int> indexesAnswersSetA, List<int> indexesAnswersSetB, int sizeFigures)
        {
            InitializeComponent();

            StringReader stringReader = new StringReader(XamlWriter.Save(canvas));
            XmlReader xmlReader = XmlReader.Create(stringReader);
            Canvas newCanvas = (Canvas)XamlReader.Load(xmlReader);

            for (int i = 4; i < newCanvas.Children.Count; i++) // i = 4, так как фигуры начинаются с 4 позиции.
            {
                newCanvas.Children.RemoveAt(4);
            }

            DeleteDuplicateIndexesFigures(ref indexesAnswersSetA, indexesAnswersSetB);

            List<Geometry> figuresSetB = GetAnswersFiguresSetB(((System.Windows.Shapes.Path)canvas.Children[3]).Data, sizeFigures, indexesAnswersSetB);
            List<Geometry> figuresSetA;

            while (true)
            {
                figuresSetA = GetAnswersFiguresSetA(((System.Windows.Shapes.Path)canvas.Children[2]).Data, sizeFigures, indexesAnswersSetA);

                if (!Figure.CheckIntersectionsFiguresAndSets(figuresSetA, new List<Geometry>() { ((System.Windows.Shapes.Path)canvas.Children[3]).Data }))
                {
                    break;
                }

                figuresSetA.Clear();
            }

            Figure.ShowFigures(figuresSetA, newCanvas);
            Figure.ShowFigures(figuresSetB, newCanvas);

            SpResult.Children.Add(newCanvas);
        }

        /// <summary>
        /// Устанавливает содержимое Grid для первого задания
        /// </summary>
        /// <param name="grid">контейнер Grid</param>
        /// <param name="figures">список фигур (множеств)</param>
        private void UploadGridTaskFirst(Grid grid, List<Geometry> figures)
        {
            int indexFigure = 0;

            for (int i = grid.Children.Count - 4; i < grid.Children.Count; i++)
            {
                StackPanel sp = (StackPanel)grid.Children[i];
                Button btnIsThere = (Button)sp.Children[0];
                Button btNot = (Button)sp.Children[1];

                if (figures[indexFigure].FillContainsWithDetail(figures[indexFigure + 1]) == IntersectionDetail.FullyContains)
                {
                    btnIsThere.Background = (SolidColorBrush)Application.Current.Resources["SecondaryColor"];
                    btnIsThere.Foreground = Brushes.White;
                    btNot.Background = (SolidColorBrush)Application.Current.Resources["PrimaryColor"];
                    btNot.Foreground = Brushes.Black;
                }
                else
                {
                    btNot.Background = (SolidColorBrush)Application.Current.Resources["SecondaryColor"];
                    btNot.Foreground = Brushes.White;
                    btnIsThere.Background = (SolidColorBrush)Application.Current.Resources["PrimaryColor"];
                    btnIsThere.Foreground = Brushes.Black;
                }

                indexFigure += 2;
            }
        }

        /// <summary>
        /// Удаляет повторяющиеся индексы фигур со списком indexesAnswersSetB из списка индексов indexesAnswersSetA
        /// </summary>
        /// <param name="indexesAnswersSetA">индексы фигур-ответов для первого множества</param>
        /// <param name="indexesAnswersSetB">индексы фигур-ответов для второго множества</param>
        private void DeleteDuplicateIndexesFigures(ref List<int> indexesAnswersSetA, List<int> indexesAnswersSetB)
        {
            bool isCollectionWithoutDuplicates = true;

            foreach (int item in indexesAnswersSetA)
            {
                if (indexesAnswersSetB.Contains(item))
                {
                    isCollectionWithoutDuplicates = false;
                    break;
                }
            }

            if (isCollectionWithoutDuplicates)
            {
                return;
            }

            List<int> indexes = new List<int>();

            foreach (int item in indexesAnswersSetB)
            {
                if (indexesAnswersSetA.Contains(item))
                {
                    indexes.Add(item);
                }
            }

            foreach (int item in indexes)
            {
                indexesAnswersSetA.Remove(item);
            }
        }

        /// <summary>
        /// Создаёт фигуры-ответы
        /// </summary>
        /// <param name="set">множество</param>
        /// <param name="size">размер фигур</param>
        /// <param name="indexesAndwers">индексы фигур-ответов</param>
        /// <returns>Список фигур-ответов</returns>
        private List<Geometry> GetAnswersFiguresSetB(Geometry set, int size, List<int> indexesAndwers)
        {
            EllipseGeometry ellipse = (EllipseGeometry)set;

            Figure figure = new Figure(size, ellipse.RadiusY * 2, ellipse.RadiusX * 2);
            List<CreateFiguresDelegate> createFiguresMethods = figure.GetAllCreateFiguresMethods();

            List<Geometry> figures = new List<Geometry>();

            while (true)
            {
                int xStart = Base.StrokeThickness + (int)(ellipse.Center.X - ellipse.RadiusX + size / 2);

                for (int i = 0; i < indexesAndwers.Count; i++)
                {
                    figures.Add(createFiguresMethods[indexesAndwers[i]](xStart, true));
                    xStart += size * 2;

                    figures[i].Transform = new TranslateTransform(0, ellipse.Center.Y - ellipse.RadiusY + size); // Для смещения фигуры вниз (так как начальный Y не задаётся).
                }

                if (!Figure.CheckIntersectionsFiguresAndSets(figures, new List<Geometry>() { set }))
                {
                    break;
                }

                figures.Clear();
            }

            return figures;
        }

        /// <summary>
        /// Создаёт фигуры-ответы
        /// </summary>
        /// <param name="set">множество</param>
        /// <param name="size">размер фигур</param>
        /// <param name="indexesAndwers">индексы фигур-ответов</param>
        /// <returns>Список фигур-ответов</returns>
        private List<Geometry> GetAnswersFiguresSetA(Geometry set, int size, List<int> indexesAndwers)
        {
            EllipseGeometry ellipse = (EllipseGeometry)set;

            Figure figure = new Figure(size, ellipse.RadiusY * 2, ellipse.RadiusX * 2);
            List<CreateFiguresDelegate> createFiguresMethods = figure.GetAllCreateFiguresMethods();

            List<Geometry> figures = new List<Geometry>();

            while (true)
            {
                int xStart = Base.StrokeThickness + (int)(ellipse.Center.X - ellipse.RadiusX + size * 2);

                for (int i = 0; i < indexesAndwers.Count; i++)
                {
                    figures.Add(createFiguresMethods[indexesAndwers[i]](xStart, false));
                    xStart += size * 2;
                }

                if (!Figure.CheckIntersectionsFiguresAndSets(figures, new List<Geometry>() { set }))
                {
                    break;
                }

                figures.Clear();
            }

            return figures;
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}