using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IconMaster.Service
{
    public static class Presets
    {

        public const int DEFAULT_SIZE = 300;

        public static WriteableBitmap Default()
        {
            return new WriteableBitmap(DEFAULT_SIZE, DEFAULT_SIZE, 96, 96, PixelFormats.Bgra32, null);
        }
    }
}
