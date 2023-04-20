using System.Windows;

namespace MathSets.windows
{
    /// <summary>
    /// Логика взаимодействия для HintSetElementsWindow.xaml
    /// </summary>
    public partial class HintSetElementsWindow : Window
    {
        public HintSetElementsWindow()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
