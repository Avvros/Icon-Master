using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using IconMaster.Core;

namespace IconMaster
{

    /// <summary>
    /// Логика взаимодействия для EditorGrid.xaml
    /// </summary>
    public partial class EditorGrid : UserControl
    {

        public Point GetRelativeMousePosition(MouseEventArgs e)
        {
            Point p = e.GetPosition(this);
            double pixelWidth = Presenter.Source.Width;
            double pixelHeight = Presenter.Source.Height;
            double x = pixelWidth * p.X / Presenter.ActualWidth;
            double y = pixelHeight * p.Y / Presenter.ActualHeight;
            return new Point(x, y);
        }

    }
}
