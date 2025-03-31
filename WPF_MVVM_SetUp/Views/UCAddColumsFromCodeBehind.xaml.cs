using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPF_Data_Grid.ViewModels;

namespace WPF_Data_Grid.Views
{
    /// <summary>
    /// Interaction logic for UCAddColumsFromCodeBehind.xaml
    /// </summary>
    public partial class UCAddColumsFromCodeBehind : UserControl
    {
        private List<string> ColumnNames = new List<string> { "Column1", "Column2", "Column3" }; // Text columns
        private string ComboBoxColumnName = "Options";
        public UCAddColumsFromCodeBehind()
        {
            InitializeComponent();
            DataContext = ColumnItemsourceVM.Instance;
            dataGrid.ItemsSource = ColumnItemsourceVM.LoadDataGrid();
            CreateDataGrid();
        }
        private void CreateDataGrid()
        {
            // Create text columns dynamically
            for (int i = 0; i < ColumnNames.Count; i++)
            {
                int columnIndex = i; // Capture index for lambda
                dataGrid.Columns.Add(new DataGridTextColumn
                {
                    Header = ColumnNames[i],
                    Binding = new Binding($"Values[{columnIndex}]")
                });
            }

            // Create ComboBox column dynamically
            DataGridComboBoxColumn comboBoxColumn = new DataGridComboBoxColumn
            {
                Header = ComboBoxColumnName,
                SelectedItemBinding = new Binding("SelectedItem") { Mode = BindingMode.TwoWay },
            };
            // Correct way to bind ItemsSource
            comboBoxColumn.ElementStyle = new Style(typeof(ComboBox))
            {
                Setters = { new Setter(ComboBox.ItemsSourceProperty, new Binding("ComboBoxOptions")) }
            };

            comboBoxColumn.EditingElementStyle = new Style(typeof(ComboBox))
            {
                Setters = { new Setter(ComboBox.ItemsSourceProperty, new Binding("ComboBoxOptions")) }
            };
            dataGrid.Columns.Add(comboBoxColumn);
        }
    }
}
