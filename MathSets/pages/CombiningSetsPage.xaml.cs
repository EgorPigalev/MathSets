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

namespace MathSets.pages
{
    /// <summary>
    /// Логика взаимодействия для CombiningSetsPage.xaml
    /// </summary>
    public partial class CombiningSetsPage : Page
    {
        Random random = new Random();
        public CombiningSetsPage()
        {
            InitializeComponent();
            EllipseOne.StrokeThickness = Base.StrokeThickness;
            EllipseTwo.StrokeThickness = Base.StrokeThickness;
            EllipseGeneration ellipseGeneration = new EllipseGeneration();
            Ellipse ellipseOne = ellipseGeneration.getEllipse(random.Next(50, 200), random.Next(50, 200), random.Next(40, 100), random.Next(0, 50)); // Создание первого эллипса
            ellipseOne.MouseDown += Ellipse_MouseDown;
            Cnv.Children.Add(ellipseOne);
            Ellipse ellipseTwo = ellipseGeneration.getEllipse(random.Next(50, 200), random.Next(50, 200), random.Next(40, 100), random.Next(0, 50)); // Создание второго эллипса
            ellipseTwo.MouseDown += Ellipse_MouseDown;
            Cnv.Children.Add(ellipseTwo);
            Path combinedPath = ellipseGeneration.getUnification(ellipseOne, ellipseTwo, GeometryCombineMode.Intersect); // Создание пересечения
            combinedPath.MouseDown += Ellipse_MouseDown;
            Cnv.Children.Add(combinedPath);
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Base.MainFrame.Navigate(new MainMenuPage());
        }

        private void BtnHint_Click(object sender, RoutedEventArgs e)
        {

        }

        public void GenerationInTheCanvas()
        {

        }
    }
}
