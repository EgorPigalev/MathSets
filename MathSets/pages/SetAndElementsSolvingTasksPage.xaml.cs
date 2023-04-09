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
        public SetAndElementsSolvingTasksPage()
        {
            InitializeComponent();
            ShowFirstRandomTask();
            ShowSecondRandomTask();
        }

        string[] rightOptions = { "Ручка", "Тетрадь", "Дневник", "Карандаш", "Ластик", "Точилка" }; // массив с верными значениями
        string[] noRightOptions = { "Самолет", "Стул", "Стол", "Машина", "Птица", "Медведь",// массив с неверными значениями
                    "Тапочки", "Трактор", "Собака", "Кошка", "Кот", "Велосипед", "Колесо" };
        string[] noRightOptions2 = { "Огурец", "Дом", "Мышка", "Губка", "Кукла", "Веник",// массив с неверными значениями
                    "Ведро", "Коньки", "Торт", "Утюг", "Хомяк", "Велосипед", "Колесо" };
        int rightOptionsIndex; // индекс верного значения
        int noRightOptionsIndex; // индекс неверного первого значения
        int noRightOptionsIndex2; // индекс неверного второго значения


        string[] answerOptions = { "Однозначные числа", "Четные числа", "Гласные буквы алфавита" }; // массив с вариантами ответов
        string[] singleDigits = {"1", "2", "3", "4" , "5", "6", "7", "8", "9" }; // массив с однозначными числами
        string[] evenNumbers = {"2","4", "6", "8","10","12", "14", "16", "18", "20", "22", "24", "26", "28",
        "30", "32","34", "36", "38", "40", "42", "44", "46", "48", "50", "52", "54", "56", "58", "60", "62", "64",
        "66", "68", "70", "72", "74", "76", "78", "80", "82", "84", "86", "88", "90", "92", "94", "96", "98"}; // массив четных чисел
        string[] vowelLetters = { "а", "о", "у", "ы", "э", "е", "ё", "и", "ю", "я" }; // массив гласный букв
        int index;
        string strTask = "";
        int verificationLabel;
        public static Random random = new Random();
        int randomAnswerOptions = random.Next(3); // вывод рандомных вариантов ответа

        /// <summary>
        /// метод для генерации задания 2
        /// </summary>
        private void ShowSecondRandomTask()
        {

            int countTask = random.Next(3, 6); // рандомное количество значений в задании
            int v = random.Next(3);
            for (int i = 0; i <= countTask; i++) // цикл для вывода формулировки задания
            {
                if(v == 0)
                {
                    verificationLabel = 0;
                    if (i == 0)
                    {
                        strTask += "{ ";
                    }
                    index = random.Next(singleDigits.Length);
                    strTask +=  singleDigits[index] + "; ";
                    if (i == countTask)
                    {
                        strTask += "}";
                    }
                }
                else if (v == 1)
                {
                    verificationLabel = 1;
                    if (i == 0)
                    {
                        strTask += "{ ";
                    }
                    index = random.Next(evenNumbers.Length);
                    strTask +=  evenNumbers[index] + "; ";
                    if (i == countTask)
                    {
                        strTask += "}";
                    }
                }
                else if (v == 2)
                {
                    verificationLabel = 2;
                    if (i == 0)
                    {
                        strTask += "{ ";
                    }
                    index = random.Next(vowelLetters.Length);
                    strTask +=  vowelLetters[index] + "; ";
                    if (i == countTask)
                    {
                        strTask += "}";
                    }
                }
            }
            TextBlockTask.Text = "Задайте множество общим свойством его элементов " + strTask; // вывод формулировки задания
            
            if (randomAnswerOptions == 0)
            {
                OptionOne.Content = answerOptions[0];
                OptionTwo.Content = answerOptions[1];
                OptionThree.Content = answerOptions[2];
            }
            else if(randomAnswerOptions == 1)
            {
                OptionOne.Content = answerOptions[1];
                OptionTwo.Content = answerOptions[2];
                OptionThree.Content = answerOptions[0];
            }
            else if (randomAnswerOptions == 2)
            {
                OptionOne.Content = answerOptions[2];
                OptionTwo.Content = answerOptions[0];
                OptionThree.Content = answerOptions[1];
            }
        }

        /// <summary>
        /// метод для генерации рандомных ответов на задание 1
        /// </summary>
        private void ShowFirstRandomTask()
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

        private void BtnResult_Click(object sender, RoutedEventArgs e)
        {
            string strAnswer = ""; // переменна для записи ответа, который выбрал пользователь
            if (BtnOption3.Background == colorButton)
            {
                strAnswer = Convert.ToString(BtnOption3.Content);
            }
            else if (BtnOption2.Background == colorButton)
            {
                strAnswer = Convert.ToString(BtnOption2.Content);
            }
            else if (BtnOption1.Background == colorButton)
            {
                strAnswer = Convert.ToString(BtnOption1.Content);
            }
            else
            {
                MessageBox.Show($"Выбери ответ");
            }

            if (strAnswer == rightOptions[rightOptionsIndex]) // если пользователь выбрал правильный ответ
            {
                windows.CorrectResult correctResult = new windows.CorrectResult(); // Вывод окна "Ты молодец"
                correctResult.ShowDialog();
                //Base.MainFrame.Navigate(new SetAndElementsSolvingTasksPage());
            }
            else // если пользователь выбрал неверный ответ
            {
                strAnswer = rightOptions[rightOptionsIndex]; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                windows.ResultSetAndElementsTasksWindow resultSetAndElementsTasks = new windows.ResultSetAndElementsTasksWindow(strAnswer); 
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

        private void OptionOne_Click(object sender, RoutedEventArgs e)
        {
            OptionOne.Background = colorButton; // красим кнопку
            OptionTwo.ClearValue(Button.BackgroundProperty); // с остальных кнопок снимаем окрас
            OptionThree.ClearValue(Button.BackgroundProperty);
        }

        private void OptionTwo_Click(object sender, RoutedEventArgs e)
        {
            OptionTwo.Background = colorButton; // красим кнопку
            OptionOne.ClearValue(Button.BackgroundProperty); // с остальных кнопок снимаем окрас
            OptionThree.ClearValue(Button.BackgroundProperty);
        }

        private void OptionThree_Click(object sender, RoutedEventArgs e)
        {
            OptionThree.Background = colorButton; // красим кнопку
            OptionOne.ClearValue(Button.BackgroundProperty); // с остальных кнопок снимаем окрас
            OptionTwo.ClearValue(Button.BackgroundProperty);
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            string strAnswer = ""; // переменна для записи ответа, который выбрал пользователь
            if (OptionOne.Background == colorButton)
            {
                strAnswer = Convert.ToString(OptionOne.Content);
            }
            else if (OptionTwo.Background == colorButton)
            {
                strAnswer = Convert.ToString(OptionTwo.Content);
            }
            else if (OptionThree.Background == colorButton)
            {
                strAnswer = Convert.ToString(OptionThree.Content);
            }
            else
            {
                MessageBox.Show($"Выбери ответ");
            }

            if (strAnswer == answerOptions[0] && verificationLabel == 0) // если пользователь выбрал правильный ответ
            {
                windows.CorrectResult correctResult = new windows.CorrectResult(); // Вывод окна "Ты молодец"
                correctResult.ShowDialog();
                //Base.MainFrame.Navigate(new SetAndElementsSolvingTasksPage());
            }
            else if (strAnswer == answerOptions[1] && verificationLabel == 1) // если пользователь выбрал правильный ответ
            {
                windows.CorrectResult correctResult = new windows.CorrectResult(); // Вывод окна "Ты молодец"
                correctResult.ShowDialog();
                //Base.MainFrame.Navigate(new SetAndElementsSolvingTasksPage());
            }
            else if (strAnswer == answerOptions[2] && verificationLabel == 2) // если пользователь выбрал правильный ответ
            {
                windows.CorrectResult correctResult = new windows.CorrectResult(); // Вывод окна "Ты молодец"
                correctResult.ShowDialog();
                //Base.MainFrame.Navigate(new SetAndElementsSolvingTasksPage());
            }
            else // если пользователь выбрал неверный ответ
            {
                strAnswer = answerOptions[verificationLabel]; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                windows.ResultSetAndElementsTasksWindow resultSetAndElementsTasks = new windows.ResultSetAndElementsTasksWindow(strAnswer);
                resultSetAndElementsTasks.ShowDialog();
            }
        }

        private void BtnHint_Click_1(object sender, RoutedEventArgs e)
        {
            windows.HintSetElementsWindow hint = new windows.HintSetElementsWindow();
            hint.ShowDialog();
        }

        private void MenuSaved_Click(object sender, RoutedEventArgs e)
        {
            MenuItem childMenuItem = (MenuItem)sender;
            MenuItem menuItem = (MenuItem)childMenuItem.Parent;
        }

        private void MenuOpenSaved_Click(object sender, RoutedEventArgs e)
        {
            MenuItem childMenuItem = (MenuItem)sender;
            MenuItem menuItem = (MenuItem)childMenuItem.Parent;
        }

        private void MenuRefresh_Click(object sender, RoutedEventArgs e)
        {
            MenuItem childMenuItem = (MenuItem)sender;
            MenuItem menuItem = (MenuItem)childMenuItem.Parent;

            switch (Convert.ToInt32(menuItem.Uid))
            {
                case 1:
                    ShowFirstRandomTask();
                   
                    break;
                case 2:
                    ShowSecondRandomTask();
                    break;
                default:
                    break;
            }
        }
    }
}
