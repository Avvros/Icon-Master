using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace IconMaster
{
    public class IMWorkspace : Panel
    {
        protected override void OnRender(DrawingContext dc)
        {
            SolidColorBrush mySolidColorBrush = new SolidColorBrush
            {
                Color = Color.FromRgb(224, 224, 224)
            };
            Pen myPen = new Pen(Brushes.Gray, 2);
            Rect myRect = new Rect(0, 0, 100, 100);
            dc.DrawRectangle(mySolidColorBrush, myPen, myRect);
        }
    }
}
