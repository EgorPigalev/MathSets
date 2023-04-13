using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MathSets.pages
{
    /// <summary>
    /// Логика взаимодействия для LessonSix.xaml
    /// </summary>
    public partial class LessonSix : Page
    {
        private Random _random = new Random();

        public LessonSix()
        {
            InitializeComponent();

            ShowTaskFirst();
        }

        private void ShowTaskFirst()
        {
            GridTaskFirst.Children.Clear();
            GridTaskFirst.ColumnDefinitions.Clear();
            GridTaskFirst.RowDefinitions.Clear();

            int countGridDefinitions = 2;
            int minSize = 50;
            List<Geometry> figures = CreateFiguresTastFirst(countGridDefinitions, minSize);
            Figure.ShowFigures(figures, GridTaskFirst);

            SetGridDefinitionsTaskFirst(countGridDefinitions);
        }

        private List<Geometry> CreateFiguresTastFirst(int countDefinitions, int minSize)
        {
            List<Geometry> figures = new List<Geometry>();

            while (true)
            {
                figures.Clear();

                Point sizeContainer = new Point(GridTaskFirst.Width / countDefinitions, GridTaskFirst.Height / countDefinitions - 60); // -60, чтобы кнопки снизу уместились.
                Point maxSize = new Point(sizeContainer.X / 2, sizeContainer.Y / 2);

                for (int i = 0; i < countDefinitions * 2; i++)
                {
                    figures.Add(CreateEllipse(sizeContainer, sizeContainer, minSize * 2));
                    figures.Add(CreateEllipse(sizeContainer, maxSize, minSize));
                }

                if (CheckContains(figures))
                {
                    break;
                }
            }

            return figures;
        }

        /// <summary>
        /// Создаёт эллипс
        /// </summary>
        /// <param name="maxWidth">максимальная ширина</param>
        /// <param name="maxHeight">максимальная высота</param>
        /// <param name="minSize">минимальный размер</param>
        /// <returns>Эллипс</returns>
        private Geometry CreateEllipse(Point sizeContainer, Point maxSize, int minSize)
        {
            int centerX = _random.Next(minSize, (int)sizeContainer.X - minSize);
            int centerY = _random.Next(minSize, (int)sizeContainer.Y - minSize);

            while (true)
            {
                EllipseGeometry g = new EllipseGeometry
                (
                    new Point
                    (
                        centerX,
                        centerY
                    ),
                    _random.Next(minSize, (int)maxSize.X) / 2 - Base.StrokeThickness * 2,
                    _random.Next(minSize, (int)maxSize.Y) / 2 - Base.StrokeThickness * 2
                );

                if (g.Center.X >= g.RadiusX && sizeContainer.X - g.Center.X >= g.RadiusX)
                {
                    if (g.Center.Y >= g.RadiusY && sizeContainer.Y - g.Center.Y >= g.RadiusY)
                    {
                        return g;
                    }
                }
            }
        }

        private bool CheckContains(List<Geometry> figures)
        {
            int countSets = figures.Count / 2;
            int countRightSets = 0;

            for (int i = 0; i < figures.Count; i += 2)
            {
                if (figures[i].FillContainsWithDetail(figures[i + 1]) == IntersectionDetail.Intersects)
                {
                    return false;
                }

                if (figures[i].FillContainsWithDetail(figures[i + 1]) == IntersectionDetail.FullyContains ||
                    figures[i + 1].FillContainsWithDetail(figures[i]) == IntersectionDetail.FullyContains)
                {
                    countRightSets++;
                }
            }

            if (countRightSets >= countSets / 2 && countSets - countRightSets >= 1)
            {
                return true;
            }

            return false;
        }

        private void SetGridDefinitionsTaskFirst(int countDefinitions)
        {
            for (int i = 0; i < countDefinitions; i++)
            {
                GridTaskFirst.ColumnDefinitions.Add(new ColumnDefinition());
                GridTaskFirst.RowDefinitions.Add(new RowDefinition());
            }

            Grid.SetColumn(GridTaskFirst.Children[2], 1);
            Grid.SetColumn(GridTaskFirst.Children[3], 1);
            Grid.SetColumn(GridTaskFirst.Children[6], 1);
            Grid.SetColumn(GridTaskFirst.Children[7], 1);
            Grid.SetRow(GridTaskFirst.Children[4], 1);
            Grid.SetRow(GridTaskFirst.Children[5], 1);
            Grid.SetRow(GridTaskFirst.Children[6], 1);
            Grid.SetRow(GridTaskFirst.Children[7], 1);

            List<Border> borders = CreateBordersTaskFirst();
            foreach (Border item in borders)
            {
                GridTaskFirst.Children.Add(item);
            }

            Grid.SetColumn(borders[1], 1);
            Grid.SetColumn(borders[3], 1);
            Grid.SetRow(borders[2], 1);
            Grid.SetRow(borders[3], 1);

            List<StackPanel> buttons = CreateStackPanelsWithButtonsTaskFirst(countDefinitions * 2);
            foreach (StackPanel item in buttons)
            {
                GridTaskFirst.Children.Add(item);
            }

            Grid.SetColumn(buttons[1], 1);
            Grid.SetColumn(buttons[3], 1);
            Grid.SetRow(buttons[2], 1);
            Grid.SetRow(buttons[3], 1);
        }

        private List<Border> CreateBordersTaskFirst()
        {
            double thickness = Base.StrokeThickness / 2;

            return new List<Border>()
            {
                new Border()
                {
                   BorderBrush = Brushes.Black,
                   BorderThickness = new Thickness(0, 0, thickness, thickness)
                },
                new Border()
                {
                   BorderBrush = Brushes.Black,
                   BorderThickness = new Thickness(thickness, 0, 0, thickness)
                },
                new Border()
                {
                   BorderBrush = Brushes.Black,
                   BorderThickness = new Thickness(0, thickness, thickness, 0)
                },
                new Border()
                {
                   BorderBrush = Brushes.Black,
                   BorderThickness = new Thickness(thickness, thickness, 0, 0)
                }
            };
        }

        private List<StackPanel> CreateStackPanelsWithButtonsTaskFirst(int count)
        {
            List<StackPanel> list = new List<StackPanel>();

            for (int i = 0; i < count; i++)
            {
                StackPanel sp = new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(0, 0, 0, 10)
                };

                Button btnIsThere = new Button
                {
                    Content = "Есть",
                    Margin = new Thickness(0, 0, 10, 0),
                    Style = (Style)Application.Current.Resources["ButtonMainStyle"],
                    Uid = i.ToString()
                };
                Button btnNot = new Button
                {
                    Content = "Нет",
                    Style = (Style)Application.Current.Resources["ButtonMainStyle"],
                    Uid = i.ToString()
                };

                btnIsThere.Click += ButtonClickTaskFirst;
                btnNot.Click += ButtonClickTaskFirst;
                sp.Children.Add(btnIsThere);
                sp.Children.Add(btnNot);

                list.Add(sp);
            }

            return list;
        }

        private void ButtonClickTaskFirst(object sender, RoutedEventArgs e)
        {
            // Смотреть Uid и красить
            // (SolidColorBrush)Application.Current.Resources["SecondaryColor"]
            // (SolidColorBrush)Application.Current.Resources["ButtonPressedColor"]
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Base.MainFrame.Navigate(new MainMenuPage());
        }

        private void BtnCheckQuestionFirst_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCheckTaskFirst_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnHint_Click(object sender, RoutedEventArgs e)
        {

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
                    ShowTaskFirst();
                    break;
                case 2:
                    //ShowExerciseSecond();
                    break;
                case 3:
                    //ShowExerciseThree();
                    break;
                default:
                    break;
            }
        }
    }
}
