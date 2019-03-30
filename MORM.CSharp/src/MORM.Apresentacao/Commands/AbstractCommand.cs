using System;
using System.Windows.Input;

namespace MORM.Apresentacao.Commands
{
    public abstract class AbstractCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public virtual bool CanExecute(object parameter) => true;
        public abstract void Execute(object parameter);

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}