using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace IconMaster
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<EditorPage> EditorPages { get; }

        public MainWindow()
        {
            EditorPages = new List<EditorPage>() {
                new EditorPage() {
                    Header = "Новая иконка 1"
                }
            };
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

        private void SaveFile(object sender, RoutedEventArgs e)
        {
            SaveFileDialog op = new() {
                Title = "Save a picture",
                Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png"
            };
            if (op.ShowDialog() == true)
            {
                // Image Viewer = FindName("Viewer") as Image;
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(EditorPages[0].Editor.Bitmap));

                using System.IO.FileStream fileStream = new(op.FileName, System.IO.FileMode.Create);
                encoder.Save(fileStream);
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
