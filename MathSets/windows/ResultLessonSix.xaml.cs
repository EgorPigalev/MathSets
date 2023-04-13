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
        public ResultLessonSix(string gridString, List<Geometry> figures)
        {
            InitializeComponent();

            StringReader stringReader = new StringReader(gridString);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            Grid grid = (Grid)XamlReader.Load(xmlReader);

            UploadGridTaskFirst(grid, figures);

            SpResult.Children.Add(grid);
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

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}