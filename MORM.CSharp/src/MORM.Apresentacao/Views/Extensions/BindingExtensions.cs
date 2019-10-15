using MORM.Apresentacao.Controls;
using MORM.Apresentacao.ViewsModel;
using MORM.CrossCutting;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MORM.Apresentacao.Views
{
    public static class BindingExtensions
    {
        #region binding
        public static Binding GetDataBinding(this PropertyInfo prop, 
            AbstractSource source, params string[] paths)
        {
            var bindingPath = paths != null && paths.Length > 0
                ? GetBindingPath(paths)
                : GetBindingPath(source.Nome, prop.Name)
                ;

            return new Binding(bindingPath)
            {
                Source = source.Source,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                StringFormat = prop.GetFormato(),
            };
        }

        public static Binding GetDataBindingSource(this object source, params string[] paths)
        {
            var bindingPath = paths != null
                ? GetBindingPath(paths)
                : null
                ;

            return new Binding(bindingPath)
            {
                Source = source,
                Mode = BindingMode.TwoWay,
            };
        }

        public static Binding GetBindingCampo(this MetadataCampo campo)
        {
            return new Binding(campo.Prop.Name)
            {
                StringFormat = string.Empty.Coalesce(campo.Formato, null),
            };
        }
        #endregion

        #region path
        public static string GetBindingPath(params string[] paths)
        {
            return string.Join(".", paths.ToList());
        }
        #endregion

        #region objeto
        public static void SetBindingObjeto(this UIElement control, Binding binding,
            bool isItemSource = false, bool isSelectedItem = false)
        {
            if (control is TextBox)
                (control as TextBox).SetBindingTextBox(binding);
            else if (control is ComboBox)
                (control as ComboBox).SetBindingComboBox(binding, 
                    isItemSource: isItemSource, isSelectedItem: isSelectedItem);
            else if (control is DataGrid)
                (control as DataGrid).SetBindingDataGrid(binding,
                    isItemSource: isItemSource, isSelectedItem: isSelectedItem);
        }
        #endregion

        #region textBox
        public static void SetBindingTextBox(this TextBox textBox, Binding binding)
        {
            textBox.SetBinding(TextBox.TextProperty, binding);
        }
        #endregion

        #region comboBox
        public static void SetBindingComboBox(this ComboBox comboBox, Binding binding,
            bool isItemSource = false, bool isSelectedItem = false)
        {
            if (isItemSource)
                comboBox.SetBinding(ComboBox.ItemsSourceProperty, binding);
            else if (isSelectedItem)
                comboBox.SetBinding(ComboBox.SelectedItemProperty, binding);
            else
                comboBox.SetBinding(ComboBox.TextProperty, binding);
        }
        #endregion

        #region dataGrid
        public static void SetBindingDataGrid(this DataGrid dataGrid, Binding binding, 
            bool isItemSource = false, bool isSelectedItem = false)
        {
            if (isItemSource)
                dataGrid.SetBinding(DataGrid.ItemsSourceProperty, binding);
            else if (isSelectedItem)
                dataGrid.SetBinding(DataGrid.SelectedItemProperty, binding);
        }

        public static void SetBindingDataGridLista(this DataGrid dataGrid, IAbstractViewModel vm)
        {
            var binding = new Binding(nameof(vm.Lista)) { Source = vm };
            dataGrid.SetBindingDataGrid(binding, isItemSource: true);
        }

        public static void SetBindingDataGridModel(this DataGrid dataGrid, IAbstractViewModel vm)
        {
            var binding = new Binding(nameof(vm.Model)) { Source = vm };
            dataGrid.SetBindingDataGrid(binding, isSelectedItem: true);
        }
        #endregion
    }
}