using System.Windows.Controls;
using System.Windows;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Markup;
using System;

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



        public object Value {
            get => GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(object), typeof(ToolGridItem), new PropertyMetadata(0));



    }

    [ContentProperty("Items")]
    [DefaultProperty("Items")]
    public partial class ToolGrid : UserControl
    {
        public ObservableCollection<ToolGridItem> Items => (ObservableCollection<ToolGridItem>)GetValue(ItemsProperty);

        public int Columns { get; } = 2;

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
            _ = gTools.Children.Add(CreateTool(item, toolsCount));
        }

        [Obsolete("Не имеет смысла")]
        public void ChangeTool(ToolGridItem newItem, int idx)
        {
            gTools.Children.RemoveAt(idx);
            gTools.Children.Insert(idx, CreateTool(newItem, idx));
        }

        private RadioButton CreateTool(ToolGridItem newItem, int idx)
        {
            RadioButton tool = new() {
                Content = newItem.Content
            };
            Grid.SetRow(tool, idx / Columns);
            Grid.SetColumn(tool, idx % Columns);
            return tool;
        }

        public ToolGrid()
        {
            InitializeComponent();

            for (int i = 0; i < Columns; i++)
            {
                gTools.ColumnDefinitions.Add(new ColumnDefinition());
            }

            Debug.Assert(Items is not null);
            Items.CollectionChanged += (sender, e) => {
                foreach (ToolGridItem item in e.NewItems)
                {
                    Debug.Assert(item is not null);
                    AddTool(item);
                }
            };
        }
    }
}
