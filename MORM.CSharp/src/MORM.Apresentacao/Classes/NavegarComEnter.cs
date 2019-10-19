using System.Configuration;
using System.Windows;
using System.Windows.Input;

namespace MORM.Apresentacao
{
    public static class NavegacaoComEnter
    {
        private static bool _isNavegacaoComEnter = 
            (ConfigurationManager.AppSettings[nameof(_isNavegacaoComEnter)] ?? "true") == "true";

        public static void Ativar()
        {
            if (_isNavegacaoComEnter)
                EventManager.RegisterClassHandler(typeof(FrameworkElement), FrameworkElement.KeyDownEvent, new KeyEventHandler(FrameworkElement_KeyDown));
        }

        private static void FrameworkElement_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    NavegarElemento(sender, e);
                    break;
            }
        }

        private static void NavegarElemento(object sender, KeyEventArgs e)
        {
            var elemento = sender as FrameworkElement;
            if (elemento == null || elemento.IsIgnorarNavegacao())
                return;

            e.Handled = true;
            var focusDirection = e.Key == Key.Up ? FocusNavigationDirection.Previous : FocusNavigationDirection.Next;
            elemento.MoveFocus(new TraversalRequest(focusDirection));
        }

        public const string IgnorarNavegacao = "IgnorarNavegacao";

        private static bool IsIgnorarNavegacao(this FrameworkElement elemento)
        {
            return IgnorarNavegacao.Equals(elemento.Tag);
        }
    }
}