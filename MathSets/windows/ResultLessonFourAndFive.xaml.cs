using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml;

namespace MathSets.windows
{
    /// <summary>
    /// Логика взаимодействия для ResultLessonFourAndFive.xaml
    /// </summary>
    public partial class ResultLessonFourAndFive : Window
    {
        public ResultLessonFourAndFive(Canvas canvas, List<int> indexesAndwers, int sizeFigures)
        {
            InitializeComponent();

            Canvas cnv = CreateCanvasWithOneSet(canvas, indexesAndwers);

            List<Geometry> figures = GetAnswersFigures(canvas, sizeFigures, indexesAndwers);
            Figure.ShowFigures(figures, cnv);

            SpResult.Children.Add(cnv);
        }

        public ResultLessonFourAndFive(Canvas canvas, List<List<int>> indexesErrors, List<Geometry> figures)
        {
            InitializeComponent();

            Canvas cnv = CreateCanvasWithTwoSets(canvas);

            SpResult.Orientation = Orientation.Horizontal;
            SpResult.Children.Add(GetStackPanelTaskSecond(cnv, indexesErrors[0], 'A', figures));
            SpResult.Children.Add(GetStackPanelTaskSecond(cnv, indexesErrors[1], 'B', figures));

            SpResult.Children.Add(cnv);
        }

        public ResultLessonFourAndFive(StackPanel stackPanel, int sizeFigures)
        {
            InitializeComponent();

            System.IO.StringReader stringReader = new System.IO.StringReader(XamlWriter.Save(stackPanel));
            XmlReader xmlReader = XmlReader.Create(stringReader);
            StackPanel spParent = (StackPanel)XamlReader.Load(xmlReader);

            Canvas canvas = (Canvas)spParent.Children[1];

            int countIterations = canvas.Children.Count - 5;
            for (int i = 0; i < countIterations; i++) // Удаление фигур из контейнера.
            {
                canvas.Children.RemoveAt(5); // 5, так как фигуры начинаются с 5 позиции.
            }

            Figure.ShowFigures(CreateFiguresTaskSecond((StackPanel)spParent.Children[0], canvas, sizeFigures), canvas);

            SpResult.Children.Add(spParent);
        }

        /// <summary>
        /// Создание и инициализация элемента Canvas с одним множеством
        /// </summary>
        /// <param name="canvas">элемент Canvas</param>
        /// <param name="indexesAndwers">индексы верных фигур-ответов</param>
        /// <returns>элемент Canvas</returns>
        private Canvas CreateCanvasWithOneSet(Canvas canvas, List<int> indexesAndwers)
        {
            Canvas cnv = new Canvas
            {
                Width = canvas.Width,
                Height = canvas.Height
            };

            List<Path> tempList = new List<Path>();

            foreach (var item in canvas.Children)
            {
                tempList.Add((Path)item);
            }

            for (int i = 0; i < tempList.Count; i++)
            {
                if (!indexesAndwers.Contains(i - 2)) // i - 2, так как фигуры начинаются с 3 элемента.
                {
                    if (i == 0)
                    {
                        cnv.Children.Add(new Path() // Добавление названия множества
                        {
                            StrokeThickness = Base.StrokeThickness,
                            Stroke = Brushes.Black,
                            Data = tempList[i].Data.Clone()
                        });
                    }
                    else
                    {
                        cnv.Children.Add(new Path()
                        {
                            StrokeThickness = Base.StrokeThickness,
                            Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18"),
                            Data = tempList[i].Data.Clone()
                        });
                    }
                }
            }

            return cnv;
        }

        /// <summary>
        /// Создаёт фигуры-ответы
        /// </summary>
        /// <param name="canvas">контейнер</param>
        /// <param name="size">размер фигур</param>
        /// <param name="indexesAndwers">индексы фигур-ответов</param>
        /// <returns>Список фигур-ответов</returns>
        private List<Geometry> GetAnswersFigures(Canvas canvas, int size, List<int> indexesAndwers)
        {
            Figure figure = new Figure(size, canvas.Height, canvas.Width / 2);
            List<CreateFiguresDelegate> createFiguresMethods = figure.GetAllCreateFiguresMethods();

            List<Geometry> figures = new List<Geometry>();

            while (true)
            {
                int xStart = Base.StrokeThickness + (int)canvas.Width / 2 + size * 2;

                for (int i = 0; i < indexesAndwers.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        figures.Add(createFiguresMethods[indexesAndwers[i]](xStart, true));
                        figures[i].Transform = new TranslateTransform(0, size / 4); // Для смещения немного вниз от верхней границы множества.
                    }
                    else
                    {
                        figures.Add(createFiguresMethods[indexesAndwers[i]](xStart, false));
                        figures[i].Transform = new TranslateTransform(0, -size / 4); // Для смещения немного вверх от нижней границы множества.
                        xStart += size * 2;
                    }
                }

                if (!Figure.CheckIntersectionsFiguresAndSets(figures, new List<Geometry>() { ((Path)canvas.Children[1]).Data }))
                {
                    break;
                }

                figures.Clear();
            }

            return figures;
        }

        /// <summary>
        /// Создание и инициализация элемента Canvas с двумя множествами
        /// </summary>
        /// <param name="canvas">элемент Canvas</param>
        /// <returns>элемент Canvas</returns>
        private Canvas CreateCanvasWithTwoSets(Canvas canvas)
        {
            Canvas cnv = new Canvas
            {
                Width = canvas.Width,
                Height = canvas.Height
            };

            List<Path> tempList = new List<Path>();

            foreach (Path item in canvas.Children)
            {
                tempList.Add(item);
            }

            for (int i = 0; i < tempList.Count; i++)
            {
                if (i == 0 || i == 1)
                {
                    cnv.Children.Add(new Path() // Добавление названия множества
                    {
                        StrokeThickness = Base.StrokeThickness,
                        Stroke = Brushes.Black,
                        Data = tempList[i].Data.Clone()
                    });
                }
                else
                {
                    cnv.Children.Add(new Path()
                    {
                        StrokeThickness = Base.StrokeThickness,
                        Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18"),
                        Data = tempList[i].Data.Clone()
                    });
                }
            }

            return cnv;
        }

        private StackPanel GetStackPanelTaskSecond(Canvas canvas, List<int> indexesErrors, char set, List<Geometry> figures)
        {
            StackPanel panelParent = new StackPanel();

            if (set == 'A')
            {
                panelParent.Margin = new Thickness(0, 0, 30, 0);
            }

            for (int i = 0; i < figures.Count; i++)
            {
                StackPanel sp = new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(0, 10, 0, 10),
                    Background = indexesErrors.Contains(i) ? Brushes.PaleVioletRed : Brushes.White
                };

                sp.Children.Add(new TextBlock() // Цифра.
                {
                    Text = (i + 1).ToString(),
                    FontFamily = new FontFamily(Base.FontFamily),
                    Width = 20,
                    Margin = new Thickness(0, 0, 10, 0),
                    VerticalAlignment = VerticalAlignment.Center
                });

                Path p = (Path)canvas.Children[set == 'A' ? 2 : 3];

                sp.Children.Add(new TextBlock() // Знак "принадлежит" или "не принадлежит",
                {
                    Text = p.Data.FillContainsWithDetail(figures[i]) == IntersectionDetail.FullyContains ? "∈" : "∉",
                    FontFamily = new FontFamily(Base.FontFamily),
                    Margin = new Thickness(0, 0, 10, 0),
                    VerticalAlignment = VerticalAlignment.Center
                });

                sp.Children.Add(new TextBlock() // Наименование множества.
                {
                    Text = set.ToString(),
                    FontFamily = new FontFamily(Base.FontFamily),
                    Margin = new Thickness(0, 0, 10, 0),
                    VerticalAlignment = VerticalAlignment.Center
                });

                panelParent.Children.Add(sp);
            }

            return panelParent;
        }

        /// <summary>
        /// Создаёт фигуры для второго задания.
        /// </summary>
        /// <param name="spCondition">StackPanel условий (принадлежит или нет)</param>
        /// <param name="canvas">контейнер</param>
        /// <param name="sizeFigures">размер фигур</param>
        /// <returns>Список фигур</returns>
        private List<Geometry> CreateFiguresTaskSecond(StackPanel spCondition, Canvas canvas, int sizeFigures)
        {
            EllipseGeometry setA = (EllipseGeometry)((Path)canvas.Children[2]).Data;
            EllipseGeometry setB = (EllipseGeometry)((Path)canvas.Children[3]).Data;
            Point centerSetIntersect = new Point(setA.Center.X + (setB.Center.X - setA.Center.X) / 2, setA.Center.Y);

            Figure figure = new Figure(sizeFigures, canvas.Height, canvas.Width);
            List<Geometry> figures = new List<Geometry>();

            List<int> countFiguresInSets = new List<int>() { 0, 0, 0, 0 }; // Индексы: 0 - множество А, 1 - множество В, 2 - пересечение А и В, 3 - фигуры без множества.

            for (int i = 0; i < ((StackPanel)spCondition.Children[0]).Children.Count; i++)
            {
                StackPanel spSetA = (StackPanel)((StackPanel)spCondition.Children[0]).Children[i]; // Условия множества A.
                StackPanel spSetB = (StackPanel)((StackPanel)spCondition.Children[1]).Children[i]; // Условия множества B.

                if (((TextBlock)spSetA.Children[1]).Text == "∈" && ((TextBlock)spSetB.Children[1]).Text == "∈") // Фигура принадлежит пересечению множеств.
                {
                    figures.Add(figure.GetGeometryFromText
                    (
                        (i + 1).ToString(),
                        (int)centerSetIntersect.X - sizeFigures/3,
                        Convert.ToInt32(centerSetIntersect.Y - setA.RadiusY *0.6 + countFiguresInSets[2] * (sizeFigures + 10))
                    ));
                    countFiguresInSets[2]++;
                }
                else if (((TextBlock)spSetA.Children[1]).Text == "∈") // Фигура принадлежит множеству А.
                {
                    if (countFiguresInSets[0] == 1)
                    {
                        figures.Add(figure.GetGeometryFromText
                        (
                            (i + 1).ToString(),
                            Convert.ToInt32(setA.Center.X - setA.RadiusX + sizeFigures / 2),
                            (int)setA.Center.Y - (int)setA.RadiusY / 2 + countFiguresInSets[0] * (sizeFigures + 10)
                        ));
                    }
                    else
                    {
                        figures.Add(figure.GetGeometryFromText
                        (
                            (i + 1).ToString(),
                            Convert.ToInt32(setA.Center.X - setA.RadiusX + sizeFigures * 1.5),
                            (int)setA.Center.Y - (int)setA.RadiusY / 2 + countFiguresInSets[0] * (sizeFigures + 10)
                        ));
                    }
                    countFiguresInSets[0]++;
                }
                else if (((TextBlock)spSetB.Children[1]).Text == "∈") // Фигура принадлежит множеству В.
                {
                    if (countFiguresInSets[1] == 1)
                    {
                        figures.Add(figure.GetGeometryFromText
                        (
                            (i + 1).ToString(),
                            Convert.ToInt32(setB.Center.X + setB.RadiusX - sizeFigures * 1.1),
                            (int)setB.Center.Y - (int)setB.RadiusY / 2 + countFiguresInSets[1] * (sizeFigures + 10)
                        ));
                    }
                    else
                    {
                        figures.Add(figure.GetGeometryFromText
                        (
                            (i + 1).ToString(),
                            Convert.ToInt32(setB.Center.X + setB.RadiusX - sizeFigures * 2),
                            (int)setB.Center.Y - (int)setB.RadiusY / 2 + countFiguresInSets[1] * (sizeFigures + 10)
                        ));
                    }
                    countFiguresInSets[1]++;
                }
                else // Фигура не принадлежит множествам А и В.
                {
                    figures.Add(figure.GetGeometryFromText
                    (
                        (i + 1).ToString(),
                        Convert.ToInt32(setA.Center.X + countFiguresInSets[3] * (sizeFigures + 10)),
                        (int)setA.Center.Y + (int)setA.RadiusY + 40
                    ));
                    countFiguresInSets[3]++;
                }
            }

            return figures;
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}