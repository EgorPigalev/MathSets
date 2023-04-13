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
        private bool _status; // Статус пауза/продолжить (true - идёт; false - стоит на паузе)
        private string _pathCurrentDirectory; // Путь до папки где хранятся видео

        /// <summary>
        /// Конструктор класса GuideWindow
        /// </summary>
        /// <param name="themeNumber">номер темы</param>
        /// <param name="taskNumber">номер задания</param>
        public GuideWindow(int themeNumber, int taskNumber)
        {
            InitializeComponent();

            _status = false;
            _pathCurrentDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\video\\";

            switch(themeNumber)
            {
                case 1:
                    if (taskNumber == 1)
                    {
                        MEGuide.Source = new Uri(_pathCurrentDirectory + "SetAndElementFirstTask.mp4");
                    }
                    if (taskNumber == 2)
                    {
                        MEGuide.Source = new Uri(_pathCurrentDirectory + "SetAndElementSecondTask.mp4");
                    }
                    break;
                case 2:
                    if (taskNumber == 1)
                    {
                        MEGuide.Source = new Uri(_pathCurrentDirectory + "EqualSetsFirstTask.mp4");
                    }
                    if (taskNumber == 2)
                    {
                        MEGuide.Source = new Uri(_pathCurrentDirectory + "EqualSetsSecondTask.mp4");
                    }
                    break;
                case 3:
                    if (taskNumber == 1)
                    {
                        MEGuide.Source = new Uri(_pathCurrentDirectory + "LessonFourAndFiveTaskFirst.mp4");
                    }
                    else if (taskNumber == 2)
                    {
                        MEGuide.Source = new Uri(_pathCurrentDirectory + "LessonFourAndFiveTaskSecond.mp4");
                    }
                    else
                    {
                        MEGuide.Source = new Uri(_pathCurrentDirectory + "LessonFourAndFiveTaskThird.mp4");
                    }
                    break;
                case 4:
                    if (taskNumber == 1)
                    {
                        MEGuide.Source = new Uri(_pathCurrentDirectory + "LessonSixTaskFirst.mp4");
                    }
                    break;
                case 5:
                    if (taskNumber == 1)
                    {
                        MEGuide.Source = new Uri(_pathCurrentDirectory + "IntersectionSetsFirstTask.mp4");
                    }
                    if (taskNumber == 2)
                    {
                        MEGuide.Source = new Uri(_pathCurrentDirectory + "IntersectionSetsSecondTask.mp4");
                    }
                    if (taskNumber == 3)
                    {
                        MEGuide.Source = new Uri(_pathCurrentDirectory + "IntersectionSetsThreeTask.mp4");
                    }
                    if (taskNumber == 4)
                    {
                        MEGuide.Source = new Uri(_pathCurrentDirectory + "IntersectionSetsFourTask.mp4");
                    }
                    break;
                case 6:
                    if (taskNumber == 1)
                    {
                        MEGuide.Source = new Uri(_pathCurrentDirectory + "CombiningSetsFirstTask.mkv");
                    }
                    if (taskNumber == 2)
                    {
                        MEGuide.Source = new Uri(_pathCurrentDirectory + "CombiningSetsSecondTask.mkv");
                    }
                    if (taskNumber == 3)
                    {
                        MEGuide.Source = new Uri(_pathCurrentDirectory + "CombiningSetsThirdTask.mkv");
                    }

                    break;
                case 7:
                    if (taskNumber == 1)
                    {
                        MEGuide.Source = new Uri(_pathCurrentDirectory + "SplittingSetsFirstTask.mp4");
                    }
                    if (taskNumber == 2)
                    {
                        MEGuide.Source = new Uri(_pathCurrentDirectory + "SplittingSetsSecondTask.mp4");
                    }
                    break;

            }

            MEGuide.Stop();
            BtnPause.Visibility = Visibility.Collapsed;
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            MEGuide.Stop();
            MEGuide.Play();
            BtnPause.Visibility = Visibility.Visible;
            _status = true;
        }

        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            if (_status)
            {
                MEGuide.Pause();
                _status = false;
                BtnPause.Content = "Продолжить";
            }
            else
            {
                MEGuide.Play();
                _status = true;
                BtnPause.Content = "Пауза";
            }
        }

        private void MEGuide_MediaEnded(object sender, RoutedEventArgs e)
        {
            BtnPause.Visibility = Visibility.Collapsed;
        }
    }
}
