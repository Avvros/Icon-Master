using System;
using System.Collections.Generic;
using System.Windows;

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

        private void Exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
