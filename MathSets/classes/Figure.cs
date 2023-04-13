using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MathSets
{
    delegate Geometry CreateFiguresDelegate(int x, bool isUp); // Чтобы можно было сделать массив из функций для создания фигур.

    internal class Figure
    {
        private static Random s_random = new Random();
        private int _heightContainer;
        private int _widthContainer;
        private int _sizeFigures;

        /// <summary>
        /// Инициализирует новый экземпляр класса Figure с заданными параметрами
        /// </summary>
        /// <param name="sizeFigures">размер фигур (длина и ширина)</param>
        /// <param name="heightContainer">высота контейнера</param>
        /// <param name="widthContainer">ширина контейнера</param>
        public Figure(int sizeFigures, double heightContainer, double widthContainer)
        {
            _heightContainer = (int)heightContainer;
            _widthContainer = (int)widthContainer;
            _sizeFigures = sizeFigures;
        }

        /// <summary>
        /// Создаёт треугольник с заданными параметрами
        /// </summary>
        /// <param name="x">позиция по оси Х крайней левой точки фигуры</param>
        /// <param name="isUp">true - фигура располагается в верхней половине контейнера, false - в нижней</param>
        /// <returns>Треугольник с заданными начальной позицией и вертикальным положением</returns>
        public Geometry CreateTriangle(int x, bool isUp)
        {
            int y = GetCoordinateY(isUp);

            return GetGeometryFromPoints(new PointCollection()
            {
                new Point(x, y),
                new Point(x + _sizeFigures / 2, y - _sizeFigures),
                new Point(x + _sizeFigures, y)
            });
        }

        /// <summary>
        /// Создаёт треугольник по заданным параметрам (не рандомно)
        /// </summary>
        /// <param name="x">Координата по x</param>
        /// <param name="y">Координата по y</param>
        /// <returns>Треугольник с заданными начальной позицией и вертикальным положением</returns>
        public Geometry CreateTriangle(int x, int y)
        {
            return GetGeometryFromPoints(new PointCollection()
            {
                new Point(x, y),
                new Point(x + _sizeFigures / 2, y - _sizeFigures),
                new Point(x + _sizeFigures, y)
            });
        }

        /// <summary>
        /// Создаёт квадрат с заданными параметрами
        /// </summary>
        /// <param name="x">позиция по оси Х крайней левой точки фигуры</param>
        /// <param name="isUp">true - фигура располагается в верхней половине контейнера, false - в нижней</param>
        /// <returns>Квадрат с заданными начальной позицией и вертикальным положением</returns>
        public Geometry CreateSquare(int x, bool isUp)
        {
            int y = GetCoordinateY(isUp);

            return GetGeometryFromPoints(new PointCollection()
            {
                new Point(x, y),
                new Point(x, y - _sizeFigures),
                new Point(x + _sizeFigures, y - _sizeFigures),
                new Point(x + _sizeFigures, y)
            });
        }

        /// <summary>
        /// Создаёт квадрат с заданными параметрами (не рандомно)
        /// </summary>
        /// <param name="x">позиция по оси Х</param>
        /// <param name="y">позиция по оси Y</param>
        /// <returns>Квадрат по заданным параметрам</returns>
        public Geometry CreateSquare(int x, int y)
        {
            return GetGeometryFromPoints(new PointCollection()
            {
                new Point(x, y),
                new Point(x, y - _sizeFigures),
                new Point(x + _sizeFigures, y - _sizeFigures),
                new Point(x + _sizeFigures, y)
            });
        }

        /// <summary>
        /// Создаёт круг с заданными параметрами
        /// </summary>
        /// <param name="x">позиция по оси Х крайней левой точки фигуры</param>
        /// <param name="isUp">true - фигура располагается в верхней половине контейнера, false - в нижней</param>
        /// <returns>Круг с заданными начальной позицией и вертикальным положением</returns>
        public Geometry CreateCircle(int x, bool isUp)
        {
            int y = GetCoordinateY(isUp);

            return new EllipseGeometry
            (
                new Point
                (
                    x + _sizeFigures / 2,
                    y - _sizeFigures / 2
                ),
                _sizeFigures / 2,
                _sizeFigures / 2
            );
        }

        /// <summary>
        /// Создаёт круг с заданными параметрами (не рандомно)
        /// </summary>
        /// <param name="x">позиция по оси x</param>
        /// <param name="y">позиция по оси y</param>
        /// <returns>Возвращает круг с заданными параметрами</returns>
        public Geometry CreateCircle(int x, int y)
        {
            return new EllipseGeometry
            (
                new Point
                (
                    x + _sizeFigures / 2,
                    y - _sizeFigures / 2
                ),
                _sizeFigures / 2,
                _sizeFigures / 2
            );
        }

        /// <summary>
        /// Создаёт вытянутый по оси Х эллипс с заданными параметрами
        /// </summary>
        /// <param name="x">позиция по оси Х крайней левой точки фигуры</param>
        /// <param name="isUp">true - фигура располагается в верхней половине контейнера, false - в нижней</param>
        /// <returns>Эллипс с заданными начальной позицией и вертикальным положением</returns>
        public Geometry CreateEllipseTransformY(int x, bool isUp)
        {
            int transformY = 3;
            int y = GetCoordinateY(isUp) - _sizeFigures / transformY;

            return new EllipseGeometry
            (
                new Point
                (
                    x + _sizeFigures / 2,
                    y - _sizeFigures / transformY
                ),
                _sizeFigures / 2,
                _sizeFigures / transformY
            );
        }

        /// <summary>
        /// Создаёт вытянутый по оси Х эллипс
        /// </summary>
        /// <param name="x">позиция по оси Х крайней левой точки фигуры</param>
        /// <param name="isUp">true - фигура располагается в верхней половине контейнера, false - в нижней</param>
        /// <param name="offsetY">смещение эллипса по оси Y</param>
        /// <returns>Эллипс с заданными начальной позицией и вертикальным положением</returns>
        public Geometry CreateEllipseTransformY(int x, bool isUp, int offsetY)
        {
            int transformY = 3;
            int y = GetCoordinateY(isUp) - _sizeFigures / transformY + offsetY;

            return new EllipseGeometry
            (
                new Point
                (
                    x + _sizeFigures / 2,
                    y - _sizeFigures / transformY
                ),
                _sizeFigures / 2,
                _sizeFigures / transformY
            );
        }

        /// <summary>
        /// Создаёт вытянутый по оси Y эллипс с заданными параметрами
        /// </summary>
        /// <param name="x">позиция по оси Х крайней левой точки фигуры</param>
        /// <param name="isUp">true - фигура располагается в верхней половине контейнера, false - в нижней</param>
        /// <returns>Эллипс с заданными начальной позицией и вертикальным положением</returns>
        public Geometry CreateEllipseTransformX(int x, bool isUp)
        {
            int transformX = 3;
            int y = GetCoordinateY(isUp);

            return new EllipseGeometry
            (
                new Point
                (
                    x + _sizeFigures / transformX,
                    y - _sizeFigures / 2
                ),
                _sizeFigures / transformX,
                _sizeFigures / 2
            );
        }

        /// <summary>
        /// Создаёт круг с заданными параметрами
        /// </summary>
        /// <param name="x">позиция по оси Х крайней левой точки фигуры</param>
        /// <param name="isUp">true - фигура располагается в верхней половине контейнера, false - в нижней</param>
        /// <returns>Круг с заданными начальной позицией и вертикальным положением</returns>
        public Geometry CreateEllipse(int x, bool isUp)
        {
            int y = GetCoordinateY(isUp);

            return new EllipseGeometry
            (
                new Point
                (
                    x + _sizeFigures / 2,
                    y - _sizeFigures / 2
                ),
                _sizeFigures / 2,
                _sizeFigures / 2
            );
        }

        /// <summary>
        /// Создаёт ромб с заданными параметрами
        /// </summary>
        /// <param name="x">позиция по оси Х крайней левой точки фигуры</param>
        /// <param name="isUp">true - фигура располагается в верхней половине контейнера, false - в нижней</param>
        /// <returns>Ромб с заданными начальной позицией и вертикальным положением</returns>
        public Geometry CreateRhomb(int x, bool isUp)
        {
            int y = GetCoordinateY(isUp);

            return GetGeometryFromPoints(new PointCollection()
            {
                new Point(x, y - _sizeFigures / 2),
                new Point(x + _sizeFigures / 2, y),
                new Point(x + _sizeFigures, y - _sizeFigures / 2),
                new Point(x + _sizeFigures / 2, y - _sizeFigures)
            });
        }

        /// <summary>
        /// Создаёт ромб с заданными параметрами (не рандомно)
        /// </summary>
        /// <param name="x">позиция по оси Х</param>
        /// <param name="y">позиция по оси Y</param>
        /// <returns>Ромб с заданными параметрами</returns>
        public Geometry CreateRhomb(int x, int y)
        {
            return GetGeometryFromPoints(new PointCollection()
            {
                new Point(x, y - _sizeFigures / 2),
                new Point(x + _sizeFigures / 2, y),
                new Point(x + _sizeFigures, y - _sizeFigures / 2),
                new Point(x + _sizeFigures / 2, y - _sizeFigures)
            });
        }

        /// <summary>
        /// Создаёт пламя с заданными параметрами
        /// </summary>
        /// <param name="x">позиция по оси Х крайней левой точки фигуры</param>
        /// <param name="isUp">true - фигура располагается в верхней половине контейнера, false - в нижней</param>
        /// <returns>Пламя с заданными начальной позицией и вертикальным положением</returns>
        public Geometry CreateFlame(int x, bool isUp)
        {
            int y = GetCoordinateY(isUp);

            return GetGeometryFromPoints(new PointCollection()
            {
                new Point(x + _sizeFigures / 6, y),
                new Point(x, y - _sizeFigures / 4),
                new Point(x + _sizeFigures / 2, y - _sizeFigures),
                new Point(x + _sizeFigures, y - _sizeFigures / 4),
                new Point(x + 5* _sizeFigures / 6, y)
            });
        }

        /// <summary>
        /// Создаёт пятиугольник с заданными параметрами
        /// </summary>
        /// <param name="x">позиция по оси Х крайней левой точки фигуры</param>
        /// <param name="isUp">true - фигура располагается в верхней половине контейнера, false - в нижней</param>
        /// <returns>Пятиугольник с заданными начальной позицией и вертикальным положением</returns>
        public Geometry CreatePentagon(int x, bool isUp)
        {
            int y = GetCoordinateY(isUp);

            return GetGeometryFromPoints(new PointCollection()
            {
                new Point(x + _sizeFigures / 6, y),
                new Point(x, y - _sizeFigures + _sizeFigures / 4),
                new Point(x + _sizeFigures / 2, y - _sizeFigures),
                new Point(x + _sizeFigures, y - _sizeFigures + _sizeFigures / 4),
                new Point(x + 5 * _sizeFigures / 6, y)
            });
        }

        /// <summary>
        /// Создаёт звезду с заданными параметрами
        /// </summary>
        /// <param name="x">позиция по оси Х центральной нижней точки фигуры</param>
        /// <param name="isUp">true - фигура располагается в верхней половине контейнера, false - в нижней</param>
        /// <returns>Звезда с заданными начальной позицией и вертикальным положением</returns>
        public Geometry CreateStar(int x, bool isUp)
        {
            int y = GetCoordinateY(isUp);

            int count = 5;
            int outerRadius = _sizeFigures / 2;
            int innerRadius = outerRadius / 2;
            double alpha = Math.PI / 2;
            x += _sizeFigures / 2;

            PointCollection tempPoints = new PointCollection();

            for (int i = 0; i < 2 * count + 1; i++)
            {
                if (i % 2 == 0)
                {
                    tempPoints.Add(new Point(x + innerRadius * Math.Cos(alpha), y + innerRadius * Math.Sin(alpha)));
                }
                else
                {
                    tempPoints.Add(new Point(x + outerRadius * Math.Cos(alpha), y + outerRadius * Math.Sin(alpha)));
                }
                alpha += Math.PI / count;
            }

            double displacementY = tempPoints[1].Y - tempPoints[0].Y + 10; // Чтобы фигура убиралась в контейнер по вертикали.
            PointCollection points = new PointCollection();

            foreach (Point item in tempPoints)
            {
                points.Add(new Point(item.X, item.Y - displacementY));
            }

            return GetGeometryFromPoints(points);
        }

        /// <summary>
        /// Генерирует случайную координату Y для фигуры в зависимости от её вертикального расположения
        /// </summary>
        /// <param name="IsUp">true - фигура располагается в верхней половине контейнера, false - в нижней</param>
        /// <returns>Координата Y крайней нижней точки фигуры</returns>
        private int GetCoordinateY(bool IsUp)
        {
            if (IsUp)
            {
                return s_random.Next(_sizeFigures + 1, _heightContainer / 2);
            }
            else
            {
                return s_random.Next(_heightContainer / 2 + _sizeFigures + 1, _heightContainer);
            }
        }

        /// <summary>
        /// Создаёт фигуру на основании её точек
        /// </summary>
        /// <param name="points">коллекция точек для отрисовки фигуры</param>
        /// <returns>Фигура, созданная по заданным точкам</returns>
        private Geometry GetGeometryFromPoints(PointCollection points)
        {
            Geometry geometry = new StreamGeometry();

            using (StreamGeometryContext ctx = ((StreamGeometry)geometry).Open())
            {
                ctx.BeginFigure(points[0], true, true);
                ctx.PolyLineTo(points, true, false);
            }

            return geometry;
        }

        /// <summary>
        /// Вычисляет отступы между фигурами (с учётом размеров самой фигуры)
        /// </summary>
        /// <param name="countFigures">количество фигур</param>
        /// <returns></returns>
        public int GetOffset(int countFigures)
        {

            if (countFigures >= 3)
            {
                int offset;

                if (countFigures % 2 == 0)
                {
                    offset = (_widthContainer - countFigures / 2 * _sizeFigures) / (countFigures / 2 - 1);
                }
                else
                {
                    offset = (_widthContainer - (countFigures / 2 + 1) * _sizeFigures) / (countFigures / 2);
                }

                return offset + _sizeFigures;
            }

            return 0;
        }

        /// <summary>
        /// Получает методы создания всех фигур у данного объекта
        /// </summary>
        /// <returns>Коллекция методов создания фигур</returns>
        public List<CreateFiguresDelegate> GetAllCreateFiguresMethods()
        {
            return new List<CreateFiguresDelegate>
            {
                CreateTriangle,
                CreateSquare,
                CreateCircle,
                CreateRhomb,
                CreateFlame,
                CreatePentagon,
                CreateStar
            };
        }

        /// <summary>
        /// Перемешивает методы создания фигур в списке
        /// </summary>
        /// <param name="methods">список методов для создания фигур</param>
        /// <returns>Список индексов методов создания фигур из первоначального списка методов</returns>
        public static List<int> ShuffleMethods(List<CreateFiguresDelegate> methods)
        {
            List<CreateFiguresDelegate> tempMethods = new List<CreateFiguresDelegate>();
            tempMethods.AddRange(methods);
            methods.Clear();

            List<int> indexsesAddedMethods = new List<int>();
            List<int> indexesFigures = new List<int>();

            for (int i = 0; i < tempMethods.Count; i++)
            {
                while (true)
                {
                    int index = s_random.Next(0, tempMethods.Count);

                    if (!indexsesAddedMethods.Contains(index))
                    {
                        methods.Add(tempMethods[index]);
                        indexsesAddedMethods.Add(index);
                        indexesFigures.Add(index);
                        break;
                    }
                }
            }

            return indexesFigures;
        }

#pragma warning disable CS0618 // Для сокрытия предупреждения об устаревшем FormattedText
        /// <summary>
        /// Создаёт фигуру на основании текста, преобразовавая его в графический элемент
        /// </summary>
        /// <param name="text">текст для преобразования в фигуру</param>
        /// <returns>Фигура, созданная на основании заданного текста</returns>
        public Geometry GetGeometryFromText(string text)
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

            return formattedText.BuildGeometry(new Point
                (
                    s_random.Next(Base.StrokeThickness, _widthContainer - _sizeFigures),
                    s_random.Next(Base.StrokeThickness + 1, _heightContainer - _sizeFigures - Base.StrokeThickness)
                ));
        }

#pragma warning disable CS0618 // Для сокрытия предупреждения об устаревшем FormattedText
        /// <summary>
        /// Создаёт фигуру на основании текста, преобразовавая его в графический элемент
        /// </summary>
        /// <param name="text">текст для преобразования в фигуру</param>
        /// <param name="_sizeFigures">размер фигуры</param>
        /// <param name="x">Координата по оси X</param>
        /// <param name="y">Координата по оси Y</param>
        /// <returns>Фигура, созданная на основании заданного текста</returns>
        public Geometry GetGeometryFromText(string text, int sizeFigures, int x, int y)
        {
            FormattedText formattedText = new FormattedText
            (
                text,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface("Comic Sans MS"),
                sizeFigures,
                (Brush)new BrushConverter().ConvertFrom("#F14C18") // Данное поле изменяется при создании объекта Path.
            );

            return formattedText.BuildGeometry(new Point(x, y));
        }

        /// <summary>
        /// Создаёт фигуру на основании текста, преобразовавая его в графический элемент
        /// </summary>
        /// <param name="text">текст для преобразования в фигуру</param>
        /// <param name="x">позиция на оси Х</param>
        /// <param name="y">позиция на оси Y</param>
        /// <returns>Фигура, созданная на основании заданного текста</returns>
        public Geometry GetGeometryFromText(string text, int x, int y)
        {
            FormattedText formattedText = new FormattedText
            (
                text,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface("Comic Sans MS"),
                _sizeFigures,
                Brushes.Black // Данное поле изменяется при создании объекта Path.
            );

            return formattedText.BuildGeometry(new Point(x, y));
        }
#pragma warning restore CS0618 // Для возобновления предупреждений об устаревших конструкциях

        /// <summary>
        /// Проверяет вхождение переданных фигур в заданную фигуру (множество)
        /// </summary>
        /// <param name="indexesAnswers">список индектов "верных" фигур</param>
        /// <param name="figures">фигуры для перемещения</param>
        /// <param name="set">фигура (множество), в которую перемещают прочие фигуры</param>
        /// <returns>true - перемещение выполнено верно, в противном случае - false</returns>
        public static bool CheckOccurrencesFiguresInSet(List<int> indexesAnswers, List<Geometry> figures, Geometry set)
        {
            int countRightAnswer = 0;

            for (int i = 0; i < figures.Count; i++)
            {
                foreach (int item in indexesAnswers)
                {
                    if (set.FillContainsWithDetail(figures[i]) == IntersectionDetail.FullyContains)
                    {
                        if (indexesAnswers.Contains(i))
                        {
                            countRightAnswer++;
                            break;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            if (countRightAnswer == indexesAnswers.Count)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Проверяет вхождение переданных фигур в заданную фигуру (множество)
        /// </summary>
        /// <param name="indexesAnswers">список индектов "верных" фигур</param>
        /// <param name="canvas">контейнер</param>
        /// <returns>true - перемещение выполнено верно, в противном случае - false</returns>
        public static bool CheckOccurrencesFiguresInSet(List<int> indexesAnswers, Canvas canvas)
        {
            int countRightAnswer = 0;
            List<Geometry> figures = new List<Geometry>();

            for (int i = 1; i < canvas.Children.Count; i++)
            {
                Path p = (Path)canvas.Children[i];
                figures.Add(p.Data);
            }

            for (int i = 1; i < figures.Count; i++)
            {
                foreach (int item in indexesAnswers)
                {
                    if (figures[0].FillContainsWithDetail(figures[i]) == IntersectionDetail.FullyContains)
                    {
                        if (indexesAnswers.Contains(i - 1)) // i - 1, так как первым элементом списка является само множество.
                        {
                            countRightAnswer++;
                            break;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            if (countRightAnswer == indexesAnswers.Count)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Проверяет пересечение множеств и фигур между собой и друг с другом.
        /// </summary>
        /// <param name="figures">список фигур</param>
        /// <param name="sets">список множеств</param>
        /// <returns>true, если пересечения множеств и фигур найдены, в противном случае - false</returns>
        public static bool CheckIntersectionsFiguresAndSets(List<Geometry> figures, List<Geometry> sets)
        {
            for (int i = 0; i < figures.Count; i++)
            {
                for (int j = i + 1; j < figures.Count; j++)
                {
                    if (figures[i].FillContainsWithDetail(figures[j]) == IntersectionDetail.Intersects)
                    {
                        return true;
                    }
                }

                foreach (Geometry set in sets)
                {
                    if (figures[i].FillContainsWithDetail(set) == IntersectionDetail.Intersects)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Добавляет созданные фигуры в контейнер
        /// </summary>
        /// <param name="figures">коллекция фигур</param>
        /// <param name="panel">контейнер</param>
        public static void ShowFigures(List<Geometry> figures, Panel panel)
        {
            for (int i = 0; i < figures.Count; i++)
            {
                panel.Children.Add(new Path()
                {
                    StrokeThickness = Base.StrokeThickness,
                    Stroke = Base.ColorFigures,
                    Data = figures[i],
                    Fill = Brushes.White,
                    Uid = i.ToString()
                });
            }
        }

        /// <summary>
        /// Добавляет созданные фигуры в контейнер
        /// </summary>
        /// <param name="figures">коллекция фигур</param>
        /// <param name="panel">контейнер</param>
        /// <param name="colorFill">цвет заливки</param>
        /// <param name="colorStroke">цвет обводки</param>
        public static void ShowFigures(List<Geometry> figures, Panel panel, SolidColorBrush colorFill, SolidColorBrush colorStroke)
        {
            for (int i = 0; i < figures.Count; i++)
            {
                panel.Children.Add(new Path()
                {
                    StrokeThickness = Base.StrokeThickness,
                    Stroke = colorStroke,
                    Data = figures[i],
                    Fill = colorFill,
                    Uid = i.ToString()
                });
            }
        }
    }
}