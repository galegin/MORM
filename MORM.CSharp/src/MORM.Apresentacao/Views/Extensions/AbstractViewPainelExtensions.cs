using System.Windows;
using System.Windows.Controls;

namespace MORM.Apresentacao
{
    public static class AbstractViewPainelExtensions
    {
        public static object AddPainel(this UserControl userControl, object painel, object parent = null,
            Orientation? orientation = null, Dock? dock = null)
        {
            var content = parent ?? userControl.Content;

            if (content == null || content is Grid)
                return userControl.AddContent(painel as UIElement);

            else if (content is ScrollViewer)
                return userControl.AddScrollViewer(painel as UIElement, content as ScrollViewer);
            else if (content is StackPanel)
                return userControl.AddStackPanel(painel as UIElement, content as StackPanel, orientation);
            else if (content is DockPanel)
                return userControl.AddDockPanel(painel as UIElement, content as DockPanel, dock);

            return painel;
        }

        private static object AddContent(this UserControl userControl, UIElement painel)
        {
            if (painel is FrameworkElement)
                (painel as FrameworkElement).Margin = new Thickness(10);
            userControl.Content = painel;
            return painel;
        }

        private static object AddFrameworkElement(this UserControl userControl, UIElement painel, Panel parent)
        {
            if (painel is FrameworkElement)
                (painel as FrameworkElement).Margin = new Thickness(0, 0, 0, 10);
            parent.Children.Add(painel);
            return painel;
        }

        private static object AddScrollViewer(this UserControl userControl, UIElement painel, ScrollViewer parent)
        {
            if (parent.Content == null)
                parent.Content = new StackPanel();
            if (parent.Content is StackPanel)
                return userControl.AddStackPanel(painel, parent.Content as StackPanel);
            return painel;
        }

        private static object AddStackPanel(this UserControl userControl, UIElement painel, StackPanel parent, Orientation? orientation = null)
        {
            userControl.AddFrameworkElement(painel, parent);
            if (orientation != null)
                parent.Orientation = orientation.Value;
            return painel;
        }

        private static object AddDockPanel(this UserControl userControl, UIElement painel, DockPanel parent, Dock? dock = null)
        {
            userControl.AddFrameworkElement(painel, parent);
            if (dock != null)
                DockPanel.SetDock(painel, dock.Value);
            return painel;
        }
    }
}