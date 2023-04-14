using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MathSets.pages
{
    /// <summary>
    /// Логика взаимодействия для EqualSetsSolvingTasksPage.xaml
    /// </summary>
    public partial class EqualSetsSolvingTasksPage : Page
    {

        string[] numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }; // массив цифр
        string[] vowelLetters = { "а", "о", "у", "ы", "э", "е", "ё", "и", "ю", "я" }; // массив гласный букв
        public static Random random = new Random();
        int index;
        string strButton = ""; // значение для первой кнопки-ответ
        string strButtonTwo = ""; // значение для второй кнопки-ответ
        string strButtonThree = ""; // значение для третьей кнопки-ответ
        Canvas c;
        Canvas c2;

        public EqualSetsSolvingTasksPage()
        {
            InitializeComponent();


            ShowRandomButton();
            ShowRandomZnachenia();
            ShowRandomZnachenia2();
        }


        /// <summary>
        /// метод для вывода варианта ответа
        /// </summary>
        private void ShowRandomZnachenia2()
        {
            int r = random.Next(2);
            if (r == 0)
            {
                for (int i = 0; i <= 4; i++) // цикл для вывода текста 
                {
                    if (i == 0)
                    {
                        TextBlockLeftVar2.Text += "{";
                        TextBlockRightVar2.Text += "{";
                    }
                    int indexx = random.Next(2);
                    if (indexx == 0)
                    {
                        index = random.Next(numbers.Length);
                        if (i == 4)
                        {
                            TextBlockLeftVar2.Text += numbers[index] + "";
                            TextBlockRightVar2.Text += numbers[index] + "";
                        }
                        else
                        {
                            TextBlockLeftVar2.Text += numbers[index] + "; ";
                            TextBlockRightVar2.Text += numbers[index] + "; ";
                        }
                    }
                    else
                    {

                        index = random.Next(vowelLetters.Length);
                        if (i == 4)
                        {
                            TextBlockLeftVar2.Text += vowelLetters[index] + "";
                            TextBlockRightVar2.Text += vowelLetters[index] + "";
                        }
                        else
                        {
                            TextBlockLeftVar2.Text += vowelLetters[index] + "; ";
                            TextBlockRightVar2.Text += vowelLetters[index] + "; ";
                        }
                    }
                    
                    if (i == 4)
                    {
                        TextBlockLeftVar2.Text += "}";
                        TextBlockRightVar2.Text += "}";
                    }
                }
            }
            else
            {
                for (int i = 0; i <= 4; i++) // цикл для вывода текста 
                {
                    if (i == 0)
                    {
                        TextBlockLeftVar2.Text += "{";

                    }
                    int indexx = random.Next(2);
                    if (indexx == 0)
                    {
                        index = random.Next(numbers.Length);
                        if (i == 4)
                        {
                            TextBlockLeftVar2.Text += numbers[index] + "";

                        }
                        else
                        {
                            TextBlockLeftVar2.Text += numbers[index] + "; ";
                        }

                    }
                    else
                    {
                        index = random.Next(vowelLetters.Length);
                        if (i == 4)
                        {
                            TextBlockLeftVar2.Text += vowelLetters[index] + "";

                        }
                        else
                        {
                            TextBlockLeftVar2.Text += vowelLetters[index] + "; ";
                        }

                    }
                    if (i == 4)
                    {
                        TextBlockLeftVar2.Text += "}";

                    }
                }
                for (int i = 0; i <= 4; i++) // цикл для вывода текста 
                {
                    if (i == 0)
                    {

                        TextBlockRightVar2.Text += "{";
                    }
                    int indexx = random.Next(2);
                    if (indexx == 0)
                    {
                        index = random.Next(numbers.Length);
                        if (i == 4)
                        {
                            TextBlockRightVar2.Text += numbers[index] + "";

                        }
                        else
                        {
                            TextBlockRightVar2.Text += numbers[index] + "; ";
                        }
                    }
                    else
                    {

                        index = random.Next(vowelLetters.Length);
                        if (i == 4)
                        {
                            TextBlockRightVar2.Text += vowelLetters[index] + "";

                        }
                        else
                        {
                            TextBlockRightVar2.Text += vowelLetters[index] + "; ";
                        }
                    }
                    if (i == 4)
                    {

                        TextBlockRightVar2.Text += "}";
                    }
                }
            }
        }

        /// <summary>
        /// метод для вывода варианта ответа
        /// </summary>
        private void ShowRandomZnachenia()
        {
            int r = random.Next(2);
            if (r == 0)
            {
                for (int i = 0; i <= 4; i++) // цикл для вывода текста 
                {
                    if (i == 0)
                    {
                        TextBlockLeftVar.Text += "{";
                        TextBlockRightVar.Text += "{";
                    }
                    int indexx = random.Next(2);
                    if (indexx == 0)
                    {
                        index = random.Next(numbers.Length);
                        if (i == 4)
                        {
                            TextBlockLeftVar.Text += numbers[index] + "";
                            TextBlockRightVar.Text += numbers[index] + "";
                        }
                        else
                        {
                            TextBlockLeftVar.Text += numbers[index] + "; ";
                            TextBlockRightVar.Text += numbers[index] + "; ";
                        }
                    }
                    else
                    {

                        index = random.Next(vowelLetters.Length);
                        if (i == 4)
                        {
                            TextBlockLeftVar.Text += vowelLetters[index] + "";
                            TextBlockRightVar.Text += vowelLetters[index] + "";
                        }
                        else
                        {
                            TextBlockLeftVar.Text += vowelLetters[index] + "; ";
                            TextBlockRightVar.Text += vowelLetters[index] + "; ";
                        }
                    }
                    if (i == 4)
                    {
                        TextBlockLeftVar.Text += "}";
                        TextBlockRightVar.Text += "}";
                    }
                }
            }
            else
            {
                for (int i = 0; i <= 4; i++) // цикл для вывода текста 
                {
                    if (i == 0)
                    {
                        TextBlockLeftVar.Text += "{";

                    }
                    int indexx = random.Next(2);
                    if (indexx == 0)
                    {
                        index = random.Next(numbers.Length);
                        if (i == 4)
                        {
                            TextBlockLeftVar.Text += numbers[index] + "";

                        }
                        else
                        {
                            TextBlockLeftVar.Text += numbers[index] + "; ";
                        }

                    }
                    else
                    {

                        index = random.Next(vowelLetters.Length);
                        if (i == 4)
                        {
                            TextBlockLeftVar.Text += vowelLetters[index] + "";

                        }
                        else
                        {
                            TextBlockLeftVar.Text += vowelLetters[index] + "; ";
                        }

                    }
                    if (i == 4)
                    {
                        TextBlockLeftVar.Text += "}";

                    }
                }
                for (int i = 0; i <= 4; i++) // цикл для вывода текста 
                {
                    if (i == 0)
                    {

                        TextBlockRightVar.Text += "{";
                    }
                    int indexx = random.Next(2);
                    if (indexx == 0)
                    {
                        index = random.Next(numbers.Length);
                        if (i == 4)
                        {
                            TextBlockRightVar.Text += numbers[index] + "";

                        }
                        else
                        {
                            TextBlockRightVar.Text += numbers[index] + "; ";
                        }
                    }
                    else
                    {

                        index = random.Next(vowelLetters.Length);
                        if (i == 4)
                        {
                            TextBlockRightVar.Text += vowelLetters[index] + "";

                        }
                        else
                        {
                            TextBlockRightVar.Text += vowelLetters[index] + "; ";
                        }
                    }
                    if (i == 4)
                    {

                        TextBlockRightVar.Text += "}";
                    }
                }
            }
        }


        /// <summary>
        /// метод длявывода рандомных ответов в задание 2
        /// </summary>
        private void ShowRandomButton()
        {
            int randomAnswerOptions = random.Next(3); // вывод рандомных вариантов ответа
            int countButtonNumbers = random.Next(1, 7); // рандомное количество значений в ответе
            for (int i = 0; i <= countButtonNumbers; i++) // цикл для вывода формирования ответа для кнопки
            {
                if (i == 0)
                {
                    strButton += "{";
                }
                index = random.Next(numbers.Length);
                if (i == countButtonNumbers)
                {
                    strButton += numbers[index] + "";
                }
                else
                {
                    strButton += numbers[index] + "; ";
                }
                if (i == countButtonNumbers)
                {
                    strButton += "}";
                }
            }
            countButtonNumbers = random.Next(1, 7); // рандомное количество значений в ответе
            for (int i = 0; i <= countButtonNumbers; i++) // цикл для вывода формирования ответа для кнопки
            {
                if (i == 0)
                {
                    strButtonTwo += "{";
                }
                index = random.Next(numbers.Length);
                if (i == countButtonNumbers)
                {
                    strButtonTwo += numbers[index] + "";
                }
                else
                {
                    strButtonTwo += numbers[index] + "; ";
                }
                if (i == countButtonNumbers)
                {
                    strButtonTwo += "}";
                }
            }
            for (int i = 0; i <= 1; i++) // цикл для вывода формирования ответа для кнопки
            {
                if (i == 0)
                {
                    strButtonThree += "{";
                }
                strButtonThree += " ";
                if (i == 1)
                {
                    strButtonThree += "}";
                }
            }

            if (randomAnswerOptions == 0)
            {
                OptionOne.Content = strButton;
                OptionTwo.Content = strButtonTwo;
                OptionThree.Content = strButtonThree;
            }
            else if (randomAnswerOptions == 1)
            {
                OptionOne.Content = strButtonTwo;
                OptionTwo.Content = strButtonThree;
                OptionThree.Content = strButton;
            }
            else if (randomAnswerOptions == 2)
            {
                OptionOne.Content = strButtonThree;
                OptionTwo.Content = strButton;
                OptionThree.Content = strButtonTwo;
            }
        }


        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Base.MainFrame.Navigate(new MainMenuPage());
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxTextSign.Text != "" && ComboBoxTextSign2.Text != "")
            {
                string strAnswer = ""; // переменна для записи ответа, который выбрал пользователь
                string strAnswer2 = ""; // переменна для записи ответа, который выбрал пользователь
                if ((((TextBlockLeftVar.Text == TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex == 0) || ((TextBlockLeftVar.Text != TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex == 1)) && (((TextBlockLeftVar2.Text != TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex == 1) || ((TextBlockLeftVar2.Text == TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex == 0))) // если пользователь выбрал правильный ответ
                {
                    windows.CorrectResult correctResult = new windows.CorrectResult(); // Вывод окна "Ты молодец"
                    correctResult.ShowDialog();
                }
                else // если пользователь выбрал неверный ответ
                {
                    if ((TextBlockLeftVar.Text == TextBlockRightVar.Text && ComboBoxTextSign.SelectedIndex == 0) || (TextBlockLeftVar.Text != TextBlockRightVar.Text && ComboBoxTextSign.SelectedIndex == 1))
                    {
                        if (TextBlockLeftVar2.Text != TextBlockRightVar2.Text)
                        {
                            strAnswer2 = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer2 = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        windows.ResultEqualSetsSolvengTasksWindow resultEqualSetsSolvengTasksWindo = new windows.ResultEqualSetsSolvengTasksWindow(strAnswer2, TextBlockLeftVar2.Text, TextBlockRightVar2.Text);
                        resultEqualSetsSolvengTasksWindo.ShowDialog();
                    }
                    else if ((TextBlockLeftVar2.Text == TextBlockRightVar2.Text && ComboBoxTextSign2.SelectedIndex == 0) || (TextBlockLeftVar2.Text != TextBlockRightVar2.Text && ComboBoxTextSign2.SelectedIndex == 1))
                    {
                        if (TextBlockLeftVar.Text != TextBlockRightVar.Text)
                        {
                            strAnswer = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        windows.ResultEqualSetsSolvengTasksWindow resultEqualSetsSolvengTasksWindow1 = new windows.ResultEqualSetsSolvengTasksWindow(strAnswer, TextBlockLeftVar.Text, TextBlockRightVar.Text);
                        resultEqualSetsSolvengTasksWindow1.ShowDialog();
                    }
                    else
                    {
                        if (TextBlockLeftVar.Text != TextBlockRightVar.Text)
                        {
                            strAnswer = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }

                        if (TextBlockLeftVar2.Text != TextBlockRightVar2.Text)
                        {
                            strAnswer2 = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer2 = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }

                        windows.ResultEqualSetsSolvengTasksWindow resultEqualSetsSolvengTasksWindow3 = new windows.ResultEqualSetsSolvengTasksWindow(strAnswer, strAnswer2, TextBlockLeftVar.Text, TextBlockRightVar.Text, TextBlockLeftVar2.Text, TextBlockRightVar2.Text);
                        resultEqualSetsSolvengTasksWindow3.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show($"Выбери ответ");
            }

        }


        SolidColorBrush colorButton = new SolidColorBrush(Color.FromRgb(241, 76, 24)); // цвет для кнопок, в который они перекрасятся при нажатии


        private void BtnHint_Click_1(object sender, RoutedEventArgs e)
        {
            windows.HintEqualSetsWindow hint = new windows.HintEqualSetsWindow();
            hint.ShowDialog();
        }


        private void MenuRefresh_Click(object sender, RoutedEventArgs e)
        {
            MenuItem childMenuItem = (MenuItem)sender;
            MenuItem menuItem = (MenuItem)childMenuItem.Parent;

            switch (Convert.ToInt32(menuItem.Uid))
            {
                case 1:
                    TextBlockLeftVar.Text = "";
                    TextBlockRightVar.Text = "";
                    TextBlockLeftVar2.Text = "";
                    TextBlockRightVar2.Text = "";
                    ComboBoxTextSign2.Text = "";
                    ComboBoxTextSign.Text = "";
                    ShowRandomZnachenia();
                    ShowRandomZnachenia2();

                    break;
                case 2:
                    strButton = "";
                    strButtonTwo = "";
                    strButtonThree = "";
                    ShowRandomButton();
                    OptionThree.ClearValue(Button.BackgroundProperty);
                    OptionOne.ClearValue(Button.BackgroundProperty);
                    OptionTwo.ClearValue(Button.BackgroundProperty);
                    break;
                default:
                    break;
            }
        }

        private void BtnResultTaskTwo_Click(object sender, RoutedEventArgs e)
        {
            string strAnswer = ""; // переменна для записи ответа, который выбрал пользователь
            if (OptionOne.Background == colorButton)
            {
                strAnswer = Convert.ToString(OptionOne.Content);
                if (strAnswer == "{  }") // если пользователь выбрал правильный ответ
                {
                    windows.CorrectResult correctResult = new windows.CorrectResult(); // Вывод окна "Ты молодец"
                    correctResult.ShowDialog();
                }
                else // если пользователь выбрал неверный ответ
                {
                    strAnswer = "{  }"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                    windows.ResultSetAndElementsTasksWindow resultSetAndElementsTasks = new windows.ResultSetAndElementsTasksWindow(strAnswer);
                    resultSetAndElementsTasks.ShowDialog();
                }
            }
            else if (OptionTwo.Background == colorButton)
            {
                strAnswer = Convert.ToString(OptionTwo.Content);
                if (strAnswer == "{  }") // если пользователь выбрал правильный ответ
                {
                    windows.CorrectResult correctResult = new windows.CorrectResult(); // Вывод окна "Ты молодец"
                    correctResult.ShowDialog();
                }
                else // если пользователь выбрал неверный ответ
                {
                    strAnswer = "{  }"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                    windows.ResultSetAndElementsTasksWindow resultSetAndElementsTasks = new windows.ResultSetAndElementsTasksWindow(strAnswer);
                    resultSetAndElementsTasks.ShowDialog();
                }
            }
            else if (OptionThree.Background == colorButton)
            {
                strAnswer = Convert.ToString(OptionThree.Content);
                if (strAnswer == "{  }") // если пользователь выбрал правильный ответ
                {
                    windows.CorrectResult correctResult = new windows.CorrectResult(); // Вывод окна "Ты молодец"
                    correctResult.ShowDialog();
                }
                else // если пользователь выбрал неверный ответ
                {
                    strAnswer = "{  }"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                    windows.ResultSetAndElementsTasksWindow resultSetAndElementsTasks = new windows.ResultSetAndElementsTasksWindow(strAnswer);
                    resultSetAndElementsTasks.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show($"Выбери ответ");
            }
        }

        private void OptionOne_Click(object sender, RoutedEventArgs e)
        {
            OptionOne.Background = colorButton; // красим кнопку
            OptionTwo.ClearValue(Button.BackgroundProperty); // с остальных кнопок снимаем окрас
            OptionThree.ClearValue(Button.BackgroundProperty); // с остальных кнопок снимаем окрас
        }

        private void OptionTwo_Click(object sender, RoutedEventArgs e)
        {
            OptionTwo.Background = colorButton; // красим кнопку
            OptionOne.ClearValue(Button.BackgroundProperty); // с остальных кнопок снимаем окрас
            OptionThree.ClearValue(Button.BackgroundProperty); // с остальных кнопок снимаем окрас
        }

        private void OptionThree_Click(object sender, RoutedEventArgs e)
        {
            OptionThree.Background = colorButton; // красим кнопку
            OptionOne.ClearValue(Button.BackgroundProperty); // с остальных кнопок снимаем окрас
            OptionTwo.ClearValue(Button.BackgroundProperty); // с остальных кнопок снимаем окрас
        }
        private void MenuGuide_Click(object sender, RoutedEventArgs e)
        {
            MenuItem childMenuItem = (MenuItem)sender;
            MenuItem menuItem = (MenuItem)childMenuItem.Parent;

            new windows.GuideWindow(2, Convert.ToInt32(menuItem.Uid)).ShowDialog();
        }
    }
}
