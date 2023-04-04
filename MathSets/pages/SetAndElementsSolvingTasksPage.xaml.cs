using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace MathSets.pages
{
    /// <summary>
    /// Логика взаимодействия для SetAndElementsSolvingTasksPage.xaml
    /// </summary>
    public partial class SetAndElementsSolvingTasksPage : Page
    {
        string[] rightOptions = { "Ручка", "Тетрадь", "Дневник", "Карандаш", "Ластик", "Точилка" }; // массив с верными значениями
        string[] noRightOptions = { "Самолет", "Стул", "Стол", "Машина", "Птица", "Медведь",// массив с неверными значениями
                    "Тапочки", "Трактор", "Собака", "Кошка", "Кот", "Велосипед", "Колесо" };
        string[] noRightOptions2 = { "Огурец", "Дом", "Мышка", "Губка", "Кукла", "Веник",// массив с неверными значениями
                    "Ведро", "Коньки", "Торт", "Утюг", "Хомяк", "Велосипед", "Колесо" };
        int rightOptionsIndex; // индекс верного значения
        int noRightOptionsIndex; // индекс неверного первого значения
        int noRightOptionsIndex2; // индекс неверного второго значения

        public SetAndElementsSolvingTasksPage()
        {
            InitializeComponent();
            ShowRandomButton();
        }

        /// <summary>
        /// метод для генерации рандомных ответов на задание
        /// </summary>
        private void ShowRandomButton()
        {
            Random random = new Random();

            int v = random.Next(3); // рандом для кнопок

            if (v == 0) // присвоение кнопкам рандомных значений
            {
                rightOptionsIndex = random.Next(rightOptions.Length);
                noRightOptionsIndex = random.Next(noRightOptions.Length);
                noRightOptionsIndex2 = random.Next(noRightOptions2.Length);
                BtnOption1.Content = rightOptions[rightOptionsIndex];
                BtnOption2.Content = noRightOptions[noRightOptionsIndex];
                BtnOption3.Content = noRightOptions2[noRightOptionsIndex2];
            }
            else if (v == 1)
            {
                rightOptionsIndex = random.Next(rightOptions.Length);
                noRightOptionsIndex = random.Next(noRightOptions.Length);
                noRightOptionsIndex2 = random.Next(noRightOptions2.Length);
                BtnOption3.Content = rightOptions[rightOptionsIndex];
                BtnOption1.Content = noRightOptions[noRightOptionsIndex];
                BtnOption2.Content = noRightOptions2[noRightOptionsIndex2];
            }
            else if (v == 2)
            {
                rightOptionsIndex = random.Next(rightOptions.Length);
                noRightOptionsIndex = random.Next(noRightOptions.Length);
                noRightOptionsIndex2 = random.Next(noRightOptions2.Length);
                BtnOption2.Content = rightOptions[rightOptionsIndex];
                BtnOption3.Content = noRightOptions[noRightOptionsIndex];
                BtnOption1.Content = noRightOptions2[noRightOptionsIndex2];
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Base.MainFrame.Navigate(new MainMenuPage());
        }

        private void BtnHint_Click(object sender, RoutedEventArgs e)
        {
            windows.HintSetElementsWindow hint = new windows.HintSetElementsWindow();
            hint.ShowDialog();
        }

        private void BtnResult_Click(object sender, RoutedEventArgs e)
        {
            string str = ""; 
            if (BtnOption3.Background == colorButton)
            {
                str = Convert.ToString(BtnOption3.Content);
            }
            else if (BtnOption2.Background == colorButton)
            {
                str = Convert.ToString(BtnOption2.Content);
            }
            else if (BtnOption1.Background == colorButton)
            {
                str = Convert.ToString(BtnOption1.Content);
            }
            else
            {
                MessageBox.Show($"Выбери ответ");
            }

            if (str == rightOptions[rightOptionsIndex])
            {
                windows.ResultSetAndElementsTasksWindow resultSetAndElementsTasks = new windows.ResultSetAndElementsTasksWindow(); // Показ результата
                resultSetAndElementsTasks.ShowDialog();
            }
            else
            {
                str = rightOptions[rightOptionsIndex];
                windows.ResultSetAndElementsTasksWindow resultSetAndElementsTasks = new windows.ResultSetAndElementsTasksWindow(str); // Показ результата
                resultSetAndElementsTasks.ShowDialog();
            }
        }

        SolidColorBrush colorButton = new SolidColorBrush(Color.FromRgb(241, 76, 24)); // цвет для кнопок, в который они перекрасятся при нажатии
        private void Option3_Click(object sender, RoutedEventArgs e)
        {
            BtnOption3.Background = colorButton; // красим кнопку
            BtnOption2.ClearValue(Button.BackgroundProperty); // с остальных кнопок снимаем окрас
            BtnOption1.ClearValue(Button.BackgroundProperty);
        }

        private void Option2_Click(object sender, RoutedEventArgs e)
        {
            BtnOption2.Background = colorButton; // красим кнопку
            BtnOption3.ClearValue(Button.BackgroundProperty); // с остальных кнопок снимаем окрас
            BtnOption1.ClearValue(Button.BackgroundProperty);
        }

        private void Option1_Click(object sender, RoutedEventArgs e)
        {
            BtnOption1.Background = colorButton; // красим кнопку
            BtnOption3.ClearValue(Button.BackgroundProperty); // с остальных кнопок снимаем окрас
            BtnOption2.ClearValue(Button.BackgroundProperty);
        }
    }
}
