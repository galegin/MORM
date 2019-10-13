namespace MORM.Apresentacao.ViewsModel
{
    public static class AbstractViewModelExtensions
    {
        #region metodos
        public static object GetFiltro(this IAbstractViewModel vm)
        {
            // vm.Model, filtro: vm.Filtro

            // expressao filtro por nome ou descricao
            // clausula comando where
            // lista de filtros (inicial, final, lista)
            // objeto campos diferente de nulos

            return vm.Filtro;
        }
        #endregion
    }
}