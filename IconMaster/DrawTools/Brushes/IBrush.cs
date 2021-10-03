using IconMaster.Core;

namespace IconMaster.DrawTools.Brushes
{
    public interface IBrush
    {
        void Draw(DrawingContext context, int x, int y);
    }

}
