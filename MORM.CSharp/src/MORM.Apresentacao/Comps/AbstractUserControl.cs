using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MORM.Apresentacao
{
    public class AbstractUserControl : UserControl, IAbstractUserControl, IDisposable
    {
        #region variaveis
        protected object _params;
        protected object _values;
        #endregion

        #region propriedades
        public bool InConfirmado { get; protected set; }
        public object Params { get => GetParams(); set => SetParams(value); }
        public object Values { get => GetValues(); set => SetValues(value); }
        #endregion

        #region construtores
        public AbstractUserControl()
        {
            KeyDown += DefaultUserControl_KeyDown;
            Loaded += (s, e) => MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        }
        #endregion

        #region metodos

        #region params / values
        protected virtual object GetParams() => _params;
        protected virtual void SetParams(object value) => _params = value;
        protected virtual object GetValues() => _values;
        protected virtual void SetValues(object value) => _values = value;
        #endregion

        #region key
        private void DefaultUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    btnFechar_Click(null, null);
                    break;
                case Key.F2:
                case Key.F5:
                    btnLimpar_Click(null, null);
                    break;
                case Key.F3:
                    btnSalvar_Click(null, null);
                    break;
                case Key.F4:
                    btnConsultar_Click(null, null);
                    break;
                case Key.F6:
                    btnImprimir_Click(null, null);
                    break;
                case Key.F7:
                    btnExportar_Click(null, null);
                    break;
                case Key.F8:
                    btnExcluir_Click(null, null);
                    break;
                case Key.F9:
                    btnImportar_Click(null, null);
                    break;
                case Key.F10:
                    btnVisualizar_Click(null, null);
                    break;
                case Key.F12:
                    btnSelecionar_Click(null, null);
                    break;
            }
        }
        #endregion

        #region opcao
        protected virtual void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
        protected virtual void btnLimpar_Click(object sender, RoutedEventArgs e) { }
        protected virtual void btnConsultar_Click(object sender, RoutedEventArgs e) { }
        protected virtual void btnSalvar_Click(object sender, RoutedEventArgs e) { }
        protected virtual void btnExcluir_Click(object sender, RoutedEventArgs e) { }
        protected virtual void btnSelecionar_Click(object sender, RoutedEventArgs e) { }
        protected virtual void btnExportar_Click(object sender, RoutedEventArgs e) { }
        protected virtual void btnImportar_Click(object sender, RoutedEventArgs e) { }
        protected virtual void btnImprimir_Click(object sender, RoutedEventArgs e) { }
        protected virtual void btnVisualizar_Click(object sender, RoutedEventArgs e) { }
        #endregion

        #region dispose
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        ~AbstractUserControl()
        {
            Dispose();
        }
        #endregion

        #endregion
    }
}