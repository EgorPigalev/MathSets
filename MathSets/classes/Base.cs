﻿using System.Windows.Controls;
using System.Windows.Media;

namespace MathSets
{
    public class Base
    {
        public static Frame MainFrame;
        public static int StrokeThickness = 2; // Толщина границ объектов.
        public static SolidColorBrush ColorDraggableElement = Brushes.Gray; // Цвет перемещаемых элементов.
        public static SolidColorBrush ColorFigures = (SolidColorBrush)new BrushConverter().ConvertFrom("#F14C18"); // Цвет фигур.
        public static string FontFamily = "Comic Sans MS";
    }
}