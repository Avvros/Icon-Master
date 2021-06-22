using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IconMaster.DrawTools.Brushes
{
    class Pen : Brush
    {
        public Pen(WriteableBitmap bitmap, int bitmapWidth, int bitmapHeight) : base(bitmap, bitmapWidth, bitmapHeight)
        {
            Color = Colors.Black;
        }

        protected override void DrawInternal(int x, int y)
        {
            bitmap.SetPixel(x, y, Color);
        }
    }
}
