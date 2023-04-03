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

namespace MathSets.pages
{
    /// <summary>
    /// Логика взаимодействия для SetAndElementsSolvingTasksPage.xaml
    /// </summary>
    public partial class SetAndElementsSolvingTasksPage : Page
    {
        public SetAndElementsSolvingTasksPage()
        {
            InitializeComponent();
            RandomButton();
        }

        private void RandomButton()
        {
            Random random = new Random();

            int v = random.Next(3); // рандом для кнопок
            string[] rightOptions = { "Ручка", "Тетрадь", "Дневник", "Карандаш", "Ластик", "Точилка" }; // массив с верными значениями
            string[] noRightOptions = { "Самолет", "Стул", "Стол", "Машина", "Птица", "Медведь",// массив с неверными значениями
                    "Тапочки", "Трактор", "Собака", "Кошка", "Кот", "Велосипед", "Колесо" };
            string[] noRightOptions2 = { "Огурец", "Дом", "Мышка", "Губка", "Кукла", "Веник",// массив с неверными значениями
                    "Ведро", "Коньки", "Торт", "Утюг", "Хомяк", "Велосипед", "Колесо" };
            if (v == 0)
            {
                int rightOptionsIndex = random.Next(rightOptions.Length);
                int noRightOptionsIndex = random.Next(noRightOptions.Length);
                int noRightOptionsIndex2 = random.Next(noRightOptions2.Length);
                Option1.Content = rightOptions[rightOptionsIndex];
                Option2.Content = noRightOptions[noRightOptionsIndex];
                Option3.Content = noRightOptions2[noRightOptionsIndex2];
            }
            else if(v == 1)
            {
                int rightOptionsIndex = random.Next(rightOptions.Length);
                int noRightOptionsIndex = random.Next(noRightOptions.Length);
                int noRightOptionsIndex2 = random.Next(noRightOptions2.Length);
                Option3.Content = rightOptions[rightOptionsIndex];
                Option1.Content = noRightOptions[noRightOptionsIndex];
                Option2.Content = noRightOptions2[noRightOptionsIndex2];
            }
            else if(v == 2)
            {
                int rightOptionsIndex = random.Next(rightOptions.Length);
                int noRightOptionsIndex = random.Next(noRightOptions.Length);
                int noRightOptionsIndex2 = random.Next(noRightOptions2.Length);
                Option2.Content = rightOptions[rightOptionsIndex];
                Option3.Content = noRightOptions[noRightOptionsIndex];
                Option1.Content = noRightOptions2[noRightOptionsIndex2];
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new MainMenuPage());
        }

        private void BtnHint_Click(object sender, RoutedEventArgs e)
        {
            windows.HintSetElementsWindow hint = new windows.HintSetElementsWindow();
            hint.ShowDialog();
        }
    }
}
