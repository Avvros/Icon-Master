using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IconMaster
{

    /// <summary>
    /// Логика взаимодействия для EditorGrid.xaml
    /// </summary>
    public partial class EditorGrid : UserControl
    {

        private WriteableBitmap data;

        private int dataWidth, dataHeight;

        public EditorGrid()
        {
            InitializeComponent();

            dataWidth = 300;
            dataHeight = 300;

            // Create a writeable bitmap (which is a valid WPF Image Source)
            data = new WriteableBitmap(dataWidth, dataHeight, 96, 96, PixelFormats.Bgra32, null);

            // Create an array of pixels to contain pixel color values
            uint[] pixels = new uint[dataWidth * dataHeight];

            int red;
            int green;
            int blue;
            int alpha;

            for (int x = 0; x < dataWidth; ++x)
            {
                for (int y = 0; y < dataHeight; ++y)
                {
                    int i = dataWidth * y + x;

                    red = 0;
                    green = 255 * y / dataHeight;
                    blue = 255 * (dataWidth - x) / dataWidth;
                    alpha = 255;

                    pixels[i] = (uint)((blue << 24) + (green << 16) + (red << 8) + alpha);
                }
            }

            // apply pixels to bitmap
            data.WritePixels(new Int32Rect(0, 0, 300, 300), pixels, dataWidth * 4, 0);

            // set image source to the new bitmap
            Presenter.Source = data;
        }

        public void DrawPixel(int i, int j, Color color)
        {
            if (i < 0 || i >= dataWidth || j < 0 || j >= dataHeight || color == null) return;
            data.SetPixel(i, j, color);
        }

        public Point GetRelativeMousePosition(MouseEventArgs e)
        {
            Point p = e.GetPosition(this);
            double pixelWidth = Presenter.Source.Width;
            double pixelHeight = Presenter.Source.Height;
            double x = pixelWidth * p.X / Presenter.ActualWidth;
            double y = pixelHeight * p.Y / Presenter.ActualHeight;
            return new Point(x, y);
        }

    }
}
