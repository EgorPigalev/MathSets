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
using System.Windows.Shapes;

namespace MathSets.windows
{
    /// <summary>
    /// Логика взаимодействия для HintCombiningSetsWindow.xaml
    /// </summary>
    public partial class HintCombiningSetsWindow : Window
    {
        public HintCombiningSetsWindow()
        {
            InitializeComponent();
            EllipseGeneration ellipseGeneration = new EllipseGeneration();
            Path combinedPath = ellipseGeneration.getUnification(EllipseOne, EllipseTwo, GeometryCombineMode.Intersect);
            combinedPath.Stroke = Brushes.White;
            Cnv.Children.Add(combinedPath);
            Ellipse ellipseOne = ellipseGeneration.getEllipse(180, 120, 20, 20);
            Ellipse ellipseTwo = ellipseGeneration.getEllipse(250, 150, 140, 10);
            ellipseOne.StrokeThickness = Base.StrokeThickness;
            ellipseTwo.StrokeThickness = Base.StrokeThickness;
            Cnv.Children.Add(ellipseOne);
            Cnv.Children.Add(ellipseTwo);
            Path combinedPath1 = ellipseGeneration.getUnification(ellipseOne, ellipseTwo, GeometryCombineMode.Intersect);
            Cnv.Children.Add(combinedPath1);

            Ellipse ellipsePoint1 = ellipseGeneration.getEllipse(5, 5, 50, 80);
            Ellipse ellipsePoint2 = ellipseGeneration.getEllipse(5, 5, 160, 50);
            Ellipse ellipsePoint3 = ellipseGeneration.getEllipse(5, 5, 170, 80);
            Ellipse ellipsePoint4 = ellipseGeneration.getEllipse(5, 5, 250, 50);
            Ellipse ellipsePoint5 = ellipseGeneration.getEllipse(5, 5, 300, 90);
            ellipsePoint1.Fill = Brushes.Black;
            ellipsePoint2.Fill = Brushes.Black;
            ellipsePoint3.Fill = Brushes.Black;
            ellipsePoint4.Fill = Brushes.Black;
            ellipsePoint5.Fill = Brushes.Black;
            Cnv.Children.Add(ellipsePoint1);
            Cnv.Children.Add(ellipsePoint2);
            Cnv.Children.Add(ellipsePoint3);
            Cnv.Children.Add(ellipsePoint4);
            Cnv.Children.Add(ellipsePoint5);

            TextBlock tbM = new TextBlock()
            {
                Text = "m",
                Margin = new Thickness(50,80,0,0)
            };
            Cnv.Children.Add(tbM);

            TextBlock tb7 = new TextBlock()
            {
                Text = "7",
                Margin = new Thickness(170, 80, 0, 0)
            };
            Cnv.Children.Add(tb7);

            TextBlock tbB = new TextBlock()
            {
                Text = "b",
                Margin = new Thickness(300, 90, 0, 0)
            };
            Cnv.Children.Add(tbB);

            PointCollection pointCollectionTriangle = new PointCollection();
            pointCollectionTriangle.Add(new Point(0, 15));
            pointCollectionTriangle.Add(new Point(10, 0));
            pointCollectionTriangle.Add(new Point(20, 15));

            Polygon triangle = new Polygon();
            triangle.Points = pointCollectionTriangle;
            triangle.Stroke = Brushes.Black;
            triangle.Margin = new Thickness(250, 50, 0, 0);
            Cnv.Children.Add(triangle);

            PointCollection pointCollectionStar = new PointCollection();
            pointCollectionStar.Add(new Point(0, 11));
            pointCollectionStar.Add(new Point(30, 11));
            pointCollectionStar.Add(new Point(5, 25));
            pointCollectionStar.Add(new Point(15, 0));
            pointCollectionStar.Add(new Point(24, 25));

            Polygon star = new Polygon();
            star.Points = pointCollectionStar;
            star.Fill = Brushes.Yellow;
            star.Margin = new Thickness(152, 50, 0, 0);
            star.FillRule = FillRule.Nonzero;
            Cnv.Children.Add(star);

        }
    }
}
