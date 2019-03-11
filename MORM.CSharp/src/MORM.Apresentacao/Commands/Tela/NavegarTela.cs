using System.Windows.Input;

namespace MORM.Apresentacao.Commands.Tela
{
    public class NavegarAnterior : AbstractTelaCommand
    {
        public override void Execute(object parameter)
        {
            MoveFocus(parameter, FocusNavigationDirection.Previous);
        }
    }

    public class NavegarPrimeiro : AbstractTelaCommand
    {
        public override void Execute(object parameter)
        {
            MoveFocus(parameter, FocusNavigationDirection.First);
        }
    }

    public class NavegarProximo : AbstractTelaCommand
    {
        public override void Execute(object parameter)
        {
            MoveFocus(parameter, FocusNavigationDirection.Next);
        }
    }

    public class NavegarUltimo : AbstractTelaCommand
    {
        public override void Execute(object parameter)
        {
            MoveFocus(parameter, FocusNavigationDirection.Last);
        }
    }
}