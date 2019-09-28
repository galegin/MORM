using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.ViewsModel;
using System.ComponentModel;

namespace MORM.Apresentacao.Commands.Tela
{
    [Description("Salvar")]
    public class SalvarTela<TModel> : AbstractCommand
        where TModel : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel<TModel>;
            vm.SetarAtualizacao();
            var connector = new AbstractSalvarConnector<TModel>();
            connector.Executar(vm.ObjModel);
        }
    }
}