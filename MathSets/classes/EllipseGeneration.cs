using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace MathSets
{
    public class EllipseGeneration
    {
        /// <summary>
        /// Генерация эллипса
        /// </summary>
        /// <param name="widht">ширина создаваемого эллипса</param>
        /// <param name="height">высота создаваемого эллипса</param>
        /// <param name="x">отступ слева</param>
        /// <param name="y">отступ справа</param>
        /// <returns></returns>
        public Ellipse getEllipse(int widht, int height, int x, int y)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Width = widht;
            ellipse.Height = height;
            ellipse.Stroke = Brushes.Black;
            ellipse.StrokeThickness = Base.StrokeThickness;
            ellipse.Margin = new Thickness(x, y, 0, 0);
            ellipse.Fill = Brushes.White;
            return ellipse;
        }

        /// <summary>
        /// Создание объединения двух эллипсов
        /// </summary>
        /// <param name="ellipseOne">Первый эллипс</param>
        /// <param name="ellipseTwo">Второй эллипс</param>
        /// <param name="geometryCombineMode">Метод комбинирования</param>
        /// <returns>Комбинированная фигура</returns>
        public Path getUnification(Ellipse ellipseOne, Ellipse ellipseTwo, GeometryCombineMode geometryCombineMode)
        {
            EllipseGeometry pathGeometryOne = new EllipseGeometry() // Создание EllipseGeometry, который равен первому эллипсу (он нужен для нахождения объединения)
            {
                RadiusX = ellipseOne.Width / 2,
                RadiusY = ellipseOne.Height / 2,
                Center = new Point(ellipseOne.Margin.Left + (ellipseOne.Width / 2), ellipseOne.Margin.Top + (ellipseOne.Height / 2)),
            };
            EllipseGeometry pathGeometryTwo = new EllipseGeometry() // Создание EllipseGeometry, который равен второму эллипсу 
            {
                RadiusX = ellipseTwo.Width / 2,
                RadiusY = ellipseTwo.Height / 2,
                Center = new Point(ellipseTwo.Margin.Left + (ellipseTwo.Width / 2), ellipseTwo.Margin.Top + (ellipseTwo.Height / 2)),
            };
            CombinedGeometry combinedGeometry = new CombinedGeometry(geometryCombineMode, pathGeometryOne, pathGeometryTwo); // Объединение двух эллипсов
            Path combinedPath = new Path();
            combinedPath.Data = combinedGeometry;
            combinedPath.Fill = Brushes.White;
            combinedPath.Stroke = Brushes.Black;
            combinedPath.StrokeThickness = Base.StrokeThickness;
            return combinedPath;
        }

        /// <summary>
        /// Создание объединения трех эллипсов
        /// </summary>
        /// <param name="ellipseOne">Первый эллипс</param>
        /// <param name="ellipseTwo">Второй эллипс</param>
        /// <param name="ellipseThree">Тритий эллипс</param>
        /// <param name="geometryCombineMode">Метод комбинирования</param>
        /// <returns>Комбинированная фигура</returns>
        public Path getUnificationThree(Ellipse ellipseOne, Ellipse ellipseTwo, Ellipse ellipseThree, GeometryCombineMode geometryCombineMode)
        {
            EllipseGeometry pathGeometryOne = new EllipseGeometry() // Создание EllipseGeometry, который равен первому эллипсу (он нужен для нахождения объединения)
            {
                RadiusX = ellipseOne.Width / 2,
                RadiusY = ellipseOne.Height / 2,
                Center = new Point(ellipseOne.Margin.Left + (ellipseOne.Width / 2), ellipseOne.Margin.Top + (ellipseOne.Height / 2)),
            };
            EllipseGeometry pathGeometryTwo = new EllipseGeometry() // Создание EllipseGeometry, который равен второму эллипсу 
            {
                RadiusX = ellipseTwo.Width / 2,
                RadiusY = ellipseTwo.Height / 2,
                Center = new Point(ellipseTwo.Margin.Left + (ellipseTwo.Width / 2), ellipseTwo.Margin.Top + (ellipseTwo.Height / 2)),
            };
            EllipseGeometry pathGeometryThree = new EllipseGeometry() // Создание EllipseGeometry, который равен третьему эллипсу 
            {
                RadiusX = ellipseThree.Width / 2,
                RadiusY = ellipseThree.Height / 2,
                Center = new Point(ellipseThree.Margin.Left + (ellipseThree.Width / 2), ellipseThree.Margin.Top + (ellipseThree.Height / 2)),
            };
            CombinedGeometry combinedGeometryOne = new CombinedGeometry(geometryCombineMode, pathGeometryOne, pathGeometryTwo); // Объединение двух эллипсов (1 и 2)
            CombinedGeometry combinedGeometryTwo = new CombinedGeometry(geometryCombineMode, pathGeometryOne, pathGeometryThree); // Объединение двух эллипсов (1 и 3)
            CombinedGeometry combinedGeometryThree = new CombinedGeometry(geometryCombineMode, pathGeometryTwo, pathGeometryThree); // Объединение двух эллипсов (2 и 3)
            CombinedGeometry combinedGeometryFour = new CombinedGeometry(geometryCombineMode, combinedGeometryOne, combinedGeometryTwo); // Объединение двух пересечений
            CombinedGeometry combinedGeometry = new CombinedGeometry(geometryCombineMode, combinedGeometryFour, combinedGeometryThree); // Объединение пересечения с третим эллипсом
            Path combinedPath = new Path();
            combinedPath.Data = combinedGeometry;
            combinedPath.Fill = Brushes.White;
            combinedPath.Stroke = Brushes.Black;
            combinedPath.StrokeThickness = Base.StrokeThickness;
            return combinedPath;
        }

        /// <summary>
        /// Формирование всей необходимой информации в массив о двух эллипсах
        /// </summary>
        /// <param name="i">Номер пункта</param>
        /// <param name="ellipseOne">Первый эллипс</param>
        /// <param name="ellipseTwo">Второй эллипс</param>
        /// <returns></returns>
        public int[] getDateEllipse(int i, Ellipse ellipseOne, Ellipse ellipseTwo)
        {
            int[] massive = new int[9]; // Информация для вывода верного ответа
            massive[0] = i;
            massive[1] = Convert.ToInt32(ellipseOne.Width);
            massive[2] = Convert.ToInt32(ellipseOne.Height);
            massive[3] = Convert.ToInt32(ellipseOne.Margin.Left);
            massive[4] = Convert.ToInt32(ellipseOne.Margin.Top);
            massive[5] = Convert.ToInt32(ellipseTwo.Width);
            massive[6] = Convert.ToInt32(ellipseTwo.Height);
            massive[7] = Convert.ToInt32(ellipseTwo.Margin.Left);
            massive[8] = Convert.ToInt32(ellipseTwo.Margin.Top);
            return massive;
        }

        /// <summary>
        /// Формирование всей необходимой информации в массив о трех эллипсах
        /// </summary>
        /// <param name="i">Номер пункта</param>
        /// <param name="ellipseOne">Первый эллипс</param>
        /// <param name="ellipseTwo">Второй эллипс</param>
        /// <param name="ellipseThree">Третий эллипс</param>
        /// <returns></returns>
        public int[] getDateEllipseThree(int i, Ellipse ellipseOne, Ellipse ellipseTwo, Ellipse ellipseThree)
        {
            int[] massive = new int[13]; // Информация для вывода верного ответа
            massive[0] = i;
            massive[1] = Convert.ToInt32(ellipseOne.Width);
            massive[2] = Convert.ToInt32(ellipseOne.Height);
            massive[3] = Convert.ToInt32(ellipseOne.Margin.Left);
            massive[4] = Convert.ToInt32(ellipseOne.Margin.Top);
            massive[5] = Convert.ToInt32(ellipseTwo.Width);
            massive[6] = Convert.ToInt32(ellipseTwo.Height);
            massive[7] = Convert.ToInt32(ellipseTwo.Margin.Left);
            massive[8] = Convert.ToInt32(ellipseTwo.Margin.Top);
            massive[9] = Convert.ToInt32(ellipseThree.Width);
            massive[10] = Convert.ToInt32(ellipseThree.Height);
            massive[11] = Convert.ToInt32(ellipseThree.Margin.Left);
            massive[12] = Convert.ToInt32(ellipseThree.Margin.Top);
            return massive;
        }
    }
}
