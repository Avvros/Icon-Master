using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IconMaster.DrawTools.Brushes
{
    class Eraser : Brush
    {
        public Eraser(WriteableBitmap bitmap, int bitmapWidth, int bitmapHeight) : base(bitmap, bitmapWidth, bitmapHeight)
        {
        }

        protected override void DrawInternal(int x, int y)
        {
            bitmap.SetPixel(x, y, Colors.Transparent);
        }
    }
}
