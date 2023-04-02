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

namespace MathSets
{
    /// <summary>
    /// Логика взаимодействия для IntersectionSetsSolvingTasksPage.xaml
    /// </summary>
    public partial class IntersectionSetsSolvingTasksPage : Page
    {
        public IntersectionSetsSolvingTasksPage()
        {
            InitializeComponent();
            NewTasks();
        }

        private void NewTasks()
        {
            int n = 1; // Номер задания
            Grid grid = new Grid(); // Добавления grid для вывода формулировки задания
            ColumnDefinition oneColumn = new ColumnDefinition();
            ColumnDefinition twoColumn = new ColumnDefinition();
            twoColumn.Width = new GridLength(100);
            grid.ColumnDefinitions.Add(oneColumn);
            grid.ColumnDefinitions.Add(twoColumn);
            TextBlock taskStatement = new TextBlock()
            {
                Text = n + ") На каждом рисунке закрась пересечение множеств A и B (если пересечение отсутствует, то ничего закрашивать не нужно).",
                TextWrapping = TextWrapping.Wrap,
            };
            SpTasks.Children.Add(grid);
            grid.Children.Add(taskStatement);
            Grid.SetColumn(taskStatement, 0);
            Button BtnHint = new Button()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Content = "?",
            };
            BtnHint.Click += BtnHint_Click;
            Grid.SetColumn(BtnHint, 1);
            grid.Children.Add(BtnHint);
            WrapPanel wrapPanel = new WrapPanel()
            {
                Name = "WP",
            };
            SpTasks.Children.Add(wrapPanel);
            Random random = new Random();
            for(int i = 0; i < 4; i++)
            {
                Canvas canvas = new Canvas()
                {
                    Width = 350,
                    Height = 250,
                };
                wrapPanel.Children.Add(canvas);
                Label label = new Label()
                {
                    Content = (Char)(65 + i) + ")",
                };
                canvas.Children.Add(label);
                int x = random.Next(40, 100);
                int y = random.Next(0, 50);
                Ellipse ellipse = new Ellipse();
                ellipse.Width = random.Next(50, 200);
                ellipse.Height = random.Next(50, 200);
                ellipse.Stroke = Brushes.Black;
                ellipse.StrokeThickness = 2;
                ellipse.Margin = new Thickness(x, y, 0, 0);
                ellipse.Fill = Brushes.White;
                ellipse.MouseDown += ellipse_MouseDown;
                canvas.Children.Add(ellipse);
                int x1 = random.Next(40, 100);
                int y1 = random.Next(0, 50);
                Ellipse ellipse1 = new Ellipse();
                ellipse1.Width = random.Next(100, 200);
                ellipse1.Height = random.Next(100, 200);
                ellipse1.Stroke = Brushes.Black;
                ellipse1.StrokeThickness = 2;
                ellipse1.Margin = new Thickness(x1, y1, 0, 0);
                ellipse1.Fill = Brushes.White;
                ellipse1.MouseDown += ellipse_MouseDown;
                canvas.Children.Add(ellipse1);
                EllipseGeometry pathGeometryOne = new EllipseGeometry()
                {
                    RadiusX = ellipse.Width / 2,
                    RadiusY = ellipse.Height / 2,
                    Center = new Point(x + (ellipse.Width / 2), y + (ellipse.Height / 2)),
                };
                EllipseGeometry pathGeometryTwo = new EllipseGeometry()
                {
                    RadiusX = ellipse1.Width / 2,
                    RadiusY = ellipse1.Height / 2,
                    Center = new Point(x1 + (ellipse1.Width / 2), y1 + (ellipse1.Height / 2)),
                };
                CombinedGeometry combinedGeometry = new CombinedGeometry(GeometryCombineMode.Intersect, pathGeometryOne, pathGeometryTwo);
                Path combinedPath = new Path();
                combinedPath.Data = combinedGeometry;
                combinedPath.Fill = Brushes.White;
                combinedPath.Stroke = Brushes.Black;
                combinedPath.StrokeThickness = 2;
                combinedPath.MouseDown += ellipse_MouseDown;
                canvas.Children.Add(combinedPath);
            }
            Button BtnResult = new Button()
            {
                Content = "Проверить",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            BtnResult.Click += BtnResult_Click;
            SpTasks.Children.Add(BtnResult);

        }

        private void ellipse_MouseDown(object sender, MouseButtonEventArgs e)
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
            FrameClass.mainFrame.Navigate(new IntersectionSetsPage());
        }

        private void BtnHint_Click(object sender, RoutedEventArgs e)
        {
            HintIntersectionSetsWindow hint = new HintIntersectionSetsWindow();
            hint.ShowDialog();
        }

        private void BtnResult_Click(object sender, RoutedEventArgs e)
        {
            WrapPanel wrapPanel = (WrapPanel)SpTasks.Children[1];
            for (int i = 0; i < wrapPanel.Children.Count; i++)
            {
                Canvas canvas = (Canvas)wrapPanel.Children[i];
            }
            MessageBox.Show("Результат верный");
        }
    }
}
