using MORM.CrossCutting;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace MORM.Apresentacao
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

    public static class AbstractCommandExtension
    {
        public static void ExecuteCommand(this ICommand command, object parameter)
        {
            if (command.CanExecute(parameter))
                command.Execute(parameter);
        }

        public static string GetDescription(this ICommand command)
        {
            return command.GetType().GetAttributeType<DescriptionAttribute>().Description;
        }

        public static string GetNameButton(this ICommand command)
        {
            return $"Button{command.GetType().Name.Replace("`1", "")}";
        }
    }
}