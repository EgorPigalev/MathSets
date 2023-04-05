using MathSets.windows;
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
    /// Логика взаимодействия для SplittingSetsSolvingTasks.xaml
    /// </summary>
    public partial class SplittingSetsSolvingTasks : Page
    {
        List<string> correctResult = new List<string>(); // Верный результат в 1 задание
        public SplittingSetsSolvingTasks()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Генерация заданий разных типов
        /// </summary>
        private void NewTasks()
        {
            int n = 1; // Номер задания
            NewOneTask(n);
            n++;
            NewTwoTask(n);
        }

        /// <summary>
        /// Генерация задания 1 типа (вставка пропущенных букв)
        /// </summary>
        /// <param name="n">Номер задания</param>
        private void NewOneTask(int n)
        {
            Random random = new Random();
            int type = random.Next(3); // Буква обозначающая совокупность всех подмножеств (выбирается рандомно)
            List<String> list = new List<String>() { "A", "B", "C", "D" }; // Список всех множеств
            List<String> subsetsList = new List<String>() { "A", "B", "C", "D" }; // Список всех множеств
            Grid grid = new Grid(); // Добавления grid для вывода формулировки задания
            ColumnDefinition oneColumn = new ColumnDefinition();
            ColumnDefinition twoColumn = new ColumnDefinition();
            twoColumn.Width = new GridLength(50); // Столбце под кнопку подсказка
            grid.ColumnDefinitions.Add(oneColumn);
            grid.ColumnDefinitions.Add(twoColumn);
            string subsets = "";
            if(list.Count - 1 == type)
            {
                subsets = "A, B, C";
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (i != type)
                    {
                        if (i != list.Count - 1)
                        {
                            subsets += list[i] + ", ";
                        }
                        else
                        {
                            subsets += list[i];
                        }
                    }
                }
            }
            TextBlock taskStatement = new TextBlock() // Формулировка задания
            {
                Text = n + ") Множество " + GetTypeSumbol(type) + " разбито на части " + subsets + ". Вставьте пропущенные буквы:",
                TextWrapping = TextWrapping.Wrap,
            };
            SpTasks.Children.Add(grid);
            grid.Children.Add(taskStatement);
            Grid.SetColumn(taskStatement, 0);
            Button BtnHint = new Button() // Кнопка для подсказки
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Content = "?",
                Style = (Style)FindResource("ButtonMainStyle"),
            };
            BtnHint.Click += BtnHint_Click;
            Grid.SetColumn(BtnHint, 1);
            grid.Children.Add(BtnHint);
            Grid gridMain = new Grid(); // Место для задания
            SpTasks.Children.Add(gridMain);
            ColumnDefinition oneColumnMain = new ColumnDefinition();
            ColumnDefinition twoColumnMain = new ColumnDefinition();
            ColumnDefinition threeColumnMain = new ColumnDefinition();
            threeColumnMain.Width = new GridLength(400);
            gridMain.ColumnDefinitions.Add(oneColumnMain);
            gridMain.ColumnDefinitions.Add(twoColumnMain);
            gridMain.ColumnDefinitions.Add(threeColumnMain);
            Image image = new Image() // Добавление картинки в правый угол
            {
                Source = new BitmapImage(new Uri("../resources/PictureForTaskSplittingSets.png", UriKind.Relative)),
                Width = 60,
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(0, 60, 0, 0),
            };
            gridMain.Children.Add(image);
            Grid.SetColumn(image, 2);
            Canvas canvas = new Canvas() // Место куда будет помещен рисунок с множеством
            {
                Width = 320,
                Height = 200,
            };
            gridMain.Children.Add(canvas);
            Grid.SetColumn(canvas, 2);
            EllipseGeneration ellipseGeneration = new EllipseGeneration();
            int height = random.Next(100, 150); // Высота множества
            int width = 300; // Ширина множества
            Ellipse ellipseOne = ellipseGeneration.getEllipse(width, height, 0, 40); // Главный эллипс
            canvas.Children.Add(ellipseOne);
            TextBlock textNamePlenty = new TextBlock() // Название множества
            {
                Text = GetTypeSumbol(type),
                Margin = new Thickness(width, 40, 0, 0),
            };
            list.Remove(list[type]); // Удаление выбранного множества
            canvas.Children.Add(textNamePlenty);
            Ellipse ellipseTwo = ellipseGeneration.getEllipse(width * 2 / 3, height * 3, -width / 3, -height);
            Path pathOne = ellipseGeneration.getUnification(ellipseOne, ellipseTwo, GeometryCombineMode.Intersect);
            pathOne.Fill = Brushes.LightYellow;
            canvas.Children.Add(pathOne);
            Ellipse ellipseThree = ellipseGeneration.getEllipse(width * 2 / 3, height * 3, width * 2 / 3, -height);
            Path pathTwo = ellipseGeneration.getUnification(ellipseOne, ellipseThree, GeometryCombineMode.Intersect);
            pathTwo.Fill = Brushes.LightGray;
            canvas.Children.Add(pathTwo);
            int b = width / 6;
            for(int i = 0; i < 3; i++) // Генерация названий подмножеств
            {
                int a = random.Next(list.Count);
                TextBlock textBlock = new TextBlock()
                {
                    Text = list[a],
                    Margin = new Thickness(b, 40 + height / 2, 0, 0),
                };
                canvas.Children.Add(textBlock);
                list.Remove(list[a]);
                b += width / 3;
            }
            subsetsList.Remove(GetTypeSumbol(type));
            CalculatePrimer(gridMain, GetTypeSumbol(type), subsetsList);
            Button BtnResult = new Button() // Кнопка для проверки результата
            {
                Content = "Проверить",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Style = (Style)FindResource("ButtonMainStyle"),
            };
            BtnResult.Click += BtnResult_Click;
            SpTasks.Children.Add(BtnResult);
        }

        /// <summary>
        /// Создание примеров для 1 задания
        /// </summary>
        /// <param name="gridMain">Куда помещать примеры</param>
        /// <param name="main">Множество</param>
        /// <param name="subsets">Подмножества</param>
        private void CalculatePrimer(Grid gridMain, string main, List<String> subsets)
        {
            StackPanel oneColumnText = new StackPanel()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            StackPanel onePrimer = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
            };// Первый пример
            Label onePrimerTextOne = new Label()
            {
                Content = "" + subsets[0] + " + " + subsets[1] + " + ",
            };
            onePrimer.Children.Add(onePrimerTextOne);
            onePrimer.Children.Add(CreateComboBox());
            Label onePrimerTextTwo = new Label()
            {
                Content = " = " + main,
            };
            onePrimer.Children.Add(onePrimerTextTwo);
            oneColumnText.Children.Add(onePrimer);
            correctResult.Add("" + subsets[0] + " + " + subsets[1] + " + " + subsets[2] + " = " + main); // Добавление правильного результата для первого примера

            StackPanel twoPrimer = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
            };// Второй пример
            Label twoPrimerTextOne = new Label()
            {
                Content = "" + main + " - " + subsets[2] + " - " + subsets[1] + " = ",
            };
            twoPrimer.Children.Add(twoPrimerTextOne);
            twoPrimer.Children.Add(CreateComboBox());
            oneColumnText.Children.Add(twoPrimer);
            correctResult.Add("" + main + " - " + subsets[2] + " - " + subsets[1] + " = " + subsets[0]); // Добавление правильного результата для второго примера

            StackPanel threePrimer = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
            };// Третий пример
            Label threePrimerTextOne = new Label()
            {
                Content = "" + main + " - " + subsets[0] + " = " + subsets[1] + " + ",
            };
            threePrimer.Children.Add(threePrimerTextOne);
            threePrimer.Children.Add(CreateComboBox());
            oneColumnText.Children.Add(threePrimer);
            correctResult.Add("" + main + " - " + subsets[0] + " = " + subsets[1] + " + " + subsets[2]); // Добавление правильного результата для третьего примера

            StackPanel fourPrimer = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
            };// Четвертый пример
            fourPrimer.Children.Add(CreateComboBox());
            Label fourPrimerTextOne = new Label()
            {
                Content = " - " + subsets[0] + " - " + subsets[1] + " = ",
            };
            fourPrimer.Children.Add(fourPrimerTextOne);
            fourPrimer.Children.Add(CreateComboBox());
            oneColumnText.Children.Add(fourPrimer);
            correctResult.Add(main + " - " + subsets[0] + " - " + subsets[1] + " = " + subsets[2]); // Добавление правильного результата для четвертого примера

            gridMain.Children.Add(oneColumnText);
            Grid.SetColumn(oneColumnText, 0);

            StackPanel twoColumnText = new StackPanel()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            StackPanel fivePrimer = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
            };// Пятый пример
            Label fivePrimerTextOne = new Label()
            {
                Content = "" + subsets[0] + " + " + subsets[2] + " = ",
            };
            fivePrimer.Children.Add(fivePrimerTextOne);
            fivePrimer.Children.Add(CreateComboBox());
            Label FivePrimerTextTwo = new Label()
            {
                Content = " - ",
            };
            fivePrimer.Children.Add(FivePrimerTextTwo);
            fivePrimer.Children.Add(CreateComboBox());
            twoColumnText.Children.Add(fivePrimer);
            correctResult.Add("" + subsets[0] + " + " + subsets[2] + " = " + main + " - " + subsets[1]); // Добавление правильного результата для пятого примера

            StackPanel sixthPrimer = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
            };// Шестой пример
            Label sixthPrimerTextOne = new Label()
            {
                Content = "" + subsets[2] + " + ",
            };
            sixthPrimer.Children.Add(sixthPrimerTextOne);
            sixthPrimer.Children.Add(CreateComboBox());
            Label sixthPrimerTextTwo = new Label()
            {
                Content = " = ",
            };
            sixthPrimer.Children.Add(sixthPrimerTextTwo);
            sixthPrimer.Children.Add(CreateComboBox());
            Label sixthPrimerTextThree = new Label()
            {
                Content = " - " + subsets[0],
            };
            sixthPrimer.Children.Add(sixthPrimerTextThree);
            twoColumnText.Children.Add(sixthPrimer);
            correctResult.Add("" + subsets[2] + " + " + subsets[1] + " = " + main + " - " + subsets[0]); // Добавление правильного результата для шестого примера

            StackPanel sevenPrimer = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
            };// Седьмой пример
            Label sevenPrimerTextOne = new Label()
            {
                Content = "" + subsets[1] + " = ",
            };
            sevenPrimer.Children.Add(sevenPrimerTextOne);
            sevenPrimer.Children.Add(CreateComboBox());
            Label sevenPrimerTextTwo = new Label()
            {
                Content = " - ",
            };
            sevenPrimer.Children.Add(sevenPrimerTextTwo);
            sevenPrimer.Children.Add(CreateComboBox());
            Label sevenPrimerTextThree = new Label()
            {
                Content = " - ",
            };
            sevenPrimer.Children.Add(sevenPrimerTextThree);
            twoColumnText.Children.Add(sevenPrimer);
            sevenPrimer.Children.Add(CreateComboBox());
            correctResult.Add("" + subsets[1] + " = " + main + " - " + subsets[2] + " - " + subsets[0]); // Добавление правильного результата для седьмого примера первый вариант
            correctResult.Add("" + subsets[1] + " = " + main + " - " + subsets[0] + " - " + subsets[2]); // Добавление правильного результата для седьмого примера второй вариант

            StackPanel eightPrimer = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
            };// Восьмой пример
            eightPrimer.Children.Add(CreateComboBox());

            Label eightPrimerTextOne = new Label()
            {
                Content = " - " + subsets[2] + " = ",
            };
            eightPrimer.Children.Add(eightPrimerTextOne);
            eightPrimer.Children.Add(CreateComboBox());
            Label eightPrimerTextTwo = new Label()
            {
                Content = " + ",
            };
            eightPrimer.Children.Add(eightPrimerTextTwo);
            eightPrimer.Children.Add(CreateComboBox());
            twoColumnText.Children.Add(eightPrimer);
            correctResult.Add(main + " - " + subsets[2] + " = " + subsets[1] + " + " + subsets[0]); // Добавление правильного результата для восьмого примера первый вариант
            correctResult.Add(main + " - " + subsets[2] + " = " + subsets[0] + " + " + subsets[1]); // Добавление правильного результата для восьмого примера второй вариант

            gridMain.Children.Add(twoColumnText);
            Grid.SetColumn(twoColumnText, 1);
        }

        /// <summary>
        /// Определяет название множества по индексу в массиве
        /// </summary>
        /// <param name="i">индекс в массиве</param>
        /// <returns></returns>
        private string GetTypeSumbol(int i)
        {
            switch(i)
            {
                case 0:
                    return "A";
                    break;
                case 1:
                    return "B";
                    break;
                case 2:
                    return "C";
                    break;
                default:
                    return "D";
                    break;
            }
        }

        /// <summary>
        /// Создания comboBox для выбора ответа
        /// </summary>
        /// <returns></returns>
        private ComboBox CreateComboBox()
        {
            ComboBox comboBox = new ComboBox()
            {
                Width = 45,
                Height = 35,
            };
            ComboBoxItem comboBoxItemOne = new ComboBoxItem
            {
                Content = "A",
            };
            ComboBoxItem comboBoxItemTwo = new ComboBoxItem
            {
                Content = "B",
            };
            ComboBoxItem comboBoxItemThree = new ComboBoxItem
            {
                Content = "C",
            };
            ComboBoxItem comboBoxItemFour = new ComboBoxItem
            {
                Content = "D",
            };
            comboBox.Items.Add(comboBoxItemOne);
            comboBox.Items.Add(comboBoxItemTwo);
            comboBox.Items.Add(comboBoxItemThree);
            comboBox.Items.Add(comboBoxItemFour);
            return comboBox;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Base.MainFrame.Navigate(new MainMenuPage());
        }

        private void BtnHint_Click(object sender, RoutedEventArgs e)
        {
            HintSplittingSetsWindow hintSplittingSetsWindow = new HintSplittingSetsWindow();
            hintSplittingSetsWindow.ShowDialog();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            NewTasks();
        }

        private void BtnResult_Click(object sender, RoutedEventArgs e)
        {
            List<string> error = new List<string>(); // Ошибки
            Grid grid = (Grid)SpTasks.Children[1];
            StackPanel oneColumn = (StackPanel)grid.Children[2];
            int j = 0;
            foreach (StackPanel primer in oneColumn.Children) // Проверка 1 столбца (первых 4 примеров)
            {
                string primerText = "";
                for (int i = 0; i < primer.Children.Count; i++)
                {
                    if (typeof(Label) == primer.Children[i].GetType())
                    {
                        Label primerLabel = (Label)primer.Children[i];
                        primerText += primerLabel.Content;
                    }
                    else if (typeof(ComboBox) == primer.Children[i].GetType())
                    {
                        ComboBox primerComboBox = (ComboBox)primer.Children[i];
                        primerText += primerComboBox.SelectionBoxItem;
                    }
                }
                if (correctResult[j] != primerText)
                {
                    error.Add(correctResult[j]);
                }
                j++;
            }
            StackPanel twoColumn = (StackPanel)grid.Children[3];
            foreach (StackPanel primer in twoColumn.Children) // Проверка 2 столбца (последних 4 примеров)
            {
                string primerText = "";
                for (int i = 0; i < primer.Children.Count; i++)
                {
                    if (typeof(Label) == primer.Children[i].GetType())
                    {
                        Label primerLabel = (Label)primer.Children[i];
                        primerText += primerLabel.Content;
                    }
                    else if (typeof(ComboBox) == primer.Children[i].GetType())
                    {
                        ComboBox primerComboBox = (ComboBox)primer.Children[i];
                        primerText += primerComboBox.SelectionBoxItem;
                    }
                }
                if (j >= 6)
                {
                    if (correctResult[j] != primerText && correctResult[j + 1] != primerText)
                    {
                        error.Add(correctResult[j] + " или " + correctResult[j + 1]);
                    }
                    j += 2;
                }
                else
                {
                    if (correctResult[j] != primerText)
                    {
                        error.Add(correctResult[j]);
                    }
                    j++;
                }
            }
            if (error.Count > 0)
            {
                ResultSplittingSetsWindows resultSplittingSetsWindows = new ResultSplittingSetsWindows(error);
                resultSplittingSetsWindows.ShowDialog();
            }
            else
            {
                CorrectResult correctResult = new CorrectResult();
                correctResult.ShowDialog();
            }
        }

        /// <summary>
        /// Генерация задания 2 типа (Разбить множество на части)
        /// </summary>
        /// <param name="n">Номер задания</param>
        private void NewTwoTask(int n)
        {
            Grid grid = new Grid(); // Добавления grid для вывода формулировки задания
            ColumnDefinition oneColumn = new ColumnDefinition();
            ColumnDefinition twoColumn = new ColumnDefinition();
            twoColumn.Width = new GridLength(50); // Столбце под кнопку подсказка
            grid.ColumnDefinitions.Add(oneColumn);
            grid.ColumnDefinitions.Add(twoColumn);
            TextBlock taskStatement = new TextBlock() // Формулировка задания
            {
                Text = "\n" + n + ") Разбей множество фигур на части: a) по форме; б) по цвету; в) по размеру.\nСколько частей получилось?",
                TextWrapping = TextWrapping.Wrap,
            };
            SpTasks.Children.Add(grid);
            grid.Children.Add(taskStatement);
            Grid.SetColumn(taskStatement, 0);
            Button BtnHint = new Button() // Кнопка для подсказки
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Content = "?",
                Style = (Style)FindResource("ButtonMainStyle"),
            };
            BtnHint.Click += BtnHint_Click;
            Grid.SetColumn(BtnHint, 1);
            grid.Children.Add(BtnHint);
            
        }
    }
}
