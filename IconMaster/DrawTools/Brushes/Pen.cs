using System.Windows.Media.Imaging;
using IconMaster.Core;

namespace IconMaster.DrawTools.Brushes
{
    public class Pen : IBrush
    {
        public void Draw(DrawingContext context, int x, int y)
        {
            context.Bitmap.SetPixel(x, y, context.Color);
        }
    }
}
