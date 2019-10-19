using MORM.CrossCutting;

namespace MORM.Apresentacao
{
    public static class AbstractViewModelExtensions
    {
        #region metodos
        public static object GetFiltro(this IAbstractViewModel vm)
        {
            // expressao filtro por nome ou descricao
            // clausula comando where
            // lista de filtros (inicial, final, lista)
            // objeto campos diferente de nulos

            var filterObjeto = !string.IsNullOrWhiteSpace(vm.Expressao) 
                ? new FilterObjeto(FilterTipo.Expressao, vm.ElementType, vm.Expressao)
                : !string.IsNullOrWhiteSpace(vm.Clausula) ? new FilterObjeto(FilterTipo.Clausula, vm.ElementType, vm.Clausula)
                : vm.Filtro != null ? new FilterObjeto(FilterTipo.Filtro, vm.ElementType, vm.Filtro)
                : new FilterObjeto(FilterTipo.Model, vm.ElementType, vm.Model)
                ;

            return filterObjeto;
        }
        #endregion
    }
}