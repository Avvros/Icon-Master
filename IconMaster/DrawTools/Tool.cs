using IconMaster.Core;

namespace IconMaster.DrawTools
{

    public abstract class Tool
    {

        public readonly DrawingContext Context;

        public Tool(DrawingContext context)
        {
            Context = context;
        }

        public abstract void Draw(int x, int y);

    }

}
