using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace MathSets
{
    struct KeyFigure // Для хранения постоянного индекса фигуры, чтобы можно было отследить "правильные" (фигуры-ответы).
    {
        public int Index;
        public CreateFiguresDelegate Method;
    }

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
                CreateEllipse,
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
        /// <returns>Список структур, представляющий из себя пару: ключ - фигура, где ключ - целочисленный индекс из первоначального списка методов</returns>
        public static List<KeyFigure> ShuffleMethods(List<CreateFiguresDelegate> methods)
        {
            List<CreateFiguresDelegate> tempMethods = new List<CreateFiguresDelegate>();
            tempMethods.AddRange(methods);
            methods.Clear();

            List<int> indexsesAddedMethods = new List<int>();
            List<KeyFigure> keysFigures = new List<KeyFigure>();

            for (int i = 0; i < tempMethods.Count; i++)
            {
                while (true)
                {
                    int index = s_random.Next(0, tempMethods.Count);

                    if (!indexsesAddedMethods.Contains(index))
                    {
                        methods.Add(tempMethods[index]);
                        indexsesAddedMethods.Add(index);
                        keysFigures.Add(new KeyFigure
                        {
                            Index = index,
                            Method = tempMethods[index]
                        });
                        break;
                    }
                }
            }

            return keysFigures;
        }

        /// <summary>
        /// Создаёт фигуру на основании текста, преобразовавая его в графический элемент
        /// </summary>
        /// <param name="text">текст для преобразования в фигуру</param>
        /// <param name="x">позиция по оси Х крайней левой точки фигуры</param>
        /// <param name="isUp">true - фигура располагается в верхней половине контейнера, false - в нижней</param>
        /// <returns>Фигура, созданная на основании заданного текста</returns>
        public Geometry GetGeometryFromText(string text, int x, bool isUp)
        {
#pragma warning disable CS0618 // Для сокрытия предупреждения об устаревшем FormattedText
            FormattedText formattedText = new FormattedText
            (
                text,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface("Arial"),
                _sizeFigures,
                (Brush)new BrushConverter().ConvertFrom("#F14C18")
            );
#pragma warning restore CS0618 // Для возобновления предупреждений об устаревших конструкциях

            return formattedText.BuildGeometry(new Point(x, GetCoordinateY(isUp) - _sizeFigures));
        }
    }
}