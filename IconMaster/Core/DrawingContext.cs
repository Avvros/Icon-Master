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
        private Color _color;

        public override string ToString()
        {
            return $"{nameof(DrawingContext)} {{ Bitmap = {Bitmap}, Color = {_color} }}";
        }

        public DrawingContext(WriteableBitmap bitmap)
        {
            Bitmap = bitmap ?? throw new ArgumentNullException(nameof(bitmap));
            _color = Colors.Black;
        }

        public Color Color { get => _color; set => _color = value; }
        public WriteableBitmap Bitmap { get; }

        public void Draw(Tool brush, int x, int y)
        {
            if (brush == null || x < 0 || y >= Bitmap.PixelWidth || y < 0 || y >= Bitmap.PixelHeight)
            {
                return;
            }

            brush.Draw(x, y);

        }
    }
}
