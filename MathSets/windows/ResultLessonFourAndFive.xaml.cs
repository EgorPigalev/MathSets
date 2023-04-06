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
        public ResultLessonFourAndFive(Canvas canvas, List<int> indexesAndwers)
        {
            InitializeComponent();

            LbResult.Content = "Ты допустил ошибку. Окно не готово пока";

            SpResult.Children.Add(new TextBlock()
            {
                Text = "Верный ответ.",
                HorizontalAlignment = HorizontalAlignment.Center,
            });

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

            foreach (var item in tempList)
            {
                cnv.Children.Add(new Path()
                {
                    StrokeThickness = Base.StrokeThickness,
                    Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18"),
                    Data = item.Data.Clone()
                });
            }

            SpResult.Children.Add(cnv);
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}