using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace IconMaster
{
    /// <summary>
    /// Логика взаимодействия для EditorPage.xaml
    /// </summary>
    public partial class EditorPage : UserControl
    {
        public EditorPage()
        {
            InitializeComponent();
        }

        private Point OnDrawingAction(MouseEventArgs e)
        {
            Point position = Workspace.GetRelativeMousePosition(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Workspace.DrawPixel((int)position.X, (int)position.Y, Colors.Black);
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                Workspace.DrawPixel((int)position.X, (int)position.Y, Colors.Transparent);
            }
            return position;
        }

        private void Workspace_MouseMove(object sender, MouseEventArgs e)
        {
            Point position = OnDrawingAction(e);
            tbCoords.Text = $"{(int)position.X}; {(int)position.Y}";
        }

        private void Workspace_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OnDrawingAction(e);
        }
    }
}
