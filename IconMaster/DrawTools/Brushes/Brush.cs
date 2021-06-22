using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IconMaster.DrawTools.Brushes
{
    public abstract class Brush
    {

        protected readonly int bitmapWidth, bitmapHeight;
        protected readonly WriteableBitmap bitmap;
        private Color _color;

        public Brush(WriteableBitmap bitmap, int bitmapWidth, int bitmapHeight)
        {
            this.bitmap = bitmap ?? throw new ArgumentNullException("Bitmap can't be null");
            if (bitmapWidth <= 0 || bitmapHeight <= 0) throw new ArgumentOutOfRangeException("Dimensions must be positive");
            this.bitmapWidth = bitmapWidth;
            this.bitmapHeight = bitmapHeight;
            _color = Colors.Transparent;
        }

        public Color Color { get => _color; set => _color = value != null ? value : Colors.Transparent; }

        public void Draw(int x, int y)
        {
            if (x < 0 || y >= bitmapWidth || y < 0 || y >= bitmapHeight) return;
            DrawInternal(x, y);
        }

        protected abstract void DrawInternal(int x, int y);

    }
}
