using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MathSets.windows;

namespace MathSets.pages
{
    /// <summary>
    /// Логика взаимодействия для LessonSix.xaml
    /// </summary>
    public partial class LessonSix : Page
    {
        private Random _random = new Random();

        public LessonSix()
        {
            InitializeComponent();

            ShowTaskFirst();
        }

        private void ShowTaskFirst()
        {
            GridTaskFirst.Children.Clear();
            GridTaskFirst.ColumnDefinitions.Clear();
            GridTaskFirst.RowDefinitions.Clear();

            GridTaskFirst.ColumnDefinitions.Add(new ColumnDefinition());
            GridTaskFirst.ColumnDefinitions.Add(new ColumnDefinition());
            GridTaskFirst.RowDefinitions.Add(new RowDefinition());
            GridTaskFirst.RowDefinitions.Add(new RowDefinition());

            int countDefinitions = 2;

            GridTaskFirst.Children.Add(new Path()
            {
                StrokeThickness = Base.StrokeThickness,
                Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18"),
                Data = CreateEllipse((int)GridTaskFirst.Width / countDefinitions, (int)GridTaskFirst.Height / countDefinitions)
            });

            GridTaskFirst.Children.Add(new Path()
            {
                StrokeThickness = Base.StrokeThickness,
                Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18"),
                Data = CreateEllipse((int)GridTaskFirst.Width / countDefinitions, (int)GridTaskFirst.Height / countDefinitions)
            });
        }

        /// <summary>
        /// Создаёт эллипс
        /// </summary>
        /// <param name="maxWidth">максимальная ширина</param>
        /// <param name="maxHeight">максимальная высота</param>
        /// <returns>Эллипс</returns>
        private Geometry CreateEllipse(int maxWidth, int maxHeight)
        {
            int minSize = 50;
            int centerX = _random.Next(minSize, maxWidth - minSize);
            int centerY = _random.Next(minSize, maxHeight - minSize);

            while (true)
            {
                EllipseGeometry g = new EllipseGeometry
                (
                    new Point
                    (
                        centerX,
                        centerY
                    ),
                    _random.Next(minSize, maxWidth) / 2,
                    _random.Next(minSize, maxHeight - minSize) / 2
                );

                if (g.Center.X >= g.RadiusX && maxWidth - g.Center.X >= g.RadiusX)
                {
                    if (g.Center.Y >= g.RadiusY && maxHeight - g.Center.Y >= g.RadiusY)
                    {
                        return g;
                    }
                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Base.MainFrame.Navigate(new MainMenuPage());
        }

        private void BtnCheckQuestionFirst_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCheckTaskFirst_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnHint_Click(object sender, RoutedEventArgs e)
        {

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
                    ShowTaskFirst();
                    break;
                case 2:
                    //ShowExerciseSecond();
                    break;
                case 3:
                    //ShowExerciseThree();
                    break;
                default:
                    break;
            }
        }
    }
}
