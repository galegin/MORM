using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.ViewsModel;
using MORM.CrossCutting;
using System.ComponentModel;

namespace MORM.Apresentacao.Commands.Tela
{
    [Description("Importar")]
    public class ImportarTela<TModel> : AbstractCommand
        where TModel : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel<TModel>;
            var connector = new AbstractImportarConnector<TModel>();

            var arquivo = DialogUtils.GetOpenFile(
                fileName: ExportsMessages.FileName,
                filter: ExportsMessages.Filters,
                defaultExt: ExportsMessages.DefaultExt);
            if (string.IsNullOrWhiteSpace(arquivo))
                return;

            var conteudo = ArquivoDiretorio.CarregarArquivo(arquivo);
            if (string.IsNullOrWhiteSpace(conteudo))
                return;

            connector.Executar(vm.ObjModel, filtro: conteudo);

            DialogsMessages.ArquivoImportadoComSucesso.GetMensagem();
        }
    }
}