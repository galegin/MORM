using System;
using System.Windows;
using System.Windows.Input;

namespace MORM.Apresentacao.Comps
{
    public class AbstractWindow : Window, IAbstractWindow, IDisposable
    {
        #region construtores
        public AbstractWindow()
        {
            KeyDown += DefaultWindow_KeyDown;
            PreviewKeyDown += DefaultWindow_PreviewKeyDown;
            Closed += DefaultWindow_Closed;
        }
        #endregion

        #region teclas
        public bool IsPrincipal { get; set; }

        private void DefaultWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    if (IsPrincipal)
                        Environment.Exit(0);
                    else
                        Close();

                    e.Handled = true;

                    break;
            }
        }

        private bool _isAltKey;
        private bool _isControlKey;
        private bool _isShiftKey;

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

        #region closed
        private void DefaultWindow_Closed(object sender, EventArgs e)
        {
            if (IsPrincipal)
                Environment.Exit(0);
        }
        #endregion

        #region posicao inicial
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
    }
}