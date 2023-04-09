using MathSets.pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            Base.MainFrame.Navigate(new SetAndElementsSolvingTasksPage());
        }

        private void SpLessonFourAndFive_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Base.MainFrame.Navigate(new LessonFourAndFive());
        }

        private void SPSplittingSets_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Base.MainFrame.Navigate(new SplittingSetsSolvingTasks());
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Base.MainFrame.Navigate(new CombiningSetsPage());
        }

        private void SpLessonSix_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Base.MainFrame.Navigate(new LessonSix());
        }
    }
}