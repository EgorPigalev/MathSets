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
    /// Логика взаимодействия для LessonFourAndFive.xaml
    /// </summary>
    public partial class LessonFourAndFive : Page
    {
        private List<KeyFigure> _answers = new List<KeyFigure>();
        private List<KeyFigure> _figures;

        public LessonFourAndFive()
        {
            InitializeComponent();

            ShowExerciseFirst();
            ShowExerciseSecond();
            ShowExerciseThree();
        }

        /// <summary>
        /// Отображает на экране первое упражнение.
        /// </summary>
        private void ShowExerciseFirst()
        {
            ShowFigures(CreateAnswersQuestionFirst(), SpFigures);
            ShowFigures(CreateFiguresQuestionFirst(), CnvQuestionFirst);
        }

        /// <summary>
        /// Добавляет созданные фигуры в контейнер
        /// </summary>
        /// <param name="figures">коллекция фигур</param>
        /// <param name="panel">контейнер</param>
        private void ShowFigures(List<Geometry> figures, Panel panel)
        {
            panel.Children.Clear();

            foreach (Geometry item in figures)
            {
                panel.Children.Add(new Path()
                {
                    StrokeThickness = 3,
                    Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18"),
                    Data = item
                });
            }
        }

        /// <summary>
        /// Генерирует ответы (3 фигуры) для первого вопроса
        /// </summary>
        /// <returns>Список структур, представляющий из себя пару: ключ - фигура, где ключ - целочисленный индекс из первоначального списка методов</returns>
        private List<Geometry> CreateAnswersQuestionFirst()
        {
            int sizeFigures = (int)TbQuestionFirst.FontSize;
            Figure figures = new Figure(sizeFigures, (sizeFigures + 2) * 2, SpFigures.Width);
            List<CreateFiguresDelegate> createFiguresMethods = figures.GetAllCreateFiguresMethods();
            List<KeyFigure> tempKeys = Figure.ShuffleMethods(createFiguresMethods);

            _answers.Clear();
            for (int i = 0; i < 3; i++)
            {
                _answers.Add(tempKeys[i]);
            }

            List<Geometry> listFigures = new List<Geometry>();
            int x = 10;

            for (int i = 0; i < 3; i++)
            {
                listFigures.Add(_answers[i].Method(x, true));
            }

            SpFigures.Width = listFigures.Count * sizeFigures + (listFigures.Count + 2) * x;

            return listFigures;
        }

        /// <summary>
        /// Генерирует фигуры.
        /// </summary>
        /// <returns>Коллекция фигур</returns>
        private List<Geometry> CreateFiguresQuestionFirst()
        {
            int sizeFigures = 40;
            Figure figures = new Figure(sizeFigures, CnvQuestionFirst.Height, CnvQuestionFirst.Width / 2);
            List<CreateFiguresDelegate> createFiguresMethods = figures.GetAllCreateFiguresMethods();
            _figures = Figure.ShuffleMethods(createFiguresMethods);

            List<Geometry> listFigures = new List<Geometry>();
            int offset = figures.GetOffset(createFiguresMethods.Count);
            int x = 0;

            for (int i = 0; i < createFiguresMethods.Count; i++)
            { 
                if (i % 2 == 0)
                {
                    listFigures.Add(createFiguresMethods[i](x, true)); // Положение фигуры по вертикали вверху.
                }
                else
                {
                    listFigures.Add(createFiguresMethods[i](x, false)); // Положение фигуры по вертикали внизу.
                    x += offset;
                }
            }

            return listFigures;
        }

































        private void ShowExerciseSecond()
        {

        }

        private void ShowExerciseThree()
        {

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new MainMenuPage());
        }
    }
}