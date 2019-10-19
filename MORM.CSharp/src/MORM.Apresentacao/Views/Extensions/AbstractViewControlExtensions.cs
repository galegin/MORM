using System.Windows;
using System.Windows.Controls;

namespace MORM.Apresentacao
{
    public static class AbstractViewControlExtensions
    {
        public static object AddControl(this UserControl userControl, object control, object parent = null,
            SelectionChangedEventHandler selectionChanged = null, object[] controls = null)
        {
            var content = parent ?? userControl.Content;

            if (content == null || content is Grid)
                return userControl.AddTabControl(control as UIElement, selectionChanged);

            if (content is TabControl)
                return userControl.AddTabItem(control as UIElement, content as TabControl, controls);

            return control;
        }

        private static object AddTabControl(this UserControl userControl, UIElement control, 
            SelectionChangedEventHandler selectionChanged = null)
        {
            userControl.Content = control;
            if (control is TabControl && selectionChanged != null)
                (control as TabControl).SelectionChanged += selectionChanged;
            return control;
        }

        private static object AddTabItem(this UserControl userControl, UIElement tabItem, 
            TabControl parent, object[] controls = null)
        {
            if (controls != null && controls.Length > 0)
            {
                var dockPanel = new DockPanel();
                (tabItem as TabItem).Content = dockPanel;
                var lastControl = controls.Length > 1 ? controls[controls.Length - 1] : null;
                foreach (var control in controls)
                {
                    dockPanel.Children.Add(control as UIElement);
                    if (!control.Equals(lastControl))
                        DockPanel.SetDock(control as UIElement, Dock.Top);
                }
            }
            parent.Items.Add(tabItem);
            if (parent.SelectedIndex == -1)
                parent.SelectedIndex = 0;
            return tabItem;
        }
    }
}