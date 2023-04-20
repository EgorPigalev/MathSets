using System.Windows;

namespace MathSets.windows
{
    /// <summary>
    /// Логика взаимодействия для HintEqualSetsWindow.xaml
    /// </summary>
    public partial class HintEqualSetsWindow : Window
    {
        public HintEqualSetsWindow()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
