using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MathSets.windows
{
    /// <summary>
    /// Логика взаимодействия для ResultLessonFourAndFive.xaml
    /// </summary>
    public partial class ResultLessonFourAndFive : Window
    {
        public ResultLessonFourAndFive(Canvas canvas, List<int> indexesAndwers, int sizeFigures)
        {
            Upload();

            Canvas cnv = CreateCanvasWithOneSet(canvas, indexesAndwers);

            List<Geometry> figures = GetAnswersFigures(canvas, sizeFigures, indexesAndwers);
            Figure.ShowFigures(figures, cnv);

            SpResult.Children.Add(cnv);
        }

        public ResultLessonFourAndFive(Canvas canvas, List<List<int>> indexesErrors, List<Geometry> figures)
        {
            Upload();

            Canvas cnv = CreateCanvasWithTwoSets(canvas);

            SpResult.Orientation = Orientation.Horizontal;
            SpResult.Children.Add(GetStackPanelTaskSecond(cnv, indexesErrors[0], 'A', figures));
            SpResult.Children.Add(GetStackPanelTaskSecond(cnv, indexesErrors[1], 'B', figures));

            SpResult.Children.Add(cnv);
        }

        public ResultLessonFourAndFive(Canvas canvas, StackPanel stackPanel, int sizeFigures)
        {
            Upload();

            Canvas cnv = CreateCanvasWithTwoSets(canvas);

            List<Geometry> figures = new List<Geometry>();
            for (int i = 0; i < cnv.Children.Count + 1; i++) // + 1, чтобы захватить индекс 4.
            {
                figures.Add(((Path)cnv.Children[4]).Data.Clone()); // 4, так как фигуры начинаются с 3 от 0 позиции.
                cnv.Children.RemoveAt(4);
            }

            SpResult.Orientation = Orientation.Horizontal;
            StackPanel spCondition = CopyStackPanel(stackPanel);
            SpResult.Children.Add(spCondition);

            double xStart = Base.StrokeThickness + (canvas.Width - canvas.Width / 2 + 100 - 100 * 2) / 2;
            CreateFiguresTaskSecond((StackPanel)spCondition.Children[0], cnv, xStart);
            CreateFiguresTaskSecond((StackPanel)spCondition.Children[1], cnv, xStart);

            SpResult.Children.Add(cnv);
        }

        private void Upload()
        {
            InitializeComponent();

            LbResult.Content = "Ты допустил ошибку.";
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

        private List<Geometry> GetAnswersFigures(Canvas canvas, int size, List<int> indexesAndwers)
        {
            Figure figure = new Figure(size, canvas.Height, canvas.Width / 2);
            List<CreateFiguresDelegate> createFiguresMethods = figure.GetAllCreateFiguresMethods();

            List<Geometry> figures = new List<Geometry>();
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

        private StackPanel CopyStackPanel(StackPanel spSource)
        {
            StackPanel sp = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 0, 30, 0)
            };

            foreach (StackPanel spSet in spSource.Children)
            {
                StackPanel newSpSet = new StackPanel();
                newSpSet.Orientation = spSet.Orientation;
                sp.Children.Add(newSpSet);

                foreach (StackPanel spRowSet in spSet.Children)
                {
                    StackPanel newSpRowSet = new StackPanel();
                    newSpRowSet.Orientation = spRowSet.Orientation;
                    newSpSet.Children.Add(newSpRowSet);

                    foreach (TextBlock tb in spRowSet.Children)
                    {
                        TextBlock newTb = new TextBlock()
                        {
                            Text = tb.Text,
                            FontFamily = tb.FontFamily,
                            Width = tb.Width,
                            Margin = tb.Margin,
                            VerticalAlignment = tb.VerticalAlignment
                        };
                        newSpRowSet.Children.Add(newTb);
                    }
                }
            }

            return sp;
        }

        private List<Geometry> CreateFiguresTaskSecond(StackPanel spParent, Canvas canvas, double x)
        {
            //for (int i = 0; i < sets.Count; i++)
            //{
            //    sets[i].Transform = new TranslateTransform(0, (panel.Height - sizeFigure / 1.5) / 2); // 1.5, потому что одна ось меньше другой в 1.5 раза.
            //}

            int sizeFigures = (int)(canvas.Height * 0.7 * 1.5 - Base.StrokeThickness * 2);
            Figure figure = new Figure(sizeFigures, canvas.Height, canvas.Width);
            List<Geometry> figures = new List<Geometry>();

            foreach (StackPanel sp in spParent.Children)
            {
                if (((TextBlock)sp.Children[1]).Text == "∈")
                {
                    figures.Add(figure.GetGeometryFromText((i + 1).ToString()));
                }
                else
                {

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