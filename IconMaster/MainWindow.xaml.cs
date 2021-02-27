using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace IconMaster
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog op = new OpenFileDialog
            //{
            //    Title = "Select a picture",
            //    Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
            //  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
            //  "Portable Network Graphic (*.png)|*.png"
            //};
            //if (op.ShowDialog() == true)
            //{
            //   // Image Viewer = FindName("Viewer") as Image;
            //    Viewer.Source = new BitmapImage(new Uri(op.FileName));
            //}
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void EditorGrid_MouseMove(object sender, MouseEventArgs e)
        {
            Point position = e.GetPosition(Workspace);
            tbCoords.Text = ((int)position.X).ToString() + "; " + ((int) position.Y).ToString();
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Workspace.DrawPixel((int) position.X, (int) position.Y, Colors.Black);
            }
        }
    }
}
