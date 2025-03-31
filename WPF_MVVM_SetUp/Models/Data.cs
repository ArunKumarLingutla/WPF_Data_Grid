using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Data_Grid.Base;

namespace WPF_Data_Grid.Models
{
    public class Data:ObservableObject
    {
        public object Column1 { get; set; }
        public object Column2 { get; set; }
        public object Column3 { get; set; }
        public object Column4 { get; set; }
        public object Column5 { get; set; }

        private string _selectedItem;
        public string SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; OnPropertyChanged(); }
        }
        public List<string> ComboBoxOptions { get; set; }
    }
}
