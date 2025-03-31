using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_Data_Grid.Base
{
    public class RelayCommand : ICommand
    {
        //_execute: A method (delegate) that is executed when the command runs.
        private readonly Action<object> _execute;

        //_canExecute: A method that determines if the command can be executed (optional).
        private readonly Predicate<object> _canExecute;

        //CanExecuteChanged is triggered when the UI needs to check if the command can execute.
        public event EventHandler CanExecuteChanged
        {
            //CommandManager.RequerySuggested ensures that UI elements (like buttons) update their enabled/disabled state.
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            //execute: The method to run when the command executes.
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));

            //canExecute: The method to determine if execution is allowed (optional).
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        //Calls the _execute method when the command is triggered.
        public void Execute(object parameter) => _execute(parameter);
    }

    //Use case 1 (Recomended)
    /*
    public class MyViewModel : ObservableObject
    {
        public RelayCommand ClickCommand { get; }

        public MyViewModel()
        {
            ClickCommand = new RelayCommand(ExecuteClick, CanExecuteClick);
        }

        private void ExecuteClick(object parameter)
        {
            // Action to perform when the button is clicked
            //Cast the input parameters if there is any parameter
            if (parameter is Tuple<string, int, bool> values)
            {
                string text = values.Item1;
                int number = values.Item2;
                bool flag = values.Item3;

                Console.WriteLine($"Text: {text}, Number: {number}, Flag: {flag}");
            }
        }

        private bool CanExecuteClick(object parameter)
        {
            return true; // Return false to disable the button
        }
    } 
    */
}
