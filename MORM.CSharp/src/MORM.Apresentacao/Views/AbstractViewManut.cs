using MORM.Apresentacao.Controls;
using MORM.Apresentacao.Extensions;
using MORM.Apresentacao.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MORM.Apresentacao.Views
{
    public class AbstractViewManut : AbstractView, IAbstractViewManut
    {
        private readonly IAbstractViewModel _viewModel;

        public AbstractViewManut(IAbstractViewModel viewModel)
        {
            _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            DataContext = _viewModel;
            CreateCampos();
        }

        private void CreateCampos()
        {
            var stackPanel = new StackPanel();
            stackPanel.Margin = new Thickness(10);
            AddChild(stackPanel);

            var userControlTitulo = new AbstractTitulo("Manutenção de " + _viewModel.GetType().Name
                .Replace("Abstract", "").Replace("ViewModel", ""));
            userControlTitulo.Margin = new Thickness(0, 0, 0, 10);
            stackPanel.Children.Add(userControlTitulo);

            var userControlOpcao = new AbstractOpcao();
            userControlOpcao.Margin = new Thickness(0, 0, 0, 10);
            userControlOpcao.DataContext = _viewModel;
            stackPanel.Children.Add(userControlOpcao);

            _viewModel.Model.GetType().GetProperties().ToList().ForEach(prop =>
            {
                var campoTipo = AbstractCampoTipo.Individual;
                var descricao = prop.GetDescricao();
                var editTipo = prop.GetEditTipo();
                var bindind = prop.GetDataBinding(_viewModel.Model);
                var abstractCampo = new AbstractCampo(campoTipo, descricao, editTipo);
                abstractCampo.Margin = new Thickness(0, 0, 0, 10);
                abstractCampo.SetDataBinding(bindind);

                stackPanel.Children.Add(abstractCampo);
            });
        }
    }
}