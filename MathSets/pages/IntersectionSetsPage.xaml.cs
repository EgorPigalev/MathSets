﻿using System;
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
    /// Логика взаимодействия для IntersectionSetsPage.xaml
    /// </summary>
    public partial class IntersectionSetsPage : Page
    {
        public IntersectionSetsPage()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new MainMenuPage());
        }

        private void BtnSolvingTasks_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new IntersectionSetsSolvingTasksPage());
        }

        private void BtnSavedTasks_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new IntersectionSetsSavedTasksPage());
        }
    }
}