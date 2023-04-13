using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для GuideWindow.xaml
    /// </summary>
    public partial class GuideWindow : Window
    {
        private bool status; // Статус пауза/продолжить (true - идёт; false - стоит на паузе)
        private string pathCurrentDirectory; // Путь до папки где хранятся видео
        public GuideWindow(int i, int j)
        {
            InitializeComponent();
            status = false;
            pathCurrentDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\video\\";
            switch(i)
            {
                case 1:
                    if (j == 1)
                    {
                        MEGuide.Source = new Uri(pathCurrentDirectory + "SetAndElementFirstTask.mp4");
                    }
                    if (j == 2)
                    {
                        MEGuide.Source = new Uri(pathCurrentDirectory + "SetAndElementSecondTask.mp4");
                    }
                    break;
                case 2:
                    if (j == 1)
                    {
                        MEGuide.Source = new Uri(pathCurrentDirectory + "EqualSetsFirstTask.mp4");
                    }
                    if (j == 2)
                    {
                        MEGuide.Source = new Uri(pathCurrentDirectory + "EqualSetsSecondTask.mp4");
                    }
                    break;
                case 3:

                    break;
                case 4:
                    
                    break;
                case 5:
                    if (j == 1)
                    {
                        MEGuide.Source = new Uri(pathCurrentDirectory + "IntersectionSetsFirstTask.mp4");
                    }
                    if (j == 2)
                    {
                        MEGuide.Source = new Uri(pathCurrentDirectory + "IntersectionSetsSecondTask.mp4");
                    }
                    if (j == 3)
                    {
                        MEGuide.Source = new Uri(pathCurrentDirectory + "IntersectionSetsThreeTask.mp4");
                    }
                    if (j == 4)
                    {
                        MEGuide.Source = new Uri(pathCurrentDirectory + "IntersectionSetsFourTask.mp4");
                    }
                    break;
                case 6:

                    break;
                case 7:
                    if (j == 1)
                    {
                        MEGuide.Source = new Uri(pathCurrentDirectory + "SplittingSetsFirstTask.mp4");
                    }
                    if (j == 2)
                    {
                        MEGuide.Source = new Uri(pathCurrentDirectory + "SplittingSetsSecondTask.mp4");
                    }
                    break;

            }
            MEGuide.Stop();
            BtnPause.Visibility = Visibility.Collapsed;
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            MEGuide.Stop();
            MEGuide.Play();
            BtnPause.Visibility = Visibility.Visible;
            status = true;
        }

        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            if (status)
            {
                MEGuide.Pause();
                status = false;
                BtnPause.Content = "Продолжить";
            }
            else
            {
                MEGuide.Play();
                status = true;
                BtnPause.Content = "Пауза";
            }
        }

        private void MEGuide_MediaEnded(object sender, RoutedEventArgs e)
        {
            BtnPause.Visibility = Visibility.Collapsed;
        }
    }
}
