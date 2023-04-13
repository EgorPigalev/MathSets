using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MathSets.windows
{
    /// <summary>
    /// Логика взаимодействия для ResultCombiningSetsWindow.xaml
    /// </summary>
    public partial class ResultCombiningSetsWindow : Window
    {
        EllipseGeneration ellipseGeneration = new EllipseGeneration();
        Random random = new Random();

        /// <summary>
        /// Конструктор для задания 1
        /// </summary>
        /// <param name="canvas">Канвас из 1 задания</param>
        /// <param name="ellipseOne">Первый эллипс</param>
        /// <param name="ellipseTwo">Второй эллипс</param>
        /// <param name="numberAnswer">Номер правильного ответа</param>
        public ResultCombiningSetsWindow(Canvas canvas, Ellipse ellipseOne, Ellipse ellipseTwo, int numberAnswer)
        {
            InitializeComponent();
            Canvas newCanvas = new Canvas()
            {
                Width = canvas.Width,
                Height = canvas.Width,
                Margin = canvas.Margin
            };

            Ellipse ellipseOneNew = new Ellipse()
            {
                Width = ellipseOne.Width,
                Height = ellipseOne.Height,
                Margin = ellipseOne.Margin,
                Stroke = ellipseOne.Stroke,
                StrokeThickness = ellipseOne.StrokeThickness
            };
            newCanvas.Children.Add(ellipseOneNew);

            Ellipse ellipseTwoNew = new Ellipse()
            {
                Width = ellipseTwo.Width,
                Height = ellipseTwo.Height,
                Margin = ellipseTwo.Margin,
                Stroke = ellipseTwo.Stroke,
                StrokeThickness = ellipseTwo.StrokeThickness
            };
            newCanvas.Children.Add(ellipseTwoNew);

            Path pathNew = ellipseGeneration.getUnification(ellipseOneNew, ellipseTwoNew, GeometryCombineMode.Intersect);
            newCanvas.Children.Add(pathNew);

            TextBlock tbA = new TextBlock()
            {
                Text = "A",
                Margin = new Thickness(5, 0, 0, 0)
            };
            newCanvas.Children.Add(tbA);
            TextBlock tbB = new TextBlock()
            {
                Text = "B",
                Margin = new Thickness(400, 0, 0, 0)
            };
            newCanvas.Children.Add(tbB);

            SpResult.Children.Add(newCanvas);

            switch (numberAnswer)
            {
                case 0:
                    ellipseOneNew.Fill = Brushes.White;
                    ellipseTwoNew.Fill = Brushes.White;
                    pathNew.Fill = Brushes.Yellow;
                    break;
                case 1:
                    ellipseOneNew.Fill = Brushes.Yellow;
                    ellipseTwoNew.Fill = Brushes.Yellow;
                    pathNew.Fill = Brushes.Yellow;
                    break;
                case 2:
                    ellipseOneNew.Fill = Brushes.Yellow;
                    ellipseTwoNew.Fill = Brushes.White;
                    pathNew.Fill = Brushes.Yellow;
                    break;
                case 3:
                    ellipseOneNew.Fill = Brushes.White;
                    ellipseTwoNew.Fill = Brushes.Yellow;
                    pathNew.Fill = Brushes.Yellow;
                    break;
            }
        }

        /// <summary>
        /// Верный ответ для задания 2
        /// </summary>
        /// <param name="ellipseOne">Первый эллипс</param>
        /// <param name="ellipseTwo">Второй эллипс</param>
        /// <param name="masOnlyA">Элементы только 1 множества</param>
        /// <param name="masOnlyB">Элементы только 2 множества</param>
        /// <param name="intersectionSets">Элементы из пересечение множеств</param>
        public ResultCombiningSetsWindow(Ellipse ellipseOne, Ellipse ellipseTwo, int[] masOnlyA, int[] masOnlyB, int[] intersectionSets)
        {
            InitializeComponent();

            Canvas newCanvas = new Canvas()
            {
                Width = 450,
                Height = 200
            };
            Ellipse ellipseOneNew = new Ellipse()
            {
                Width = ellipseOne.Width,
                Height = ellipseOne.Height,
                Margin = new Thickness(0, 0, 0, 0),
                Stroke = ellipseOne.Stroke,
                StrokeThickness = ellipseOne.StrokeThickness
            };
            newCanvas.Children.Add(ellipseOneNew);

            Ellipse ellipseTwoNew = new Ellipse()
            {
                Width = ellipseTwo.Width,
                Height = ellipseTwo.Height,
                Margin = new Thickness(150, 0, 0, 0),
                Stroke = ellipseTwo.Stroke,
                StrokeThickness = ellipseTwo.StrokeThickness
            };
            newCanvas.Children.Add(ellipseTwoNew);

            Path pathNew = ellipseGeneration.getUnification(ellipseOneNew, ellipseTwoNew, GeometryCombineMode.Intersect);
            newCanvas.Children.Add(pathNew);

            AddElementsIncanvas(masOnlyA, 30, newCanvas);
            AddElementsIncanvas(masOnlyB, 300, newCanvas);
            AddElementsIncanvas(intersectionSets, 170, newCanvas);

            SpResult.Children.Add(newCanvas);
        }

        /// <summary>
        /// Отрисовка элементов
        /// </summary>
        /// <param name="mas">Элементы, которые выводятся</param>
        /// <param name="marginLeft">Начальный отступ слева</param>
        /// <param name="newCanvas">Канвас, куда выводятся элементы</param>
        private void AddElementsIncanvas(int[] mas, int marginLeft, Canvas newCanvas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] != 0)
                {
                    Figure figure = new Figure(28, 0, 0);
                    Geometry geometry = null;
                    geometry = GetGeometryFromText(mas[i].ToString(), 50, marginLeft, random.Next(15, 60));
                    marginLeft += 30;

                    Path pathNumbers = new Path()
                    {
                        StrokeThickness = Base.StrokeThickness,
                        Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18"),
                        Data = geometry,
                        Fill = Brushes.White,
                    };
                    newCanvas.Children.Add(pathNumbers);
                }
            }
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
        /// Конструктор для 3 задания
        /// </summary>
        /// <param name="answerOne">Первый правильный ответ</param>
        /// <param name="answerTwo">Второй правильный ответ</param>
        public ResultCombiningSetsWindow(string answerOne, string answerTwo)
        {
            InitializeComponent();

            TextBlock tbA = new TextBlock()
            {
                Text = answerOne

            };
            SpResult.Children.Add(tbA);
            TextBlock tbB = new TextBlock()
            {
                Text = answerTwo

            };
            SpResult.Children.Add(tbB);
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
