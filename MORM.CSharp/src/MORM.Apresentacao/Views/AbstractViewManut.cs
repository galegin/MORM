using MORM.Apresentacao.Controls;
using MORM.Apresentacao.Extensions;
using MORM.Apresentacao.ViewsModel;
//using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
//using System.Windows.Markup;
//using System.Xml;

namespace MORM.Apresentacao.Views
{
    public class AbstractViewManut : AbstractView
    {
        #region variaveis
        private string[] _ignoreCampos = 
            { "U_Version", "Cd_Operador", "Dt_Cadastro", "Cd_Senha" };
        #endregion

        #region metodos
        protected void CreateCampos<TModel>(AbstractViewModel<TModel> viewModel)
        {
            DataContext = viewModel;

            var stackPanel = new StackPanel();
            stackPanel.Margin = new Thickness(10);
            AddChild(stackPanel);

            var userControlTitulo = new AbstractTitulo("Manutenção de " + viewModel.Model.GetType().Name
                .Replace("Abstract", "").Replace("Model", "").Replace("View", ""));
            userControlTitulo.Margin = new Thickness(0, 0, 0, 10);
            stackPanel.Children.Add(userControlTitulo);

            var userControlOpcao = new AbstractOpcao<TModel>(viewModel.Model);
            userControlOpcao.Margin = new Thickness(0, 0, 0, 10);
            stackPanel.Children.Add(userControlOpcao);

            viewModel.Model.GetType().GetProperties().ToList().ForEach(prop =>
            {
                if (_ignoreCampos.Contains(prop.Name))
                    return;

                var campoTipo = AbstractCampoTipo.Individual;
                var descricao = prop.GetDescricao();
                var tamanho = prop.GetTamanho();
                var precisao = prop.GetPrecisao();
                var editTipo = prop.GetEditTipo();
                var bindind = prop.GetDataBinding(viewModel, nameof(viewModel.Model));
                var abstractCampo = new AbstractCampo(campoTipo, descricao, tamanho, precisao, editTipo);
                abstractCampo.Margin = new Thickness(0, 0, 0, 10);
                abstractCampo.SetDataBinding(bindind);
                stackPanel.Children.Add(abstractCampo);
            });

            #region xaml
            /*
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
        }
        #endregion
    }
}