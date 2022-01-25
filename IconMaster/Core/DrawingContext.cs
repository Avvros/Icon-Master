using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using IconMaster.DrawTools;
using IconMaster.DrawTools.Brushes;
using Color = System.Windows.Media.Color;

namespace IconMaster.Core
{
    public class DrawingContext
    {

        protected readonly WriteableBitmap _bitmap;
        private Color _color;

        public override string ToString()
        {
            return $"{nameof(DrawingContext)} {{ Bitmap = {_bitmap}, Color = {_color} }}";
        }

        public DrawingContext(WriteableBitmap bitmap)
        {
            _bitmap = bitmap ?? throw new ArgumentNullException("Bitmap can't be null");
            _color = Colors.Black;
        }

        public Color Color { get => _color; set => _color = value != null ? value : Colors.Black; }
        public WriteableBitmap Bitmap => _bitmap;

        public void Draw(Tool brush, int x, int y)
        {
            if (brush == null || x < 0 || y >= _bitmap.PixelWidth || y < 0 || y >= _bitmap.PixelHeight)
            {
                return;
            }

            brush.Draw(x, y);

        }
    }
}
