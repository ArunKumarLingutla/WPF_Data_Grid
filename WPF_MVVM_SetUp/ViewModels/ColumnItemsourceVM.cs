using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WPF_Data_Grid.Base;
using WPF_Data_Grid.Models;

namespace WPF_Data_Grid.ViewModels
{
    public class ColumnItemsourceVM:ObservableObject
    {
        private static ColumnItemsourceVM _instance;
        public static ColumnItemsourceVM Instance
        {
            get 
            {
                if (_instance == null)
                {
                    _instance = new ColumnItemsourceVM();
                }
                return _instance;
            }
        }

        public static ObservableCollection<Data> LoadDataGrid()
        {
            List<List<object>> list = new List<List<object>>    //Delete after feeding original list
            {
            new List<object>{"1","1","1",new List<string> { "p1","p2","p3"} },
            new List<object>{"2","2","2",new List<string> { "p1","p2","p3"}},
            new List<object>{"3","3","3",new List<string> { "p1","p2","p3"}},
            };

            ObservableCollection<Data> ColumnData = new ObservableCollection<Data>();
            //Getting each item from the list of list Globals.UpdateExternalReferenceList and storing each list as an object
            foreach (var item in list)
            {
                ColumnData.Add(new Data
                {
                    Column1 = item.FirstOrDefault(),
                    Column2 = item[1],
                    Column3 = item[2],
                    SelectedItem = ((List<string>)item[3]).FirstOrDefault().ToString(),
                    ComboBoxOptions = (List<string>)item[3],
                });
            }
            return ColumnData;
        }

        public ColumnItemsourceVM()
        {

        }
    }
}
