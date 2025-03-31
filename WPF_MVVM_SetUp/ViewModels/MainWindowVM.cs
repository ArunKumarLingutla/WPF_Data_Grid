using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPF_Data_Grid.Base;
using WPF_Data_Grid.Views;

namespace WPF_Data_Grid.ViewModels
{
    public class MainWindowVM:ObservableObject
    {
        private static MainWindowVM _instance;
        public static MainWindowVM Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MainWindowVM();
                }
                return _instance;
            }
        }
        private UserControl _currentPanel;

        public UserControl CurrentPanel
        {
            get { return _currentPanel; }
            set { _currentPanel = value;OnPropertyChanged(); }
        }

        private UserControl _columnItemSource;
        public UserControl ColumnItemSource
        {
            get { return _columnItemSource; }
            set { _columnItemSource = value; OnPropertyChanged(); }
        }

        public RelayCommand CMDColumnItemSource { get; }
        public RelayCommand CMDAddColumsCodeBehind { get; }
        private void ColumnItemsource(object parm)
        {
            CurrentPanel = new UCColumnItemsource();
        }
        private void AddColumnsCodeBehind(object parm)
        {
            CurrentPanel = new UCAddColumsFromCodeBehind();
        }

        public MainWindowVM()
        {
            CMDColumnItemSource = new RelayCommand(ColumnItemsource);
            CMDAddColumsCodeBehind = new RelayCommand(AddColumnsCodeBehind);
        }
        
    }
}
