using System;
using System.Windows;
using System.Windows.Input;

namespace MORM.Apresentacao.Comps
{
    public class AbstractUserControl : AbstractUserControlNotify, IAbstractUserControl, IDisposable
    {
        public AbstractUserControl()
        {
            KeyDown += DefaultUserControl_KeyDown;
        }

        //-- key

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

        public bool InConfirmado { get; protected set; }

        //-- metodo

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

        //-- dispose

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        ~AbstractUserControl()
        {
            Dispose();
        }
    }
}