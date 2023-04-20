using System.Windows;

namespace MathSets.windows
{
    /// <summary>
    /// Логика взаимодействия для HintSplittingSetsWindow.xaml
    /// </summary>
    public partial class HintSplittingSetsWindow : Window
    {
        public HintSplittingSetsWindow()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
