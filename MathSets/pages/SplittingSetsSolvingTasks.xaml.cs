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
        Random random = new Random();

        List<string> correctResultFirstTask = new List<string>(); // Верный результат в 1 задание
        List<string> correctResultSecondTask = new List<string>(); // Верный результат во 2 задание


        public SplittingSetsSolvingTasks()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Генерация заданий разных типов
        /// </summary>
        private void NewTasks()
        {
            NewOneTask();
            NewTwoTask();
        }

        /// <summary>
        /// Генерация задания 1 типа (вставка пропущенных букв)
        /// </summary>
        /// <param name="n">Номер задания</param>
        private void NewOneTask()
        {
            Random random = new Random();
            WPMainPlaceQuestionFirst.Children.Clear();
            int type = random.Next(4); // Буква обозначающая совокупность всех подмножеств (выбирается рандомно)
            List<String> list = new List<String>() { "A", "B", "C", "D" }; // Список всех множеств
            List<String> subsetsList = new List<String>() { "A", "B", "C", "D" }; // Список всех множеств
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
            NameSet.Text = GetTypeSumbol(type);
            NameSubsets.Text = subsets;
            
            Grid gridMain = new Grid();
            WPMainPlaceQuestionFirst.Children.Add(gridMain);
            ColumnDefinition oneColumnMain = new ColumnDefinition();
            ColumnDefinition twoColumnMain = new ColumnDefinition();
            ColumnDefinition threeColumnMain = new ColumnDefinition();
            threeColumnMain.Width = new GridLength(350);
            gridMain.ColumnDefinitions.Add(oneColumnMain);
            gridMain.ColumnDefinitions.Add(twoColumnMain);
            gridMain.ColumnDefinitions.Add(threeColumnMain);
            Canvas canvas = new Canvas() // Место куда будет помещен рисунок с множеством
            {
                Width = 320,
                Height = 200,
            };
            gridMain.Children.Add(canvas);
            Grid.SetColumn(canvas, 2);
            EllipseGeneration ellipseGeneration = new EllipseGeneration();
            int height = 150; // Высота множества
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
        }

        /// <summary>
        /// Создание примеров для 1 задания
        /// </summary>
        /// <param name="gridMain">Куда помещать примеры</param>
        /// <param name="main">Множество</param>
        /// <param name="subsets">Подмножества</param>
        private void CalculatePrimer(Grid gridMain, string main, List<String> subsets)
        {
            correctResultFirstTask.Clear();
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
            correctResultFirstTask.Add("" + subsets[0] + " + " + subsets[1] + " + " + subsets[2] + " = " + main); // Добавление правильного результата для первого примера

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
            correctResultFirstTask.Add("" + main + " - " + subsets[2] + " - " + subsets[1] + " = " + subsets[0]); // Добавление правильного результата для второго примера

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
            correctResultFirstTask.Add("" + main + " - " + subsets[0] + " = " + subsets[1] + " + " + subsets[2]); // Добавление правильного результата для третьего примера

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
            correctResultFirstTask.Add(main + " - " + subsets[0] + " - " + subsets[1] + " = " + subsets[2]); // Добавление правильного результата для четвертого примера

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
            correctResultFirstTask.Add("" + subsets[0] + " + " + subsets[2] + " = " + main + " - " + subsets[1]); // Добавление правильного результата для пятого примера

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
            correctResultFirstTask.Add("" + subsets[2] + " + " + subsets[1] + " = " + main + " - " + subsets[0]); // Добавление правильного результата для шестого примера

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
            correctResultFirstTask.Add("" + subsets[1] + " = " + main + " - " + subsets[2] + " - " + subsets[0]); // Добавление правильного результата для седьмого примера первый вариант
            correctResultFirstTask.Add("" + subsets[1] + " = " + main + " - " + subsets[0] + " - " + subsets[2]); // Добавление правильного результата для седьмого примера второй вариант

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
            correctResultFirstTask.Add(main + " - " + subsets[2] + " = " + subsets[1] + " + " + subsets[0]); // Добавление правильного результата для восьмого примера первый вариант
            correctResultFirstTask.Add(main + " - " + subsets[2] + " = " + subsets[0] + " + " + subsets[1]); // Добавление правильного результата для восьмого примера второй вариант

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
                case 1:
                    return "B";
                case 2:
                    return "C";
                default:
                    return "D";
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

        List<int> sets = new List<int>(); // Индексы выбранных букв (0 - общее множество; 1,2 - подмножества)
        List<string> list = new List<String>() { "A", "B", "C", "D", "M", "K" }; // Список всех множеств

        /// <summary>
        /// Генерация задания 2 типа (Разбить множество на части)
        /// </summary>
        private void NewTwoTask()
        {
            CVMainPlaceQuestionSecond.Children.Clear();
            PartsSet.Children.Clear();
            MarkRight.Children.Clear();
            correctResultSecondTask.Clear();

            sets.Clear();
            CreateSet();
            List<string> parts = new List<string>();
            parts.Add(list[sets[0]] + ", " + list[sets[1]] + " и " + list[sets[2]]);
            parts.Add(list[sets[1]] + " и " + list[sets[2]]);
            parts.Add(list[sets[0]] + " и " + list[sets[2]]);
            parts.Add(list[sets[random.Next(3, sets.Count)]] + " и " + list[sets[random.Next(3, sets.Count)]]);

            correctResultSecondTask.Add(list[sets[1]] + " и " + list[sets[2]]);

            ComboBox comboBoxParts = new ComboBox();
            for(int i = 0; i < 4; i++)
            {
                int a = random.Next(parts.Count);
                comboBoxParts.Items.Add(parts[a]);
                parts.Remove(parts[a]);
            }
            PartsSet.Children.Add(comboBoxParts);
            CalculatePrimerTaskTwo();
        }

        /// <summary>
        /// Генерация множества для второго задания
        /// </summary>
        private void CreateSet()
        {
            List<string> listCopy = new List<String>() { "A", "B", "C", "D", "M", "K" }; // Список всех множеств

            int type = random.Next(6); // Буква обозначающая совокупность всех подмножеств (выбирается рандомно)
            NameSets.Text = listCopy[type];
            sets.Add(type);
            EllipseGeneration ellipseGeneration = new EllipseGeneration();
            int height = 150; // Высота множества
            int width = 300; // Ширина множества
            Ellipse ellipseOne = ellipseGeneration.getEllipse(width, height, 0, 40); // Главный эллипс
            CVMainPlaceQuestionSecond.Children.Add(ellipseOne);
            TextBlock textNamePlenty = new TextBlock() // Название множества
            {
                Text = listCopy[type],
                Margin = new Thickness(width, 40, 0, 0),
            };
            listCopy.Remove(listCopy[type]); // Удаление выбранного множества
            CVMainPlaceQuestionSecond.Children.Add(textNamePlenty);
            Ellipse ellipseTwo = ellipseGeneration.getEllipse(width, height * 3, -width / 2, -height);
            Path pathOne = ellipseGeneration.getUnification(ellipseOne, ellipseTwo, GeometryCombineMode.Intersect);
            pathOne.Fill = Brushes.LightYellow;
            CVMainPlaceQuestionSecond.Children.Add(pathOne);
            int b = width / 4;
            for (int i = 0; i < 2; i++) // Генерация подмножеств
            {
                int a = random.Next(listCopy.Count);
                TextBlock textBlock = new TextBlock()
                {
                    Text = listCopy[a],
                    Margin = new Thickness(b, 40 + height / 2, 0, 0),
                };
                sets.Add(list.IndexOf(listCopy[a]));
                CVMainPlaceQuestionSecond.Children.Add(textBlock);
                listCopy.Remove(listCopy[a]);
                b += width / 2;
            }
            foreach (string str in listCopy)
            {
                sets.Add(list.IndexOf(str));
            }
        }

        /// <summary>
        /// Генерация примеров для выбора правильных во втором задание
        /// </summary>
        private void CalculatePrimerTaskTwo()
        {
            List<string> primer = new List<string>();
            primer.Add(list[sets[1]] + " + " + list[sets[2]] + " = " + list[sets[0]]);
            primer.Add(list[sets[0]] + " - " + list[sets[2]] + " = " + list[sets[1]]);
            primer.Add(list[sets[2]] + " + " + list[sets[1]] + " = " + list[sets[0]]);
            primer.Add(list[sets[1]] + " - " + list[sets[2]] + " = " + list[sets[0]]);
            primer.Add(list[sets[2]] + " - " + list[sets[1]] + " = " + list[sets[0]]);
            primer.Add(list[sets[random.Next(3, sets.Count)]] + " + " + list[sets[random.Next(3, sets.Count)]] + " = " + list[sets[random.Next(3, sets.Count)]]);

            correctResultSecondTask.Add(list[sets[1]] + " + " + list[sets[2]] + " = " + list[sets[0]]);
            correctResultSecondTask.Add(list[sets[0]] + " - " + list[sets[2]] + " = " + list[sets[1]]);
            correctResultSecondTask.Add(list[sets[2]] + " + " + list[sets[1]] + " = " + list[sets[0]]);

            for (int i = 0; i < 6; i++)
            {
                int a = random.Next(primer.Count);
                CheckBox checkBox = new CheckBox()
                {
                    Content = primer[a]
                };
                MarkRight.Children.Add(checkBox);
                primer.Remove(primer[a]);
            }
        }

        private void MenuGuide_Click(object sender, RoutedEventArgs e)
        {
            MenuItem childMenuItem = (MenuItem)sender;
            MenuItem menuItem = (MenuItem)childMenuItem.Parent;

            switch (Convert.ToInt32(menuItem.Uid))
            {
                case 1:
                    GuideIntersectionSetsWindow guideIntersectionSetsWindow = new GuideIntersectionSetsWindow();
                    guideIntersectionSetsWindow.ShowDialog();
                    break;
                case 2:

                    break;
                case 3:

                    break;
                default:
                    break;
            }
        }

        private void MenuRefresh_Click(object sender, RoutedEventArgs e)
        {
            MenuItem childMenuItem = (MenuItem)sender;
            MenuItem menuItem = (MenuItem)childMenuItem.Parent;

            switch (Convert.ToInt32(menuItem.Uid))
            {
                case 1:
                    NewOneTask();
                    break;
                default:
                    NewTwoTask();
                    break;
            }
        }

        private void BtnCheckQuestionFirst_Click(object sender, RoutedEventArgs e)
        {
            List<string> error = new List<string>(); // Ошибки
            Grid grid = (Grid)WPMainPlaceQuestionFirst.Children[0];
            StackPanel oneColumn = (StackPanel)grid.Children[1];
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
                if (correctResultFirstTask[j] != primerText)
                {
                    error.Add(correctResultFirstTask[j]);
                }
                j++;
            }
            StackPanel twoColumn = (StackPanel)grid.Children[2];
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
                    if (correctResultFirstTask[j] != primerText && correctResultFirstTask[j + 1] != primerText)
                    {
                        error.Add(correctResultFirstTask[j] + " или " + correctResultFirstTask[j + 1]);
                    }
                    j += 2;
                }
                else
                {
                    if (correctResultFirstTask[j] != primerText)
                    {
                        error.Add(correctResultFirstTask[j]);
                    }
                    j++;
                }
            }
            if (error.Count > 0)
            {
                ResultSplittingSetsWindows resultSplittingSetsWindows = new ResultSplittingSetsWindows(error, 1);
                resultSplittingSetsWindows.ShowDialog();
            }
            else
            {
                CorrectResult correctResult = new CorrectResult();
                correctResult.ShowDialog();
            }
        }

        private void BtnCheckQuestionSecond_Click(object sender, RoutedEventArgs e)
        {
            bool result = true;
            int kolCorrectResult = 0;
            ComboBox comboBox = (ComboBox)PartsSet.Children[0];
            if(!comboBox.SelectionBoxItem.Equals(correctResultSecondTask[0]))
            {
                result = false;
            }
            else
            {
                kolCorrectResult++;
            }
            for(int i = 0; i < MarkRight.Children.Count; i++)
            {
                CheckBox checkBox = (CheckBox)MarkRight.Children[i];
                if(checkBox.IsChecked == true)
                {
                    if(correctResultSecondTask.IndexOf(checkBox.Content.ToString()) == -1)
                    {
                        result = false;
                    }
                    else
                    {
                        kolCorrectResult++;
                    }
                }
            }
            if(result && kolCorrectResult == correctResultSecondTask.Count)
            {
                CorrectResult correctResult = new CorrectResult();
                correctResult.ShowDialog();
            }
            else
            {
                ResultSplittingSetsWindows resultSplittingSetsWindows = new ResultSplittingSetsWindows(correctResultSecondTask, 2);
                resultSplittingSetsWindows.ShowDialog();
            }
        }
    }
}
