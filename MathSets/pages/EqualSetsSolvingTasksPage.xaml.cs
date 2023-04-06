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
using static System.Net.Mime.MediaTypeNames;

namespace MathSets.pages
{
    /// <summary>
    /// Логика взаимодействия для EqualSetsSolvingTasksPage.xaml
    /// </summary>
    public partial class EqualSetsSolvingTasksPage : Page
    {
        public EqualSetsSolvingTasksPage()
        {
            InitializeComponent();
            ShowFigures(CreateFigures(), cnvFigure);
            ShowFigures(CreateFigures(), cnvFigureTwo);
            ShowRandomSign();
        }

        /// <summary>
        /// Метод два вывода рандомного знака
        /// </summary>
        private void ShowRandomSign()
        {
            Random random = new Random();
            int rnd = random.Next(2);
            if(rnd == 0)
            {
                TextSign.Text = "=";
            }
            else if(rnd == 1)
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

        }

        private void BtnHint_Click(object sender, RoutedEventArgs e)
        {
            windows.HintEqualSetsWindow hint = new windows.HintEqualSetsWindow();
            hint.ShowDialog();
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
                
                //ellipse.Fill = Brushes.Yellow;
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
    }
}
