using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_MVVM_SetUp.Base
{

    public class ObservableObject : INotifyPropertyChanged
    {
        //This event is triggered whenever a property changes. WPF's data binding listens to this event to update the UI
        public event PropertyChangedEventHandler PropertyChanged;

        //This method raises the PropertyChanged event.
        //[CallerMemberName] automatically gets the name of the property that calls this method, so you don’t have to manually pass it.
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //This is a helper method to simplify property setters.It checks if the new value is different from the old value.
        //If the value changes, it updates the field and raises OnPropertyChanged
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }

    //Use case 1
    /* 
    private string _name;
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }
    */

    //**********************************************************

    //Use case 2
    /* 
    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }
    */
}
