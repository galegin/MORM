using MORM.Apresentacao.Controls;
using MORM.Apresentacao.Extensions;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MORM.Apresentacao.Views
{
    public class AbstractViewManut : AbstractView
    {
        #region metodos
        protected void CreateCampos(object viewModel, object model)
        {
            var stackPanel = new StackPanel();
            stackPanel.Margin = new Thickness(10);
            AddChild(stackPanel);

            var userControlTitulo = new AbstractTitulo("Manutenção de " + model.GetType().Name
                .Replace("Abstract", "").Replace("ViewModel", ""));
            userControlTitulo.Margin = new Thickness(0, 0, 0, 10);
            stackPanel.Children.Add(userControlTitulo);

            var userControlOpcao = new AbstractOpcao(model);
            userControlOpcao.Margin = new Thickness(0, 0, 0, 10);
            stackPanel.Children.Add(userControlOpcao);

            model.GetType().GetProperties().ToList().ForEach(prop =>
            {
                var campoTipo = AbstractCampoTipo.Individual;
                var descricao = prop.GetDescricao();
                var editTipo = prop.GetEditTipo();
                var bindind = prop.GetDataBinding(model);
                var abstractCampo = new AbstractCampo(campoTipo, descricao, editTipo);
                abstractCampo.Margin = new Thickness(0, 0, 0, 10);
                abstractCampo.SetDataBinding(bindind);
                stackPanel.Children.Add(abstractCampo);
            });
        }
        #endregion
    }
}