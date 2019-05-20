using System;
using System.Windows.Input;

namespace C4TestTask
{
    /// <summary>
    /// Добавляет возможность использования команд,реалезуем интерфейc IComand
    /// </summary>
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged //вызывается при изменении условий, указывает, может ли команда выполнятся
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter); //определяет, может ли команда выполняться  
        }

        public void Execute(object parameter)
        {
            execute(parameter);// выполняет логику команды
        }
    }
}