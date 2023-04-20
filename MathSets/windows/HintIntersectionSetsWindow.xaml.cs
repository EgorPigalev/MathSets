using System.Windows;

namespace MathSets
{
    /// <summary>
    /// Логика взаимодействия для HintIntersectionSetsWindow.xaml
    /// </summary>
    public partial class HintIntersectionSetsWindow : Window
    {
        public HintIntersectionSetsWindow()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
