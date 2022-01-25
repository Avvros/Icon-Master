using System.Windows.Media;
using System.Windows.Media.Imaging;
using DrawingContext = IconMaster.Core.DrawingContext;

namespace IconMaster.DrawTools.Brushes
{
    public class Eraser : Tool
    {
        public Eraser(DrawingContext context) : base(context)
        {
        }

        public override void Draw(int x, int y)
        {
            Context.Bitmap.SetPixel(x, y, Colors.Transparent);
        }
    }
}
