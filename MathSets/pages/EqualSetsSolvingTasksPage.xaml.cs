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

        private string[] _numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }; // массив цифр
        private string[] _vowelLetters = { "а", "о", "у", "ы", "э", "е", "ё", "и", "ю", "я" }; // массив гласный букв
        private static Random _random = new Random();
        private int _index;
        private string _strButton = ""; // значение для первой кнопки-ответ
        private string _strButtonTwo = ""; // значение для второй кнопки-ответ
        private string _strButtonThree = ""; // значение для третьей кнопки-ответ


        public EqualSetsSolvingTasksPage()
        {
            InitializeComponent();


            ShowRandomButton();
            ShowRandomZnachenia();
            ShowRandomZnachenia2();
            ShowRandomZnachenia3();
            ShowRandomZnachenia4();
        }

        /// <summary>
        /// метод для вывода множества в задание 1 для третьего равенства
        /// </summary>
        private void ShowRandomZnachenia3()
        {
            int r = _random.Next(2);
            if (r == 0)
            {
                for (int i = 0; i <= 4; i++) // цикл для вывода текста 
                {
                    if (i == 0)
                    {
                        TextBlockLeftVar3.Text += "{";
                        TextBlockRightVar3.Text += "{";
                    }
                    int indexx = _random.Next(2);
                    if (indexx == 0)
                    {
                        _index = _random.Next(_numbers.Length);
                        if (i == 4)
                        {
                            TextBlockLeftVar3.Text += _numbers[_index] + "";
                            TextBlockRightVar3.Text += _numbers[_index] + "";
                        }
                        else
                        {
                            TextBlockLeftVar3.Text += _numbers[_index] + "; ";
                            TextBlockRightVar3.Text += _numbers[_index] + "; ";
                        }
                    }
                    else
                    {
                        _index = _random.Next(_vowelLetters.Length);
                        if (i == 4)
                        {
                            TextBlockLeftVar3.Text += _vowelLetters[_index] + "";
                            TextBlockRightVar3.Text += _vowelLetters[_index] + "";
                        }
                        else
                        {
                            TextBlockLeftVar3.Text += _vowelLetters[_index] + "; ";
                            TextBlockRightVar3.Text += _vowelLetters[_index] + "; ";
                        }
                    }

                    if (i == 4)
                    {
                        TextBlockLeftVar3.Text += "}";
                        TextBlockRightVar3.Text += "}";
                    }
                }
            }
            else
            {
                for (int i = 0; i <= 4; i++) // цикл для вывода текста 
                {
                    if (i == 0)
                    {
                        TextBlockLeftVar3.Text += "{";

                    }
                    int indexx = _random.Next(2);
                    if (indexx == 0)
                    {
                        _index = _random.Next(_numbers.Length);
                        if (i == 4)
                        {
                            TextBlockLeftVar3.Text += _numbers[_index] + "";

                        }
                        else
                        {
                            TextBlockLeftVar3.Text += _numbers[_index] + "; ";
                        }

                    }
                    else
                    {
                        _index = _random.Next(_vowelLetters.Length);
                        if (i == 4)
                        {
                            TextBlockLeftVar3.Text += _vowelLetters[_index] + "";

                        }
                        else
                        {
                            TextBlockLeftVar3.Text += _vowelLetters[_index] + "; ";
                        }

                    }
                    if (i == 4)
                    {
                        TextBlockLeftVar3.Text += "}";

                    }
                }
                for (int i = 0; i <= 4; i++) // цикл для вывода текста 
                {
                    if (i == 0)
                    {

                        TextBlockRightVar3.Text += "{";
                    }
                    int indexx = _random.Next(2);
                    if (indexx == 0)
                    {
                        _index = _random.Next(_numbers.Length);
                        if (i == 4)
                        {
                            TextBlockRightVar3.Text += _numbers[_index] + "";

                        }
                        else
                        {
                            TextBlockRightVar3.Text += _numbers[_index] + "; ";
                        }
                    }
                    else
                    {

                        _index = _random.Next(_vowelLetters.Length);
                        if (i == 4)
                        {
                            TextBlockRightVar3.Text += _vowelLetters[_index] + "";

                        }
                        else
                        {
                            TextBlockRightVar3.Text += _vowelLetters[_index] + "; ";
                        }
                    }
                    if (i == 4)
                    {

                        TextBlockRightVar3.Text += "}";
                    }
                }
            }
        }

        /// <summary>
        /// метод для вывода множества в задание 1 для четвертого равенства
        /// </summary>
        private void ShowRandomZnachenia4()
        {
            int r = _random.Next(2);
            if (r == 0)
            {
                for (int i = 0; i <= 4; i++) // цикл для вывода текста 
                {
                    if (i == 0)
                    {
                        TextBlockLeftVar4.Text += "{";
                        TextBlockRightVar4.Text += "{";
                    }
                    int indexx = _random.Next(2);
                    if (indexx == 0)
                    {
                        _index = _random.Next(_numbers.Length);
                        if (i == 4)
                        {
                            TextBlockLeftVar4.Text += _numbers[_index] + "";
                            TextBlockRightVar4.Text += _numbers[_index] + "";
                        }
                        else
                        {
                            TextBlockLeftVar4.Text += _numbers[_index] + "; ";
                            TextBlockRightVar4.Text += _numbers[_index] + "; ";
                        }
                    }
                    else
                    {
                        _index = _random.Next(_vowelLetters.Length);
                        if (i == 4)
                        {
                            TextBlockLeftVar4.Text += _vowelLetters[_index] + "";
                            TextBlockRightVar4.Text += _vowelLetters[_index] + "";
                        }
                        else
                        {
                            TextBlockLeftVar4.Text += _vowelLetters[_index] + "; ";
                            TextBlockRightVar4.Text += _vowelLetters[_index] + "; ";
                        }
                    }

                    if (i == 4)
                    {
                        TextBlockLeftVar4.Text += "}";
                        TextBlockRightVar4.Text += "}";
                    }
                }
            }
            else
            {
                for (int i = 0; i <= 4; i++) // цикл для вывода текста 
                {
                    if (i == 0)
                    {
                        TextBlockLeftVar4.Text += "{";

                    }
                    int indexx = _random.Next(2);
                    if (indexx == 0)
                    {
                        _index = _random.Next(_numbers.Length);
                        if (i == 4)
                        {
                            TextBlockLeftVar4.Text += _numbers[_index] + "";

                        }
                        else
                        {
                            TextBlockLeftVar4.Text += _numbers[_index] + "; ";
                        }

                    }
                    else
                    {
                        _index = _random.Next(_vowelLetters.Length);
                        if (i == 4)
                        {
                            TextBlockLeftVar4.Text += _vowelLetters[_index] + "";

                        }
                        else
                        {
                            TextBlockLeftVar4.Text += _vowelLetters[_index] + "; ";
                        }

                    }
                    if (i == 4)
                    {
                        TextBlockLeftVar4.Text += "}";

                    }
                }
                for (int i = 0; i <= 4; i++) // цикл для вывода текста 
                {
                    if (i == 0)
                    {

                        TextBlockRightVar4.Text += "{";
                    }
                    int indexx = _random.Next(2);
                    if (indexx == 0)
                    {
                        _index = _random.Next(_numbers.Length);
                        if (i == 4)
                        {
                            TextBlockRightVar4.Text += _numbers[_index] + "";

                        }
                        else
                        {
                            TextBlockRightVar4.Text += _numbers[_index] + "; ";
                        }
                    }
                    else
                    {

                        _index = _random.Next(_vowelLetters.Length);
                        if (i == 4)
                        {
                            TextBlockRightVar4.Text += _vowelLetters[_index] + "";

                        }
                        else
                        {
                            TextBlockRightVar4.Text += _vowelLetters[_index] + "; ";
                        }
                    }
                    if (i == 4)
                    {

                        TextBlockRightVar4.Text += "}";
                    }
                }
            }
        }

        /// <summary>
        /// метод для вывода множества в задание 1 для второго равенства
        /// </summary>
        private void ShowRandomZnachenia2()
        {
            int r = _random.Next(2);
            if (r == 0)
            {
                for (int i = 0; i <= 4; i++) // цикл для вывода текста 
                {
                    if (i == 0)
                    {
                        TextBlockLeftVar2.Text += "{";
                        TextBlockRightVar2.Text += "{";
                    }
                    int indexx = _random.Next(2);
                    if (indexx == 0)
                    {
                        _index = _random.Next(_numbers.Length);
                        if (i == 4)
                        {
                            TextBlockLeftVar2.Text += _numbers[_index] + "";
                            TextBlockRightVar2.Text += _numbers[_index] + "";
                        }
                        else
                        {
                            TextBlockLeftVar2.Text += _numbers[_index] + "; ";
                            TextBlockRightVar2.Text += _numbers[_index] + "; ";
                        }
                    }
                    else
                    {

                        _index = _random.Next(_vowelLetters.Length);
                        if (i == 4)
                        {
                            TextBlockLeftVar2.Text += _vowelLetters[_index] + "";
                            TextBlockRightVar2.Text += _vowelLetters[_index] + "";
                        }
                        else
                        {
                            TextBlockLeftVar2.Text += _vowelLetters[_index] + "; ";
                            TextBlockRightVar2.Text += _vowelLetters[_index] + "; ";
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
                    int indexx = _random.Next(2);
                    if (indexx == 0)
                    {
                        _index = _random.Next(_numbers.Length);
                        if (i == 4)
                        {
                            TextBlockLeftVar2.Text += _numbers[_index] + "";

                        }
                        else
                        {
                            TextBlockLeftVar2.Text += _numbers[_index] + "; ";
                        }

                    }
                    else
                    {
                        _index = _random.Next(_vowelLetters.Length);
                        if (i == 4)
                        {
                            TextBlockLeftVar2.Text += _vowelLetters[_index] + "";

                        }
                        else
                        {
                            TextBlockLeftVar2.Text += _vowelLetters[_index] + "; ";
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
                    int indexx = _random.Next(2);
                    if (indexx == 0)
                    {
                        _index = _random.Next(_numbers.Length);
                        if (i == 4)
                        {
                            TextBlockRightVar2.Text += _numbers[_index] + "";

                        }
                        else
                        {
                            TextBlockRightVar2.Text += _numbers[_index] + "; ";
                        }
                    }
                    else
                    {

                        _index = _random.Next(_vowelLetters.Length);
                        if (i == 4)
                        {
                            TextBlockRightVar2.Text += _vowelLetters[_index] + "";

                        }
                        else
                        {
                            TextBlockRightVar2.Text += _vowelLetters[_index] + "; ";
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
        /// метод для вывода множества в задание 1 для первого равенства
        /// </summary>
        private void ShowRandomZnachenia()
        {
            int r = _random.Next(2);
            if (r == 0)
            {
                for (int i = 0; i <= 4; i++) // цикл для вывода текста 
                {
                    if (i == 0)
                    {
                        TextBlockLeftVar.Text += "{";
                        TextBlockRightVar.Text += "{";
                    }
                    int indexx = _random.Next(2);
                    if (indexx == 0)
                    {
                        _index = _random.Next(_numbers.Length);
                        if (i == 4)
                        {
                            TextBlockLeftVar.Text += _numbers[_index] + "";
                            TextBlockRightVar.Text += _numbers[_index] + "";
                        }
                        else
                        {
                            TextBlockLeftVar.Text += _numbers[_index] + "; ";
                            TextBlockRightVar.Text += _numbers[_index] + "; ";
                        }
                    }
                    else
                    {

                        _index = _random.Next(_vowelLetters.Length);
                        if (i == 4)
                        {
                            TextBlockLeftVar.Text += _vowelLetters[_index] + "";
                            TextBlockRightVar.Text += _vowelLetters[_index] + "";
                        }
                        else
                        {
                            TextBlockLeftVar.Text += _vowelLetters[_index] + "; ";
                            TextBlockRightVar.Text += _vowelLetters[_index] + "; ";
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
                    int indexx = _random.Next(2);
                    if (indexx == 0)
                    {
                        _index = _random.Next(_numbers.Length);
                        if (i == 4)
                        {
                            TextBlockLeftVar.Text += _numbers[_index] + "";

                        }
                        else
                        {
                            TextBlockLeftVar.Text += _numbers[_index] + "; ";
                        }

                    }
                    else
                    {

                        _index = _random.Next(_vowelLetters.Length);
                        if (i == 4)
                        {
                            TextBlockLeftVar.Text += _vowelLetters[_index] + "";

                        }
                        else
                        {
                            TextBlockLeftVar.Text += _vowelLetters[_index] + "; ";
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
                    int indexx = _random.Next(2);
                    if (indexx == 0)
                    {
                        _index = _random.Next(_numbers.Length);
                        if (i == 4)
                        {
                            TextBlockRightVar.Text += _numbers[_index] + "";

                        }
                        else
                        {
                            TextBlockRightVar.Text += _numbers[_index] + "; ";
                        }
                    }
                    else
                    {

                        _index = _random.Next(_vowelLetters.Length);
                        if (i == 4)
                        {
                            TextBlockRightVar.Text += _vowelLetters[_index] + "";

                        }
                        else
                        {
                            TextBlockRightVar.Text += _vowelLetters[_index] + "; ";
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
        /// метод для вывода рандомных ответов в задание 2
        /// </summary>
        private void ShowRandomButton()
        {
            int randomAnswerOptions = _random.Next(3); // вывод рандомных вариантов ответа
            int countButtonNumbers = _random.Next(1, 7); // рандомное количество значений в ответе
            for (int i = 0; i <= countButtonNumbers; i++) // цикл для вывода формирования ответа для кнопки
            {
                if (i == 0)
                {
                    _strButton += "{";
                }
                _index = _random.Next(_numbers.Length);
                if (i == countButtonNumbers)
                {
                    _strButton += _numbers[_index] + "";
                }
                else
                {
                    _strButton += _numbers[_index] + "; ";
                }
                if (i == countButtonNumbers)
                {
                    _strButton += "}";
                }
            }
            countButtonNumbers = _random.Next(1, 7); // рандомное количество значений в ответе
            for (int i = 0; i <= countButtonNumbers; i++) // цикл для вывода формирования ответа для кнопки
            {
                if (i == 0)
                {
                    _strButtonTwo += "{";
                }
                _index = _random.Next(_numbers.Length);
                if (i == countButtonNumbers)
                {
                    _strButtonTwo += _numbers[_index] + "";
                }
                else
                {
                    _strButtonTwo += _numbers[_index] + "; ";
                }
                if (i == countButtonNumbers)
                {
                    _strButtonTwo += "}";
                }
            }
            for (int i = 0; i <= 1; i++) // цикл для вывода формирования ответа для кнопки
            {
                if (i == 0)
                {
                    _strButtonThree += "{";
                }
                _strButtonThree += " ";
                if (i == 1)
                {
                    _strButtonThree += "}";
                }
            }

            if (randomAnswerOptions == 0)
            {
                OptionOne.Content = _strButton;
                OptionTwo.Content = _strButtonTwo;
                OptionThree.Content = _strButtonThree;
            }
            else if (randomAnswerOptions == 1)
            {
                OptionOne.Content = _strButtonTwo;
                OptionTwo.Content = _strButtonThree;
                OptionThree.Content = _strButton;
            }
            else if (randomAnswerOptions == 2)
            {
                OptionOne.Content = _strButtonThree;
                OptionTwo.Content = _strButton;
                OptionThree.Content = _strButtonTwo;
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
                string strAnswer3 = ""; // переменна для записи ответа, который выбрал пользователь
                string strAnswer4 = ""; // переменна для записи ответа, который выбрал пользователь
                if ((((TextBlockLeftVar.Text == TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex == 0) || ((TextBlockLeftVar.Text != TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex == 1)) && 
                    (((TextBlockLeftVar2.Text != TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex == 1) || ((TextBlockLeftVar2.Text == TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex == 0)) &&
                     (((TextBlockLeftVar3.Text != TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex == 1) || ((TextBlockLeftVar3.Text == TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex == 0)) &&
                      (((TextBlockLeftVar4.Text != TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex == 1) || ((TextBlockLeftVar4.Text == TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex == 0))) // если пользователь выбрал правильный ответ
                {
                    windows.CorrectResult correctResult = new windows.CorrectResult(); // Вывод окна "Ты молодец"
                    correctResult.ShowDialog();
                }
                else // если пользователь выбрал неверный ответ
                {
                    if ((((TextBlockLeftVar.Text == TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex == 0) || ((TextBlockLeftVar.Text != TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex == 1)) &&
                        (((TextBlockLeftVar3.Text != TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex == 1) || ((TextBlockLeftVar3.Text == TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex == 0)) &&
                        (((TextBlockLeftVar4.Text != TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex == 1) || ((TextBlockLeftVar4.Text == TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex == 0)))
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
                    else if ((((TextBlockLeftVar.Text == TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex != 0) || ((TextBlockLeftVar.Text != TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex != 1)) &&
                        (((TextBlockLeftVar3.Text != TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex == 1) || ((TextBlockLeftVar3.Text == TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex == 0)) &&
                        (((TextBlockLeftVar4.Text != TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex == 1) || ((TextBlockLeftVar4.Text == TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex == 0)) &&
                        (((TextBlockLeftVar2.Text == TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex != 0) || ((TextBlockLeftVar2.Text != TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex != 1)))
                    {
                        if (TextBlockLeftVar2.Text != TextBlockRightVar2.Text)
                        {
                            strAnswer2 = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer2 = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        if (TextBlockLeftVar.Text != TextBlockRightVar.Text)
                        {
                            strAnswer = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        windows.ResultEqualSetsSolvengTasksWindow resultEqualSetsSolvengTasksWindo = new windows.ResultEqualSetsSolvengTasksWindow(strAnswer, strAnswer2, TextBlockLeftVar.Text, TextBlockRightVar.Text, TextBlockLeftVar2.Text, TextBlockRightVar2.Text);
                        resultEqualSetsSolvengTasksWindo.ShowDialog();
                    }
                    else if ((((TextBlockLeftVar.Text == TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex != 0) || ((TextBlockLeftVar.Text != TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex != 1)) &&
                       (((TextBlockLeftVar3.Text != TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex != 1) || ((TextBlockLeftVar3.Text == TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex != 0)) &&
                       (((TextBlockLeftVar4.Text != TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex == 1) || ((TextBlockLeftVar4.Text == TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex == 0)) &&
                       (((TextBlockLeftVar2.Text == TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex != 0) || ((TextBlockLeftVar2.Text != TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex != 1)))
                    {
                        if (TextBlockLeftVar2.Text != TextBlockRightVar2.Text)
                        {
                            strAnswer2 = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer2 = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        if (TextBlockLeftVar.Text != TextBlockRightVar.Text)
                        {
                            strAnswer = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        if (TextBlockLeftVar3.Text != TextBlockRightVar3.Text)
                        {
                            strAnswer3 = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer3 = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        windows.ResultEqualSetsSolvengTasksWindow resultEqualSetsSolvengTasksWindo = new windows.ResultEqualSetsSolvengTasksWindow(strAnswer, strAnswer2, strAnswer3, TextBlockLeftVar.Text, TextBlockRightVar.Text, TextBlockLeftVar2.Text, TextBlockRightVar2.Text, TextBlockLeftVar3.Text, TextBlockRightVar3.Text);
                        resultEqualSetsSolvengTasksWindo.ShowDialog();
                    }
                    else if ((((TextBlockLeftVar.Text == TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex != 0) || ((TextBlockLeftVar.Text != TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex != 1)) &&
                        (((TextBlockLeftVar2.Text != TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex == 1) || ((TextBlockLeftVar2.Text == TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex == 0)) &&
                        (((TextBlockLeftVar4.Text != TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex == 1) || ((TextBlockLeftVar4.Text == TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex == 0)) &&
                        (((TextBlockLeftVar3.Text == TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex != 0) || ((TextBlockLeftVar3.Text != TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex != 1)))
                    {
                        if (TextBlockLeftVar3.Text != TextBlockRightVar3.Text)
                        {
                            strAnswer3 = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer3 = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        if (TextBlockLeftVar.Text != TextBlockRightVar.Text)
                        {
                            strAnswer = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        windows.ResultEqualSetsSolvengTasksWindow resultEqualSetsSolvengTasksWindo = new windows.ResultEqualSetsSolvengTasksWindow(strAnswer, strAnswer3, TextBlockLeftVar.Text, TextBlockRightVar.Text, TextBlockLeftVar3.Text, TextBlockRightVar3.Text);
                        resultEqualSetsSolvengTasksWindo.ShowDialog();
                    }
                    else if ((((TextBlockLeftVar.Text == TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex != 0) || ((TextBlockLeftVar.Text != TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex != 1)) &&
                      (((TextBlockLeftVar2.Text != TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex == 1) || ((TextBlockLeftVar2.Text == TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex == 0)) &&
                      (((TextBlockLeftVar4.Text != TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex != 1) || ((TextBlockLeftVar4.Text == TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex != 0)) &&
                      (((TextBlockLeftVar3.Text == TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex != 0) || ((TextBlockLeftVar3.Text != TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex != 1)))
                    {
                        if (TextBlockLeftVar3.Text != TextBlockRightVar3.Text)
                        {
                            strAnswer3 = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer3 = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        if (TextBlockLeftVar.Text != TextBlockRightVar.Text)
                        {
                            strAnswer = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        if (TextBlockLeftVar4.Text != TextBlockRightVar4.Text)
                        {
                            strAnswer4 = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer4 = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        windows.ResultEqualSetsSolvengTasksWindow resultEqualSetsSolvengTasksWindo = new windows.ResultEqualSetsSolvengTasksWindow(strAnswer, strAnswer3, strAnswer4, TextBlockLeftVar.Text, TextBlockRightVar.Text, TextBlockLeftVar3.Text, TextBlockRightVar3.Text, TextBlockLeftVar4.Text, TextBlockRightVar4.Text);
                        resultEqualSetsSolvengTasksWindo.ShowDialog();
                    }
                    else if ((((TextBlockLeftVar.Text == TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex != 0) || ((TextBlockLeftVar.Text != TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex != 1)) &&
                      (((TextBlockLeftVar2.Text != TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex == 1) || ((TextBlockLeftVar2.Text == TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex == 0)) &&
                      (((TextBlockLeftVar3.Text != TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex == 1) || ((TextBlockLeftVar3.Text == TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex == 0)) &&
                      (((TextBlockLeftVar4.Text == TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex != 0) || ((TextBlockLeftVar4.Text != TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex != 1)))
                    {
                        if (TextBlockLeftVar4.Text != TextBlockRightVar4.Text)
                        {
                            strAnswer4 = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer4 = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        if (TextBlockLeftVar.Text != TextBlockRightVar.Text)
                        {
                            strAnswer = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        windows.ResultEqualSetsSolvengTasksWindow resultEqualSetsSolvengTasksWindo = new windows.ResultEqualSetsSolvengTasksWindow(strAnswer, strAnswer4, TextBlockLeftVar.Text, TextBlockRightVar.Text, TextBlockLeftVar4.Text, TextBlockRightVar4.Text);
                        resultEqualSetsSolvengTasksWindo.ShowDialog();
                    }
                    else if ((((TextBlockLeftVar2.Text == TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex != 0) || ((TextBlockLeftVar2.Text != TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex != 1)) &&
                    (((TextBlockLeftVar.Text != TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex == 1) || ((TextBlockLeftVar.Text == TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex == 0)) &&
                    (((TextBlockLeftVar4.Text != TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex == 1) || ((TextBlockLeftVar4.Text == TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex == 0)) &&
                    (((TextBlockLeftVar3.Text == TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex != 0) || ((TextBlockLeftVar3.Text != TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex != 1)))
                    {
                        if (TextBlockLeftVar3.Text != TextBlockRightVar3.Text)
                        {
                            strAnswer3 = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer3 = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        if (TextBlockLeftVar2.Text != TextBlockRightVar2.Text)
                        {
                            strAnswer2 = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer2 = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        windows.ResultEqualSetsSolvengTasksWindow resultEqualSetsSolvengTasksWindo = new windows.ResultEqualSetsSolvengTasksWindow(strAnswer2, strAnswer3, TextBlockLeftVar2.Text, TextBlockRightVar2.Text, TextBlockLeftVar3.Text, TextBlockRightVar3.Text);
                        resultEqualSetsSolvengTasksWindo.ShowDialog();
                    }
                    else if ((((TextBlockLeftVar2.Text == TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex != 0) || ((TextBlockLeftVar2.Text != TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex != 1)) &&
                 (((TextBlockLeftVar.Text != TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex == 1) || ((TextBlockLeftVar.Text == TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex == 0)) &&
                 (((TextBlockLeftVar4.Text != TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex != 1) || ((TextBlockLeftVar4.Text == TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex != 0)) &&
                 (((TextBlockLeftVar3.Text == TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex != 0) || ((TextBlockLeftVar3.Text != TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex != 1)))
                    {
                        if (TextBlockLeftVar3.Text != TextBlockRightVar3.Text)
                        {
                            strAnswer3 = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer3 = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        if (TextBlockLeftVar2.Text != TextBlockRightVar2.Text)
                        {
                            strAnswer2 = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer2 = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        if (TextBlockLeftVar4.Text != TextBlockRightVar4.Text)
                        {
                            strAnswer4 = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer4 = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        windows.ResultEqualSetsSolvengTasksWindow resultEqualSetsSolvengTasksWindo = new windows.ResultEqualSetsSolvengTasksWindow(strAnswer2, strAnswer3, strAnswer4, TextBlockLeftVar2.Text, TextBlockRightVar2.Text, TextBlockLeftVar3.Text, TextBlockRightVar3.Text, TextBlockLeftVar4.Text, TextBlockRightVar4.Text);
                        resultEqualSetsSolvengTasksWindo.ShowDialog();
                    }
                    else if ((((TextBlockLeftVar2.Text == TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex != 0) || ((TextBlockLeftVar2.Text != TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex != 1)) &&
               (((TextBlockLeftVar3.Text != TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex == 1) || ((TextBlockLeftVar3.Text == TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex == 0)) &&
               (((TextBlockLeftVar4.Text != TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex != 1) || ((TextBlockLeftVar4.Text == TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex != 0)) &&
               (((TextBlockLeftVar.Text == TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex != 0) || ((TextBlockLeftVar.Text != TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex != 1)))
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
                        if (TextBlockLeftVar4.Text != TextBlockRightVar4.Text)
                        {
                            strAnswer4 = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer4 = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        windows.ResultEqualSetsSolvengTasksWindow resultEqualSetsSolvengTasksWindo = new windows.ResultEqualSetsSolvengTasksWindow(strAnswer2, strAnswer, strAnswer4, TextBlockLeftVar2.Text, TextBlockRightVar2.Text, TextBlockLeftVar.Text, TextBlockRightVar.Text, TextBlockLeftVar4.Text, TextBlockRightVar4.Text);
                        resultEqualSetsSolvengTasksWindo.ShowDialog();
                    }
                    else if ((((TextBlockLeftVar2.Text == TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex != 0) || ((TextBlockLeftVar2.Text != TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex != 1)) &&
                    (((TextBlockLeftVar.Text != TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex == 1) || ((TextBlockLeftVar.Text == TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex == 0)) &&
                    (((TextBlockLeftVar3.Text != TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex == 1) || ((TextBlockLeftVar3.Text == TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex == 0)) &&
                    (((TextBlockLeftVar4.Text == TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex != 0) || ((TextBlockLeftVar4.Text != TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex != 1)))
                    {
                        if (TextBlockLeftVar4.Text != TextBlockRightVar4.Text)
                        {
                            strAnswer4 = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer4 = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        if (TextBlockLeftVar2.Text != TextBlockRightVar2.Text)
                        {
                            strAnswer2 = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer2 = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        windows.ResultEqualSetsSolvengTasksWindow resultEqualSetsSolvengTasksWindo = new windows.ResultEqualSetsSolvengTasksWindow(strAnswer2, strAnswer4, TextBlockLeftVar2.Text, TextBlockRightVar2.Text, TextBlockLeftVar4.Text, TextBlockRightVar4.Text);
                        resultEqualSetsSolvengTasksWindo.ShowDialog();
                    }
                    else if ((((TextBlockLeftVar3.Text == TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex != 0) || ((TextBlockLeftVar3.Text != TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex != 1)) &&
                   (((TextBlockLeftVar.Text != TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex == 1) || ((TextBlockLeftVar.Text == TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex == 0)) &&
                   (((TextBlockLeftVar2.Text != TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex == 1) || ((TextBlockLeftVar2.Text == TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex == 0)) &&
                   (((TextBlockLeftVar4.Text == TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex != 0) || ((TextBlockLeftVar4.Text != TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex != 1)))
                    {
                        if (TextBlockLeftVar4.Text != TextBlockRightVar4.Text)
                        {
                            strAnswer4 = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer4 = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        if (TextBlockLeftVar3.Text != TextBlockRightVar3.Text)
                        {
                            strAnswer3 = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer3 = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        windows.ResultEqualSetsSolvengTasksWindow resultEqualSetsSolvengTasksWindo = new windows.ResultEqualSetsSolvengTasksWindow(strAnswer3, strAnswer4, TextBlockLeftVar3.Text, TextBlockRightVar3.Text, TextBlockLeftVar4.Text, TextBlockRightVar4.Text);
                        resultEqualSetsSolvengTasksWindo.ShowDialog();
                    }
                    else if ((((TextBlockLeftVar2.Text == TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex == 0) || ((TextBlockLeftVar2.Text != TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex == 1)) &&
                             (((TextBlockLeftVar3.Text != TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex == 1) || ((TextBlockLeftVar3.Text == TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex == 0)) &&
                        (((TextBlockLeftVar4.Text != TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex == 1) || ((TextBlockLeftVar4.Text == TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex == 0)))
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
                    else if ((((TextBlockLeftVar2.Text == TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex == 0) || ((TextBlockLeftVar2.Text != TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex == 1)) &&
                             (((TextBlockLeftVar.Text != TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex == 1) || ((TextBlockLeftVar.Text == TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex == 0)) &&
                        (((TextBlockLeftVar4.Text != TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex == 1) || ((TextBlockLeftVar4.Text == TextBlockRightVar4.Text) && ComboBoxTextSign4.SelectedIndex == 0)))
                    {
                        if (TextBlockLeftVar3.Text != TextBlockRightVar3.Text)
                        {
                            strAnswer3 = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer3 = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        windows.ResultEqualSetsSolvengTasksWindow resultEqualSetsSolvengTasksWindow1 = new windows.ResultEqualSetsSolvengTasksWindow(strAnswer3, TextBlockLeftVar3.Text, TextBlockRightVar3.Text);
                        resultEqualSetsSolvengTasksWindow1.ShowDialog();
                    }
                    else if ((((TextBlockLeftVar2.Text == TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex == 0) || ((TextBlockLeftVar2.Text != TextBlockRightVar2.Text) && ComboBoxTextSign2.SelectedIndex == 1)) &&
                             (((TextBlockLeftVar3.Text != TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex == 1) || ((TextBlockLeftVar3.Text == TextBlockRightVar3.Text) && ComboBoxTextSign3.SelectedIndex == 0)) &&
                        (((TextBlockLeftVar.Text != TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex == 1) || ((TextBlockLeftVar.Text == TextBlockRightVar.Text) && ComboBoxTextSign.SelectedIndex == 0)))
                    {
                        if (TextBlockLeftVar4.Text != TextBlockRightVar4.Text)
                        {
                            strAnswer4 = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer4 = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        windows.ResultEqualSetsSolvengTasksWindow resultEqualSetsSolvengTasksWindow1 = new windows.ResultEqualSetsSolvengTasksWindow(strAnswer4, TextBlockLeftVar4.Text, TextBlockRightVar4.Text);
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
                        if (TextBlockLeftVar3.Text != TextBlockRightVar3.Text)
                        {
                            strAnswer3 = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer3 = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        if (TextBlockLeftVar4.Text != TextBlockRightVar4.Text)
                        {
                            strAnswer4 = "≠"; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }
                        else
                        {
                            strAnswer4 = "="; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                        }

                        windows.ResultEqualSetsSolvengTasksWindow resultEqualSetsSolvengTasksWindow3 = new windows.ResultEqualSetsSolvengTasksWindow(strAnswer, strAnswer2, strAnswer3, strAnswer4, TextBlockLeftVar.Text, TextBlockRightVar.Text, TextBlockLeftVar2.Text, TextBlockRightVar2.Text,
                            TextBlockRightVar3.Text, TextBlockLeftVar3.Text, TextBlockRightVar4.Text, TextBlockLeftVar4.Text);
                        resultEqualSetsSolvengTasksWindow3.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show($"Выбери ответ");
            }

        }


        private SolidColorBrush _colorButton = new SolidColorBrush(Color.FromRgb(241, 76, 24)); // цвет для кнопок, в который они перекрасятся при нажатии


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
                    TextBlockLeftVar3.Text = "";
                    TextBlockRightVar3.Text = "";
                    TextBlockLeftVar4.Text = "";
                    TextBlockRightVar4.Text = "";
                    TextBlockLeftVar2.Text = "";
                    TextBlockRightVar2.Text = "";
                    ComboBoxTextSign2.Text = "";
                    ComboBoxTextSign.Text = "";
                    ComboBoxTextSign3.Text = "";
                    ComboBoxTextSign4.Text = "";
                    ShowRandomZnachenia();
                    ShowRandomZnachenia2();
                    ShowRandomZnachenia3();
                    ShowRandomZnachenia4();

                    break;
                case 2:
                    _strButton = "";
                    _strButtonTwo = "";
                    _strButtonThree = "";
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
            if (OptionOne.Background == _colorButton)
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
            else if (OptionTwo.Background == _colorButton)
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
            else if (OptionThree.Background == _colorButton)
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
            OptionOne.Background = _colorButton; // красим кнопку
            OptionTwo.ClearValue(Button.BackgroundProperty); // с остальных кнопок снимаем окрас
            OptionThree.ClearValue(Button.BackgroundProperty); // с остальных кнопок снимаем окрас
        }

        private void OptionTwo_Click(object sender, RoutedEventArgs e)
        {
            OptionTwo.Background = _colorButton; // красим кнопку
            OptionOne.ClearValue(Button.BackgroundProperty); // с остальных кнопок снимаем окрас
            OptionThree.ClearValue(Button.BackgroundProperty); // с остальных кнопок снимаем окрас
        }

        private void OptionThree_Click(object sender, RoutedEventArgs e)
        {
            OptionThree.Background = _colorButton; // красим кнопку
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
