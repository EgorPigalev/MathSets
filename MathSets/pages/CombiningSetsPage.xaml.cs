using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MathSets.pages
{
    /// <summary>
    /// Логика взаимодействия для CombiningSetsPage.xaml
    /// </summary>
    public partial class CombiningSetsPage : Page
    {
        Random random = new Random();
        EllipseGeneration ellipseGeneration = new EllipseGeneration();
        Ellipse ellipseOne;
        Ellipse ellipseTwo;
        Path combinedPath;
        int n = 0;
        public CombiningSetsPage()
        {
            InitializeComponent();

            GenerationCondition();
            GenerationCondition2();
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (typeof(Ellipse) == sender.GetType())
            {
                Ellipse ellipse = sender as Ellipse;
                if (ellipse.Fill == Brushes.Yellow)
                {
                    ellipse.Fill = Brushes.White;
                }
                else
                {
                    ellipse.Fill = Brushes.Yellow;
                }
            }
            else
            {
                Path ellipse = sender as Path;
                if (ellipse.Fill == Brushes.Yellow)
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
            windows.HintCombiningSetsWindow hintCombiningSetsWindow = new windows.HintCombiningSetsWindow();
            hintCombiningSetsWindow.ShowDialog();
        }

        /// <summary>
        /// Генерация 1 задания
        /// </summary>
        public void GenerationCondition()
        {           
            ellipseOne = ellipseGeneration.getEllipse(300, 150, 0, 10);
            ellipseOne.MouseDown += Ellipse_MouseDown;
            Cnv.Children.Add(ellipseOne);
            ellipseTwo = ellipseGeneration.getEllipse(300, 150, 150, 10);
            ellipseTwo.MouseDown += Ellipse_MouseDown;
            Cnv.Children.Add(ellipseTwo);
            combinedPath = ellipseGeneration.getUnification(ellipseOne, ellipseTwo, GeometryCombineMode.Intersect);
            combinedPath.MouseDown += Ellipse_MouseDown;
            Cnv.Children.Add(combinedPath);
            ellipseOne.StrokeThickness = Base.StrokeThickness;
            ellipseTwo.StrokeThickness = Base.StrokeThickness;
            TextBlock tbA = new TextBlock()
            {
                Text = "A",
                Margin = new Thickness(5, 0, 0, 0)
            };
            Cnv.Children.Add(tbA);
            TextBlock tbB = new TextBlock()
            {
                Text = "B",
                Margin = new Thickness(400, 0, 0, 0)
            };
            Cnv.Children.Add(tbB);

            n = random.Next(4);
            switch (n)
            {
                case 0:
                    TbCondition.Text = "1) Даны два множества. Закрась A ∩ B (нажми на нужные области).";
                    break;
                case 1:
                    TbCondition.Text = "1) Даны два множества. Закрась A ∪ B (нажми на нужные области).";
                    break;
                case 2:
                    TbCondition.Text = "1) Даны два множества. Закрась множество А (нажми на нужные области).";
                    break;
                case 3:
                    TbCondition.Text = "1) Даны два множества. Закрась множество В (нажми на нужные области).";
                    break;
            }
        }

        /// <summary>
        /// Генерация 2 задания
        /// </summary>
        public void GenerationCondition2()
        {
            int[] setElementsA = new int[4];
            string strElementsA = "";
            for (int i = 0; i < 4; i++)
            {
            met: int randomElement = random.Next(1, 10);
                for (int j = 0; j < setElementsA.Length; j++)
                {
                    if (randomElement == setElementsA[j])
                    {
                        goto met;
                    }
                }
                setElementsA[i] = randomElement;
                strElementsA += setElementsA[i] + ", ";
            }
            strElementsA = strElementsA.Substring(0, strElementsA.Length - 2);

            int[] setElementsB = new int[4];
            string strElementsB = "";
            for (int i = 0; i < 4; i++)
            {
            met: int randomElement = random.Next(1, 10);
                for (int j = 0; j < setElementsB.Length; j++)
                {
                    if (randomElement == setElementsB[j])
                    {
                        goto met;
                    }
                }
                setElementsB[i] = randomElement;
                strElementsB += setElementsB[i] + ", ";
            }
            strElementsB = strElementsB.Substring(0, strElementsB.Length - 2);

            TbCondition2.Text = "2) Даны множества А {" + strElementsA + "} и В {" + strElementsB + "}. Изобрази элементы данных множеств на диаграмме (перетащи цифры)";

            Ellipse ellipseOne = ellipseGeneration.getEllipse(300, 150, 430, 10);
            Ellipse ellipseTwo = ellipseGeneration.getEllipse(300, 150, 580, 10);
            combinedPath = ellipseGeneration.getUnification(ellipseOne, ellipseTwo, GeometryCombineMode.Intersect);
            ellipseOne.StrokeThickness = Base.StrokeThickness;
            ellipseTwo.StrokeThickness = Base.StrokeThickness;
            Canvas2.Children.Add(ellipseOne);
            Canvas2.Children.Add(ellipseTwo);
            Canvas2.Children.Add(combinedPath);
            TextBlock tbA = new TextBlock()
            {
                Text = "A",
                Margin = new Thickness(440, 10, 0, 0)
            };
            Canvas2.Children.Add(tbA);
            TextBlock tbB = new TextBlock()
            {
                Text = "B",
                Margin = new Thickness(850, 10, 0, 0)
            };
            Canvas2.Children.Add(tbB);

            int[] masElements = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < 4; i++)
            {
                masElements[i] = setElementsA[i];
            }
            int n = 0;
            for (int i = 4; i < masElements.Length; i++)
            {
            met: if (n != 4)
                {
                    masElements[i] = setElementsB[n];
                    for (int j = 0; j < setElementsA.Length; j++)
                    {
                        if (masElements[i] == setElementsA[j])
                        {
                            n++;
                            goto met;
                        }
                    }
                    n++;
                }
            }
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            switch (n)
            {
                case 0:
                    if (ellipseOne.Fill == Brushes.White && ellipseTwo.Fill == Brushes.White && combinedPath.Fill == Brushes.Yellow)
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

        private void MenuSaved_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuOpenSaved_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuRefresh_Click(object sender, RoutedEventArgs e)
        {
            MenuItem childMenuItem = (MenuItem)sender;
            MenuItem menuItem = (MenuItem)childMenuItem.Parent;

            switch (Convert.ToInt32(menuItem.Uid))
            {
                case 1:
                    GenerationCondition();
                    break;
                case 2:
                    GenerationCondition2();
                    break;
                case 3:
                    
                    break;
                default:
                    break;
            }
        }

        private void BtnCheck2_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
