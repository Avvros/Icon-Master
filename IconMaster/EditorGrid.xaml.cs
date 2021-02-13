using System.Windows;
using System.Windows.Controls;
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

        public EditorGrid()
        {
            InitializeComponent();

            int width = 300;
            int height = 300;

            // Create a writeable bitmap (which is a valid WPF Image Source)
            data = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgra32, null);

            // Create an array of pixels to contain pixel color values
            uint[] pixels = new uint[width * height];

            int red;
            int green;
            int blue;
            int alpha;

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    int i = width * y + x;

                    red = 0;
                    green = 255 * y / height;
                    blue = 255 * (width - x) / width;
                    alpha = 255;

                    pixels[i] = (uint)((blue << 24) + (green << 16) + (red << 8) + alpha);
                }
            }

            // apply pixels to bitmap
            data.WritePixels(new Int32Rect(0, 0, 300, 300), pixels, width * 4, 0);

            // set image source to the new bitmap
            presenter.Source = data;
        }
    }
}
