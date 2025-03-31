using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Data_Grid.ViewModels;

namespace WPF_Data_Grid.Views
{
    /// <summary>
    /// Interaction logic for UCColumnItemsource.xaml
    /// </summary>
    public partial class UCColumnItemsource : UserControl
    {
        public UCColumnItemsource()
        {
            InitializeComponent();
            DataContext = ColumnItemsourceVM.Instance;
            DataGrid1.ItemsSource=ColumnItemsourceVM.LoadDataGrid();
        }
    }
}
