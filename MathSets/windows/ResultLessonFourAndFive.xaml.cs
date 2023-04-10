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
                if (!indexesAndwers.Contains(i))
                {
                    cnv.Children.Add(new Path()
                    {
                        StrokeThickness = Base.StrokeThickness,
                        Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18"),
                        Data = tempList[i].Data.Clone()
                    });
                }
            }

            Figure figure = new Figure(sizeFigures, cnv.Height, cnv.Width / 2);
            List<CreateFiguresDelegate> tempCreateFiguresMethods = figure.GetAllCreateFiguresMethods();
            List<CreateFiguresDelegate> createFiguresMethods = new List<CreateFiguresDelegate>();

            for (int i = 0; i < tempCreateFiguresMethods.Count; i++)
            {
                if (indexesAndwers.Contains(i))
                {
                    createFiguresMethods.Add(tempCreateFiguresMethods[i]);
                }
            }

            List<Geometry> figures = new List<Geometry>();
            int offset = figure.GetOffset(createFiguresMethods.Count);
            int xStart = Base.StrokeThickness + (int)cnv.Width / 2;

            for (int i = 0; i < createFiguresMethods.Count; i++)
            {
                if (i % 2 == 0)
                {
                    figures.Add(createFiguresMethods[i](xStart, true));
                }
                else
                {
                    figures.Add(createFiguresMethods[i](xStart, false));
                    xStart += offset;
                }
            }

            Figure.ShowFigures(figures, cnv);

            SpResult.Children.Add(cnv);
        }

        private void Upload()
        {
            InitializeComponent();

            LbResult.Content = "Ты допустил ошибку.";

            SpResult.Children.Add(new TextBlock()
            {
                Text = "Верный ответ.",
                HorizontalAlignment = HorizontalAlignment.Center,
            });
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}