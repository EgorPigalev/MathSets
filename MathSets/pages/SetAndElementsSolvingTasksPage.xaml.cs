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

        private string[] _rightOptions = { "Ручка", "Тетрадь", "Дневник", "Карандаш", "Ластик", "Точилка" }; // массив с верными значениями
        private string[] _noRightOptions = { "Самолет", "Стул", "Стол", "Машина", "Птица", "Медведь",// массив с неверными значениями
                    "Тапочки", "Трактор", "Собака", "Кошка", "Кот", "Велосипед", "Колесо" };
        private string[] _noRightOptions2 = { "Огурец", "Дом", "Мышка", "Губка", "Кукла", "Веник",// массив с неверными значениями
                    "Ведро", "Коньки", "Торт", "Утюг", "Хомяк", "Велосипед", "Колесо" };
        private int _rightOptionsIndex; // индекс верного значения
        private int _noRightOptionsIndex; // индекс неверного первого значения
        private int _noRightOptionsIndex2; // индекс неверного второго значения


        private string[] _answerOptions = { "Однозначные числа", "Четные числа", "Гласные буквы алфавита" }; // массив с вариантами ответов
        private string[] _singleDigits = {"1", "2", "3", "4" , "5", "6", "7", "8", "9" }; // массив с однозначными числами
        private string[] _evenNumbers = {"2","4", "6", "8","10","12", "14", "16", "18", "20", "22", "24", "26", "28",
        "30", "32","34", "36", "38", "40", "42", "44", "46", "48", "50", "52", "54", "56", "58", "60", "62", "64",
        "66", "68", "70", "72", "74", "76", "78", "80", "82", "84", "86", "88", "90", "92", "94", "96", "98"}; // массив четных чисел
        private string[] _vowelLetters = { "а", "о", "у", "ы", "э", "е", "ё", "и", "ю", "я" }; // массив гласный букв
        private int _index;
        private string _strTask = "";
        private int _verificationLabel;
        private  static Random _random = new Random();
        private string _strAnswer = ""; // переменна для записи ответа, который выбрал пользователь


        /// <summary>
        /// метод для генерации задания 2
        /// </summary>
        private void ShowSecondRandomTask()
        {
            int randomAnswerOptions = _random.Next(3); // вывод рандомных вариантов ответа
            int countTask = _random.Next(3, 6); // рандомное количество значений в задании
            int v = _random.Next(3);
            for (int i = 0; i <= countTask; i++) // цикл для вывода формулировки задания
            {
                if (v == 0)
                {
                    _verificationLabel = 0;
                    if (i == 0)
                    {
                        _strTask += "{";
                    }
                    _index = _random.Next(_singleDigits.Length);
                    if(i == countTask)
                    {
                        _strTask += _singleDigits[_index] + "";
                    }
                    else
                    {
                        _strTask += _singleDigits[_index] + "; ";
                    }
                 
                    if (i == countTask)
                    {
                        _strTask += "}";
                    }
                }
                else if (v == 1)
                {
                    _verificationLabel = 1;
                    if (i == 0)
                    {
                        _strTask += "{";
                    }
                    _index = _random.Next(_evenNumbers.Length);
                    if (i == countTask)
                    {
                        _strTask += _evenNumbers[_index] + "";
                    }
                    else
                    {
                        _strTask += _evenNumbers[_index] + "; ";
                    }

                    if (i == countTask)
                    {
                        _strTask += "}";
                    }
                }
                else if (v == 2)
                {
                    _verificationLabel = 2;
                    if (i == 0)
                    {
                        _strTask += "{";
                    }
                    _index = _random.Next(_vowelLetters.Length);
                    if (i == countTask)
                    {
                        _strTask += _vowelLetters[_index] + "";
                    }
                    else
                    {
                        _strTask += _vowelLetters[_index] + "; ";
                    }

                    if (i == countTask)
                    {
                        _strTask += "}";
                    }
                }
            }
            TextBlockTask.Text = "Задайте множество общим свойством его элементов " + _strTask; // вывод формулировки задания

            if (randomAnswerOptions == 0)
            {
                OptionOne.Content = _answerOptions[0];
                OptionTwo.Content = _answerOptions[1];
                OptionThree.Content = _answerOptions[2];
            }
            else if (randomAnswerOptions == 1)
            {
                OptionOne.Content = _answerOptions[1];
                OptionTwo.Content = _answerOptions[2];
                OptionThree.Content = _answerOptions[0];
            }
            else if (randomAnswerOptions == 2)
            {
                OptionOne.Content = _answerOptions[2];
                OptionTwo.Content = _answerOptions[0];
                OptionThree.Content = _answerOptions[1];
            }
        }

        /// <summary>
        /// метод для генерации рандомных ответов на задание 1
        /// </summary>
        private void ShowFirstRandomTask()
        {
            

            int v = _random.Next(3); // рандом для кнопок

            if (v == 0) // присвоение кнопкам рандомных значений
            {
                _rightOptionsIndex = _random.Next(_rightOptions.Length);
                _noRightOptionsIndex = _random.Next(_noRightOptions.Length);
                _noRightOptionsIndex2 = _random.Next(_noRightOptions2.Length);
                BtnOption1.Content = _rightOptions[_rightOptionsIndex];
                BtnOption2.Content = _noRightOptions[_noRightOptionsIndex];
                BtnOption3.Content = _noRightOptions2[_noRightOptionsIndex2];
            }
            else if (v == 1)
            {
                _rightOptionsIndex = _random.Next(_rightOptions.Length);
                _noRightOptionsIndex = _random.Next(_noRightOptions.Length);
                _noRightOptionsIndex2 = _random.Next(_noRightOptions2.Length);
                BtnOption3.Content = _rightOptions[_rightOptionsIndex];
                BtnOption1.Content = _noRightOptions[_noRightOptionsIndex];
                BtnOption2.Content = _noRightOptions2[_noRightOptionsIndex2];
            }
            else if (v == 2)
            {
                _rightOptionsIndex = _random.Next(_rightOptions.Length);
                _noRightOptionsIndex = _random.Next(_noRightOptions.Length);
                _noRightOptionsIndex2 = _random.Next(_noRightOptions2.Length);
                BtnOption2.Content = _rightOptions[_rightOptionsIndex];
                BtnOption3.Content = _noRightOptions[_noRightOptionsIndex];
                BtnOption1.Content = _noRightOptions2[_noRightOptionsIndex2];
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Base.MainFrame.Navigate(new MainMenuPage());
        }

        private void BtnResult_Click(object sender, RoutedEventArgs e)
        {
            if (BtnOption3.Background == _colorButton)
            {
                _strAnswer = Convert.ToString(BtnOption3.Content);
                if (_strAnswer == _rightOptions[_rightOptionsIndex]) // если пользователь выбрал правильный ответ
                {
                    windows.CorrectResult correctResult = new windows.CorrectResult(); // Вывод окна "Ты молодец"
                    correctResult.ShowDialog();
                }
                else // если пользователь выбрал неверный ответ
                {
                    _strAnswer = _rightOptions[_rightOptionsIndex]; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                    windows.ResultSetAndElementsTasksWindow resultSetAndElementsTasks = new windows.ResultSetAndElementsTasksWindow(_strAnswer);
                    resultSetAndElementsTasks.ShowDialog();
                }
            }
            else if (BtnOption2.Background == _colorButton)
            {
                _strAnswer = Convert.ToString(BtnOption2.Content);
                if (_strAnswer == _rightOptions[_rightOptionsIndex]) // если пользователь выбрал правильный ответ
                {
                    windows.CorrectResult correctResult = new windows.CorrectResult(); // Вывод окна "Ты молодец"
                    correctResult.ShowDialog();
                }
                else // если пользователь выбрал неверный ответ
                {
                    _strAnswer = _rightOptions[_rightOptionsIndex]; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                    windows.ResultSetAndElementsTasksWindow resultSetAndElementsTasks = new windows.ResultSetAndElementsTasksWindow(_strAnswer);
                    resultSetAndElementsTasks.ShowDialog();
                }
            }
            else if (BtnOption1.Background == _colorButton)
            {
                _strAnswer = Convert.ToString(BtnOption1.Content);
                if (_strAnswer == _rightOptions[_rightOptionsIndex]) // если пользователь выбрал правильный ответ
                {
                    windows.CorrectResult correctResult = new windows.CorrectResult(); // Вывод окна "Ты молодец"
                    correctResult.ShowDialog();
                }
                else // если пользователь выбрал неверный ответ
                {
                    _strAnswer = _rightOptions[_rightOptionsIndex]; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                    windows.ResultSetAndElementsTasksWindow resultSetAndElementsTasks = new windows.ResultSetAndElementsTasksWindow(_strAnswer);
                    resultSetAndElementsTasks.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show($"Выбери ответ");
            }
        }

        private SolidColorBrush _colorButton = new SolidColorBrush(Color.FromRgb(241, 76, 24)); // цвет для кнопок, в который они перекрасятся при нажатии
        private void Option3_Click(object sender, RoutedEventArgs e)
        {
            BtnOption3.Background = _colorButton; // красим кнопку
            BtnOption2.ClearValue(Button.BackgroundProperty); // с остальных кнопок снимаем окрас
            BtnOption1.ClearValue(Button.BackgroundProperty);
        }

        private void Option2_Click(object sender, RoutedEventArgs e)
        {
            BtnOption2.Background = _colorButton; // красим кнопку
            BtnOption3.ClearValue(Button.BackgroundProperty); // с остальных кнопок снимаем окрас
            BtnOption1.ClearValue(Button.BackgroundProperty);
        }

        private void Option1_Click(object sender, RoutedEventArgs e)
        {
            BtnOption1.Background = _colorButton; // красим кнопку
            BtnOption3.ClearValue(Button.BackgroundProperty); // с остальных кнопок снимаем окрас
            BtnOption2.ClearValue(Button.BackgroundProperty);
        }

        private void OptionOne_Click(object sender, RoutedEventArgs e)
        {
            OptionOne.Background = _colorButton; // красим кнопку
            OptionTwo.ClearValue(Button.BackgroundProperty); // с остальных кнопок снимаем окрас
            OptionThree.ClearValue(Button.BackgroundProperty);
        }

        private void OptionTwo_Click(object sender, RoutedEventArgs e)
        {
            OptionTwo.Background = _colorButton; // красим кнопку
            OptionOne.ClearValue(Button.BackgroundProperty); // с остальных кнопок снимаем окрас
            OptionThree.ClearValue(Button.BackgroundProperty);
        }

        private void OptionThree_Click(object sender, RoutedEventArgs e)
        {
            OptionThree.Background = _colorButton; // красим кнопку
            OptionOne.ClearValue(Button.BackgroundProperty); // с остальных кнопок снимаем окрас
            OptionTwo.ClearValue(Button.BackgroundProperty);
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
          
            if (OptionOne.Background == _colorButton)
            {
                _strAnswer = Convert.ToString(OptionOne.Content);
                if (_strAnswer == _answerOptions[0] && _verificationLabel == 0) // если пользователь выбрал правильный ответ
                {
                    windows.CorrectResult correctResult = new windows.CorrectResult(); // Вывод окна "Ты молодец"
                    correctResult.ShowDialog();
                }
                else if (_strAnswer == _answerOptions[1] && _verificationLabel == 1) // если пользователь выбрал правильный ответ
                {
                    windows.CorrectResult correctResult = new windows.CorrectResult(); // Вывод окна "Ты молодец"
                    correctResult.ShowDialog();
                }
                else if (_strAnswer == _answerOptions[2] && _verificationLabel == 2) // если пользователь выбрал правильный ответ
                {
                    windows.CorrectResult correctResult = new windows.CorrectResult(); // Вывод окна "Ты молодец"
                    correctResult.ShowDialog();
                }
                else // если пользователь выбрал неверный ответ
                {
                    _strAnswer = _answerOptions[_verificationLabel]; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                    windows.ResultSetAndElementsTasksWindow resultSetAndElementsTasks = new windows.ResultSetAndElementsTasksWindow(_strAnswer);
                    resultSetAndElementsTasks.ShowDialog();
                }
            }
            else if (OptionTwo.Background == _colorButton)
            {
                _strAnswer = Convert.ToString(OptionTwo.Content);
                if (_strAnswer == _answerOptions[0] && _verificationLabel == 0) // если пользователь выбрал правильный ответ
                {
                    windows.CorrectResult correctResult = new windows.CorrectResult(); // Вывод окна "Ты молодец"
                    correctResult.ShowDialog();
                }
                else if (_strAnswer == _answerOptions[1] && _verificationLabel == 1) // если пользователь выбрал правильный ответ
                {
                    windows.CorrectResult correctResult = new windows.CorrectResult(); // Вывод окна "Ты молодец"
                    correctResult.ShowDialog();
                }
                else if (_strAnswer == _answerOptions[2] && _verificationLabel == 2) // если пользователь выбрал правильный ответ
                {
                    windows.CorrectResult correctResult = new windows.CorrectResult(); // Вывод окна "Ты молодец"
                    correctResult.ShowDialog();
                }
                else // если пользователь выбрал неверный ответ
                {
                    _strAnswer = _answerOptions[_verificationLabel]; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                    windows.ResultSetAndElementsTasksWindow resultSetAndElementsTasks = new windows.ResultSetAndElementsTasksWindow(_strAnswer);
                    resultSetAndElementsTasks.ShowDialog();
                }
            }
            else if (OptionThree.Background == _colorButton)
            {
                _strAnswer = Convert.ToString(OptionThree.Content);
                if (_strAnswer == _answerOptions[0] && _verificationLabel == 0) // если пользователь выбрал правильный ответ
                {
                    windows.CorrectResult correctResult = new windows.CorrectResult(); // Вывод окна "Ты молодец"
                    correctResult.ShowDialog();
                }
                else if (_strAnswer == _answerOptions[1] && _verificationLabel == 1) // если пользователь выбрал правильный ответ
                {
                    windows.CorrectResult correctResult = new windows.CorrectResult(); // Вывод окна "Ты молодец"
                    correctResult.ShowDialog();
                }
                else if (_strAnswer == _answerOptions[2] && _verificationLabel == 2) // если пользователь выбрал правильный ответ
                {
                    windows.CorrectResult correctResult = new windows.CorrectResult(); // Вывод окна "Ты молодец"
                    correctResult.ShowDialog();
                }
                else // если пользователь выбрал неверный ответ
                {
                    _strAnswer = _answerOptions[_verificationLabel]; // переменной присваиваем значение верного ответа, чтобы вывести его в ошибки
                    windows.ResultSetAndElementsTasksWindow resultSetAndElementsTasks = new windows.ResultSetAndElementsTasksWindow(_strAnswer);
                    resultSetAndElementsTasks.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show($"Выбери ответ");
            }
        }

        private void BtnHint_Click_1(object sender, RoutedEventArgs e)
        {
            windows.HintSetElementsWindow hint = new windows.HintSetElementsWindow();
            hint.ShowDialog();
        }


        private void MenuRefresh_Click(object sender, RoutedEventArgs e)
        {
            MenuItem childMenuItem = (MenuItem)sender;
            MenuItem menuItem = (MenuItem)childMenuItem.Parent;

            switch (Convert.ToInt32(menuItem.Uid))
            {
                case 1:
                    ShowFirstRandomTask();
                    BtnOption1.ClearValue(Button.BackgroundProperty);
                    BtnOption3.ClearValue(Button.BackgroundProperty);
                    BtnOption2.ClearValue(Button.BackgroundProperty);
                    break;
                case 2:
                    _strTask = "";
                    ShowSecondRandomTask();
                    OptionThree.ClearValue(Button.BackgroundProperty);
                    OptionOne.ClearValue(Button.BackgroundProperty); 
                    OptionTwo.ClearValue(Button.BackgroundProperty);
                    break;
                default:
                    break;
            }
        }

        private void MenuGuide_Click(object sender, RoutedEventArgs e)
        {
            MenuItem childMenuItem = (MenuItem)sender;
            MenuItem menuItem = (MenuItem)childMenuItem.Parent;

            new windows.GuideWindow(1, Convert.ToInt32(menuItem.Uid)).ShowDialog();
        }
    }
}
