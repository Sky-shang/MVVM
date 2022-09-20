using System;
using System.Windows.Input;

namespace MVVMToolkit_Sample.Common
{
    public class DelegateCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;
        public event EventHandler CanExecuteChanged;
        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        { }
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            if (execute == null) throw new ArgumentNullException(nameof(execute));

            _execute = execute;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            _execute?.Invoke(parameter);
        }
    }
}
