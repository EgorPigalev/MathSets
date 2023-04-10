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
        int[] masAnswerOptions = new int[4];
        public CombiningSetsPage()
        {
            InitializeComponent();

            GenerationCondition();
            GenerationCondition2();
            GenerationCondition3();
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
            int[] setElementsA = GenerationElementsSet(4);
            string strElementsA = ConvertMasInString(setElementsA);
            
            int[] setElementsB = GenerationElementsSet(4);
            string strElementsB = ConvertMasInString(setElementsB);  

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

            int[] masElements = CombiningElementsSets(setElementsA, setElementsB);


        }

        /// <summary>
        /// Генерация 3 задания
        /// </summary>
        public void GenerationCondition3()
        {
            Canvas3.Children.Clear();
            Cb1.IsChecked = false;
            Cb2.IsChecked = false;
            Cb3.IsChecked = false;
            Cb4.IsChecked = false;
            Ellipse ellipseOne = ellipseGeneration.getEllipse(300, 150, 0, 10);
            Ellipse ellipseTwo = ellipseGeneration.getEllipse(300, 150, 150, 10);
            combinedPath = ellipseGeneration.getUnification(ellipseOne, ellipseTwo, GeometryCombineMode.Intersect);
            ellipseOne.StrokeThickness = Base.StrokeThickness;
            ellipseTwo.StrokeThickness = Base.StrokeThickness;
            Canvas3.Children.Add(ellipseOne);
            Canvas3.Children.Add(ellipseTwo);
            Canvas3.Children.Add(combinedPath);
            TextBlock tbA = new TextBlock()
            {
                Text = "A",
                Margin = new Thickness(10, 10, 0, 0)
            };
            Canvas3.Children.Add(tbA);
            TextBlock tbB = new TextBlock()
            {
                Text = "B",
                Margin = new Thickness(420, 10, 0, 0)
            };
            Canvas3.Children.Add(tbB);

            int[] masElementsSetA = GenerationElementsSet(4);
            int[] masElementsSetB = GenerationElementsSet(4);
            int[] masElementsCombining = CombiningElementsSets(masElementsSetA, masElementsSetB);
            int[] masElementsIntersection = IntersectionElementsSets(masElementsSetA, masElementsSetB);

            for(int i=0;i<masAnswerOptions.Length;i++)
            {
                masAnswerOptions[i] = -1;
            }

            string[] str = new string[4];
            for (int j = 0; j<4;j++)
            { 
                met: int g = random.Next(4);
                for(int i=0;i< masAnswerOptions.Length;i++)
                {
                    if(g== masAnswerOptions[i])
                    {
                        goto met;
                    }
                }
                masAnswerOptions[j] = g;
                switch (g)
                {
                    case 0:
                        str[j] = "A ∪ B = {" + ConvertMasInString(masElementsCombining) + "}";
                        break;
                    case 1:
                        str[j] = "A ∩ B = {" + ConvertMasInString(masElementsIntersection) + "}";
                        break;
                    case 2:
                        str[j] = "A ∩ B = {" + ConvertMasInString(GenerationElementsSet(random.Next(1,9))) + "}";
                        break;
                    case 3:
                        str[j] = "A ∪ B = {" + ConvertMasInString(GenerationElementsSet(random.Next(1, 9))) + "}";  
                        break;
                    default:
                        break;
                }   
            }

            Cb1.Content = str[0];
            Cb2.Content = str[1];
            Cb3.Content = str[2];
            Cb4.Content = str[3];

            bool elementFoundA = false;
            int marginA = 30;
            for(int i =0; i<masElementsSetA.Length;i++)
            {
                for(int j=0;j<masElementsIntersection.Length;j++)
                {
                    if(masElementsSetA[i]==masElementsIntersection[j])
                    {
                        elementFoundA = true;
                    }
                }
                if(elementFoundA == false)
                {
                    TextBlock tb = new TextBlock()
                    {
                        Text = masElementsSetA[i].ToString(),
                        Margin = new Thickness(marginA,random.Next(35,100),0,0)
                    };
                    Canvas3.Children.Add(tb);
                    marginA += random.Next(10,30);
                }
                elementFoundA = false;
            }

            bool elementFoundB = false;
            for (int i = 0; i < masElementsSetB.Length; i++)
            {
                for (int j = 0; j < masElementsIntersection.Length; j++)
                {
                    if (masElementsSetB[i] == masElementsIntersection[j])
                    {
                        elementFoundB = true;
                    }
                }
                if (elementFoundB == false)
                {
                    TextBlock tb = new TextBlock()
                    {
                        Text = masElementsSetB[i].ToString(),
                        Margin = new Thickness(random.Next(300,400), random.Next(30,100), 0, 0)
                    };
                    Canvas3.Children.Add(tb);
                }
                elementFoundB = false;
            }

            for (int j = 0; j < masElementsIntersection.Length; j++)
            {
                if (masElementsIntersection[j]!=0)
                {
                    TextBlock tb = new TextBlock()
                    {
                        Text = masElementsIntersection[j].ToString(),
                        Margin = new Thickness(random.Next(180,260), random.Next(30,100), 0, 0)
                    };
                    Canvas3.Children.Add(tb);
                } 
            }
        }

        /// <summary>
        /// Вывод элементов массива строкой
        /// </summary>
        /// <param name="mas">Массив, который нужно показать в виде строки</param>
        /// <returns></returns>
        private string ConvertMasInString(int[] mas)
        {
            string str = "";
            if(mas[0]==0)
            {
                str = "Ø";
            }
            else
            {
                for (int i = 0; i < mas.Length; i++)
                {
                    if (mas[i] != 0)
                    {
                        str += mas[i] + ", ";
                    }
                }
                str = str.Substring(0, str.Length - 2);
            } 
            return str;
        }

        /// <summary>
        /// Генерация элементов множества
        /// </summary>
        /// <param name="size">Количество элементов в множестве</param>
        /// <returns></returns>
        private int[] GenerationElementsSet(int size)
        {
            int[] masElementsSet = new int[size];
            for (int i = 0; i < size; i++)
            {
            met: int randomElement = random.Next(1, 10);
                for (int j = 0; j < masElementsSet.Length; j++)
                {
                    if (randomElement == masElementsSet[j])
                    {
                        goto met;
                    }
                }
                masElementsSet[i] = randomElement;
            }
            return masElementsSet;
        }

        /// <summary>
        /// Объединение элементов множеств без повторения
        /// </summary>
        /// <param name="masA">Множество А</param>
        /// <param name="masB">Множество В</param>
        /// <returns></returns>
        private int[] CombiningElementsSets(int[] masA, int[] masB)
        {
            int[] masElements = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < 4; i++)
            {
                masElements[i] = masA[i];
            }
            int n = 0;
            for (int i = 4; i < masElements.Length; i++)
            {
            met: if (n != 4)
                {
                    
                    for (int j = 0; j < masA.Length; j++)
                    {
                        if (masB[n] == masA[j])
                        {
                            n++;
                            goto met;
                        }
                    }
                    masElements[i] = masB[n];
                    n++;
                }
            }
            return masElements;
        }

        /// <summary>
        /// Пересечение элементов множеств
        /// </summary>
        /// <param name="masA">Множество А</param>
        /// <param name="masB">Множество В</param>
        /// <returns></returns>
        private int[] IntersectionElementsSets(int[] masA, int[] masB)
        {
            int[] masElements = new int[4] { 0, 0, 0, 0};
            int n = 0;
            for (int i = 0; i < masA.Length; i++)
            {
                for (int j = 0; j < masB.Length; j++)
                {
                    if (masA[i] == masB[j])
                    {
                        masElements[n] = masA[i];
                        n++;
                    }
                }
            }
            if(masElements.Length==0)
            {
                masElements[0] = 0;
            }

            return masElements;
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
                    GenerationCondition3();
                    break;
                default:
                    break;
            }
        }

        private void BtnCheck2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCheck3_Click(object sender, RoutedEventArgs e)
        {
            int combining=0, intersection=0;
            for(int i=0;i<masAnswerOptions.Length;i++)
            {
                if(masAnswerOptions[i] == 0)
                {
                    combining = i+1;
                }
                if(masAnswerOptions[i]==1)
                {
                    intersection = i+1;
                }
            }
            switch(combining)
            {
                case 1:
                    switch(intersection)
                    {
                        case 2:
                            if(Cb1.IsChecked==true && Cb2.IsChecked==true && Cb3.IsChecked==false && Cb4.IsChecked==false)
                            {
                                windows.CorrectResult correctResult = new windows.CorrectResult();
                                correctResult.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }
                            break;
                        case 3:
                            if (Cb1.IsChecked == true && Cb2.IsChecked == false && Cb3.IsChecked == true && Cb4.IsChecked == false)
                            {
                                windows.CorrectResult correctResult = new windows.CorrectResult();
                                correctResult.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }
                            break;
                        case 4:
                            if (Cb1.IsChecked == true && Cb2.IsChecked == false && Cb3.IsChecked == false && Cb4.IsChecked == true)
                            {
                                windows.CorrectResult correctResult = new windows.CorrectResult();
                                correctResult.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    switch (intersection)
                    {
                        case 1:
                            if (Cb1.IsChecked == true && Cb2.IsChecked == true && Cb3.IsChecked == false && Cb4.IsChecked == false)
                            {
                                windows.CorrectResult correctResult = new windows.CorrectResult();
                                correctResult.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }
                            break;
                        case 3:
                            if (Cb1.IsChecked == false && Cb2.IsChecked == true && Cb3.IsChecked == true && Cb4.IsChecked == false)
                            {
                                windows.CorrectResult correctResult = new windows.CorrectResult();
                                correctResult.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }
                            break;
                        case 4:
                            if (Cb1.IsChecked == false && Cb2.IsChecked == true && Cb3.IsChecked == false && Cb4.IsChecked == true)
                            {
                                windows.CorrectResult correctResult = new windows.CorrectResult();
                                correctResult.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    switch (intersection)
                    {
                        case 1:
                            if (Cb1.IsChecked == true && Cb2.IsChecked == false && Cb3.IsChecked == true && Cb4.IsChecked == false)
                            {
                                windows.CorrectResult correctResult = new windows.CorrectResult();
                                correctResult.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }
                            break;
                        case 2:
                            if (Cb1.IsChecked == false && Cb2.IsChecked == true && Cb3.IsChecked == true && Cb4.IsChecked == false)
                            {
                                windows.CorrectResult correctResult = new windows.CorrectResult();
                                correctResult.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }
                            break;
                        case 4:
                            if (Cb1.IsChecked == false && Cb2.IsChecked == false && Cb3.IsChecked == true && Cb4.IsChecked == true)
                            {
                                windows.CorrectResult correctResult = new windows.CorrectResult();
                                correctResult.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case 4:
                    switch (intersection)
                    {
                        case 1:
                            if (Cb1.IsChecked == true && Cb2.IsChecked == false && Cb3.IsChecked == false && Cb4.IsChecked == true)
                            {
                                windows.CorrectResult correctResult = new windows.CorrectResult();
                                correctResult.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }
                            break;
                        case 2:
                            if (Cb1.IsChecked == false && Cb2.IsChecked == true && Cb3.IsChecked == false && Cb4.IsChecked == true)
                            {
                                windows.CorrectResult correctResult = new windows.CorrectResult();
                                correctResult.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }
                            break;
                        case 3:
                            if (Cb1.IsChecked == false && Cb2.IsChecked == false && Cb3.IsChecked == true && Cb4.IsChecked == true)
                            {
                                windows.CorrectResult correctResult = new windows.CorrectResult();
                                correctResult.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            
        }
    }
}
