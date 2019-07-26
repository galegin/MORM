using MORM.Apresentacao.Controls;
using MORM.Apresentacao.ViewsModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MORM.Apresentacao.Views
{
    public class AbstractViewFiltro : AbstractView
    {
        #region construtores
        public AbstractViewFiltro(IAbstractViewModelManut vm) : base(vm)
        {
        }
        #endregion
    }

    /*

    Filtro de ...

    [ Limpar ] [ Salvar ] [ Confirmar ] [ Cancelar ]

    [ Codigo ] [          ]
    [ Nome   ] [                        ]
    [ Data   ] [          ]
    [ Valor  ] [          ]

    */

    public class AbstractViewFiltro<TViewModel> : AbstractViewFiltro
        where TViewModel : IAbstractViewModel
    {
        #region construtores
        public AbstractViewFiltro() : base(null)
        {
            CreateComps(Activator.CreateInstance<TViewModel>());
        }
        #endregion

        #region metodos
        protected void CreateComps(IAbstractViewModel vm)
        {
            SetDataContext(vm);

            vm.ConfirmarAction = () => ConfirmarFiltro();
            vm.CancelarAction = () => CancelarFiltro();

            vm.SetOpcoes(new[]
            {
                nameof(vm.IsExibirConfirmar),
                nameof(vm.IsExibirCancelar),
                nameof(vm.IsExibirSalvar),
                nameof(vm.IsExibirLimpar),
            });

            var stackPanel = new StackPanel();
            stackPanel.Margin = new Thickness(10);
            Content = stackPanel;

            var userControlTitulo = new AbstractTitulo("Filtro de " + vm.GetTitulo());
            userControlTitulo.Margin = new Thickness(0, 0, 0, 10);
            stackPanel.Children.Add(userControlTitulo);

            var userControlOpcao = new AbstractOpcao(vm);
            userControlOpcao.Margin = new Thickness(0, 0, 0, 10);
            stackPanel.Children.Add(userControlOpcao);

            var userControlFiltro = new AbstractFiltro(vm);
            userControlFiltro.Margin = new Thickness(0, 0, 0, 10);
            stackPanel.Children.Add(userControlFiltro);
        }

        public void ConfirmarFiltro()
        {
        }

        public void CancelarFiltro()
        {
        }
        #endregion
    }
}

#region xaml
/*
using System.IO;
using System.Windows.Markup;
using System.Xml;

var xamlDefinition = string.Empty;
var xamlCampo = string.Empty;
var nroRow = 0;

viewModel.Model.GetType().GetProperties().ToList().ForEach(prop =>
{
    var descricao = prop.GetDescricao();

    xamlDefinition +=
        "<RowDefinition Height='Auto' />";

    xamlCampo +=
        $"<TextBlock Text='{descricao}' Height='19' Grid.Row='{nroRow}' Grid.Column='0' />" +
        $"<TextBox Text='{{Binding Model.{prop.Name}}}' Margin='3' Grid.Row='{nroRow}' Grid.Column='1' />";

    nroRow++;
});

string xaml =
    "<UserControl " +
        "xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' " +
        "xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml' " +
        ">" +
        "<Grid>" +
            "<Grid.ColumnDefinitions>" +
                "<ColumnDefinition Width='100' />" +
                "<ColumnDefinition Width='*' />" +
            "</Grid.ColumnDefinitions>" +
            "<Grid.RowDefinitions>" +
                xamlDefinition +
                "<RowDefinition Height='*' />" +
            "</Grid.RowDefinitions>" +
            xamlCampo +
        "</Grid>" +
    "</UserControl>";

StringReader stringReader = new StringReader(xaml);
XmlReader xmlReader = XmlReader.Create(stringReader);
UserControl userControl = (UserControl)XamlReader.Load(xmlReader);
userControl.DataContext = viewModel;
stackPanel.Children.Add(userControl);
*/
#endregion