using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MORM.Apresentacao.Comps
{
    public class AbstractUserControl : UserControl, IAbstractUserControl, IDisposable
    {
        #region construtores
        public AbstractUserControl()
        {
            KeyDown += DefaultUserControl_KeyDown;
            Loaded += (s, e) => MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        }
        #endregion

        #region metodos

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

        public bool InConfirmado { get; protected set; }
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

        #region painel
        protected object AddPainel(object painel, object parent = null, 
            Orientation? orientation = null, Dock? dock = null)
        {
            var content = parent ?? Content;

            if (content == null)
                return AddContent(painel as UIElement);

            else if (content is ScrollViewer)
                return AddScrollViewer(painel as UIElement, content as ScrollViewer);
            else if (content is StackPanel)
                return AddStackPanel(painel as UIElement, content as StackPanel, orientation);
            else if (content is DockPanel)
                return AddDockPanel(painel as UIElement, content as DockPanel, dock);

            return painel;
        }

        private object AddContent(UIElement painel)
        {
            if (painel is FrameworkElement)
                (painel as FrameworkElement).Margin = new Thickness(10);
            Content = painel;
            return painel;
        }

        private object AddScrollViewer(UIElement painel, ScrollViewer parent)
        {
            if (parent.Content == null)
                parent.Content = new StackPanel();
            if (parent.Content is StackPanel)
                return AddStackPanel(painel, parent.Content as StackPanel);
            return painel;
        }

        private object AddFrameworkElement(UIElement painel, Panel parent)
        {
            if (painel is FrameworkElement)
                (painel as FrameworkElement).Margin = new Thickness(0, 0, 0, 10);
            parent.Children.Add(painel);
            return painel;
        }

        private object AddStackPanel(UIElement painel, StackPanel parent, Orientation? orientation = null)
        {
            AddFrameworkElement(painel, parent);
            if (orientation != null)
                parent.Orientation = orientation.Value;
            return painel;
        }

        private object AddDockPanel(UIElement painel, DockPanel parent, Dock? dock = null)
        {
            AddFrameworkElement(painel, parent);
            if (dock != null)
                DockPanel.SetDock(painel, dock.Value);
            return painel;
        }
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