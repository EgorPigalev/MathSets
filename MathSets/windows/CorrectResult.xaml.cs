using System.Windows;

namespace MathSets.windows
{
    /// <summary>
    /// Логика взаимодействия для CorrectResult.xaml
    /// </summary>
    public partial class CorrectResult : Window
    {
        public CorrectResult()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
