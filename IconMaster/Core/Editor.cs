using System;
using System.Windows.Media.Imaging;

namespace IconMaster.Core
{
    public class Editor
    {

        public DrawingContext DrawingContext { get; }

        public Editor()
        {
            DrawingContext = new DrawingContext(EditorGrid.DEFAULT_BITMAP());
        }

        public Editor(WriteableBitmap bitmap)
        {
            if (bitmap == null)
            {
                throw new ArgumentNullException("Bitmap can't be null");
            }
            DrawingContext = new DrawingContext(bitmap);
        }

        public override string ToString()
        {
            return $"Editor {{ DrawingContext = {DrawingContext} }}";
        }
    }

}
