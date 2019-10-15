using MORM.CrossCutting;

namespace MORM.Apresentacao.ViewsModel
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
                ? new FilterObjeto(FilterTipo.Expressao, vm.Expressao)
                : !string.IsNullOrWhiteSpace(vm.Clausula) ? new FilterObjeto(FilterTipo.Clausula, vm.Clausula)
                : vm.Filtro != null ? new FilterObjeto(FilterTipo.Filtro, vm.Filtro)
                : new FilterObjeto(FilterTipo.Model, vm.Model)
                ;

            //return filterObjeto.GetJsonFromObject();
            return filterObjeto;
        }
        #endregion
    }
}