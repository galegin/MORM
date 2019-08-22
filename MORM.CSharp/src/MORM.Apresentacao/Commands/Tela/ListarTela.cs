using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Commands.Tela
{
    public class ListarTela<TModel> : AbstractCommand
        where TModel : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel<TModel>;
            if (!vm.IsExibirListar)
                return;
            var connector = new AbstractListarConnector<TModel>();
            vm.Lista = connector.Executar(vm.Filtro as TModel);

            // ?????
            // aqui logica para listagem / selecao 
            // ?????

        }
    }
}