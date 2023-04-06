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

namespace MathSets
{
    /// <summary>
    /// Логика взаимодействия для MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SPIntersectionSets_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Base.MainFrame.Navigate(new IntersectionSetsSolvingTasksPage());
        }

        private void SPSetAndElements_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Base.MainFrame.Navigate(new pages.SetAndElementsSolvingTasksPage());
        }

        private void SpLessonFourAndFive_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Base.MainFrame.Navigate(new pages.LessonFourAndFive());
        }

        private void SPSplittingSets_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Base.MainFrame.Navigate(new pages.SplittingSetsSolvingTasks());
        }

        private void SPEqualSets_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Base.MainFrame.Navigate(new pages.EqualSetsSolvingTasksPage());
        }
    }
}
