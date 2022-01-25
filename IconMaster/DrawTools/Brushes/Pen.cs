using System.Windows.Media.Imaging;
using IconMaster.Core;

namespace IconMaster.DrawTools.Brushes
{
    public class Pen : Tool
    {
        public Pen(DrawingContext context) : base(context)
        {
        }

        public override void Draw(int x, int y)
        {
            Context.Bitmap.SetPixel(x, y, Context.Color);
        }
    }
}
