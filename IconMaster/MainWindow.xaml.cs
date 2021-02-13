using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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

        private void Workspace_Initialized(object sender, EventArgs e)
        {
            
        }
    }
}
