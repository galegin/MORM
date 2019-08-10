using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Views
{
    public static class AbstractViewOpcaoExtensions
    {
        public static void OnHabilitarOpcao(this IAbstractViewModel vm, 
            bool isExibirConsulta, bool isExibirCadastro, bool isExibirFiltro)
        {
            vm.IsExibirFechar = false;
            vm.IsExibirVoltar = true;
            vm.IsExibirLimpar = true;

            vm.IsExibirListar = isExibirConsulta;
            vm.IsExibirExportar = isExibirConsulta;
            vm.IsExibirImportar = isExibirConsulta;
            vm.IsExibirImprimir = isExibirConsulta;

            vm.IsExibirConsultar = isExibirCadastro;
            vm.IsExibirSalvar = isExibirCadastro;
            vm.IsExibirExcluir = isExibirCadastro;

            vm.IsExibirConfirmar = isExibirFiltro;
            vm.IsExibirCancelar = isExibirFiltro;
        }
    }
}