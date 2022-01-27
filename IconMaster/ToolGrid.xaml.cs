using System.Windows.Controls;
using System.Windows;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Markup;

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

    [ContentProperty("Items")]
    [DefaultProperty("Items")]
    public partial class ToolGrid : UserControl
    {

        public readonly int Columns = 2;

        public ObservableCollection<ToolGridItem> Items => (ObservableCollection<ToolGridItem>)GetValue(ItemsProperty);

        //public ObservableCollection<ToolGridItem> Items {
        //    get => (ObservableCollection<ToolGridItem>)GetValue(ItemsProperty);
        //    //set => SetValue(ItemsProperty, value);
        //}

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public readonly static DependencyProperty ItemsProperty =
            DependencyProperty.Register(
                "MyProperty",
                typeof(ObservableCollection<ToolGridItem>),
                typeof(ToolGrid),
                new PropertyMetadata(new ObservableCollection<ToolGridItem>())
            );

        public void AddTool(ToolGridItem item)
        {
            int toolsCount = gTools.Children.Count;
            if (toolsCount % Columns == 0)
            {
                gTools.RowDefinitions.Add(new RowDefinition());
            }
            RadioButton tool = new RadioButton {
                Content = item.Content
            };
            Grid.SetRow(tool, toolsCount / Columns);
            Grid.SetColumn(tool, toolsCount % Columns);
            _ = gTools.Children.Add(tool);
        }

        public ToolGrid()
        {
            InitializeComponent();

            for (int i = 0; i < Columns; i++)
            {
                gTools.ColumnDefinitions.Add(new ColumnDefinition());
            }

            //if (Items != null)
            //{
            //    Items.CollectionChanged += (sender, e) => {
            //        foreach (ToolGridItem item in e.NewItems)
            //        {
            //            AddTool(item);
            //        }
            //    };
            //}
            //else
            //{
            //    Debug.WriteLine("Assertion failed");
            //}
        }
    }
}
