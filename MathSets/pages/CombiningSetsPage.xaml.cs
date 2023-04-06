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
        Ellipse ellipseOne;
        Ellipse ellipseTwo;
        Path combinedPath;
        int n = 0;
        public CombiningSetsPage()
        {
            InitializeComponent();
            
            EllipseGeneration ellipseGeneration = new EllipseGeneration();
            ellipseOne = ellipseGeneration.getEllipse(300, 150, 0, 10); // Создание первого эллипса
            ellipseOne.MouseDown += Ellipse_MouseDown;
            Cnv.Children.Add(ellipseOne);
            ellipseTwo = ellipseGeneration.getEllipse(300, 150, 150, 10); // Создание второго эллипса
            ellipseTwo.MouseDown += Ellipse_MouseDown;
            Cnv.Children.Add(ellipseTwo);
            combinedPath = ellipseGeneration.getUnification(ellipseOne, ellipseTwo, GeometryCombineMode.Intersect); // Создание пересечения
            combinedPath.MouseDown += Ellipse_MouseDown;
            Cnv.Children.Add(combinedPath);
            ellipseOne.StrokeThickness = Base.StrokeThickness;
            ellipseTwo.StrokeThickness = Base.StrokeThickness;
            TextBlock tbA = new TextBlock()
            {
                Text = "A",
                Margin = new Thickness(5,0,0,0)
            };
            Cnv.Children.Add(tbA);
            TextBlock tbB = new TextBlock()
            {
                Text = "B",
                Margin = new Thickness(400, 0, 0, 0)
            };
            Cnv.Children.Add(tbB);


            GenerationCondition();
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (typeof(Ellipse) == sender.GetType()) // Если нажали на эллипс, то его закрашиваем
            {
                Ellipse ellipse = sender as Ellipse;
                if (ellipse.Fill == Brushes.Yellow) // Если уже закрашен, то возвращаем обратно белый фон
                {
                    ellipse.Fill = Brushes.White;
                }
                else
                {
                    ellipse.Fill = Brushes.Yellow;
                }
            }
            else // Если нажали не на эллипс
            {
                Path ellipse = sender as Path;
                if (ellipse.Fill == Brushes.Yellow) // Если уже закрашен, то возвращаем обратно белый фон
                {
                    ellipse.Fill = Brushes.White;
                }
                else
                {
                    ellipse.Fill = Brushes.Yellow;
                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Base.MainFrame.Navigate(new MainMenuPage());
        }

        private void BtnHint_Click(object sender, RoutedEventArgs e)
        {

        }

        public void GenerationCondition()
        {
            n = random.Next(4);
            switch(n)
            {
                case 0:
                    TbCondition.Text = "Закрась A ∩ B.";
                    break;
                case 1:
                    TbCondition.Text = "Закрась A ∪ B.";
                    break;
                case 2:
                    TbCondition.Text = "Закрась множество А.";
                    break;
                case 3:
                    TbCondition.Text = "Закрась множество В.";
                    break;
            }
            for(int i=0; i>8;i++)
            {

            }

            TbCondition2.Text = "Даны множества А {";
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            switch (n)
            {
                case 0:
                    if(ellipseOne.Fill == Brushes.White && ellipseTwo.Fill == Brushes.White && combinedPath.Fill == Brushes.Yellow)
                    {
                        windows.CorrectResult correctResult = new windows.CorrectResult();
                        correctResult.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Неправильно!");
                    }
                    break;
                case 1:
                    if (ellipseOne.Fill == Brushes.Yellow && ellipseTwo.Fill == Brushes.Yellow && combinedPath.Fill == Brushes.Yellow)
                    {
                        windows.CorrectResult correctResult = new windows.CorrectResult();
                        correctResult.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Неправильно!");
                    }
                    break;
                case 2:
                    if (ellipseOne.Fill == Brushes.Yellow && ellipseTwo.Fill == Brushes.White && combinedPath.Fill == Brushes.Yellow)
                    {
                        windows.CorrectResult correctResult = new windows.CorrectResult();
                        correctResult.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Неправильно!");
                    }
                    break;
                case 3:
                    if (ellipseOne.Fill == Brushes.White && ellipseTwo.Fill == Brushes.Yellow && combinedPath.Fill == Brushes.Yellow)
                    {
                        windows.CorrectResult correctResult = new windows.CorrectResult();
                        correctResult.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Неправильно!");
                    }
                    break;
            }
        }
    }
}
