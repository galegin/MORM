using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Controls;
using MORM.Apresentacao.ViewsModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MORM.Apresentacao.Views
{
    public class AbstractViewManut : AbstractView
    {
        #region construtores
        public AbstractViewManut(IAbstractViewModelManut vm) : base(vm)
        {
        }
        #endregion
    }

    /*

    Manutenção de ...

    [ Limpar ] [ Consultar ] [ Salvar ] [ Excluir ]

    [ Codigo ] [          ]
    [ Nome   ] [                        ]
    [ Data   ] [          ]
    [ Valor  ] [          ]

    */

    public class AbstractViewManut<TViewModel> : AbstractViewManut
    {
        #region construtores
        public AbstractViewManut() : base(null)
        {
            CreateComps(Activator.CreateInstance<TViewModel>() as IAbstractViewModel);
        }
        #endregion

        #region metodos
        protected void CreateComps(IAbstractViewModel vm)
        {
            SetDataContext(vm);

            vm.SelecionarListaAction = () => SelecionarLista();

            vm.SetOpcoes(new[]
            {
                nameof(vm.IsExibirFechar),
                nameof(vm.IsExibirVoltar),
                nameof(vm.IsExibirLimpar),
                nameof(vm.IsExibirConsultar),
                nameof(vm.IsExibirSalvar),
                nameof(vm.IsExibirExcluir),
                nameof(vm.IsExibirSelecionar),
            });

            var stackPanel = new StackPanel();
            stackPanel.Margin = new Thickness(10);
            Content = stackPanel;

            var userControlTitulo = new AbstractTitulo("Manutenção de " + vm.GetTituloModel());
            userControlTitulo.Margin = new Thickness(0, 0, 0, 10);
            stackPanel.Children.Add(userControlTitulo);

            var userControlOpcao = new AbstractOpcao(vm);
            userControlOpcao.Margin = new Thickness(0, 0, 0, 10);
            stackPanel.Children.Add(userControlOpcao);

            var userControlManut = new AbstractManut(vm);
            userControlManut.Margin = new Thickness(0, 0, 0, 10);
            stackPanel.Children.Add(userControlManut);
        }

        public void SelecionarLista()
        {
            var vm = DataContext as IAbstractViewModel;

            var viewLista = new AbstractViewLista<TViewModel>();

            if (TelaUtils.Instance.AbrirDialog(viewLista, isFullScreen: true) == false)
            {
                var vmLista = viewLista.DataContext as IAbstractViewModel;
                if (vmLista.IsConfirmado)
                    vm.SetModel(vmLista.GetModel());
            }
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