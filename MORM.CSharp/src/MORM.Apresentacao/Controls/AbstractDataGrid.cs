using System.Windows;
using System.Windows.Controls;

namespace MORM.Apresentacao.Controls
{
    public class AbstractDataGrid : DataGrid
    {
        #region construtores
        public AbstractDataGrid(bool isReadOnly = true)
        {
            Margin = new Thickness(10);
            VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            AutoGenerateColumns = false;
            CanUserAddRows = false;
            CanUserDeleteRows = false;
            IsReadOnly = isReadOnly;
        }
        #endregion
    }
}