using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MathSets.pages
{
    /// <summary>
    /// Логика взаимодействия для EqualSetsSolvingTasksPage.xaml
    /// </summary>
    public partial class EqualSetsSolvingTasksPage : Page
    {

        string[] numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }; // значения для задания 2
        public static Random random = new Random();
        int index;
        string strButton = ""; // значение для первой кнопки-ответ
        string strButtonTwo = ""; // значение для второй кнопки-ответ
        string strButtonThree = ""; // значение для третьей кнопки-ответ
        int randomAnswerOptions = random.Next(3); // вывод рандомных вариантов ответа

        public EqualSetsSolvingTasksPage()
        {
            InitializeComponent();
            ShowFigures(CreateFigures(), cnvFigure);
            ShowFigures(CreateFigures(), cnvFigureTwo);
            ShowRandomSign();
            ShowRandomButton();
        }

        /// <summary>
        /// метод длявывода рандомных ответов в задание 2
        /// </summary>
        private void ShowRandomButton()
        {
            int countButtonNumbers = random.Next(1, 7); // рандомное количество значений в ответе
            for (int i = 0; i <= countButtonNumbers; i++) // цикл для вывода формирования ответа для кнопки
            {
                if (i == 0)
                {
                    strButton += "{ ";
                }
                index = random.Next(numbers.Length);
                strButton += numbers[index] + "; ";
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
                    strButtonTwo += "{ ";
                }
                index = random.Next(numbers.Length);
                strButtonTwo += numbers[index] + "; ";
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
                strButtonThree +=  " ";
                if (i == 1)
                {
                    strButtonThree += "}";
                }
            }

            if (randomAnswerOptions == 0)
            {
                OptionOne.Content = strButton;
                OptionTwo.Content =  strButtonTwo;
                OptionThree.Content =  strButtonThree;
            }
            else if (randomAnswerOptions == 1)
            {
                OptionOne.Content =  strButtonTwo;
                OptionTwo.Content =  strButtonThree;
                OptionThree.Content =  strButton;
            }
            else if (randomAnswerOptions == 2)
            {
                OptionOne.Content = strButtonThree;
                OptionTwo.Content =  strButton;
                OptionThree.Content =  strButtonTwo;
            }
        }

        /// <summary>
        /// Метод два вывода рандомного знака
        /// </summary>
        private void ShowRandomSign()
        {
            Random random = new Random();
            int rnd = random.Next(2);
            if (rnd == 0)
            {
                TextSign.Text = "=";
            }
            else if (rnd == 1)
            {
                TextSign.Text = "≠";
            }
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Base.MainFrame.Navigate(new MainMenuPage());
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            if(cnvFigure == cnvFigureTwo)
            {
                MessageBox.Show("xaxa");
            }
            else
            {
                MessageBox.Show("lllll");
            }
        }



        /// <summary>
        /// Создаёт фигуры.
        /// </summary>
        /// <returns>Коллекция фигур</returns>
        private List<Geometry> CreateFigures()
        {
            classes.Figures figures = new classes.Figures(40, cnvFigure.Height, cnvFigure.Width); // Размер фигур, высота и ширина контейнера.

            List<classes.CreateFiguresDelegate> createFiguresMethods = new List<classes.CreateFiguresDelegate> // Сюда добавляем фигуры, которые нам надо.
            {
                figures.CreateTriangle,
                figures.CreateSquare,
                figures.CreateEllipse,
                figures.CreateStar
            };

            classes.Figures.ShuffleMethods(createFiguresMethods); // Перемешиваем фигуры для рандомного расположения их в контейнере.

            List<Geometry> listFigures = new List<Geometry>();
            int offset = figures.GetOffset(createFiguresMethods.Count); // Отступы между фигурами (высчитывается автоматически на основании ширины контейнера,
            int x = 0;                                                  // при желании можно вручную указать.

            for (int i = 0; i < createFiguresMethods.Count; i++)
            {
                listFigures.Add(createFiguresMethods[i](x, true)); // Положение фигуры по вертикали вверху.
                x += 50;
            }

            return listFigures;
        }

        /// <summary>
        /// Добавляет созданные фигуры в элемент управления "Canvas"
        /// </summary>
        /// <param name="figures">коллекция фигур</param>
        /// <param name="canvas">элемент управления "Canvas"</param>
        private void ShowFigures(List<Geometry> figures, Canvas canvas)
        {
            canvas.Children.Clear();
            Random random = new Random();
            foreach (Geometry item in figures)
            {
                int rnd = random.Next(2);
                if (rnd == 0)
                {
                    canvas.Children.Add(new Path()
                    {
                        StrokeThickness = 3,
                        Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18"),
                        Fill = (Brush)new BrushConverter().ConvertFrom("#F14C18"),
                        Data = item
                    });
                }
                else if (rnd == 1)
                {
                    canvas.Children.Add(new Path()
                    {
                        StrokeThickness = 3,
                        Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18"),

                        Data = item
                    });
                }

            }
        }

        SolidColorBrush colorButton = new SolidColorBrush(Color.FromRgb(241, 76, 24)); // цвет для кнопок, в который они перекрасятся при нажатии
        private void BtnOption1_Click(object sender, RoutedEventArgs e)
        {
            BtnOption1.Background = colorButton; // красим кнопку
            BtnOption2.ClearValue(Button.BackgroundProperty); // с остальных кнопок снимаем окрас
        }

        private void BtnOption2_Click(object sender, RoutedEventArgs e)
        {
            BtnOption2.Background = colorButton; // красим кнопку
            BtnOption1.ClearValue(Button.BackgroundProperty); // с остальных кнопок снимаем окрас
        }

        private void BtnHint_Click_1(object sender, RoutedEventArgs e)
        {
            windows.HintEqualSetsWindow hint = new windows.HintEqualSetsWindow();
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
                    ShowFigures(CreateFigures(), cnvFigure);
                    ShowFigures(CreateFigures(), cnvFigureTwo);
                    ShowRandomSign();

                    break;
                case 2:
                    ShowRandomButton();
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
    }
}
