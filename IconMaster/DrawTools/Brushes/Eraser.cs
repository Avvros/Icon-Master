using System.Windows.Media;
using System.Windows.Media.Imaging;
using DrawingContext = IconMaster.Core.DrawingContext;

namespace IconMaster.DrawTools.Brushes
{
    public class Eraser : IBrush
    {
        public void Draw(DrawingContext context, int x, int y)
        {
            context.Bitmap.SetPixel(x, y, Colors.Transparent);
        }
    }
}
