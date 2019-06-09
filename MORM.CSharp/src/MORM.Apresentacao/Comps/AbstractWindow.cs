using System;
using System.Windows;
using System.Windows.Input;

namespace MORM.Apresentacao.Comps
{
    public class AbstractWindow : Window, IAbstractWindow, IDisposable
    {
        #region variaveis
        private bool _isAltKey;
        private bool _isControlKey;
        private bool _isShiftKey;
        #endregion

        #region propriedades
        public bool IsPrincipal { get; set; }
        public virtual bool IsConfirmado { get; protected set; }
        #endregion

        #region construtores
        public AbstractWindow()
        {
            KeyDown += DefaultWindow_KeyDown;
            Loaded += (s, e) => MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            PreviewKeyDown += DefaultWindow_PreviewKeyDown;
            Closed += DefaultWindow_Closed;
        }
        #endregion

        #region metodos

        #region execute

        public virtual object Execute(object parameter)
        {
            if (PreConfirmado(parameter))
                return PosConfirmado(parameter);

            if (PreExecute(parameter))
            {
                ShowDialog();
                if (IsConfirmado)
                    return PosExecute(parameter);
            }

            return null;
        }

        protected virtual bool PreConfirmado(object parameter) => false;
        protected virtual object PosConfirmado(object parameter) => null;
        protected virtual bool PreExecute(object parameter) => true;
        protected virtual object PosExecute(object parameter) => null;

        #endregion

        #region fechar

        public void FecharTela()
        {
            if (IsPrincipal)
                Environment.Exit(0);
            else
                Close();
        }

        #endregion

        #region teclas
        private void DefaultWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    FecharTela();

                    e.Handled = true;

                    break;
            }
        }

        private void DefaultWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            _isAltKey = Keyboard.Modifiers == ModifierKeys.Alt;
            _isControlKey = Keyboard.Modifiers == ModifierKeys.Control;
            _isShiftKey = Keyboard.Modifiers == ModifierKeys.Shift;

            if (_isControlKey)
            {
                switch (e.Key)
                {
                    case Key.M:
                        MensagemLogExtensions.ShowMensagemLog();
                        break;
                }
            }
        }
        #endregion

        #region close
        private void DefaultWindow_Closed(object sender, EventArgs e)
        {
            if (IsPrincipal)
                Environment.Exit(0);
        }
        #endregion

        #region posicao
        protected void SetPositionInitial()
        {
            Top = SystemParameters.WorkArea.Top;
            Left = SystemParameters.WorkArea.Left;
            Height = SystemParameters.WorkArea.Height;
            Width = SystemParameters.WorkArea.Width;
        }
        #endregion

        #region timer
        private AbstractTimer _timer;
        protected void SetarTimer(OnTimerExecute onTimerExecute)
        {
            if (_timer == null)
                _timer = new AbstractTimer(onTimerExecute);
        }
        protected void IniciarTimer() => _timer?.Iniciar();
        protected void PararTimer() => _timer?.Parar();
        #endregion

        #region dispose
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        ~AbstractWindow()
        {
            Dispose();
        }
        #endregion

        #endregion
    }
}