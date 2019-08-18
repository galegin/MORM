using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MORM.Apresentacao.Controls
{
    public class AbstractDataGrid : DataGrid
    {
        #region variaveis
        #endregion

        #region propriedades
        #endregion

        #region comandos
        #endregion

        #region construtores
        public AbstractDataGrid()
        {
            Margin = new Thickness(10);
            VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            AutoGenerateColumns = false;
            CanUserAddRows = false;
            CanUserDeleteRows = false;
            IsReadOnly = true;
        }
        #endregion

        #region metodos
        #endregion
    }
}