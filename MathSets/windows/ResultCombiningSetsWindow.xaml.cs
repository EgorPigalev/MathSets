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
    /// Логика взаимодействия для ResultCombiningSetsWindow.xaml
    /// </summary>
    public partial class ResultCombiningSetsWindow : Window
    {
        EllipseGeneration ellipseGeneration = new EllipseGeneration();
        public ResultCombiningSetsWindow(Canvas canvas, Ellipse ellipseOne, Ellipse ellipseTwo, Path combinedPath, int numberAnswer)
        {
            InitializeComponent();
            Canvas newCanvas = new Canvas()
            {
                Width = canvas.Width,
                Height = canvas.Width,
                Margin = canvas.Margin
            };

            Ellipse ellipseOneNew = new Ellipse()
            {
                Width = ellipseOne.Width,
                Height = ellipseOne.Height,
                Margin = ellipseOne.Margin,
                Stroke = ellipseOne.Stroke,
                StrokeThickness = ellipseOne.StrokeThickness
            };
            newCanvas.Children.Add(ellipseOneNew);

            Ellipse ellipseTwoNew = new Ellipse()
            {
                Width = ellipseTwo.Width,
                Height = ellipseTwo.Height,
                Margin = ellipseTwo.Margin,
                Stroke = ellipseTwo.Stroke,
                StrokeThickness = ellipseTwo.StrokeThickness
            };
            newCanvas.Children.Add(ellipseTwoNew);

            Path pathNew = ellipseGeneration.getUnification(ellipseOneNew, ellipseTwoNew, GeometryCombineMode.Intersect);
            newCanvas.Children.Add(pathNew);

            TextBlock tbA = new TextBlock()
            {
                Text = "A",
                Margin = new Thickness(5, 0, 0, 0)
            };
            newCanvas.Children.Add(tbA);
            TextBlock tbB = new TextBlock()
            {
                Text = "B",
                Margin = new Thickness(400, 0, 0, 0)
            };
            newCanvas.Children.Add(tbB);

            SpResult.Children.Add(newCanvas);

            switch(numberAnswer)
            {
                case 0:
                    ellipseOneNew.Fill = Brushes.White;
                    ellipseTwoNew.Fill = Brushes.White;
                    pathNew.Fill = Brushes.Yellow;
                    break;
                case 1:
                    ellipseOneNew.Fill = Brushes.Yellow;
                    ellipseTwoNew.Fill = Brushes.Yellow;
                    pathNew.Fill = Brushes.Yellow;
                    break;
                case 2:
                    ellipseOneNew.Fill = Brushes.Yellow;
                    ellipseTwoNew.Fill = Brushes.White;
                    pathNew.Fill = Brushes.Yellow;
                    break;
                case 3:
                    ellipseOneNew.Fill = Brushes.White;
                    ellipseTwoNew.Fill = Brushes.Yellow;
                    pathNew.Fill = Brushes.Yellow;
                    break;
            }
        }

        public ResultCombiningSetsWindow(Canvas canvas)
        {
            InitializeComponent();
          
        }

        public ResultCombiningSetsWindow(string answerOne, string answerTwo)
        {
            InitializeComponent();

            TextBlock tbA = new TextBlock()
            {
                Text = answerOne
                
            };
            SpResult.Children.Add(tbA);
            TextBlock tbB = new TextBlock()
            {
                Text = answerTwo
                
            };
            SpResult.Children.Add(tbB);
        }


        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
