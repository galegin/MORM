using System.Windows;
using System.Windows.Input;

namespace MORM.Apresentacao.Commands
{
    public abstract class AbstractTelaCommand : AbstractCommand
    {
        protected void CloseWindow(object parameter)
        {
            if (parameter is Window)
                (parameter as Window).Close();
        }

        protected void MoveFocus(object parameter, FocusNavigationDirection direction)
        {
            if (parameter is Window)
                (parameter as Window).MoveFocus(new TraversalRequest(direction));
        }
    }
}