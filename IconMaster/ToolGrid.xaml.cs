using System.Windows.Controls;
using System.Windows;
using System.Diagnostics;
using System.ComponentModel;

namespace IconMaster
{

    /// <summary>
    /// Логика взаимодействия для ToolGrid.xaml
    /// </summary>

    public class ToolGridItem : DependencyObject
    {
        [Bindable(true)]
        public object Content {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        // Using a DependencyProperty as the backing store for Content.  This enables animation, styling, binding, etc...
        public readonly static DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(ToolGridItem), new PropertyMetadata(0));

    }

    public partial class ToolGrid : ItemsControl
    {

        public readonly int Columns = 2;
        public readonly int Rows = 1;

        public void AddTool(UIElement element)
        {
            if (gTools.Children.Count % Columns == 0)
            {
                gTools.RowDefinitions.Add(new RowDefinition());
            }
            _ = gTools.Children.Add(element);
        }

        public ToolGrid()
        {
            InitializeComponent();

            gTools.ColumnDefinitions.Add(new ColumnDefinition());
            gTools.ColumnDefinitions.Add(new ColumnDefinition());

            gTools.RowDefinitions.Add(new RowDefinition());
            Debug.WriteLine(Items.Count);
        }
    }
}
