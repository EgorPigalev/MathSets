using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MathSets.pages
{
    /// <summary>
    /// Логика взаимодействия для CombiningSetsPage.xaml
    /// </summary>
    public partial class CombiningSetsPage : Page
    {
        Random random = new Random();
        EllipseGeneration ellipseGeneration = new EllipseGeneration();
        Ellipse ellipseOneEx1;
        Ellipse ellipseTwoEx1;
        Path combinedPathEx1;
        int numberEx1 = 0;
        int[] masAnswerOptions = new int[4];
        List<Point> _pointsQuestionFirst = new List<Point>(); // Точки смещения для второго задания
        private Path _pathToMoved; // Фигура для перемещения
        private Point _oldMouseCoordinate; // Предыдущие координаты курсора (для перемещения фигуры)
        int[] setElementsA;
        int[] setElementsB;
        int[] masElements;

        public CombiningSetsPage()
        {
            InitializeComponent();

            GenerationCondition();
            GenerationCondition2();
            GenerationCondition3();
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (typeof(Ellipse) == sender.GetType())
            {
                Ellipse ellipse = sender as Ellipse;
                if (ellipse.Fill == Brushes.Yellow)
                {
                    ellipse.Fill = Brushes.White;
                }
                else
                {
                    ellipse.Fill = Brushes.Yellow;
                }
            }
            else
            {
                Path ellipse = sender as Path;
                if (ellipse.Fill == Brushes.Yellow)
                {
                    ellipse.Fill = Brushes.White;
                }
                else
                {
                    ellipse.Fill = Brushes.Yellow;
                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Base.MainFrame.Navigate(new MainMenuPage());
        }

        private void BtnHint_Click(object sender, RoutedEventArgs e)
        {
            windows.HintCombiningSetsWindow hintCombiningSetsWindow = new windows.HintCombiningSetsWindow();
            hintCombiningSetsWindow.ShowDialog();
        }

        /// <summary>
        /// Генерация 1 задания
        /// </summary>
        public void GenerationCondition()
        {
            ellipseOneEx1 = ellipseGeneration.getEllipse(300, 150, 0, 10);
            ellipseOneEx1.MouseDown += Ellipse_MouseDown;
            Cnv.Children.Add(ellipseOneEx1);
            ellipseTwoEx1 = ellipseGeneration.getEllipse(300, 150, 150, 10);
            ellipseTwoEx1.MouseDown += Ellipse_MouseDown;
            Cnv.Children.Add(ellipseTwoEx1);
            combinedPathEx1 = ellipseGeneration.getUnification(ellipseOneEx1, ellipseTwoEx1, GeometryCombineMode.Intersect);
            combinedPathEx1.MouseDown += Ellipse_MouseDown;
            Cnv.Children.Add(combinedPathEx1);
            ellipseOneEx1.StrokeThickness = Base.StrokeThickness;
            ellipseTwoEx1.StrokeThickness = Base.StrokeThickness;
            TextBlock tbA = new TextBlock()
            {
                Text = "A",
                Margin = new Thickness(5, 0, 0, 0)
            };
            Cnv.Children.Add(tbA);
            TextBlock tbB = new TextBlock()
            {
                Text = "B",
                Margin = new Thickness(400, 0, 0, 0)
            };
            Cnv.Children.Add(tbB);

            numberEx1 = random.Next(4);
            switch (numberEx1)
            {
                case 0:
                    TbCondition.Text = "1) Даны два множества. Закрась A ∩ B (нажми на нужные области).";
                    break;
                case 1:
                    TbCondition.Text = "1) Даны два множества. Закрась A ∪ B (нажми на нужные области).";
                    break;
                case 2:
                    TbCondition.Text = "1) Даны два множества. Закрась множество А (нажми на нужные области).";
                    break;
                case 3:
                    TbCondition.Text = "1) Даны два множества. Закрась множество В (нажми на нужные области).";
                    break;
            }
        }

        /// <summary>
        /// Генерация 2 задания
        /// </summary>
        public void GenerationCondition2()
        {
            Canvas2.Children.Clear();

            setElementsA = GenerationElementsSet(4);
            string strElementsA = ConvertMasInString(setElementsA);

            setElementsB = GenerationElementsSet(4);
            string strElementsB = ConvertMasInString(setElementsB);

            TbCondition2.Text = "2) Даны множества А {" + strElementsA + "} и В {" + strElementsB + "}. Изобрази элементы данных множеств на диаграмме (перетащи цифры)";

            Ellipse ellipseOne = ellipseGeneration.getEllipse(300, 150, 430, 10);        
            Ellipse ellipseTwo = ellipseGeneration.getEllipse(300, 150, 580, 10);         
            Path combinedPath = ellipseGeneration.getUnification(ellipseOne, ellipseTwo, GeometryCombineMode.Intersect);
            Ellipse ellipseOneD = ellipseGeneration.getEllipse(300, 150, 430, 10);
            Ellipse ellipseTwoD = ellipseGeneration.getEllipse(300, 150, 580, 10);
            Path combEllipseOne = ellipseGeneration.getUnification(ellipseOne, ellipseOneD, GeometryCombineMode.Intersect);
            Path combEllipseTwo = ellipseGeneration.getUnification(ellipseTwo, ellipseTwoD, GeometryCombineMode.Intersect);
            combEllipseOne.StrokeThickness = Base.StrokeThickness;
            combEllipseTwo.StrokeThickness = Base.StrokeThickness;          
            Canvas2.Children.Add(combEllipseOne);
            Canvas2.Children.Add(combEllipseTwo);
            Canvas2.Children.Add(combinedPath);

            TextBlock tbA = new TextBlock()
            {
                Text = "A",
                Margin = new Thickness(440, 10, 0, 0)
            };
            Canvas2.Children.Add(tbA);
            TextBlock tbB = new TextBlock()
            {
                Text = "B",
                Margin = new Thickness(850, 10, 0, 0)
            };
            Canvas2.Children.Add(tbB);

            int[] masCombiningElements = CombiningElementsSets(setElementsA, setElementsB);
            int[] masElementsRandom = RandomElementsCombining(masCombiningElements);
            int marginText = 0;
            for (int i = 0; i < masElementsRandom.Length; i++)
            {
                if (masElementsRandom[i] != 0)
                {
                    Figure figure = new Figure(28, 0, 0);
                    Geometry geometry = null;
                    geometry = GetGeometryFromText(masElementsRandom[i].ToString(), 50, marginText, 40);
                    marginText += 40;

                    Path pathNumbers = new Path()
                    {
                        StrokeThickness = Base.StrokeThickness,
                        Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18"),
                        Data = geometry,
                        Fill = Brushes.White,
                    };
                    pathNumbers.MouseDown += OnMouseDown;
                    pathNumbers.MouseMove += OnMouseMove;
                    pathNumbers.MouseUp += OnMouseUp;
                    pathNumbers.Uid = i.ToString();
                    Canvas2.Children.Add(pathNumbers);
                }
            }
            _pointsQuestionFirst.Clear();
            for (int i = 0; i < masElementsRandom.Length; i++) // Заполнение точек смещения
            {
                _pointsQuestionFirst.Add(new Point(0, 0));
            }
        }

        /// <summary>
        /// Рандомный вывод элементов в задании 2
        /// </summary>
        /// <param name="combining"></param>
        /// <returns></returns>
        private int[] RandomElementsCombining(int[] combining)
        {
            masElements = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] masPosition = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            int n = 0;
            for (int i = 0; i < combining.Length; i++)
            {
            met: int q = random.Next(1, 9);
                for (int j = 0; j < masPosition.Length; j++)
                {
                    if (masPosition[j] == q)
                    {
                        goto met;
                    }
                }
                masPosition[i] = q;
                if (combining[q - 1] != 0)
                {
                    masElements[n] = combining[q - 1];
                    n++;
                }
            }
            return masElements;
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Path path = (Path)sender;

            if (path.Uid != string.Empty)
            {
                path.Fill = Brushes.Gray;
                _pathToMoved = path;
                _oldMouseCoordinate = e.GetPosition(Canvas2);
                path.CaptureMouse(); // Захватывание мыши
            }
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            for (int i = 5; i < Canvas2.Children.Count; i++)
            {
                Path p = (Path)Canvas2.Children[i];
                p.Fill = Brushes.White;
                _pathToMoved = null;
                p.ReleaseMouseCapture();
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_pathToMoved != null)
            {
                if (_pathToMoved.Uid != "")
                {
                    int id = Convert.ToInt32(_pathToMoved.Uid);
                    SetOffsetFigure(id, e.GetPosition(Canvas2));
                    _pathToMoved.Data.Transform = new TranslateTransform(_pointsQuestionFirst[id].X, _pointsQuestionFirst[id].Y);
                }
            }
        }

        private void SetOffsetFigure(int id, Point actualCoordinate)
        {
            Point tempPoint = _pointsQuestionFirst[id];

            if (actualCoordinate.Y > _oldMouseCoordinate.Y)
            {
                tempPoint.Y++;
            }
            else if (actualCoordinate.Y < _oldMouseCoordinate.Y)
            {
                tempPoint.Y--;
            }

            if (actualCoordinate.X > _oldMouseCoordinate.X)
            {
                tempPoint.X++;
            }
            else if (actualCoordinate.X < _oldMouseCoordinate.X)
            {
                tempPoint.X--;
            }

            _pointsQuestionFirst[id] = tempPoint;

            _oldMouseCoordinate = actualCoordinate;
        }

#pragma warning disable CS0618 // Для сокрытия предупреждения об устаревшем FormattedText
        /// <summary>
        /// Создаёт фигуру на основании текста, преобразовавая его в графический элемент
        /// </summary>
        /// <param name="text">текст для преобразования в фигуру</param>
        /// <returns>Фигура, созданная на основании заданного текста</returns>
        public Geometry GetGeometryFromText(string text, int _sizeFigures, int x, int y)
        {
            FormattedText formattedText = new FormattedText
            (
                text,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface("Comic Sans MS"),
                _sizeFigures,
                (Brush)new BrushConverter().ConvertFrom("#F14C18") // Данное поле изменяется при создании объекта Path.
            );

            return formattedText.BuildGeometry(new Point(x, y));
        }

        /// <summary>
        /// Генерация 3 задания
        /// </summary>
        public void GenerationCondition3()
        {
            Canvas3.Children.Clear();
            Cb1.IsChecked = false;
            Cb2.IsChecked = false;
            Cb3.IsChecked = false;
            Cb4.IsChecked = false;
            Ellipse ellipseOne = ellipseGeneration.getEllipse(300, 150, 0, 10);
            Ellipse ellipseTwo = ellipseGeneration.getEllipse(300, 150, 150, 10);
            Path combinedPath = ellipseGeneration.getUnification(ellipseOne, ellipseTwo, GeometryCombineMode.Intersect);
            ellipseOne.StrokeThickness = Base.StrokeThickness;
            ellipseTwo.StrokeThickness = Base.StrokeThickness;
            Canvas3.Children.Add(ellipseOne);
            Canvas3.Children.Add(ellipseTwo);
            Canvas3.Children.Add(combinedPath);
            TextBlock tbA = new TextBlock()
            {
                Text = "A",
                Margin = new Thickness(10, 10, 0, 0)
            };
            Canvas3.Children.Add(tbA);
            TextBlock tbB = new TextBlock()
            {
                Text = "B",
                Margin = new Thickness(420, 10, 0, 0)
            };
            Canvas3.Children.Add(tbB);

            int[] masElementsSetA = GenerationElementsSet(4);
            int[] masElementsSetB = GenerationElementsSet(4);
            int[] masElementsCombining = CombiningElementsSets(masElementsSetA, masElementsSetB);
            int[] masElementsIntersection = IntersectionElementsSets(masElementsSetA, masElementsSetB);

            for (int i = 0; i < masAnswerOptions.Length; i++)
            {
                masAnswerOptions[i] = -1;
            }

            string[] str = new string[4];
            for (int j = 0; j < 4; j++)
            {
            met: int g = random.Next(4);
                for (int i = 0; i < masAnswerOptions.Length; i++)
                {
                    if (g == masAnswerOptions[i])
                    {
                        goto met;
                    }
                }
                masAnswerOptions[j] = g;
                switch (g)
                {
                    case 0:
                        str[j] = "A ∪ B = {" + ConvertMasInString(masElementsCombining) + "}";
                        break;
                    case 1:
                        str[j] = "A ∩ B = {" + ConvertMasInString(masElementsIntersection) + "}";
                        break;
                    case 2:
                        str[j] = "A ∩ B = {" + ConvertMasInString(GenerationElementsSet(random.Next(1, 9))) + "}";
                        break;
                    case 3:
                        str[j] = "A ∪ B = {" + ConvertMasInString(GenerationElementsSet(random.Next(1, 9))) + "}";
                        break;
                    default:
                        break;
                }
            }

            Cb1.Content = str[0];
            Cb2.Content = str[1];
            Cb3.Content = str[2];
            Cb4.Content = str[3];

            int marginA = 30;

            int[] masA = ElementsOnlyOneSet(masElementsSetA, masElementsIntersection);
            int[] masB = ElementsOnlyOneSet(masElementsSetB, masElementsIntersection);
            for (int i = 0; i < masA.Length; i++)
            {
                if (masA[i] != 0)
                {
                    TextBlock tb = new TextBlock()
                    {
                        Text = masA[i].ToString(),
                        Margin = new Thickness(marginA, random.Next(35, 100), 0, 0)
                    };
                    Canvas3.Children.Add(tb);
                    marginA += 30;
                }
            }

            int marginB = 300;
            for (int i = 0; i < masB.Length; i++)
            {
                if (masB[i] != 0)
                {
                    TextBlock tb = new TextBlock()
                    {
                        Text = masB[i].ToString(),
                        Margin = new Thickness(marginB, random.Next(30, 100), 0, 0)
                    };
                    Canvas3.Children.Add(tb);
                    marginB += 30;
                }
            }

            int marginCenter = 180;
            for (int j = 0; j < masElementsIntersection.Length; j++)
            {
                if (masElementsIntersection[j] != 0)
                {
                    TextBlock tb = new TextBlock()
                    {
                        Text = masElementsIntersection[j].ToString(),
                        Margin = new Thickness(marginCenter, random.Next(30, 100), 0, 0)
                    };
                    Canvas3.Children.Add(tb);
                }
                marginCenter += 30;
            }
        }

        /// <summary>
        /// Вывод элементов массива строкой
        /// </summary>
        /// <param name="mas">Массив, который нужно показать в виде строки</param>
        /// <returns></returns>
        private string ConvertMasInString(int[] mas)
        {
            string str = "";
            if (mas[0] == 0)
            {
                str = "Ø";
            }
            else
            {
                for (int i = 0; i < mas.Length; i++)
                {
                    if (mas[i] != 0)
                    {
                        str += mas[i] + ", ";
                    }
                }
                str = str.Substring(0, str.Length - 2);
            }
            return str;
        }

        /// <summary>
        /// Генерация элементов множества
        /// </summary>
        /// <param name="size">Количество элементов в множестве</param>
        /// <returns></returns>
        private int[] GenerationElementsSet(int size)
        {
            int[] masElementsSet = new int[size];
            for (int i = 0; i < size; i++)
            {
            met: int randomElement = random.Next(1, 10);
                for (int j = 0; j < masElementsSet.Length; j++)
                {
                    if (randomElement == masElementsSet[j])
                    {
                        goto met;
                    }
                }
                masElementsSet[i] = randomElement;
            }
            return masElementsSet;
        }

        /// <summary>
        /// Объединение элементов множеств
        /// </summary>
        /// <param name="masA">Множество А</param>
        /// <param name="masB">Множество В</param>
        /// <returns></returns>
        private int[] CombiningElementsSets(int[] masA, int[] masB)
        {
            int[] masElements = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < 4; i++)
            {
                masElements[i] = masA[i];
            }
            int n = 0;
            for (int i = 4; i < masElements.Length; i++)
            {
            met: if (n != 4)
                {

                    for (int j = 0; j < masA.Length; j++)
                    {
                        if (masB[n] == masA[j])
                        {
                            n++;
                            goto met;
                        }
                    }
                    masElements[i] = masB[n];
                    n++;
                }
            }
            return masElements;
        }

        /// <summary>
        /// Пересечение элементов множеств
        /// </summary>
        /// <param name="masA">Множество А</param>
        /// <param name="masB">Множество В</param>
        /// <returns></returns>
        private int[] IntersectionElementsSets(int[] masA, int[] masB)
        {
            int[] masElements = new int[4] { 0, 0, 0, 0 };
            int n = 0;
            for (int i = 0; i < masA.Length; i++)
            {
                for (int j = 0; j < masB.Length; j++)
                {
                    if (masA[i] == masB[j])
                    {
                        masElements[n] = masA[i];
                        n++;
                    }
                }
            }
            if (masElements.Length == 0)
            {
                masElements[0] = 0;
            }

            return masElements;
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            switch (numberEx1)
            {
                case 0:
                    if (ellipseOneEx1.Fill == Brushes.White && ellipseTwoEx1.Fill == Brushes.White && combinedPathEx1.Fill == Brushes.Yellow)
                    {
                        windows.CorrectResult correctResult = new windows.CorrectResult();
                        correctResult.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Неправильно!");
                    }
                    break;
                case 1:
                    if (ellipseOneEx1.Fill == Brushes.Yellow && ellipseTwoEx1.Fill == Brushes.Yellow && combinedPathEx1.Fill == Brushes.Yellow)
                    {
                        windows.CorrectResult correctResult = new windows.CorrectResult();
                        correctResult.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Неправильно!");
                    }
                    break;
                case 2:
                    if (ellipseOneEx1.Fill == Brushes.Yellow && ellipseTwoEx1.Fill == Brushes.White && combinedPathEx1.Fill == Brushes.Yellow)
                    {
                        windows.CorrectResult correctResult = new windows.CorrectResult();
                        correctResult.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Неправильно!");
                    }
                    break;
                case 3:
                    if (ellipseOneEx1.Fill == Brushes.White && ellipseTwoEx1.Fill == Brushes.Yellow && combinedPathEx1.Fill == Brushes.Yellow)
                    {
                        windows.CorrectResult correctResult = new windows.CorrectResult();
                        correctResult.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Неправильно!");
                    }
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
                    GenerationCondition();
                    break;
                case 2:
                    GenerationCondition2();
                    break;
                case 3:
                    GenerationCondition3();
                    break;
                default:
                    break;
            }
        }

        private void BtnCheck2_Click(object sender, RoutedEventArgs e)
        {
            int[] intersectionSets = IntersectionElementsSets(setElementsA, setElementsB);
            int[] positionElementsA = new int[4];
            int[] positionElementsB = new int[4];
            int[] intersectionAB = new int[4];
            int razmA = 0, razmB = 0, razmIntersection = 0;

            for (int i = 0; i < masElements.Length; i++)
            {
                if (masElements[i] != 0)
                {
                    for (int j = 0; j < setElementsA.Length; j++)
                    {
                        if (masElements[i] == setElementsA[j])
                        {
                            positionElementsA[razmA] = i + 1;
                            razmA++;
                        }
                    }
                    for (int j = 0; j < setElementsB.Length; j++)
                    {
                        if (masElements[i] == setElementsB[j])
                        {
                            positionElementsB[razmB] = i + 1;
                            razmB++;
                        }
                    }
                    for (int j = 0; j < intersectionSets.Length; j++)
                    {
                        if (masElements[i] == intersectionSets[j])
                        {
                            intersectionAB[razmIntersection] = i + 1;
                            razmIntersection++;
                        }
                    }
                }
            }

            if (CheckSet(positionElementsA, 0) == true && CheckSet(positionElementsB, 1) == true && CheckSet(intersectionAB, 2) == true)
            {
                windows.CorrectResult correctResult = new windows.CorrectResult();
                correctResult.ShowDialog();
            }
        }

        /// <summary>
        /// Поиск элементов, которые содержаться только в одном множестве
        /// </summary>
        /// <param name="set">Множество, в котором идет поиск элементов</param>
        /// <param name="intersectionSets">Множество, в котором храняться общие элементы</param>
        /// <returns></returns>
        private int[] ElementsOnlyOneSet(int[] set, int[] intersectionSets)
        {
            int[] mas = new int[4];
            int n = 0;
            bool yes = false;
            for (int i = 0; i < set.Length; i++)
            {
                for (int j = 0; j < intersectionSets.Length; j++)
                {
                    if (set[i] == intersectionSets[j])
                    {
                        yes = true;
                    }
                }
                if (yes == false)
                {
                    mas[n] = set[i];
                    n++;
                }
                yes = false;
            }
            return mas;
        }

        /// <summary>
        /// Проверка задания 2
        /// </summary>
        /// <param name="elements">Верные элементы</param>
        /// <param name="canvasChildren">В какую часть должны входить элементы</param>
        /// <returns></returns>
        private bool CheckSet(int[] elements, int canvasChildren)
        {
            int prov = 0;
            int real = 0;
            Path path = (Path)Canvas2.Children[canvasChildren];
            for (int i = 5; i < Canvas2.Children.Count; i++)
            {
                Path path1 = (Path)Canvas2.Children[i];
                if (path.Data.FillContainsWithDetail(path1.Data) == IntersectionDetail.FullyContains)
                {
                    for (int j = 0; j < elements.Length; j++)
                    {
                        if (elements[j] == i - 4)
                        {
                            prov++;
                        }
                    }
                    real++;
                }
            }

            int elementsDontZero = 0;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] != 0)
                {
                    elementsDontZero++;
                }
            }

            if (prov == elementsDontZero && real == prov)
            {
                return true;
            }
            return false;
        }

        private void BtnCheck3_Click(object sender, RoutedEventArgs e)
        {
            int combining = 0, intersection = 0;
            for (int i = 0; i < masAnswerOptions.Length; i++)
            {
                if (masAnswerOptions[i] == 0)
                {
                    combining = i + 1;
                }
                if (masAnswerOptions[i] == 1)
                {
                    intersection = i + 1;
                }
            }
            switch (combining)
            {
                case 1:
                    switch (intersection)
                    {
                        case 2:
                            if (Cb1.IsChecked == true && Cb2.IsChecked == true && Cb3.IsChecked == false && Cb4.IsChecked == false)
                            {
                                windows.CorrectResult correctResult = new windows.CorrectResult();
                                correctResult.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }
                            break;
                        case 3:
                            if (Cb1.IsChecked == true && Cb2.IsChecked == false && Cb3.IsChecked == true && Cb4.IsChecked == false)
                            {
                                windows.CorrectResult correctResult = new windows.CorrectResult();
                                correctResult.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }
                            break;
                        case 4:
                            if (Cb1.IsChecked == true && Cb2.IsChecked == false && Cb3.IsChecked == false && Cb4.IsChecked == true)
                            {
                                windows.CorrectResult correctResult = new windows.CorrectResult();
                                correctResult.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    switch (intersection)
                    {
                        case 1:
                            if (Cb1.IsChecked == true && Cb2.IsChecked == true && Cb3.IsChecked == false && Cb4.IsChecked == false)
                            {
                                windows.CorrectResult correctResult = new windows.CorrectResult();
                                correctResult.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }
                            break;
                        case 3:
                            if (Cb1.IsChecked == false && Cb2.IsChecked == true && Cb3.IsChecked == true && Cb4.IsChecked == false)
                            {
                                windows.CorrectResult correctResult = new windows.CorrectResult();
                                correctResult.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }
                            break;
                        case 4:
                            if (Cb1.IsChecked == false && Cb2.IsChecked == true && Cb3.IsChecked == false && Cb4.IsChecked == true)
                            {
                                windows.CorrectResult correctResult = new windows.CorrectResult();
                                correctResult.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    switch (intersection)
                    {
                        case 1:
                            if (Cb1.IsChecked == true && Cb2.IsChecked == false && Cb3.IsChecked == true && Cb4.IsChecked == false)
                            {
                                windows.CorrectResult correctResult = new windows.CorrectResult();
                                correctResult.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }
                            break;
                        case 2:
                            if (Cb1.IsChecked == false && Cb2.IsChecked == true && Cb3.IsChecked == true && Cb4.IsChecked == false)
                            {
                                windows.CorrectResult correctResult = new windows.CorrectResult();
                                correctResult.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }
                            break;
                        case 4:
                            if (Cb1.IsChecked == false && Cb2.IsChecked == false && Cb3.IsChecked == true && Cb4.IsChecked == true)
                            {
                                windows.CorrectResult correctResult = new windows.CorrectResult();
                                correctResult.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case 4:
                    switch (intersection)
                    {
                        case 1:
                            if (Cb1.IsChecked == true && Cb2.IsChecked == false && Cb3.IsChecked == false && Cb4.IsChecked == true)
                            {
                                windows.CorrectResult correctResult = new windows.CorrectResult();
                                correctResult.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }
                            break;
                        case 2:
                            if (Cb1.IsChecked == false && Cb2.IsChecked == true && Cb3.IsChecked == false && Cb4.IsChecked == true)
                            {
                                windows.CorrectResult correctResult = new windows.CorrectResult();
                                correctResult.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }
                            break;
                        case 3:
                            if (Cb1.IsChecked == false && Cb2.IsChecked == false && Cb3.IsChecked == true && Cb4.IsChecked == true)
                            {
                                windows.CorrectResult correctResult = new windows.CorrectResult();
                                correctResult.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void MenuHint_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
