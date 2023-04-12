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
        public GuideWindow(int i)
        {
            InitializeComponent();
            status = false;
            pathCurrentDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\video\\";
            switch(i)
            {
                case 10:
                    MEGuide.Source = new Uri(pathCurrentDirectory + "IntersectionSetsFirstTask.mp4");
                    break;
                case 11:
                    MEGuide.Source = new Uri(pathCurrentDirectory + "IntersectionSetsSecondTask.mp4");
                    break;
                case 12:
                    MEGuide.Source = new Uri(pathCurrentDirectory + "IntersectionSetsThreeTask.mp4");
                    break;
                case 13:
                    MEGuide.Source = new Uri(pathCurrentDirectory + "IntersectionSetsFourTask.mp4");
                    break;
                case 17:
                    MEGuide.Source = new Uri(pathCurrentDirectory + "SplittingSetsFirstTask.mp4");
                    break;
                case 18:
                    MEGuide.Source = new Uri(pathCurrentDirectory + "SplittingSetsSecondTask.mp4");
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
