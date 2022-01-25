using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using IconMaster.Core;

namespace IconMaster
{

    /// <summary>
    /// Логика взаимодействия для EditorGrid.xaml
    /// </summary>
    public partial class EditorGrid : UserControl
    {

        #region Constants

        public const int DEFAULT_SIZE = 300;

        public readonly static Func<WriteableBitmap> DEFAULT_BITMAP = () => new WriteableBitmap(DEFAULT_SIZE, DEFAULT_SIZE, 96, 96, PixelFormats.Bgra32, null);
        #endregion

        #region DrawingContext Property

        public Core.DrawingContext DrawingContext {
            get => (Core.DrawingContext)GetValue(DrawingContextProperty);
            set => SetValue(DrawingContextProperty, value);
        }

        // Using a DependencyProperty as the backing store for DrawingContext.  This enables animation, styling, binding, etc...
        public readonly static DependencyProperty DrawingContextProperty =
            DependencyProperty.Register("DrawingContext", typeof(Core.DrawingContext), typeof(EditorGrid), new PropertyMetadata(OnDrawingContextChanged));

        #endregion

        private static void OnDrawingContextChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            (obj as EditorGrid).Draw();
        }

        private void Draw()
        {
            WriteableBitmap bitmap = DrawingContext.Bitmap;

            // Create a writeable bitmap (which is a valid WPF Image Source)

            int _dataWidth = bitmap.PixelWidth;
            int _dataHeight = bitmap.PixelHeight;

            // Create an array of pixels to contain pixel color values
            uint[] pixels = new uint[_dataWidth * _dataHeight];

            int red;
            int green;
            int blue;
            int alpha;

            for (int x = 0; x < _dataWidth; ++x)
            {
                for (int y = 0; y < _dataHeight; ++y)
                {
                    int i = _dataWidth * y + x;

                    red = 0;
                    green = 255 * y / _dataHeight;
                    blue = 255 * (_dataWidth - x) / _dataWidth;
                    alpha = 255;

                    pixels[i] = (uint)((blue << 24) + (green << 16) + (red << 8) + alpha);
                }
            }

            // apply pixels to bitmap
            bitmap.WritePixels(new Int32Rect(0, 0, 300, 300), pixels, _dataWidth * 4, 0);

            // set image source to the new bitmap
            Presenter.Source = bitmap;
        }

        public EditorGrid()
        {
            InitializeComponent();
        }

        public void DrawPixel(int i, int j, Color color)
        {
            WriteableBitmap bitmap = DrawingContext.Bitmap;
            if (i < 0 || i >= bitmap.PixelWidth || j < 0 || j >= bitmap.PixelHeight || color == null)
            {
                return;
            }

            bitmap.SetPixel(i, j, color);
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
